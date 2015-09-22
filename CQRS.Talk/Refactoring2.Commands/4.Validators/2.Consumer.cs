using System.Linq;
using CQRS.Talk.Dependencies;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;


namespace CQRS.Talk.Refactoring2.Commands._4.Validators
{
    class ServiceConsumer : Controller
    {
		//I'm so tired of typing!
        private readonly ICommandHandler<AddDelegateToSessionCommand> addHandler;
        private readonly ICommandValidator<AddDelegateToSessionCommand> addValidator;
        private readonly ICommandHandler<UpdateDelegateFromSessionCommand> updateHandler;
        private readonly ICommandValidator<UpdateDelegateFromSessionCommand> updateValidator;


        public ServiceConsumer(
            ICommandHandler<AddDelegateToSessionCommand> addHandler, 
            ICommandHandler<UpdateDelegateFromSessionCommand> updateHandler, 
            ICommandValidator<AddDelegateToSessionCommand> addValidator, 
            ICommandValidator<UpdateDelegateFromSessionCommand> updateValidator)
        {
            this.addHandler = addHandler;
            this.updateHandler = updateHandler;
            this.addValidator = addValidator;
            this.updateValidator = updateValidator;
        }


    
        [HttpPost]
        public ActionResult AddSessionDelegate(AddDelegateToSessionCommand command)
        {
            var errors = addValidator.GetErrorList(command);

            if (errors.Any())
            {
                //diplay errors to the user
                return View(errors);
            }

            addHandler.Handle(command);
            return RedirectToAction("Index", "SessionDelegate");
        }


        [HttpPost]
        public ActionResult CancelSessionDelegateFromSession(UpdateDelegateFromSessionCommand command)
        {
            var errors = updateValidator.GetErrorList(command);

            if (errors.Any())
            {
                //diplay errors to the user
                return View(errors);
            }

            updateHandler.Handle(command);

            return RedirectToAction("Index", "Session");
        }
    }
}
