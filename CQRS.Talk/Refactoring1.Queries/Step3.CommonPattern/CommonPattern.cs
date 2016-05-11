using System;
using System.Collections.Generic;
using CQRS.Talk.Dependencies;
using PetaPoco;


namespace CQRS.Talk.Refactoring1.Queries.Step3.CommonPattern
{
    public class StaffForReviewQuery { }

    public class StaffForReviewQueryHandler
    {
        private readonly Database database;
        public StaffForReviewQueryHandler(Database database)
        {
            this.database = database;
        }


        public IEnumerable<Person> Handle(StaffForReviewQuery query)
        {
            const string sql = @"where 
                                    isCurrentlyEmployed = 1 
                                    and datediff(Year, DateOfJoin, GetDate()) >= 3
                                    and isNewPensionScheme = 1";

            var people = database.Query<Person>(sql);

            return people;
        }
    }


    public class PersonByEmailQuery
    {
        public String Email { get; set; }
        public bool? IsCurrentlyEmployed { get; set; }
    }

    public class PersonByEmailQueryHandler
    {
        private readonly Database database;
        public PersonByEmailQueryHandler(Database database)
        {
            this.database = database;
        }


        public Person Handle(PersonByEmailQuery query)
        {
            var sql = Sql.Builder.Append("select top 1 * from people")
                         .Append("where email = @0", query.Email);

            if (query.IsCurrentlyEmployed.HasValue)
            {
                sql.Append("and isCurrentlyEmployed = @0", query.IsCurrentlyEmployed);
            }


            var person = database.SingleOrDefault<Person>(sql);

            return person;
        }
    }
}
