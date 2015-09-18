namespace CQRS.Talk.Sample4.Decorator
{
    interface IMagicService
    {
        int DoSomeMagic(float numberOfTrolls);
    }


    class MagicService : IMagicService
    {
        public int DoSomeMagic(float numberOfTrolls)
        {
            return 4;
        }
    }


    class Consumer
    {
        private readonly IMagicService magicService;


        public Consumer(IMagicService magicService)
        {
            this.magicService = magicService;
        }


        public void SomeAction()
        {
            // ...
            var magicNumber = magicService.DoSomeMagic(7);
			//..
        }
    }
}
