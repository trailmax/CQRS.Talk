using System;
using System.Diagnostics;

namespace CQRS.Talk.Dependencies
{
    static class Logger
    {
        public static void Info(String message, params object[] stringParams)
        {
            var formattedMessage = String.Format(message, stringParams);

            Trace.WriteLine(formattedMessage);
        }
    }

}
