using Newtonsoft.Json;
using PullRequestExtractor.Helpers;
using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Models.Projects;
using System;
using System.Net;
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
                throw new InvalidOperationException("Could not find an Organisation for Azure DevOps");
        }
    
        // error handling!
        internal async Task<Project> GetAuthedProjectsAsync()
        {
            HttpStatusCode statusCode = new HttpStatusCode();

            try
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
                        statusCode = response.StatusCode;
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Project>(responseBody);
                    }
                }           
            }
            catch (HttpRequestException e)
            {
                int code = (int)statusCode;

                string error = code != 0 ?
                    $"Could not connect to the Azure DevOps API. HTTP Response {(int)statusCode} ({statusCode})" :
                    $"Could not connect to the Azure DevOps API.";

                EventLogWriter.WriteToEventLog(e, error);

                throw new Exception(error, e);
            }
        }
    }
}
