
namespace PullRequestExtractor.Forms
{
    partial class ArchivedPullRequestsUC
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
            this.grpBoxArchived = new System.Windows.Forms.GroupBox();
            this.adgvArchived = new Zuby.ADGV.AdvancedDataGridView();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.btnArchPrs = new System.Windows.Forms.Button();
            this.grpBoxArchived.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvArchived)).BeginInit();
            this.panelFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxArchived
            // 
            this.grpBoxArchived.Controls.Add(this.adgvArchived);
            this.grpBoxArchived.Controls.Add(this.panelFilter);
            this.grpBoxArchived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxArchived.Location = new System.Drawing.Point(0, 0);
            this.grpBoxArchived.Name = "grpBoxArchived";
            this.grpBoxArchived.Size = new System.Drawing.Size(1004, 372);
            this.grpBoxArchived.TabIndex = 7;
            this.grpBoxArchived.TabStop = false;
            this.grpBoxArchived.Text = "Archived PRs - Double click row to open in Azure DevOps";
            // 
            // adgvArchived
            // 
            this.adgvArchived.AllowUserToAddRows = false;
            this.adgvArchived.AllowUserToDeleteRows = false;
            this.adgvArchived.AllowUserToOrderColumns = true;
            this.adgvArchived.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvArchived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adgvArchived.FilterAndSortEnabled = true;
            this.adgvArchived.Location = new System.Drawing.Point(3, 50);
            this.adgvArchived.Name = "adgvArchived";
            this.adgvArchived.ReadOnly = true;
            this.adgvArchived.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.adgvArchived.Size = new System.Drawing.Size(998, 319);
            this.adgvArchived.TabIndex = 7;
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.btnArchPrs);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(3, 16);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(998, 34);
            this.panelFilter.TabIndex = 6;
            // 
            // btnArchPrs
            // 
            this.btnArchPrs.Location = new System.Drawing.Point(5, 6);
            this.btnArchPrs.Name = "btnArchPrs";
            this.btnArchPrs.Size = new System.Drawing.Size(66, 23);
            this.btnArchPrs.TabIndex = 5;
            this.btnArchPrs.Text = "Refresh";
            this.btnArchPrs.UseVisualStyleBackColor = true;
            this.btnArchPrs.Click += new System.EventHandler(this.btnArchPrs_Click);
            // 
            // ArchivedPullRequestsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxArchived);
            this.Name = "ArchivedPullRequestsUC";
            this.Size = new System.Drawing.Size(1004, 372);
            this.grpBoxArchived.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgvArchived)).EndInit();
            this.panelFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxArchived;
        private Zuby.ADGV.AdvancedDataGridView adgvArchived;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Button btnArchPrs;
    }
}
