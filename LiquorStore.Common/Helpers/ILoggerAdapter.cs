using System;
using System.Collections.Generic;
using System.Text;

namespace LiquorStore.Common.Helpers
{
    public interface ILoggerAdapter<T>
    {
        void LogInformation(string message);
        void LogError(Exception ex, string message, params object[] args);
    }
}
