using System;
using System.Collections.Generic;
using CQRS.Talk.Dependencies;
using PetaPoco;


namespace CQRS.Talk.Refactoring1.Queries.Step2.BasicQueries
{
    public class StaffEligibleForReviewQuery
    {
        private readonly PetaPoco.Database database;


        public StaffEligibleForReviewQuery(Database database)
        {
            this.database = database;
        }


        public IEnumerable<Person> GetStaffEligibleForReview()
        {
            const string sql = @"where 
                                    isCurrentlyEmployed = 1 and 
                                    datediff(Year, DateOfJoin, GetDate()) >= 3 
                                    and isNewPensionScheme = 1";
            var people = database.Query<Person>(sql);

            return people;
        }
    }


    public class FindPersonByEmailQuery
    {
        private readonly PetaPoco.Database database;
        public FindPersonByEmailQuery(Database database)
        {
            this.database = database;
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
