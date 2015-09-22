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
    public class StaffWithLengthOfServiceQueryHandler : 
        IQueryHandler<StaffWithLengthOfServiceQuery, IEnumerable<Person>>
    {
        public IEnumerable<Person> Handle(StaffWithLengthOfServiceQuery query)
        {
            throw new NotImplementedException();
        }
    }


    public class FindPersonByEmailQuery : IQuery<Person>
    {
        public String Email { get; private set; }
        public bool? IsCurrentlyEmployed { get; set; }

        public FindPersonByEmailQuery(String email)
        {
            this.Email = email;
        }
    }
    public class FindPersonByEmailQueryHandler : IQueryHandler<FindPersonByEmailQuery, Person>
    {
        public Person Handle(FindPersonByEmailQuery query)
        {
            throw new NotImplementedException();
        }
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
            var people = mediator.Handle(new StaffWithLengthOfServiceQuery());

            return View(people);
        }


        public ActionResult FindByEmail(String email)
        {
            var query = new FindPersonByEmailQuery(email);
            var person = mediator.Handle(query);

            return View(person);
        }
    }
}
