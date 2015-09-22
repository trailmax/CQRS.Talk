using System.Linq;
using CQRS.Talk.Dependencies;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;


namespace CQRS.Talk.Refactoring2.Commands._5.Mediator
{
    class ServiceConsumer : Controller
    {
        private readonly IMediator mediator;

        public ServiceConsumer(IMediator mediator)
        {
            this.mediator = mediator;
        }


    
        [HttpPost]
        public ActionResult AddSessionDelegate(AddDelegateCommand command)
        {
            var errors = mediator.ProcessCommand(command);

            if (errors.Any())
            {
                //diplay errors to the user
                return View(errors);
            }

            return RedirectToAction("Index", "SessionDelegate");
        }


        [HttpPost]
        public ActionResult CancelSessionDelegateFromSession(UpdateDelegateCommand command)
        {
            var errors = mediator.ProcessCommand(command);

            if (errors.Any())
            {
                //diplay errors to the user
                return View(errors);
            }

            return RedirectToAction("Index", "Session");
        }
    }
}
