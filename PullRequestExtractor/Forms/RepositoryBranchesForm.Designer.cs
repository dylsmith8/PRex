
namespace PullRequestExtractor.Forms
{
    partial class RepositoryBranchesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepositoryBranchesForm));
            this.grpBoxBranches = new System.Windows.Forms.GroupBox();
            this.adgvBranches = new Zuby.ADGV.AdvancedDataGridView();
            this.grpBoxBranches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvBranches)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxBranches
            // 
            this.grpBoxBranches.Controls.Add(this.adgvBranches);
            this.grpBoxBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxBranches.Location = new System.Drawing.Point(0, 0);
            this.grpBoxBranches.Name = "grpBoxBranches";
            this.grpBoxBranches.Size = new System.Drawing.Size(800, 450);
            this.grpBoxBranches.TabIndex = 0;
            this.grpBoxBranches.TabStop = false;
            this.grpBoxBranches.Text = "Choose a branch to subscribe to";
            // 
            // adgvBranches
            // 
            this.adgvBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adgvBranches.FilterAndSortEnabled = true;
            this.adgvBranches.Location = new System.Drawing.Point(3, 16);
            this.adgvBranches.Name = "adgvBranches";
            this.adgvBranches.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.adgvBranches.Size = new System.Drawing.Size(794, 431);
            this.adgvBranches.TabIndex = 0;
            // 
            // RepositoryBranchesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpBoxBranches);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RepositoryBranchesForm";
            this.Text = "Repository Branches";
            this.Load += new System.EventHandler(this.RepositoryBranchesForm_Load);
            this.grpBoxBranches.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgvBranches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxBranches;
        private Zuby.ADGV.AdvancedDataGridView adgvBranches;
    }
}