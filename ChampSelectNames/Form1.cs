﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace ChampSelectSpy
{
    public partial class Form1 : Form
    {
        private struct ClientData
        {
            public bool isRunning;
            public int ProcessId;
            public bool LeagueRunning;
            public int RiotPort;
            public string RiotToken;
            public int ClientPort;
            public string ClientToken;
            public string Region;
            public string SummonerDisplayName;
            public string GameState;
        }

        readonly List<string> participants = [];
        class Summoner
        {
            public string GameName;
            public string TagLine;
        }
        class TeamData
        {
            public List<Dictionary<string,string>> MyTeam;
            public List<Dictionary<string, string>> TheirTeam;
        }

        private ClientData ClientInfo;
        ManagementClass mngmtClass;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mngmtClass = new ManagementClass("Win32_Process");
            toolStripStatusLabel1.Text = "Waiting for League...";
            chkAutoOPGG.Checked = Properties.Settings.Default.AutoOPGG;
            chkAutoUGG.Checked = Properties.Settings.Default.AutoUGG;
            chkAutoPORO.Checked = Properties.Settings.Default.AutoPORO;
            chkTopMost.Checked = Properties.Settings.Default.TopMost;
            TopMost = Properties.Settings.Default.TopMost;
            chkAutoMinimize.Checked = Properties.Settings.Default.AutoMinimize;

        }

        private void Tmr1_Tick(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("LeagueClientUx");
            if (processes.Length > 0)
            {
                ClientInfo.isRunning = true;
                ClientInfo.ProcessId = processes[0].Id;
                toolStripStatusLabel1.Text = "Summoner: " + ClientInfo.SummonerDisplayName + " - Gamestate: " + ClientInfo.GameState;
                if (!ClientInfo.LeagueRunning)
                {
                    foreach (ManagementObject obj in mngmtClass.GetInstances())
                    {
                        if (obj["Name"].Equals("LeagueClientUx.exe"))
                        {
                            Dictionary<string, string> commandLine = ((string)obj["CommandLine"])
                                .Split(' ')
                                .Select(couple => couple
                                    .Substring(1, couple.Length - 2)
                                    .Split(new[] { '=' }, 2)
                                )
                                .Where(couple => couple.Length == 2)
                                .ToDictionary(sp => sp[0], sp => sp[1]);
                            ClientInfo.RiotPort = int.Parse(commandLine.First(param => param.Key == "--riotclient-app-port").Value);
                            ClientInfo.RiotToken = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("riot:" + commandLine.First(param => param.Key == "--riotclient-auth-token").Value));
                            ClientInfo.ClientPort = int.Parse(commandLine.First(param => param.Key == "--app-port").Value);
                            ClientInfo.ClientToken = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("riot:" + commandLine.First(param => param.Key == "--remoting-auth-token").Value));
                            ClientInfo.LeagueRunning = true;
                        }
                    }
                }
            }
            else
            {
                ClientInfo = default;
                toolStripStatusLabel1.Text = "Waiting for League...";
            }

            if (ClientInfo.isRunning)
            {
                if (ClientInfo.Region == null)
                {
                    string Request = MakeRequest(ClientInfo, "GET", "/lol-rso-auth/v1/authorization", client: true);
                    if (Request != string.Empty)
                        ClientInfo.Region = string.Concat(JsonConvert.DeserializeObject<Dictionary<string, string>>(Request)["currentPlatformId"].Where(char.IsLetter));
                    txtRegion.Text = ClientInfo.Region is not null ? ClientInfo.Region : "EUW";
                }

                if (ClientInfo.SummonerDisplayName == null)
                {
                    Summoner summ = JsonConvert.DeserializeObject<Summoner>(MakeRequest(ClientInfo, "GET", "/lol-summoner/v1/current-summoner", client: true));
                    if (summ != null)
                    {
                        ClientInfo.SummonerDisplayName = String.Format("{0}#{1}",summ.GameName,summ.TagLine);

                    }
                }

                ClientInfo.GameState = MakeRequest(ClientInfo, "GET", "/lol-gameflow/v1/gameflow-phase", true).Trim('"');
                if (ClientInfo.GameState == "ChampSelect")
                {
                    if (participants.Count < 5)
                    {

                        TeamData teamData = JsonConvert.DeserializeObject<TeamData>(MakeRequest(ClientInfo, "GET", "/lol-champ-select/v1/session", true));
                        if (teamData is null) { participants.Add("Non disponible en entrainement"); }
                        else
                        {
                            foreach (Dictionary<string,string> player in teamData.MyTeam)
                            {
                                MessageBox.Show(player["summonerId"]);
                                Summoner summoner = JsonConvert.DeserializeObject<Summoner>(MakeRequest(ClientInfo, "GET", String.Format("/lol-summoner/v1/summoners/{0}", int.Parse(player["summonerId"])),false));
                                participants.Add(String.Format("{0}#{1}", summoner.GameName, summoner.TagLine));
                            }
                            participants.Add("test");
                        }
                        //if (dataTable.Rows.Count == 5)
                        //{
                        //    foreach (DataRow row in dataTable.Rows)
                        //    {
                        //        participants.Add(row["game_name"].ToString() + "-" + row["game_tag"]);
                        //    }
                        //    if (chkAutoOPGG.Checked)
                        //    {
                        //        BtnOpGGAll_Click(null, null);
                        //    }
                        //    if (chkAutoUGG.Checked)
                        //    {
                        //        BtnUGGALL_Click(null, null);
                        //    }
                        //    if (chkAutoPORO.Checked)
                        //    {
                        //        BtnPOROALL_Click(null, null);
                        //    }
                        //}
                    }


                }
                else if (ClientInfo.GameState == "InProgress")
                {
                    if (Properties.Settings.Default.AutoMinimize)
                        this.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    participants.Clear();
                }
                if (participants.Count > 0)
                {
                    txtParticipants.Text = string.Join("\r\n", participants);
                }
                else
                {
                    txtParticipants.Text = string.Empty;
                }
            }

        }
        private static string MakeRequest(ClientData info, string method, string url, bool client)
        {
            int port = client ? info.ClientPort : info.RiotPort;
            string authToken = client ? info.ClientToken : info.RiotToken;
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                HttpWebRequest obj = (HttpWebRequest)WebRequest.Create("https://127.0.0.1:" + port + url);
                obj.PreAuthenticate = true;
                obj.ContentType = "application/json";
                obj.Method = method;
                obj.Headers.Add("Authorization", "Basic " + authToken);
                using StreamReader streamReader = new StreamReader(((HttpWebResponse)obj.GetResponse()).GetResponseStream());
                return streamReader.ReadToEnd();
            }
            catch
            {
                return "";
            }
        }

        private void BtnOpGGAll_Click(object sender, EventArgs e)
        {
            if (participants.Count > 0)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://www.op.gg/multisearch/" + ClientInfo.Region + "?summoners=" + string.Join(",", participants),
                    UseShellExecute = true
                });
            }
        }

        private void BtnUGGALL_Click(object sender, EventArgs e)
        {
            if (participants.Count > 0)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://u.gg/multisearch?summoners=" + string.Join(",", participants) + "&region=" + ClientInfo.Region,
                    UseShellExecute = true
                });
            }
        }

        private void BtnPOROALL_Click(object sender, EventArgs e)
        {
            if (participants.Count > 0)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://porofessor.gg/pregame/" + ClientInfo.Region + "/" + string.Join(",", participants) + "/soloqueue",
                    UseShellExecute = true
                });
            }
        }

        private void ChkAutoOPGG_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoOPGG = chkAutoOPGG.Checked;
            Properties.Settings.Default.Save();
        }

        private void ChkAutoUGG_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoUGG = chkAutoUGG.Checked;
            Properties.Settings.Default.Save();
        }

        private void ChkAutoPORO_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoPORO = chkAutoPORO.Checked;
            Properties.Settings.Default.Save();
        }

        private void ChkTopMost_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TopMost = chkTopMost.Checked;
            this.TopMost = chkTopMost.Checked;
            Properties.Settings.Default.Save();

        }

        private void ChkAutoMinimize_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoMinimize = chkAutoMinimize.Checked;
            Properties.Settings.Default.Save();

        }
    }
}
