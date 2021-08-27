
namespace PullRequestExtractor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.grpActiveSettings = new System.Windows.Forms.GroupBox();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.lblStatusColour = new System.Windows.Forms.Label();
            this.lblTokenAuthed = new System.Windows.Forms.Label();
            this.lblProjectPlaceHolder = new System.Windows.Forms.Label();
            this.lblOrgPlaceHolder = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.lblOrg = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.pButtons = new System.Windows.Forms.Panel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.prexTablControl = new System.Windows.Forms.TabControl();
            this.tcActivePrs = new System.Windows.Forms.TabPage();
            this.tcPrArchive = new System.Windows.Forms.TabPage();
            this.tcStats = new System.Windows.Forms.TabPage();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grpActiveSettings.SuspendLayout();
            this.pButtons.SuspendLayout();
            this.prexTablControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(271, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Subbed Projects";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.TestGetProjects_Click);
            // 
            // grpActiveSettings
            // 
            this.grpActiveSettings.Controls.Add(this.lblStatusText);
            this.grpActiveSettings.Controls.Add(this.button1);
            this.grpActiveSettings.Controls.Add(this.lblStatusColour);
            this.grpActiveSettings.Controls.Add(this.lblTokenAuthed);
            this.grpActiveSettings.Controls.Add(this.lblProjectPlaceHolder);
            this.grpActiveSettings.Controls.Add(this.lblOrgPlaceHolder);
            this.grpActiveSettings.Controls.Add(this.lblProject);
            this.grpActiveSettings.Controls.Add(this.lblOrg);
            this.grpActiveSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActiveSettings.Location = new System.Drawing.Point(0, 0);
            this.grpActiveSettings.Name = "grpActiveSettings";
            this.grpActiveSettings.Size = new System.Drawing.Size(1194, 100);
            this.grpActiveSettings.TabIndex = 2;
            this.grpActiveSettings.TabStop = false;
            this.grpActiveSettings.Text = "Active Settings";
            // 
            // lblStatusText
            // 
            this.lblStatusText.AutoSize = true;
            this.lblStatusText.Location = new System.Drawing.Point(127, 66);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(52, 13);
            this.lblStatusText.TabIndex = 9;
            this.lblStatusText.Text = "[Runtime]";
            // 
            // lblStatusColour
            // 
            this.lblStatusColour.BackColor = System.Drawing.Color.LimeGreen;
            this.lblStatusColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatusColour.Location = new System.Drawing.Point(108, 67);
            this.lblStatusColour.Name = "lblStatusColour";
            this.lblStatusColour.Size = new System.Drawing.Size(14, 13);
            this.lblStatusColour.TabIndex = 8;
            // 
            // lblTokenAuthed
            // 
            this.lblTokenAuthed.AutoSize = true;
            this.lblTokenAuthed.Location = new System.Drawing.Point(7, 67);
            this.lblTokenAuthed.Name = "lblTokenAuthed";
            this.lblTokenAuthed.Size = new System.Drawing.Size(93, 13);
            this.lblTokenAuthed.TabIndex = 4;
            this.lblTokenAuthed.Text = "Token authorised:";
            // 
            // lblProjectPlaceHolder
            // 
            this.lblProjectPlaceHolder.AutoSize = true;
            this.lblProjectPlaceHolder.Location = new System.Drawing.Point(105, 46);
            this.lblProjectPlaceHolder.Name = "lblProjectPlaceHolder";
            this.lblProjectPlaceHolder.Size = new System.Drawing.Size(39, 13);
            this.lblProjectPlaceHolder.TabIndex = 3;
            this.lblProjectPlaceHolder.Text = "projPH";
            // 
            // lblOrgPlaceHolder
            // 
            this.lblOrgPlaceHolder.AutoSize = true;
            this.lblOrgPlaceHolder.Location = new System.Drawing.Point(105, 25);
            this.lblOrgPlaceHolder.Name = "lblOrgPlaceHolder";
            this.lblOrgPlaceHolder.Size = new System.Drawing.Size(35, 13);
            this.lblOrgPlaceHolder.TabIndex = 2;
            this.lblOrgPlaceHolder.Text = "orgPh";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(56, 46);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(43, 13);
            this.lblProject.TabIndex = 1;
            this.lblProject.Text = "Project:";
            // 
            // lblOrg
            // 
            this.lblOrg.AutoSize = true;
            this.lblOrg.Location = new System.Drawing.Point(30, 25);
            this.lblOrg.Name = "lblOrg";
            this.lblOrg.Size = new System.Drawing.Size(69, 13);
            this.lblOrg.TabIndex = 0;
            this.lblOrg.Text = "Organisation:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(10, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(54, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pButtons
            // 
            this.pButtons.Controls.Add(this.btnExit);
            this.pButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtons.Location = new System.Drawing.Point(0, 668);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(1194, 46);
            this.pButtons.TabIndex = 6;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Minimised";
            this.notifyIcon.BalloonTipTitle = "PRex";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "PRex";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // prexTablControl
            // 
            this.prexTablControl.Controls.Add(this.tcActivePrs);
            this.prexTablControl.Controls.Add(this.tcPrArchive);
            this.prexTablControl.Controls.Add(this.tcStats);
            this.prexTablControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prexTablControl.Location = new System.Drawing.Point(0, 100);
            this.prexTablControl.Name = "prexTablControl";
            this.prexTablControl.SelectedIndex = 0;
            this.prexTablControl.Size = new System.Drawing.Size(1194, 568);
            this.prexTablControl.TabIndex = 5;
            // 
            // tcActivePrs
            // 
            this.tcActivePrs.Location = new System.Drawing.Point(4, 22);
            this.tcActivePrs.Name = "tcActivePrs";
            this.tcActivePrs.Padding = new System.Windows.Forms.Padding(3);
            this.tcActivePrs.Size = new System.Drawing.Size(1186, 542);
            this.tcActivePrs.TabIndex = 0;
            this.tcActivePrs.Text = "Active Pull Requests";
            this.tcActivePrs.UseVisualStyleBackColor = true;
            // 
            // tcPrArchive
            // 
            this.tcPrArchive.Location = new System.Drawing.Point(4, 22);
            this.tcPrArchive.Name = "tcPrArchive";
            this.tcPrArchive.Padding = new System.Windows.Forms.Padding(3);
            this.tcPrArchive.Size = new System.Drawing.Size(1186, 542);
            this.tcPrArchive.TabIndex = 1;
            this.tcPrArchive.Text = "Archived";
            this.tcPrArchive.UseVisualStyleBackColor = true;
            // 
            // tcStats
            // 
            this.tcStats.Location = new System.Drawing.Point(4, 22);
            this.tcStats.Name = "tcStats";
            this.tcStats.Padding = new System.Windows.Forms.Padding(3);
            this.tcStats.Size = new System.Drawing.Size(1186, 542);
            this.tcStats.TabIndex = 2;
            this.tcStats.Text = "Statistics";
            this.tcStats.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 714);
            this.Controls.Add(this.prexTablControl);
            this.Controls.Add(this.pButtons);
            this.Controls.Add(this.grpActiveSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PREx - An Azure DevOps Pull Request Parser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.grpActiveSettings.ResumeLayout(false);
            this.grpActiveSettings.PerformLayout();
            this.pButtons.ResumeLayout(false);
            this.prexTablControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpActiveSettings;
        private System.Windows.Forms.Label lblOrg;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label lblOrgPlaceHolder;
        private System.Windows.Forms.Label lblProjectPlaceHolder;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTokenAuthed;
        private System.Windows.Forms.Label lblStatusColour;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.Label lblStatusText;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TabControl prexTablControl;
        public System.Windows.Forms.TabPage tcPrArchive;
        public System.Windows.Forms.TabPage tcStats;
        public System.Windows.Forms.TabPage tcActivePrs;
    }
}

