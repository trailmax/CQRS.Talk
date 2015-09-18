using System;
using System.Diagnostics;


namespace CQRS.Talk.Sample4.Decorator
{
    class LoggingDecorator : IMagicService
    {
        private readonly IMagicService decorated;


        public LoggingDecorator(IMagicService decorated)
        {
            this.decorated = decorated;
        }


        public int DoSomeMagic(float numberOfTrolls)
        {
			Logger.Info("Starting doing Some Magic, Number of trolls: " + numberOfTrolls);

            var result = decorated.DoSomeMagic(numberOfTrolls);

            Logger.Info("Finished doing Some Magic");

            return result;
        }
    }


#region Logger

    static class Logger
    {
        public static void Info(String message)
        {
            Trace.WriteLine(message);
        }
    }

#endregion
}
