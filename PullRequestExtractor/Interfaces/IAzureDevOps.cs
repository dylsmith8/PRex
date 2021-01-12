using PullRequestExtractor.Models.PullRequests;
using System.Threading.Tasks;
using Project = PullRequestExtractor.Models.Projects.Project;

namespace PullRequestExtractor.Interfaces
{
    public interface IAzureDevOps
    {
        IAppSettings Settings { get; }

        Task<Project> GetAuthedProjectsAsync();
        Task<PullRequest> GetActivePullRequestsAsync(string organisation, string project);
        Task<PullRequest> GetArchivedPullRequestsAsync();
    }
}
