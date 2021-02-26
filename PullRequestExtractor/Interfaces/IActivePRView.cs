using System.Data;
using System.Threading.Tasks;

namespace PullRequestExtractor.Interfaces.IActivePRView
{
    public delegate Task<DataTable> GetActivePullRequestsDelegate();
    public delegate void OpenPullRequestDelegate(string codeReviewId, string repository, string org, string project);
    public interface IActivePRView
    {
        event GetActivePullRequestsDelegate GetActivePullRequests;
        event OpenPullRequestDelegate OpenPullRequest;
    }
}
