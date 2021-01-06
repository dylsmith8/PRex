using Newtonsoft.Json;
using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Models.Projects;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PullRequestExtractor.Managers
{
    class ProjectManager
    {
        private readonly string _pat;
        private readonly string _org;

        public ProjectManager(IAppSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (!settings.TryGetAppSetting("PAT", out _pat))
                throw new InvalidOperationException("Could not find a valid personal access token for Azure DevOps");

            if (!settings.TryGetAppSetting("Org", out _org))
                throw new InvalidOperationException("Could not find a Organisation for Azure DevOps");
        }
    
        // error handling!
        internal async Task<Project> GetAuthedProjectsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        System.Text.Encoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "", _pat))));

                using (HttpResponseMessage response = await client.GetAsync($"https://dev.azure.com/{_org}/_apis/projects"))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Project>(responseBody);
                }
            }
        }
    }
}
