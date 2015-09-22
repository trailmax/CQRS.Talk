using CQRS.Talk.Dependencies;


namespace CQRS.Talk.Refactoring2.Commands._3.Interfaces
{
    class ServiceConsumer : Controller
    {
		//OMG!!!! LOOK AT THIS AGAIN!!!
        private readonly ICommandHandler<AddDelegateCommand> addHandler;
        private readonly ICommandHandler<UpdateDelegateCommand> updateHandler;


        public ServiceConsumer(
            ICommandHandler<AddDelegateCommand> addHandler, 
            ICommandHandler<UpdateDelegateCommand> updateHandler)
        {
            this.addHandler = addHandler;
            this.updateHandler = updateHandler;
        }


    
        [HttpPost]
        public ActionResult AddSessionDelegate(AddDelegateCommand command)
        {
            addHandler.Handle(command);

            return RedirectToAction("Index", "SessionDelegate");
        }


        [HttpPost]
        public ActionResult CancelSessionDelegateFromSession(UpdateDelegateCommand command)
        {
            updateHandler.Handle(command);

            return RedirectToAction("Index", "Session");
        }
    }
}
