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


        public int MagicMethod(float numberOfTrolls)
        {
            Logger.Info("Starting doing Some Magic, Number of trolls: {0}", numberOfTrolls);

            var result = decorated.MagicMethod(numberOfTrolls);

            Logger.Info("Finished doing Some Magic");

            return result;
        }
    }
}
