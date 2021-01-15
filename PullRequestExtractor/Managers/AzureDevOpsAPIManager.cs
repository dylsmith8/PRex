﻿using Newtonsoft.Json;
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
    // TODO: make an Executor class to wrap the exception handling.. lots of repeated code here
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

            try
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

        public async Task<PullRequest> GetActivePullRequestsAsync()
        {
            HttpStatusCode statusCode = new HttpStatusCode();

            try
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

        public async Task<PullRequest> GetArchivedPullRequestsAsync()
        {
            HttpStatusCode statusCode = new HttpStatusCode();

            try
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
