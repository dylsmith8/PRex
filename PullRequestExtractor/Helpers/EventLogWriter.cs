using System;
using System.Diagnostics;

namespace PullRequestExtractor.Helpers
{
    internal static class EventLogWriter
    {
        internal static void WriteToEventLog(Exception exception, string errorMessage)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            using (EventLog eventLog = new EventLog("Application"))
            {
                if (!EventLog.SourceExists("PRex", "."))
                {
                    EventSourceCreationData data = new EventSourceCreationData("PRex", "Application")
                    {
                        MachineName = "."
                    };

                    EventLog.CreateEventSource(data);
                }

                eventLog.Source = "PRex";
                eventLog.WriteEntry($"{errorMessage}\n {exception}", EventLogEntryType.Error);
            }
        }
    }
}
