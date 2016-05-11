using System;
using System.Collections.Generic;
using CQRS.Talk.Dependencies;
using PetaPoco;


namespace CQRS.Talk.Refactoring1.Queries.Step1.Repository
{
    public interface IPeopleRepository
    {
        Person Find(Guid personId);
        void Insert(Person newPerson);
        void Update(Person person);

        IEnumerable<Person> GetStaffEligibleForReview();

        Person FindPersonByEmail(String email, bool? isCurrentlyEmployed = null);
    }


    public class PeopleRepository : IPeopleRepository
    {
        private readonly PetaPoco.Database database;

        public PeopleRepository(PetaPoco.Database database)
        {
            this.database = database;
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


        public IEnumerable<Person> GetStaffEligibleForReview()
        {
            const string sql = @"where 
                                    isCurrentlyEmployed = 1 
                                    and datediff(Year, DateOfJoin, GetDate()) >= 3 
                                    and isNewPensionScheme = 1";
            var people = database.Query<Person>(sql);

            return people;
        }


        public Person FindPersonByEmail(String email, bool? isCurrentlyEmployed = null)
        {
            var sql = Sql.Builder.Append("select top 1 * from people")
                         .Append("where email = @0", email);

            if (isCurrentlyEmployed.HasValue)
            {
                sql.Append("and isCurrentlyEmployed = @0", isCurrentlyEmployed);
            }


            var person = database.SingleOrDefault<Person>(sql);

            return person;
        }
    }
}
