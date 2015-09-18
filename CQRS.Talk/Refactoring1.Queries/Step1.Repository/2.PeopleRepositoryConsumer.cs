using System;
using CQRS.Talk.Dependencies;
// ReSharper disable RedundantArgumentNameForLiteralExpression


namespace CQRS.Talk.Refactoring1.Queries.Step1.Repository
{
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository peopleRepository;


        public PeopleController(IPeopleRepository peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }


        public ActionResult EligibleForReview()
        {
            var people = peopleRepository.GetStaffWithLengthOfServiceMoreThan();

            return View(people);
        }


        public ActionResult FindByEmail(String email)
        {
            var person = peopleRepository.FindPersonByEmail(email, isCurrentlyEmployed: true);

            return View(person);
        }
    }
}
