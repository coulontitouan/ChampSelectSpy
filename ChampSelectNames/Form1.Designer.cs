﻿namespace ChampSelectSpy
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tmr1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnOpGGAll = new System.Windows.Forms.Button();
            this.chkAutoOPGG = new System.Windows.Forms.CheckBox();
            this.txtParticipants = new System.Windows.Forms.TextBox();
            this.btnUGGALL = new System.Windows.Forms.Button();
            this.chkAutoUGG = new System.Windows.Forms.CheckBox();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.chkAutoMinimize = new System.Windows.Forms.CheckBox();
            this.chkAutoPORO = new System.Windows.Forms.CheckBox();
            this.btnPOROALL = new System.Windows.Forms.Button();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmr1
            // 
            this.tmr1.Enabled = true;
            this.tmr1.Interval = 500;
            this.tmr1.Tick += new System.EventHandler(this.Tmr1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 198);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(329, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // btnOpGGAll
            // 
            this.btnOpGGAll.Location = new System.Drawing.Point(12, 87);
            this.btnOpGGAll.Name = "btnOpGGAll";
            this.btnOpGGAll.Size = new System.Drawing.Size(75, 23);
            this.btnOpGGAll.TabIndex = 10;
            this.btnOpGGAll.Text = "OP.GG All";
            this.btnOpGGAll.UseVisualStyleBackColor = true;
            this.btnOpGGAll.Click += new System.EventHandler(this.BtnOpGGAll_Click);
            // 
            // chkAutoOPGG
            // 
            this.chkAutoOPGG.AutoSize = true;
            this.chkAutoOPGG.Location = new System.Drawing.Point(93, 91);
            this.chkAutoOPGG.Name = "chkAutoOPGG";
            this.chkAutoOPGG.Size = new System.Drawing.Size(112, 17);
            this.chkAutoOPGG.TabIndex = 11;
            this.chkAutoOPGG.Text = "Auto open OP.GG";
            this.chkAutoOPGG.UseVisualStyleBackColor = true;
            this.chkAutoOPGG.CheckedChanged += new System.EventHandler(this.ChkAutoOPGG_CheckedChanged);
            // 
            // txtParticipants
            // 
            this.txtParticipants.Location = new System.Drawing.Point(12, 3);
            this.txtParticipants.Multiline = true;
            this.txtParticipants.Name = "txtParticipants";
            this.txtParticipants.ReadOnly = true;
            this.txtParticipants.Size = new System.Drawing.Size(302, 78);
            this.txtParticipants.TabIndex = 13;
            // 
            // btnUGGALL
            // 
            this.btnUGGALL.Location = new System.Drawing.Point(12, 116);
            this.btnUGGALL.Name = "btnUGGALL";
            this.btnUGGALL.Size = new System.Drawing.Size(75, 23);
            this.btnUGGALL.TabIndex = 14;
            this.btnUGGALL.Text = "U.GG All";
            this.btnUGGALL.UseVisualStyleBackColor = true;
            this.btnUGGALL.Click += new System.EventHandler(this.BtnUGGALL_Click);
            // 
            // chkAutoUGG
            // 
            this.chkAutoUGG.AutoSize = true;
            this.chkAutoUGG.Location = new System.Drawing.Point(93, 120);
            this.chkAutoUGG.Name = "chkAutoUGG";
            this.chkAutoUGG.Size = new System.Drawing.Size(105, 17);
            this.chkAutoUGG.TabIndex = 15;
            this.chkAutoUGG.Text = "Auto open U.GG";
            this.chkAutoUGG.UseVisualStyleBackColor = true;
            this.chkAutoUGG.CheckedChanged += new System.EventHandler(this.ChkAutoUGG_CheckedChanged);
            // 
            // chkTopMost
            // 
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.Location = new System.Drawing.Point(12, 175);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(123, 17);
            this.chkTopMost.TabIndex = 16;
            this.chkTopMost.Text = "Keep window on top";
            this.chkTopMost.UseVisualStyleBackColor = true;
            this.chkTopMost.CheckedChanged += new System.EventHandler(this.ChkTopMost_CheckedChanged);
            // 
            // chkAutoMinimize
            // 
            this.chkAutoMinimize.AutoSize = true;
            this.chkAutoMinimize.Location = new System.Drawing.Point(141, 175);
            this.chkAutoMinimize.Name = "chkAutoMinimize";
            this.chkAutoMinimize.Size = new System.Drawing.Size(159, 17);
            this.chkAutoMinimize.TabIndex = 17;
            this.chkAutoMinimize.Text = "Auto minimize when in game";
            this.chkAutoMinimize.UseVisualStyleBackColor = true;
            this.chkAutoMinimize.CheckedChanged += new System.EventHandler(this.ChkAutoMinimize_CheckedChanged);
            // 
            // chkAutoPORO
            // 
            this.chkAutoPORO.AutoSize = true;
            this.chkAutoPORO.Location = new System.Drawing.Point(93, 147);
            this.chkAutoPORO.Name = "chkAutoPORO";
            this.chkAutoPORO.Size = new System.Drawing.Size(128, 17);
            this.chkAutoPORO.TabIndex = 19;
            this.chkAutoPORO.Text = "Auto open Porofessor";
            this.chkAutoPORO.UseVisualStyleBackColor = true;
            this.chkAutoPORO.CheckedChanged += new System.EventHandler(this.ChkAutoPORO_CheckedChanged);
            // 
            // btnPOROALL
            // 
            this.btnPOROALL.Location = new System.Drawing.Point(12, 143);
            this.btnPOROALL.Name = "btnPOROALL";
            this.btnPOROALL.Size = new System.Drawing.Size(75, 23);
            this.btnPOROALL.TabIndex = 20;
            this.btnPOROALL.Text = "PORO All";
            this.btnPOROALL.UseVisualStyleBackColor = true;
            this.btnPOROALL.Click += new System.EventHandler(this.BtnPOROALL_Click);
            // 
            // txtRegion
            // 
            this.txtRegion.Location = new System.Drawing.Point(264, 91);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.ReadOnly = true;
            this.txtRegion.Size = new System.Drawing.Size(50, 20);
            this.txtRegion.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 220);
            this.Controls.Add(this.txtRegion);
            this.Controls.Add(this.btnPOROALL);
            this.Controls.Add(this.chkAutoPORO);
            this.Controls.Add(this.chkAutoMinimize);
            this.Controls.Add(this.chkTopMost);
            this.Controls.Add(this.chkAutoUGG);
            this.Controls.Add(this.btnUGGALL);
            this.Controls.Add(this.txtParticipants);
            this.Controls.Add(this.chkAutoOPGG);
            this.Controls.Add(this.btnOpGGAll);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "ChampSelectSpy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmr1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnOpGGAll;
        private System.Windows.Forms.CheckBox chkAutoOPGG;
        private System.Windows.Forms.TextBox txtParticipants;
        private System.Windows.Forms.Button btnUGGALL;
        private System.Windows.Forms.CheckBox chkAutoUGG;
        private System.Windows.Forms.CheckBox chkTopMost;
        private System.Windows.Forms.CheckBox chkAutoMinimize;
        private System.Windows.Forms.CheckBox chkAutoPORO;
        private System.Windows.Forms.Button btnPOROALL;
        private System.Windows.Forms.TextBox txtRegion;
    }
}

