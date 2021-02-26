using PullRequestExtractor.Helpers;
using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Interfaces.IArchivedPRView;
using PullRequestExtractor.Models;
using PullRequestExtractor.Models.PullRequests;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PullRequestExtractor.Presenters
{
    public class ArchivedPullRequestPresenter
    {
        private readonly IAzureAPI _api;
        
        public ArchivedPullRequestPresenter(IArchivedPRView view, IAzureAPI api)
        {
            _api = api;

            view.GetArchivedPullRequests += View_GetArchivedPullRequests;
            view.OpenPullRequest += View_OpenPullRequest;
        }

        private async Task<DataTable> View_GetArchivedPullRequests()
        {
            PullRequest pullRequest = await _api.GetArchivedPullRequestsAsync();
            return ParseArchivedPullRequests(pullRequest);
        }

        private void View_OpenPullRequest(string codeReviewId, string repository, string org, string project)
        {
            string uri = $"https://dev.azure.com/{org}/{project}/_git/{repository}/pullrequest/{codeReviewId}";
            Process.Start(uri);
        }

        private DataTable ParseArchivedPullRequests(PullRequest prs)
        {
            List<CompletedGridSource> dgvSource = new List<CompletedGridSource>();

            foreach (var pr in prs.value)
            {
                var src = new CompletedGridSource
                {
                    CodeReviewId = pr.codeReviewId.ToString(),
                    Title = pr.title,
                    Repo = pr.repository.name,
                    CreationDate = pr.creationDate.ToLocalTime().ToShortDateString(),
                    Author = pr.createdBy.displayName,
                    Status = pr.status,
                    Reviewers = string.Join(", ", pr.reviewers.Select(x => x.displayName)),
                    SourceBranch = pr.sourceRefName.Substring(pr.sourceRefName.LastIndexOf(@"/")),
                    TargetBranch = pr.targetRefName.Substring(pr.targetRefName.LastIndexOf(@"/")),

                    MergeStatus = pr.mergeStatus,
                    ClosedDate = pr.closedDate.ToLocalTime().ToShortDateString()
                };


                dgvSource.Add(src);
            }

            dgvSource.OrderByDescending(x => x.CreationDate);
            return Util.ToDataTable(dgvSource);          
        }
    }
}
