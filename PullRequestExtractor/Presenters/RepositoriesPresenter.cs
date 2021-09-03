using PullRequestExtractor.Forms;
using PullRequestExtractor.Helpers;
using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PullRequestExtractor.Presenters
{
    public class RepositoriesPresenter
    {
        private readonly IAzureAPI _api;
        private readonly Action<bool> _setConnectivityError;

        public RepositoriesPresenter(IRepositoriesView view, IAzureAPI api, Action<bool> setConnectivityError)
        {
            view.GetRepositoryNames += View_GetRepositoryNames;
            view.GetRepositoryBranches += View_GetRepositoryBranches;

            _api = api;
            _setConnectivityError = setConnectivityError;
        }

        private async Task<DataTable> View_GetRepositoryNames()
        {
            GitRepository repos = await _api.GetRepositories();
            return ParseRepositories(repos);
        }

        private void View_GetRepositoryBranches(Guid repoId, Guid projectId)
        {
            using (RepositoryBranchesForm frm = new RepositoryBranchesForm(_api, _setConnectivityError, repoId, projectId))
                frm.ShowDialog();
        }

        private DataTable ParseRepositories(GitRepository repos)
        {
            List<RepositoryDetail> repositoryDetails = new List<RepositoryDetail>();

            foreach (var repo in repos.value)
            {
                var src = new RepositoryDetail
                {
                    RepositoryID = Guid.Parse(repo.id),
                    Name = repo.name,
                    Project = repo.project.name,
                    ProjectID = Guid.Parse(repo.project.id)
                };

                repositoryDetails.Add(src);
            }

            repositoryDetails.OrderBy(x => x.Name);

            return Util.ToDataTable(repositoryDetails);
        }
    }
}
