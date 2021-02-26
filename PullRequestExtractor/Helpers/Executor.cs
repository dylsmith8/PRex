using System;
using System.Threading.Tasks;

namespace PullRequestExtractor.Helpers
{
    internal static class Executor<T>
    {
        internal static async Task<T> TryExecute(Func<Task<T>> func)
        {
            try
            {
                return await func();
            }
            catch (Exception e)
            {
                EventLogWriter.WriteToEventLog(e);
                throw;
            }
        }
    }
}
