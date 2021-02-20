
namespace PullRequestExtractor.Forms
{
    partial class StatisticsUC
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
            this.grpStats = new System.Windows.Forms.GroupBox();
            this.dgvPRs = new System.Windows.Forms.DataGridView();
            this.panelActivePRs = new System.Windows.Forms.Panel();
            this.btnRefreshStats = new System.Windows.Forms.Button();
            this.grpStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRs)).BeginInit();
            this.panelActivePRs.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpStats
            // 
            this.grpStats.Controls.Add(this.dgvPRs);
            this.grpStats.Controls.Add(this.panelActivePRs);
            this.grpStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStats.Location = new System.Drawing.Point(0, 0);
            this.grpStats.Name = "grpStats";
            this.grpStats.Size = new System.Drawing.Size(848, 408);
            this.grpStats.TabIndex = 7;
            this.grpStats.TabStop = false;
            this.grpStats.Text = "Author Statistics";
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
            this.dgvPRs.Size = new System.Drawing.Size(842, 355);
            this.dgvPRs.TabIndex = 4;
            // 
            // panelActivePRs
            // 
            this.panelActivePRs.Controls.Add(this.btnRefreshStats);
            this.panelActivePRs.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelActivePRs.Location = new System.Drawing.Point(3, 16);
            this.panelActivePRs.Name = "panelActivePRs";
            this.panelActivePRs.Size = new System.Drawing.Size(842, 34);
            this.panelActivePRs.TabIndex = 7;
            // 
            // btnRefreshStats
            // 
            this.btnRefreshStats.Location = new System.Drawing.Point(6, 7);
            this.btnRefreshStats.Name = "btnRefreshStats";
            this.btnRefreshStats.Size = new System.Drawing.Size(67, 23);
            this.btnRefreshStats.TabIndex = 2;
            this.btnRefreshStats.Text = "Refresh";
            this.btnRefreshStats.UseVisualStyleBackColor = true;
            // 
            // StatisticsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpStats);
            this.Name = "StatisticsUC";
            this.Size = new System.Drawing.Size(848, 408);
            this.grpStats.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRs)).EndInit();
            this.panelActivePRs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpStats;
        private System.Windows.Forms.DataGridView dgvPRs;
        private System.Windows.Forms.Panel panelActivePRs;
        private System.Windows.Forms.Button btnRefreshStats;
    }
}
