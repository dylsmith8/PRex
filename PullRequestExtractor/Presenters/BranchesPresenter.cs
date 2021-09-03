using PullRequestExtractor.Helpers;
using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Models;
using PullRequestExtractor.Models.BranchDetails;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullRequestExtractor.Presenters
{
    public class BranchesPresenter
    {
        private IAzureAPI _api;

        public BranchesPresenter(IBranchesView view, IAzureAPI api)
        {
            _api = api;
            view.GetBranches += View_GetBranches;
        }

        private async Task<DataTable> View_GetBranches(Guid repositoryId, Guid projectId)
        {
            Branch branches = await _api.GetBranches(repositoryId, projectId);
            return ParseBranches(branches);
        }

        private DataTable ParseBranches(Branch branches)
        {
            List<BranchGridSource> src = new List<BranchGridSource>();

            foreach (var branch in branches.value)
            {
                var item = new BranchGridSource
                {
                    Name = branch.name.Replace("refs/heads", string.Empty),
                    Creator = branch.creator.displayName,
                    IsSubscribedTo = false
                };

                src.Add(item);
            }

            return Util.ToDataTable(src);
        }
    }
}
