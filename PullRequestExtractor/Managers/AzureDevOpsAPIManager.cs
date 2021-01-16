using Newtonsoft.Json;
using PullRequestExtractor.Helpers;
using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Models.PullRequests;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Project = PullRequestExtractor.Models.Projects.Project;

namespace PullRequestExtractor.Managers
{
    public class AzureDevOpsAPIManager : IAzureDevOps
    {
        private readonly string _pat;
        private readonly string _org;
        private readonly string _project;

        public IAppSettings Settings => new AppSettings();

        public AzureDevOpsAPIManager()
        {
            IAppSettings settings = Settings;

            if (!settings.TryGetAppSetting("PAT", out _pat))
                throw new InvalidOperationException("Could not find a valid personal access token for Azure DevOps");

            if (!settings.TryGetAppSetting("Org", out _org))
                throw new InvalidOperationException("Could not find an Organisation for Azure DevOps");

            if (!settings.TryGetAppSetting("ActiveProject", out _project))
                throw new InvalidOperationException("Could not find an Organisation for Azure DevOps");
        }

        public async Task<Project> GetAuthedProjectsAsync()
        {
            HttpStatusCode statusCode = new HttpStatusCode();

            return await Executor<Project>.TryExecute(async delegate
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = BuildAuthenticationHeader();

                    using (HttpResponseMessage response = await client.GetAsync($"https://dev.azure.com/{_org}/_apis/projects"))
                    {
                        statusCode = response.StatusCode;
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Project>(responseBody);
                    }
                }
            }, $"Could not connect to the Azure DevOps API. Status Code {(int)statusCode}");
        }

        public async Task<PullRequest> GetActivePullRequestsAsync()
        {
            HttpStatusCode statusCode = new HttpStatusCode();

            return await Executor<PullRequest>.TryExecute(async delegate
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = BuildAuthenticationHeader();

                    using (HttpResponseMessage response = await client.GetAsync($"https://dev.azure.com/{_org}/{_project}/_apis/git/pullrequests?api-version=6.0"))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<PullRequest>(responseBody);
                    }
                }
            }, $"Could not connect to the Azure DevOps API. Status Code {(int)statusCode}");
        }

        public async Task<PullRequest> GetArchivedPullRequestsAsync()
        {
            HttpStatusCode statusCode = new HttpStatusCode();

            return await Executor<PullRequest>.TryExecute(async delegate
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = BuildAuthenticationHeader();

                    using (HttpResponseMessage response = await client.GetAsync($"https://dev.azure.com/{_org}/{_project}/_apis/git/pullrequests?searchCriteria.status=completed&api-version=6.0"))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<PullRequest>(responseBody);
                    }
                }
            }, $"Could not connect to the Azure DevOps API. Status Code {(int)statusCode}");
        }

        private AuthenticationHeaderValue BuildAuthenticationHeader()
        {
            return new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(
                    System.Text.Encoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", string.Empty, _pat))
                    )
                );
        }
    }
}