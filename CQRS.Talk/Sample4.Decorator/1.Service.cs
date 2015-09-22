namespace CQRS.Talk.Sample4.Decorator
{
    interface IMagicService
    {
        int MagicMethod(float numberOfTrolls);
    }


    class MagicService : IMagicService
    {
        public int MagicMethod(float numberOfTrolls)
        {
            return 4; // random according to XKCD
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
            var magicNumber = magicService.MagicMethod(7);
			//..
        }
    }
}
