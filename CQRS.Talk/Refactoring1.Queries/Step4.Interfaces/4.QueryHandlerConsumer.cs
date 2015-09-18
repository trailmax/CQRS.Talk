using System;
using System.Collections.Generic;
using CQRS.Talk.Dependencies;


namespace CQRS.Talk.Refactoring1.Queries.Step4.Interfaces
{
    public class QueryHandlerConsumer : Controller
    {
        //WHOA!!! Hold your horses, my eyes are bleeding!!!!11!!
        private readonly IQueryHandler<StaffWithLengthOfServiceQuery, IEnumerable<Person>> eligibleForReviewHandler;
        private readonly IQueryHandler<FindPersonByEmailQuery, Person> findByEmailHandler;


        public QueryHandlerConsumer(
            IQueryHandler<StaffWithLengthOfServiceQuery, IEnumerable<Person>> eligibleForReviewHandler, 
            IQueryHandler<FindPersonByEmailQuery, Person> findByEmailHandler)
        {
            this.eligibleForReviewHandler = eligibleForReviewHandler;
            this.findByEmailHandler = findByEmailHandler;
        }


        public ActionResult EligibleForReview()
        {
            var people = eligibleForReviewHandler.Handle(
                new StaffWithLengthOfServiceQuery());

            return View(people);
        }


        public ActionResult FindByEmail(String email)
        {
            var query = new FindPersonByEmailQuery()
            {
                Email = email,
                IsCurrentlyEmployed = true
            };
            var person = findByEmailHandler.Handle(query);

            return View(person);
        }

    }
}
