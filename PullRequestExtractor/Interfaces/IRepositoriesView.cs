using System;
using System.Data;
using System.Threading.Tasks;

namespace PullRequestExtractor.Interfaces
{
    public delegate Task<DataTable> GetRepositoryNamesDelegate();
    public delegate void DisplayRepositoryBranchesDelegate(Guid repoId, Guid projectId);
    
    public interface IRepositoriesView
    {
        event GetRepositoryNamesDelegate GetRepositoryNames;
        event DisplayRepositoryBranchesDelegate GetRepositoryBranches;
    }
}