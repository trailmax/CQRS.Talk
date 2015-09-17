using System;
using System.Collections.Generic;
using CQRS.Talk.Dependencies;


namespace CQRS.Talk.Refactoring1.Queries.Step5.Mediator
{
    #region Queries

    public class StaffWithLengthOfServiceQuery : IQuery<IEnumerable<Person>>
    {
        public int NumberOfYears { get; set; }
        public bool IsNewPensionScheme { get; set; }
    }

    public class FindPersonByEmailQuery : IQuery<Person>
    {
        public String Email { get; set; }
        public bool? IsCurrentlyEmployed { get; set; }
    }

    #endregion


    public class MediatorConsumer : Controller
    {
        private readonly IMediator mediator;

        public MediatorConsumer(IMediator mediator)
        {
            this.mediator = mediator;
        }


        public ActionResult EligibleForReview()
        {
            var people = mediator.Request(new StaffWithLengthOfServiceQuery());

            return View(people);
        }


        public ActionResult FindByEmail(String email)
        {
            var query = new FindPersonByEmailQuery() { Email = email, IsCurrentlyEmployed = true };
            Person person =
                mediator.Request(query);

            return View(person);
        }
    }
}
