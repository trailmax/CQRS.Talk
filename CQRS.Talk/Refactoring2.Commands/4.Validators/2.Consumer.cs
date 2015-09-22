using System.Linq;
using CQRS.Talk.Dependencies;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;


namespace CQRS.Talk.Refactoring2.Commands._4.Validators
{
    class ServiceConsumer : Controller
    {
		//I'm so tired of typing!
        private readonly ICommandHandler<AddDelegateCommand> addHandler;
        private readonly ICommandValidator<AddDelegateCommand> addValidator;
        private readonly ICommandHandler<UpdateDelegateCommand> updateHandler;
        private readonly ICommandValidator<UpdateDelegateCommand> updateValidator;


        public ServiceConsumer(
            ICommandHandler<AddDelegateCommand> addHandler, 
            ICommandHandler<UpdateDelegateCommand> updateHandler, 
            ICommandValidator<AddDelegateCommand> addValidator, 
            ICommandValidator<UpdateDelegateCommand> updateValidator)
        {
            this.addHandler = addHandler;
            this.updateHandler = updateHandler;
            this.addValidator = addValidator;
            this.updateValidator = updateValidator;
        }


    
        [HttpPost]
        public ActionResult AddSessionDelegate(AddDelegateCommand command)
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
        public ActionResult CancelSessionDelegateFromSession(UpdateDelegateCommand command)
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
