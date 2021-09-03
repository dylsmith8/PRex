using System;
using System.Data;
using System.Threading.Tasks;

namespace PullRequestExtractor.Interfaces
{
    public delegate Task<DataTable> GetBranchesDelegate(Guid repositoryId, Guid projectId);

    public interface IBranchesView
    {
        event GetBranchesDelegate GetBranches;
    }
}
