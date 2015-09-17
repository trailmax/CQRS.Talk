using System;
using System.Collections.Generic;
using CQRS.Talk.Dependencies;
using PetaPoco;


namespace CQRS.Talk.Refactoring1.Queries.Step4.Interfaces
{
    public class StaffWithLengthOfServiceQuery
    {
        public int NumberOfYears { get; set; }
        public bool IsNewPensionScheme { get; set; }
    }

    public class StaffWithLengthOfServiceQueryHandler : IQueryHandler<StaffWithLengthOfServiceQuery, IEnumerable<Person>>
    {
        private readonly PetaPoco.Database database;
        public StaffWithLengthOfServiceQueryHandler(Database database)
        {
            this.database = database;
        }


        public IEnumerable<Person> Handle(StaffWithLengthOfServiceQuery query)
        {
            const string sql = "where isCurrentlyEmployed = 1 and datediff(Year, DateOfJoin, GetDate()) >= @0 And isNewPensionScheme = @1";
            var people = database.Query<Person>(sql, query.NumberOfYears, query.IsNewPensionScheme);

            return people;
        }
    }


    public class FindPersonByEmailQuery
    {
        public String Email { get; set; }
        public bool? IsCurrentlyEmployed { get; set; }
    }

    public class FindPersonByEmailQueryHandler : IQueryHandler<FindPersonByEmailQuery, Person>
    {
        private readonly PetaPoco.Database database;
        public FindPersonByEmailQueryHandler(Database database)
        {
            this.database = database;
        }


        public Person Handle(FindPersonByEmailQuery query)
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
