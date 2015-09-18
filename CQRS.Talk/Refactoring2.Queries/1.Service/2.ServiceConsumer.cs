using CQRS.Talk.Dependencies;


namespace CQRS.Talk.Refactoring2.Queries._1.Service
{
    class ServiceConsumer : Controller
    {
        private readonly ITrainingService trainingService;


        public ServiceConsumer(ITrainingService trainingService)
        {
            this.trainingService = trainingService;
        }


        [HttpPost]
        public ActionResult AddSessionDelegate(SessionDelegateCreate sessionDelegate)
        {
            trainingService.AddDelegateToSession(sessionDelegate);

            return RedirectToAction("Index", "SessionDelegate");
        }


        [HttpPost]
        public ActionResult CancelSessionDelegateFromSession(int delegateId)
        {
            trainingService.CancelDelegateFromSession(delegateId);

            return RedirectToAction("Index", "Session");
        }
    }
}
