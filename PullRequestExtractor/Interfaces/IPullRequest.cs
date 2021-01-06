using PullRequestExtractor.Models.PullRequests;
using System.Threading.Tasks;

namespace PullRequestExtractor.Interfaces
{
    public delegate Task<PullRequest> GetPullRequestsDelegate(string organisation, string project);

    public interface IPullRequest
    {
        event GetPullRequestsDelegate GetPullRequests;
    }
}