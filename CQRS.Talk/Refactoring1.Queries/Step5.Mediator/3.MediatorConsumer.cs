using System;
using System.Collections.Generic;
using CQRS.Talk.Dependencies;


namespace CQRS.Talk.Refactoring1.Queries.Step5.Mediator
{
    #region Queries

    public class StaffForReviewQuery : IQuery<IEnumerable<Person>>
    {
        public int NumberOfYears { get; set; }
        public bool IsNewPensionScheme { get; set; }
    }

    public class StaffForReviewQueryHandler : 
        IQueryHandler<StaffForReviewQuery, IEnumerable<Person>>
    {
        public IEnumerable<Person> Handle(StaffForReviewQuery query)
        {
            throw new NotImplementedException();
        }
    }


    public class PersonByEmailQuery : IQuery<Person>
    {
        public String Email { get; private set; }
        public bool? IsCurrentlyEmployed { get; set; }

        public PersonByEmailQuery(String email)
        {
            this.Email = email;
        }
    }
    public class PersonByEmailQueryHandler : IQueryHandler<PersonByEmailQuery, Person>
    {
        public Person Handle(PersonByEmailQuery query)
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


        public ActionResult StaffForReview()
        {
            var people = mediator.Handle(new StaffForReviewQuery());

            return View(people);
        }


        public ActionResult PersonByEmail(String email)
        {
            var query = new PersonByEmailQuery(email);
            var person = mediator.Handle(query);

            return View(person);
        }
    }
}
