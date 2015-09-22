using CQRS.Talk.Dependencies;


namespace CQRS.Talk.Refactoring2.Commands._3.Interfaces
{
    class ServiceConsumer : Controller
    {
		//OMG!!!! LOOK AT THIS AGAIN!!!
        private readonly ICommandHandler<AddDelegateToSessionCommand> addHandler;
        private readonly ICommandHandler<UpdateDelegateFromSessionCommand> updateHandler;


        public ServiceConsumer(
            ICommandHandler<AddDelegateToSessionCommand> addHandler, 
            ICommandHandler<UpdateDelegateFromSessionCommand> updateHandler)
        {
            this.addHandler = addHandler;
            this.updateHandler = updateHandler;
        }


    
        [HttpPost]
        public ActionResult AddSessionDelegate(AddDelegateToSessionCommand command)
        {
            addHandler.Handle(command);

            return RedirectToAction("Index", "SessionDelegate");
        }


        [HttpPost]
        public ActionResult CancelSessionDelegateFromSession(UpdateDelegateFromSessionCommand command)
        {
            updateHandler.Handle(command);

            return RedirectToAction("Index", "Session");
        }
    }
}
