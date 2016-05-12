using System;
using System.Collections.Generic;
using CQRS.Talk.Dependencies;
using PetaPoco;


namespace CQRS.Talk.Refactoring1.Queries.Step4.Interfaces
{
    public class StaffForReviewQuery : IQuery<IEnumerable<Person>>
    {
    }

    public class StaffForReviewQueryHandler : 
        IQueryHandler<StaffForReviewQuery, IEnumerable<Person>>
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


    public class PersonByEmailQuery : IQuery<Person>
    {
        public String Email { get; set; }
        public bool? IsCurrentlyEmployed { get; set; }
    }

    public class PersonByEmailQueryHandler : 
        IQueryHandler<PersonByEmailQuery, Person>
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
