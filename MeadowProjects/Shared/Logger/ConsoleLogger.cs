using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Logger
{
    public class ConsoleLogService : ILoggerService
    {
        public void Log(string message, LogSeverity level)
        {
            Console.WriteLine($"Severity { GetSeverity(level) }:  { message }");
        }

        public void Info(string message)
        {
            Console.WriteLine($"Informational: { message }");
        }

        private string GetSeverity(LogSeverity level)
        {
            switch (level)
            {
                case LogSeverity.Informational:
                    return "Informational";

                case LogSeverity.Warning:
                    return "Warning";

                case LogSeverity.Error:
                    return "Error";

                case LogSeverity.Fatal:
                    return "Fatal";

                default:
                    return "Unknown";
            }
        }
    }
}
