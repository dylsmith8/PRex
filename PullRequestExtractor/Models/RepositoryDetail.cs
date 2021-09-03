using System;

namespace PullRequestExtractor.Models
{
    public class RepositoryDetail
    {
        public string Name { get; set; }
        public string Project { get; set; }
        public Guid RepositoryID { get; set; }
        public Guid ProjectID { get; set; }
    }
}