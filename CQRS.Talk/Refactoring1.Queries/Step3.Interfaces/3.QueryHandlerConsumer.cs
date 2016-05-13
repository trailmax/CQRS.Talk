using System;
using System.Collections.Generic;
using CQRS.Talk.Dependencies;


namespace CQRS.Talk.Refactoring1.Queries.Step3.Interfaces
{
    public class QueryHandlerConsumer : Controller
    {
        //WHOA!!! My eyes are bleeding!!!!11!!
        // Look at that!! is that XML?????
        private readonly IQueryHandler<StaffForReviewQuery, IEnumerable<Person>> reviewHandler;
        private readonly IQueryHandler<PersonByEmailQuery, Person> emailHandler;


        public QueryHandlerConsumer(
            IQueryHandler<StaffForReviewQuery, IEnumerable<Person>> reviewHandler, 
            IQueryHandler<PersonByEmailQuery, Person> emailHandler)
        {
            this.reviewHandler = reviewHandler;
            this.emailHandler = emailHandler;
        }


        public ActionResult EligibleForReview()
        {
            var query = new StaffForReviewQuery();
            var people = reviewHandler.Handle(query);

            return View(people);
        }


        public ActionResult FindByEmail(String email)
        {
            var query = new PersonByEmailQuery()
            {
                Email = email,
                IsCurrentlyEmployed = true
            };
            var person = emailHandler.Handle(query);

            return View(person);
        }

    }
}
