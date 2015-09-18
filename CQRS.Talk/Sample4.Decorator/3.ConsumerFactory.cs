using NUnit.Framework;

namespace CQRS.Talk.Sample4.Decorator
{
    class ConsumerFactory
    {
        public static Consumer GetConsumerInstance()
        {
            var magicService = new MagicService();
            var loggingDecorator = new LoggingDecorator(magicService);

            var consumer = new Consumer(loggingDecorator);

            return consumer;
        }
    }


    #region Debug

    public class TryDebugging
    {
        [Test]
        public void StepThrough()
        {
            var consumer = ConsumerFactory.GetConsumerInstance();

            consumer.SomeAction();
        }
    }

    #endregion
}
