using System;
using CQRS.Talk.Dependencies;
using CQRS.Talk.Refactoring1.Queries.Step4.Interfaces;


namespace CQRS.Talk.Refactoring1.Queries.Step5.Mediator
{
    public class MediatorConsumer : Controller
    {
        private readonly IMediator mediator;

        public MediatorConsumer(IMediator mediator)
        {
            this.mediator = mediator;
        }


        public ActionResult StaffForReview()
        {
            var people = mediator.Handle(new StaffForReviewQuery());

            return View(people);
        }


        public ActionResult PersonByEmail(String email)
        {
            var query = new PersonByEmailQuery()
            {
                Email = email,
            };
            var person = mediator.Handle(query);

            return View(person);
        }
    }
}
