using System;

namespace PullRequestExtractor.Models
{
    public class PullRequestGridSource
    {
        public PullRequestGridSource()
        { }

        public string Title { get; set; }
        public string Repo { get; set; }
        public DateTime CreationDate { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public string Reviewers { get; set; }
        public string SourceBranch { get; set; }
        public string TargetBranch { get; set; }
        public int CodeReviewId { get; set; }
    }
}
