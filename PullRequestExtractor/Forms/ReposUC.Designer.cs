
namespace PullRequestExtractor.Forms
{
    partial class ReposUC
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
            this.grpBoxRepos = new System.Windows.Forms.GroupBox();
            this.panelRepos = new System.Windows.Forms.Panel();
            this.btnRefreshRepos = new System.Windows.Forms.Button();
            this.adgvRepos = new Zuby.ADGV.AdvancedDataGridView();
            this.grpBoxRepos.SuspendLayout();
            this.panelRepos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvRepos)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxRepos
            // 
            this.grpBoxRepos.Controls.Add(this.adgvRepos);
            this.grpBoxRepos.Controls.Add(this.panelRepos);
            this.grpBoxRepos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxRepos.Location = new System.Drawing.Point(0, 0);
            this.grpBoxRepos.Name = "grpBoxRepos";
            this.grpBoxRepos.Size = new System.Drawing.Size(733, 337);
            this.grpBoxRepos.TabIndex = 0;
            this.grpBoxRepos.TabStop = false;
            this.grpBoxRepos.Text = "Repos - double click to view branches";
            // 
            // panelRepos
            // 
            this.panelRepos.Controls.Add(this.btnRefreshRepos);
            this.panelRepos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRepos.Location = new System.Drawing.Point(3, 16);
            this.panelRepos.Name = "panelRepos";
            this.panelRepos.Size = new System.Drawing.Size(727, 34);
            this.panelRepos.TabIndex = 8;
            // 
            // btnRefreshRepos
            // 
            this.btnRefreshRepos.Location = new System.Drawing.Point(6, 7);
            this.btnRefreshRepos.Name = "btnRefreshRepos";
            this.btnRefreshRepos.Size = new System.Drawing.Size(67, 23);
            this.btnRefreshRepos.TabIndex = 2;
            this.btnRefreshRepos.Text = "Refresh";
            this.btnRefreshRepos.UseVisualStyleBackColor = true;
            this.btnRefreshRepos.Click += new System.EventHandler(this.btnRefreshRepos_Click);
            // 
            // adgvRepos
            // 
            this.adgvRepos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvRepos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adgvRepos.FilterAndSortEnabled = true;
            this.adgvRepos.Location = new System.Drawing.Point(3, 50);
            this.adgvRepos.Name = "adgvRepos";
            this.adgvRepos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.adgvRepos.Size = new System.Drawing.Size(727, 284);
            this.adgvRepos.TabIndex = 9;
            this.adgvRepos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvRepos_CellDoubleClick);
            // 
            // ReposUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxRepos);
            this.Name = "ReposUC";
            this.Size = new System.Drawing.Size(733, 337);
            this.Load += new System.EventHandler(this.ReposUC_Load);
            this.grpBoxRepos.ResumeLayout(false);
            this.panelRepos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgvRepos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxRepos;
        private System.Windows.Forms.Panel panelRepos;
        private System.Windows.Forms.Button btnRefreshRepos;
        private Zuby.ADGV.AdvancedDataGridView adgvRepos;
    }
}
