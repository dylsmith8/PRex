
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
            this.btnGetActivePRs = new System.Windows.Forms.Button();
            this.grpActiveSettings = new System.Windows.Forms.GroupBox();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.lblStatusColour = new System.Windows.Forms.Label();
            this.lblTokenAuthed = new System.Windows.Forms.Label();
            this.lblProjectPlaceHolder = new System.Windows.Forms.Label();
            this.lblOrgPlaceHolder = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.lblOrg = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvPRs = new System.Windows.Forms.DataGridView();
            this.grpPRs = new System.Windows.Forms.GroupBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pButtons = new System.Windows.Forms.Panel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.prexTablControl = new System.Windows.Forms.TabControl();
            this.tcActivePrs = new System.Windows.Forms.TabPage();
            this.tcPrArchive = new System.Windows.Forms.TabPage();
            this.grpBoxArchived = new System.Windows.Forms.GroupBox();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.btnArchPrs = new System.Windows.Forms.Button();
            this.txtBoxFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.dgvArchived = new System.Windows.Forms.DataGridView();
            this.grpActiveSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRs)).BeginInit();
            this.grpPRs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.pButtons.SuspendLayout();
            this.prexTablControl.SuspendLayout();
            this.tcActivePrs.SuspendLayout();
            this.tcPrArchive.SuspendLayout();
            this.grpBoxArchived.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchived)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Projects";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.TestGetProjects_Click);
            // 
            // btnGetActivePRs
            // 
            this.btnGetActivePRs.Location = new System.Drawing.Point(16, 16);
            this.btnGetActivePRs.Name = "btnGetActivePRs";
            this.btnGetActivePRs.Size = new System.Drawing.Size(92, 23);
            this.btnGetActivePRs.TabIndex = 1;
            this.btnGetActivePRs.Text = "Get Active PRs";
            this.btnGetActivePRs.UseVisualStyleBackColor = true;
            this.btnGetActivePRs.Click += new System.EventHandler(this.TestGetPRs_Click);
            // 
            // grpActiveSettings
            // 
            this.grpActiveSettings.Controls.Add(this.lblStatusText);
            this.grpActiveSettings.Controls.Add(this.lblStatusColour);
            this.grpActiveSettings.Controls.Add(this.lblTokenAuthed);
            this.grpActiveSettings.Controls.Add(this.lblProjectPlaceHolder);
            this.grpActiveSettings.Controls.Add(this.lblOrgPlaceHolder);
            this.grpActiveSettings.Controls.Add(this.lblProject);
            this.grpActiveSettings.Controls.Add(this.lblOrg);
            this.grpActiveSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActiveSettings.Location = new System.Drawing.Point(0, 0);
            this.grpActiveSettings.Name = "grpActiveSettings";
            this.grpActiveSettings.Size = new System.Drawing.Size(1194, 65);
            this.grpActiveSettings.TabIndex = 2;
            this.grpActiveSettings.TabStop = false;
            this.grpActiveSettings.Text = "Active Settings";
            // 
            // lblStatusText
            // 
            this.lblStatusText.AutoSize = true;
            this.lblStatusText.Location = new System.Drawing.Point(530, 28);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(52, 13);
            this.lblStatusText.TabIndex = 9;
            this.lblStatusText.Text = "[Runtime]";
            // 
            // lblStatusColour
            // 
            this.lblStatusColour.BackColor = System.Drawing.Color.LimeGreen;
            this.lblStatusColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatusColour.Location = new System.Drawing.Point(510, 29);
            this.lblStatusColour.Name = "lblStatusColour";
            this.lblStatusColour.Size = new System.Drawing.Size(14, 13);
            this.lblStatusColour.TabIndex = 8;
            // 
            // lblTokenAuthed
            // 
            this.lblTokenAuthed.AutoSize = true;
            this.lblTokenAuthed.Location = new System.Drawing.Point(407, 29);
            this.lblTokenAuthed.Name = "lblTokenAuthed";
            this.lblTokenAuthed.Size = new System.Drawing.Size(93, 13);
            this.lblTokenAuthed.TabIndex = 4;
            this.lblTokenAuthed.Text = "Token authorised:";
            // 
            // lblProjectPlaceHolder
            // 
            this.lblProjectPlaceHolder.AutoSize = true;
            this.lblProjectPlaceHolder.Location = new System.Drawing.Point(281, 29);
            this.lblProjectPlaceHolder.Name = "lblProjectPlaceHolder";
            this.lblProjectPlaceHolder.Size = new System.Drawing.Size(39, 13);
            this.lblProjectPlaceHolder.TabIndex = 3;
            this.lblProjectPlaceHolder.Text = "projPH";
            // 
            // lblOrgPlaceHolder
            // 
            this.lblOrgPlaceHolder.AutoSize = true;
            this.lblOrgPlaceHolder.Location = new System.Drawing.Point(95, 28);
            this.lblOrgPlaceHolder.Name = "lblOrgPlaceHolder";
            this.lblOrgPlaceHolder.Size = new System.Drawing.Size(35, 13);
            this.lblOrgPlaceHolder.TabIndex = 2;
            this.lblOrgPlaceHolder.Text = "orgPh";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(215, 29);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(43, 13);
            this.lblProject.TabIndex = 1;
            this.lblProject.Text = "Project:";
            // 
            // lblOrg
            // 
            this.lblOrg.AutoSize = true;
            this.lblOrg.Location = new System.Drawing.Point(10, 28);
            this.lblOrg.Name = "lblOrg";
            this.lblOrg.Size = new System.Drawing.Size(69, 13);
            this.lblOrg.TabIndex = 0;
            this.lblOrg.Text = "Organisation:";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Location = new System.Drawing.Point(1108, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvPRs
            // 
            this.dgvPRs.AllowUserToAddRows = false;
            this.dgvPRs.AllowUserToDeleteRows = false;
            this.dgvPRs.AllowUserToOrderColumns = true;
            this.dgvPRs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPRs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPRs.Location = new System.Drawing.Point(3, 16);
            this.dgvPRs.Name = "dgvPRs";
            this.dgvPRs.ReadOnly = true;
            this.dgvPRs.Size = new System.Drawing.Size(1174, 546);
            this.dgvPRs.TabIndex = 4;
            this.dgvPRs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPRs_CellDoubleClick);
            // 
            // grpPRs
            // 
            this.grpPRs.Controls.Add(this.dgvPRs);
            this.grpPRs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPRs.Location = new System.Drawing.Point(3, 3);
            this.grpPRs.Name = "grpPRs";
            this.grpPRs.Size = new System.Drawing.Size(1180, 565);
            this.grpPRs.TabIndex = 5;
            this.grpPRs.TabStop = false;
            this.grpPRs.Text = "Active PRs - Double click row to open in Azure DevOps";
            // 
            // pButtons
            // 
            this.pButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pButtons.Controls.Add(this.btnGetActivePRs);
            this.pButtons.Controls.Add(this.button1);
            this.pButtons.Controls.Add(this.btnExit);
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
            this.prexTablControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.prexTablControl.Location = new System.Drawing.Point(0, 65);
            this.prexTablControl.Name = "prexTablControl";
            this.prexTablControl.SelectedIndex = 0;
            this.prexTablControl.Size = new System.Drawing.Size(1194, 597);
            this.prexTablControl.TabIndex = 5;
            // 
            // tcActivePrs
            // 
            this.tcActivePrs.Controls.Add(this.grpPRs);
            this.tcActivePrs.Location = new System.Drawing.Point(4, 22);
            this.tcActivePrs.Name = "tcActivePrs";
            this.tcActivePrs.Padding = new System.Windows.Forms.Padding(3);
            this.tcActivePrs.Size = new System.Drawing.Size(1186, 571);
            this.tcActivePrs.TabIndex = 0;
            this.tcActivePrs.Text = "Active Pull Requests";
            this.tcActivePrs.UseVisualStyleBackColor = true;
            // 
            // tcPrArchive
            // 
            this.tcPrArchive.Controls.Add(this.grpBoxArchived);
            this.tcPrArchive.Location = new System.Drawing.Point(4, 22);
            this.tcPrArchive.Name = "tcPrArchive";
            this.tcPrArchive.Padding = new System.Windows.Forms.Padding(3);
            this.tcPrArchive.Size = new System.Drawing.Size(1186, 571);
            this.tcPrArchive.TabIndex = 1;
            this.tcPrArchive.Text = "Archived";
            this.tcPrArchive.UseVisualStyleBackColor = true;
            // 
            // grpBoxArchived
            // 
            this.grpBoxArchived.Controls.Add(this.panelFilter);
            this.grpBoxArchived.Controls.Add(this.dgvArchived);
            this.grpBoxArchived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxArchived.Location = new System.Drawing.Point(3, 3);
            this.grpBoxArchived.Name = "grpBoxArchived";
            this.grpBoxArchived.Size = new System.Drawing.Size(1180, 565);
            this.grpBoxArchived.TabIndex = 6;
            this.grpBoxArchived.TabStop = false;
            this.grpBoxArchived.Text = "Archived PRs - Double click row to open in Azure DevOps";
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.btnArchPrs);
            this.panelFilter.Controls.Add(this.txtBoxFilter);
            this.panelFilter.Controls.Add(this.lblFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(3, 16);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1174, 34);
            this.panelFilter.TabIndex = 6;
            // 
            // btnArchPrs
            // 
            this.btnArchPrs.Location = new System.Drawing.Point(877, 5);
            this.btnArchPrs.Name = "btnArchPrs";
            this.btnArchPrs.Size = new System.Drawing.Size(66, 23);
            this.btnArchPrs.TabIndex = 5;
            this.btnArchPrs.Text = "Refresh";
            this.btnArchPrs.UseVisualStyleBackColor = true;
            this.btnArchPrs.Click += new System.EventHandler(this.btnArchPrs_Click);
            // 
            // txtBoxFilter
            // 
            this.txtBoxFilter.Location = new System.Drawing.Point(49, 7);
            this.txtBoxFilter.Name = "txtBoxFilter";
            this.txtBoxFilter.Size = new System.Drawing.Size(822, 20);
            this.txtBoxFilter.TabIndex = 1;
            this.txtBoxFilter.TextChanged += new System.EventHandler(this.txtBoxFilter_TextChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(10, 11);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(32, 13);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter:";
            // 
            // dgvArchived
            // 
            this.dgvArchived.AllowUserToAddRows = false;
            this.dgvArchived.AllowUserToDeleteRows = false;
            this.dgvArchived.AllowUserToOrderColumns = true;
            this.dgvArchived.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArchived.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArchived.Location = new System.Drawing.Point(3, 56);
            this.dgvArchived.Name = "dgvArchived";
            this.dgvArchived.ReadOnly = true;
            this.dgvArchived.Size = new System.Drawing.Size(1174, 509);
            this.dgvArchived.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 714);
            this.Controls.Add(this.pButtons);
            this.Controls.Add(this.prexTablControl);
            this.Controls.Add(this.grpActiveSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PREx - An Azure DevOps Pull Request Parser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.grpActiveSettings.ResumeLayout(false);
            this.grpActiveSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRs)).EndInit();
            this.grpPRs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.pButtons.ResumeLayout(false);
            this.prexTablControl.ResumeLayout(false);
            this.tcActivePrs.ResumeLayout(false);
            this.tcPrArchive.ResumeLayout(false);
            this.grpBoxArchived.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchived)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGetActivePRs;
        private System.Windows.Forms.GroupBox grpActiveSettings;
        private System.Windows.Forms.Label lblOrg;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label lblOrgPlaceHolder;
        private System.Windows.Forms.Label lblProjectPlaceHolder;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvPRs;
        private System.Windows.Forms.GroupBox grpPRs;
        private System.Windows.Forms.Label lblTokenAuthed;
        private System.Windows.Forms.Label lblStatusColour;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.Label lblStatusText;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TabControl prexTablControl;
        private System.Windows.Forms.TabPage tcActivePrs;
        private System.Windows.Forms.TabPage tcPrArchive;
        private System.Windows.Forms.GroupBox grpBoxArchived;
        private System.Windows.Forms.DataGridView dgvArchived;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.TextBox txtBoxFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnArchPrs;
    }
}

