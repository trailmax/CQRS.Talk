using System;
using System.Collections.Generic;
using CQRS.Talk.Dependencies;


namespace CQRS.Talk.Refactoring1.Queries.Step4.Interfaces
{
    public class QueryHandlerConsumer : Controller
    {
        //WHOA!!! Hold your horses, my eyes are bleeding!!!!11!!
        private readonly IQueryHandler<StaffEligibleForReviewQuery, IEnumerable<Person>> reviewHandler;
        private readonly IQueryHandler<FindPersonByEmailQuery, Person> emailHandler;


        public QueryHandlerConsumer(
            IQueryHandler<StaffEligibleForReviewQuery, IEnumerable<Person>> reviewHandler, 
            IQueryHandler<FindPersonByEmailQuery, Person> emailHandler)
        {
            this.reviewHandler = reviewHandler;
            this.emailHandler = emailHandler;
        }


        public ActionResult EligibleForReview()
        {
            var query = new StaffEligibleForReviewQuery();
            var people = reviewHandler.Handle(query);

            return View(people);
        }


        public ActionResult FindByEmail(String email)
        {
            var query = new FindPersonByEmailQuery()
            {
                Email = email,
                IsCurrentlyEmployed = true
            };
            var person = emailHandler.Handle(query);

            return View(person);
        }

    }
}
