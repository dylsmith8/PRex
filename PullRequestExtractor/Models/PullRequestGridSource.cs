using System;
using System.Collections.Generic;

namespace PullRequestExtractor.Models
{
    public class PullRequestGridSource
    {
        public PullRequestGridSource()
        { }

        public string Title { get; set; }
        public string Repo { get; set; }
        public string CreationDate { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public string Reviewers { get; set; }
        public string SourceBranch { get; set; }
        public string TargetBranch { get; set; }
        public string CodeReviewId { get; set; }
    }

    public class PullRequestComparer : IEqualityComparer<PullRequestGridSource>
    {
        public bool Equals(PullRequestGridSource x, PullRequestGridSource y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else if (x.CodeReviewId.Equals(y.CodeReviewId))
                return true;
            else
                return false;
        }

        public int GetHashCode(PullRequestGridSource obj)
        {
            return obj.CodeReviewId.GetHashCode();
        }
    }
}
