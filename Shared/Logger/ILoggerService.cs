using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Logger
{
    public interface ILoggerService
    {
        void Log(string message, LogSeverity level);
        void Info(string message);

    }
}
