
namespace PullRequestExtractor.Forms
{
    partial class ActivePullRequestsUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpPRs = new System.Windows.Forms.GroupBox();
            this.dgvPRs = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGetActivePRs = new System.Windows.Forms.Button();
            this.grpPRs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRs)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPRs
            // 
            this.grpPRs.Controls.Add(this.dgvPRs);
            this.grpPRs.Controls.Add(this.panel1);
            this.grpPRs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPRs.Location = new System.Drawing.Point(0, 0);
            this.grpPRs.Name = "grpPRs";
            this.grpPRs.Size = new System.Drawing.Size(957, 482);
            this.grpPRs.TabIndex = 6;
            this.grpPRs.TabStop = false;
            this.grpPRs.Text = "Active PRs - Double click row to open in Azure DevOps";
            // 
            // dgvPRs
            // 
            this.dgvPRs.AllowUserToAddRows = false;
            this.dgvPRs.AllowUserToDeleteRows = false;
            this.dgvPRs.AllowUserToOrderColumns = true;
            this.dgvPRs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPRs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPRs.Location = new System.Drawing.Point(3, 50);
            this.dgvPRs.Name = "dgvPRs";
            this.dgvPRs.ReadOnly = true;
            this.dgvPRs.Size = new System.Drawing.Size(951, 429);
            this.dgvPRs.TabIndex = 4;
            this.dgvPRs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPRs_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGetActivePRs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 34);
            this.panel1.TabIndex = 7;
            // 
            // btnGetActivePRs
            // 
            this.btnGetActivePRs.Location = new System.Drawing.Point(6, 7);
            this.btnGetActivePRs.Name = "btnGetActivePRs";
            this.btnGetActivePRs.Size = new System.Drawing.Size(67, 23);
            this.btnGetActivePRs.TabIndex = 2;
            this.btnGetActivePRs.Text = "Refresh";
            this.btnGetActivePRs.UseVisualStyleBackColor = true;
            this.btnGetActivePRs.Click += new System.EventHandler(this.btnGetActivePRs_Click);
            // 
            // ActivePullRequestsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpPRs);
            this.Name = "ActivePullRequestsUC";
            this.Size = new System.Drawing.Size(957, 482);
            this.Load += new System.EventHandler(this.ActivePullRequestsUC_Load);
            this.grpPRs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPRs;
        private System.Windows.Forms.DataGridView dgvPRs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGetActivePRs;
    }
}
