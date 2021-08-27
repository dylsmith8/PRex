using PullRequestExtractor.Helpers;
using PullRequestExtractor.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PullRequestExtractor.Presenters
{
    public class SubscribedProjectsPresenter
    {
        private readonly IAzureAPI _api;

        public SubscribedProjectsPresenter(IGetSubscribedProjects view, IAzureAPI api)
        {
            _api = api;
            view.GetProjects += View_GetProjects;
        }

        private async Task<DataTable> View_GetProjects()
        {
            var projects = await _api.GetAuthedProjectsAsync();
            return ParseSubbedProjects(projects);
        }

        private DataTable ParseSubbedProjects(Models.Projects.Project projects)
        {
            List<string> subbedProjectsDgvSrc = new List<string>();

            foreach (var project in projects.value)
                subbedProjectsDgvSrc.Add(project.name);

            return Util.StringListToDataTable(subbedProjectsDgvSrc);
        }
    }
}
