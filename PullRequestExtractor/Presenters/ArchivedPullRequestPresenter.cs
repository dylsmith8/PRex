using PullRequestExtractor.Forms;
using PullRequestExtractor.Helpers;
using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Models;
using PullRequestExtractor.Models.PullRequests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullRequestExtractor.Presenters
{
    public class ArchivedPullRequestPresenter
    {
        private readonly IAzureAPI _api;
        
        public ArchivedPullRequestPresenter(IArchivedPRView view, IAzureAPI api)
        {
            _api = api;

            view.GetArchivedPullRequests += View_GetArchivedPullRequests; ;
        }

        private async Task<DataTable> View_GetArchivedPullRequests()
        {
            PullRequest pullRequest = await _api.GetArchivedPullRequestsAsync();
            return ParseArchivedPullRequests(pullRequest);
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
