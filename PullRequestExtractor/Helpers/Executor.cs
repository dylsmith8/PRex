﻿using System;
using System.Threading.Tasks;

namespace PullRequestExtractor.Helpers
{
    public static class Executor<T>
    {
        public static async Task<T> TryExecute(Func<Task<T>> func, string error)
        {
            try
            {
                return await func();
            }
            catch (Exception e)
            {
                EventLogWriter.WriteToEventLog(e, error);
                throw new Exception(error, e);
            }
        }
    }
}