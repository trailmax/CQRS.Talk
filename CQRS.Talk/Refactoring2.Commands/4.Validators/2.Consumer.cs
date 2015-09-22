using System.Linq;
using CQRS.Talk.Dependencies;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;


namespace CQRS.Talk.Refactoring2.Commands._4.Validators
{
    class ServiceConsumer : Controller
    {
		//I'm so tired of typing!
        private readonly ICommandHandler<AddDelegateToSessionCommand> 
            addDelegateCommandHandler;
        private readonly ICommandValidator<AddDelegateToSessionCommand> 
            addDelegateCommandValidator;

        private readonly ICommandHandler<UpdateDelegateFromSessionCommand> 
            updateDelegateCommandHandler;
        private readonly ICommandValidator<UpdateDelegateFromSessionCommand> 
            updateDelegateCommandValidator;


        public ServiceConsumer(ICommandHandler<AddDelegateToSessionCommand> addDelegateCommandHandler, ICommandHandler<UpdateDelegateFromSessionCommand> updateDelegateCommandHandler, ICommandValidator<AddDelegateToSessionCommand> addDelegateCommandValidator, ICommandValidator<UpdateDelegateFromSessionCommand> updateDelegateCommandValidator)
        {
            this.addDelegateCommandHandler = addDelegateCommandHandler;
            this.updateDelegateCommandHandler = updateDelegateCommandHandler;
            this.addDelegateCommandValidator = addDelegateCommandValidator;
            this.updateDelegateCommandValidator = updateDelegateCommandValidator;
        }


    
        [HttpPost]
        public ActionResult AddSessionDelegate(AddDelegateToSessionCommand command)
        {
            var errors = addDelegateCommandValidator.GetErrorList(command);

            if (errors.Any())
            {
                //diplay errors to the user
                return View(errors);
            }

            addDelegateCommandHandler.Handle(command);
            return RedirectToAction("Index", "SessionDelegate");
        }


        [HttpPost]
        public ActionResult CancelSessionDelegateFromSession(UpdateDelegateFromSessionCommand command)
        {
            var errors = updateDelegateCommandValidator.GetErrorList(command);

            if (errors.Any())
            {
                //diplay errors to the user
                return View(errors);
            }

            updateDelegateCommandHandler.Handle(command);

            return RedirectToAction("Index", "Session");
        }
    }
}
