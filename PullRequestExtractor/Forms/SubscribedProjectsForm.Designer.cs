
namespace PullRequestExtractor.Forms
{
    partial class SubscribedProjectsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubscribedProjectsForm));
            this.grpBoxSubscribedProjects = new System.Windows.Forms.GroupBox();
            this.adgvSubbed = new Zuby.ADGV.AdvancedDataGridView();
            this.grpBoxSubscribedProjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvSubbed)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxSubscribedProjects
            // 
            this.grpBoxSubscribedProjects.Controls.Add(this.adgvSubbed);
            this.grpBoxSubscribedProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxSubscribedProjects.Location = new System.Drawing.Point(0, 0);
            this.grpBoxSubscribedProjects.Name = "grpBoxSubscribedProjects";
            this.grpBoxSubscribedProjects.Size = new System.Drawing.Size(522, 312);
            this.grpBoxSubscribedProjects.TabIndex = 0;
            this.grpBoxSubscribedProjects.TabStop = false;
            this.grpBoxSubscribedProjects.Text = "Subscribed Projects";
            // 
            // adgvSubbed
            // 
            this.adgvSubbed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvSubbed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adgvSubbed.FilterAndSortEnabled = true;
            this.adgvSubbed.Location = new System.Drawing.Point(3, 16);
            this.adgvSubbed.Name = "adgvSubbed";
            this.adgvSubbed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.adgvSubbed.Size = new System.Drawing.Size(516, 293);
            this.adgvSubbed.TabIndex = 0;
            // 
            // SubscribedProjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 312);
            this.Controls.Add(this.grpBoxSubscribedProjects);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SubscribedProjectsForm";
            this.Text = "Subscribed Projects";
            this.Load += new System.EventHandler(this.SubscribedProjects_Load);
            this.grpBoxSubscribedProjects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgvSubbed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxSubscribedProjects;
        private Zuby.ADGV.AdvancedDataGridView adgvSubbed;
    }
}