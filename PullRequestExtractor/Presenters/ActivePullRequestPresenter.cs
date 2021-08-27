using PullRequestExtractor.Helpers;
using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Interfaces.IActivePRView;
using PullRequestExtractor.Models;
using PullRequestExtractor.Models.PullRequests;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tulpep.NotificationWindow;

namespace PullRequestExtractor.Presenters
{
    public class ActivePullRequestPresenter
    {
        private readonly IAzureAPI _api;
        private List<PullRequestGridSource> _seenPullRequests;

        public ActivePullRequestPresenter(IActivePRView view, IAzureAPI api)
        {
            _api = api;
            view.GetActivePullRequests += View_GetActivePullRequests;
            view.OpenPullRequest += View_OpenPullRequest;
            _seenPullRequests = new List<PullRequestGridSource>();
        }

        private async Task<DataTable> View_GetActivePullRequests()
        {
            PullRequest pullRequests = await _api.GetActivePullRequestsAsync();
            return ParseActivePullRequestData(pullRequests);
        }

        private void View_OpenPullRequest(string codeReviewId, string repository, string org, string project)
        {
            string uri = $"https://dev.azure.com/{org}/{project}/_git/{repository}/pullrequest/{codeReviewId}";
            Process.Start(uri);
        }

        private DataTable ParseActivePullRequestData(PullRequest prs)
        {
            List<PullRequestGridSource> dgvSource = new List<PullRequestGridSource>();

            foreach (var pr in prs.value)
            {
                var src = new PullRequestGridSource
                {
                    PullRequestId = pr.pullRequestId.ToString(),
                    Title = pr.title,
                    Repo = pr.repository.name,
                    CreationDate = pr.creationDate.ToLocalTime().ToString(),
                    Author = pr.createdBy.displayName,
                    Status = pr.status,
                    Reviewers = string.Join(", ", pr.reviewers.Select(x => x.displayName)),
                    SourceBranch = pr.sourceRefName.Substring(pr.sourceRefName.LastIndexOf(@"/")),
                    TargetBranch = pr.targetRefName.Substring(pr.targetRefName.LastIndexOf(@"/")),
                };

                dgvSource.Add(src);
            }

            var distict = dgvSource.Except(_seenPullRequests, new PullRequestComparer()).ToList();
            if (distict.Count == 1)
                CreateToast(distict.Single().Title, distict.Single().Author);
            else if (distict.Count >= 2)
                CreateToast(distict.Count);

            _seenPullRequests = dgvSource;
            return Util.ToDataTable(_seenPullRequests);
        }

        private static void CreateToast(int newPrs)
        {
            DisplayToast("New pull requests for your attention", $"{newPrs} Pull Requests have been added.");
        }

        private static void CreateToast(string pullRequestName, string author)
        {
            DisplayToast("A new pull request has been added", $"A new pull request with title '{pullRequestName}' has been added by {author}.");
        }

        private static void DisplayToast(string title, string content)
        {
            using (PopupNotifier notifier = new PopupNotifier())
            {
                notifier.TitleText = title;
                notifier.ContentText = content;
                notifier.IsRightToLeft = false;
                notifier.Popup();
            }
        }
    }
}
