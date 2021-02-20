using PullRequestExtractor.Interfaces;
using System.Threading.Tasks;

namespace PullRequestExtractor.Presenters
{
    class StatisticsPresenter
    {
        private readonly IAzureAPI _api;

        public StatisticsPresenter(IStatisticsView view, IAzureAPI api)
        {
            _api = api;
            view.GetRepositories += View_GetRepositories;
        }

        private async Task<Models.GitRepository> View_GetRepositories()
        {
            return await _api.GetRepositories();
        }
    }
}
