using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PullRequestExtractor.Forms
{
    public partial class RepositoryBranchesForm : Form, IBranchesView
    {
        public event GetBranchesDelegate GetBranches;

        private readonly IAzureAPI _api;
        private readonly Action<bool> _setConnectivityError;
        private readonly Guid _repositoryId;
        private readonly Guid _projectId;

        public RepositoryBranchesForm(IAzureAPI api, Action<bool> setConnectivityError, Guid repositoryId, Guid projectId)
        {
            InitializeComponent();

            _api = api;
            _setConnectivityError = setConnectivityError;
            _repositoryId = repositoryId;
            _projectId = projectId;

            adgvBranches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            new BranchesPresenter(this, _api);
        }

        private async void RepositoryBranchesForm_Load(object sender, EventArgs e)
        {
            DataTable branches = null;

            try
            {
                branches = await GetBranches?.Invoke(_repositoryId, _projectId);

                adgvBranches.DataSource = null;
                adgvBranches.AutoGenerateColumns = true;
                adgvBranches.Refresh();

                adgvBranches.DataSource = branches;
                adgvBranches.Refresh();
            }
            catch (TaskCanceledException) { /* swallow - app is closing */ }
            catch (Exception ex)
            {
                // some other error happened
                MessageBox.Show($"{ex.Message}\n{ex.InnerException.Message}\n Check the Windows Event Viewer for more information.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _setConnectivityError(false);
            };
        }
    }
}
