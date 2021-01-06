
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.grpActiveSettings = new System.Windows.Forms.GroupBox();
            this.lblProjectPlaceHolder = new System.Windows.Forms.Label();
            this.lblOrgPlaceHolder = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.lblOrg = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvPRs = new System.Windows.Forms.DataGridView();
            this.grpPRs = new System.Windows.Forms.GroupBox();
            this.grpActiveSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRs)).BeginInit();
            this.grpPRs.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 679);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Projects";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.TestGetProjects_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 679);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Get PRs";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.TestGetPRs_Click);
            // 
            // grpActiveSettings
            // 
            this.grpActiveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpActiveSettings.Controls.Add(this.lblProjectPlaceHolder);
            this.grpActiveSettings.Controls.Add(this.lblOrgPlaceHolder);
            this.grpActiveSettings.Controls.Add(this.lblProject);
            this.grpActiveSettings.Controls.Add(this.lblOrg);
            this.grpActiveSettings.Location = new System.Drawing.Point(0, 0);
            this.grpActiveSettings.Name = "grpActiveSettings";
            this.grpActiveSettings.Size = new System.Drawing.Size(1190, 65);
            this.grpActiveSettings.TabIndex = 2;
            this.grpActiveSettings.TabStop = false;
            this.grpActiveSettings.Text = "Active Settings";
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
            this.btnExit.Location = new System.Drawing.Point(1115, 679);
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
            this.dgvPRs.Size = new System.Drawing.Size(1180, 583);
            this.dgvPRs.TabIndex = 4;
            this.dgvPRs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPRs_CellDoubleClick);
            // 
            // grpPRs
            // 
            this.grpPRs.Controls.Add(this.dgvPRs);
            this.grpPRs.Location = new System.Drawing.Point(4, 71);
            this.grpPRs.Name = "grpPRs";
            this.grpPRs.Size = new System.Drawing.Size(1186, 602);
            this.grpPRs.TabIndex = 5;
            this.grpPRs.TabStop = false;
            this.grpPRs.Text = "Active PRs";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 714);
            this.Controls.Add(this.grpPRs);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grpActiveSettings);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "PREx";
            this.grpActiveSettings.ResumeLayout(false);
            this.grpActiveSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRs)).EndInit();
            this.grpPRs.ResumeLayout(false);
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
    }
}

