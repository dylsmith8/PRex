using PullRequestExtractor.Models;
using PullRequestExtractor.Models.PullRequests;
using System.Threading.Tasks;
using Project = PullRequestExtractor.Models.Projects.Project;

namespace PullRequestExtractor.Interfaces
{
    public interface IAzureAPI
    {
        IAppSettings Settings { get; }

        Task<Project> GetAuthedProjectsAsync();
        Task<PullRequest> GetActivePullRequestsAsync();
        Task<PullRequest> GetArchivedPullRequestsAsync();
        Task<GitRepository> GetRepositories();
    }
}
