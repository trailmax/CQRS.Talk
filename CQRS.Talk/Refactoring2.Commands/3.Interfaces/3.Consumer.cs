using CQRS.Talk.Dependencies;
using CQRS.Talk.Refactoring2.Queries;
using CQRS.Talk.Refactoring2.Queries._3.Interfaces;


namespace CQRS.Talk.Refactoring2.Commands._3.Interfaces
{
    class ServiceConsumer : Controller
    {
		//OMG!!!! LOOK AT THIS AGAIN!!!
        private readonly ICommandHandler<AddDelegateToSessionCommand> addDelegateCommandHandler;
        private readonly ICommandHandler<UpdateDelegateFromSessionCommand> updateDelegateCommandHandler;


        public ServiceConsumer(ICommandHandler<AddDelegateToSessionCommand> addDelegateCommandHandler, ICommandHandler<UpdateDelegateFromSessionCommand> updateDelegateCommandHandler)
        {
            this.addDelegateCommandHandler = addDelegateCommandHandler;
            this.updateDelegateCommandHandler = updateDelegateCommandHandler;
        }


    
        [HttpPost]
        public ActionResult AddSessionDelegate(AddDelegateToSessionCommand command)
        {
            addDelegateCommandHandler.Handle(command);

            return RedirectToAction("Index", "SessionDelegate");
        }


        [HttpPost]
        public ActionResult CancelSessionDelegateFromSession(UpdateDelegateFromSessionCommand command)
        {
            updateDelegateCommandHandler.Handle(command);

            return RedirectToAction("Index", "Session");
        }
    }
}
