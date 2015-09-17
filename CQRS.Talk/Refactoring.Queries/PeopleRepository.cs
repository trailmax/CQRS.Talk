using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using CQRS.Talk.Dependencies;


namespace CQRS.Talk.Refactoring.Queries
{
    public class PeopleRepository
    {
        private readonly PetaPoco.Database database;
        private readonly IPrincipal currentPrincipal;

        public PeopleRepository(PetaPoco.Database database, IPrincipal currentPrincipal)
        {
            this.database = database;
            this.currentPrincipal = currentPrincipal;
        }


        public Person Find(Guid personId)
        {
            var person = database.SingleOrDefault<Person>("where people_id = @0", personId);

            return person;
        }


        public void Insert(Person newPerson)
        {
            database.Insert(newPerson);
        }


        public void Update(Person person)
        {
            database.Update(person);
        }


        public IEnumerable<Person> GetAllCurrentStaff()
        {
            var people = database.Query<Person>("where IsCurrentlyEmployed = 1").ToList();

            return people;
        }


        public IEnumerable<Person> GetStaffWithLengthOfServiceMoreThan(int numberOfYears = 3, bool isNewPensionScheme = true)
        {
            const string sql = "where isCurrentlyEmployed = 1 and datediff(Year, DateOfJoin, GetDate()) >= @0 And isNewPensionScheme = @1";
            var people = database.Query<Person>(sql, numberOfYears, isNewPensionScheme);

            return people;
        }
    }
}
