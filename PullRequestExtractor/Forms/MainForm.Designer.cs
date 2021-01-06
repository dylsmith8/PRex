
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
            this.button2 = new System.Windows.Forms.Button();
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
            this.grpActiveSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRs)).BeginInit();
            this.grpPRs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.pButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Projects";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.TestGetProjects_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Get PRs";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.TestGetPRs_Click);
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
            this.lblStatusText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusText.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusText.Location = new System.Drawing.Point(661, 24);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(55, 19);
            this.lblStatusText.TabIndex = 9;
            this.lblStatusText.Text = "[Runtime]";
            this.lblStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatusColour
            // 
            this.lblStatusColour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusColour.BackColor = System.Drawing.Color.LimeGreen;
            this.lblStatusColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatusColour.Location = new System.Drawing.Point(641, 28);
            this.lblStatusColour.Name = "lblStatusColour";
            this.lblStatusColour.Size = new System.Drawing.Size(14, 13);
            this.lblStatusColour.TabIndex = 8;
            // 
            // lblTokenAuthed
            // 
            this.lblTokenAuthed.AutoSize = true;
            this.lblTokenAuthed.Location = new System.Drawing.Point(538, 28);
            this.lblTokenAuthed.Name = "lblTokenAuthed";
            this.lblTokenAuthed.Size = new System.Drawing.Size(93, 13);
            this.lblTokenAuthed.TabIndex = 4;
            this.lblTokenAuthed.Text = "Token authorised:";
            // 
            // lblProjectPlaceHolder
            // 
            this.lblProjectPlaceHolder.AutoSize = true;
            this.lblProjectPlaceHolder.Location = new System.Drawing.Point(358, 28);
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
            this.lblProject.Location = new System.Drawing.Point(292, 28);
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
            this.btnExit.Location = new System.Drawing.Point(830, 16);
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
            this.dgvPRs.Size = new System.Drawing.Size(1180, 568);
            this.dgvPRs.TabIndex = 4;
            this.dgvPRs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPRs_CellDoubleClick);
            // 
            // grpPRs
            // 
            this.grpPRs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPRs.Controls.Add(this.dgvPRs);
            this.grpPRs.Location = new System.Drawing.Point(0, 68);
            this.grpPRs.Name = "grpPRs";
            this.grpPRs.Size = new System.Drawing.Size(1186, 587);
            this.grpPRs.TabIndex = 5;
            this.grpPRs.TabStop = false;
            this.grpPRs.Text = "Active PRs - Double click row to open in Azure DevOps";
            // 
            // pButtons
            // 
            this.pButtons.Controls.Add(this.button2);
            this.pButtons.Controls.Add(this.button1);
            this.pButtons.Controls.Add(this.btnExit);
            this.pButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtons.Location = new System.Drawing.Point(0, 661);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(1194, 53);
            this.pButtons.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 714);
            this.Controls.Add(this.grpActiveSettings);
            this.Controls.Add(this.grpPRs);
            this.Controls.Add(this.pButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PREx";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpActiveSettings.ResumeLayout(false);
            this.grpActiveSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRs)).EndInit();
            this.grpPRs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.pButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
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
        private System.Windows.Forms.Label lblStatusText;
        private System.Windows.Forms.Panel pButtons;
    }
}

