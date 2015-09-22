using CQRS.Talk.Dependencies;


namespace CQRS.Talk.Refactoring2.Commands._1.Service
{
    class ServiceConsumer : Controller
    {
        private readonly ITrainingService trainingService;


        public ServiceConsumer(ITrainingService trainingService)
        {
            this.trainingService = trainingService;
        }


        [HttpPost]
        public ActionResult AddDelegate(SessionDelegateCreate sessionDelegate)
        {
            trainingService.AddDelegate(sessionDelegate);

            return RedirectToAction("Index", "SessionDelegate");
        }


        [HttpPost]
        public ActionResult CancelDelegate(int delegateId)
        {
            trainingService.CancelDelegate(delegateId);

            return RedirectToAction("Index", "Session");
        }
    }
}
