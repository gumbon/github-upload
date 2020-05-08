using System;
using System.IO;
using System.Security;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace myLogger
{// This logger will derive from the Microsoft.Build.Utilities.Logger class,
    // which provides it with getters and setters for Verbosity and Parameters,
    // and a default empty Shutdown() implementation.
    public class BasicFileLogger : Logger
    {
        private int warnings = 0;
        private int errors = 0;

        public override void Initialize(IEventSource eventSource)
        {
            eventSource.WarningRaised += (s, e) => ++warnings;
            eventSource.ErrorRaised += (s, e) => ++errors;
            eventSource.BuildFinished += (s, e) =>
            {
                Console.WriteLine(errors == 0 ? "Build succeeded." : "Build failed.");
                Console.WriteLine(String.Format("{0} Warning(s)", warnings));
                Console.WriteLine(String.Format("{0} Error(s)", errors));
            };
        }
    }
}
