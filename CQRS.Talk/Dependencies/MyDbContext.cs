using System.Collections.Generic;


namespace CQRS.Talk.Dependencies
{
    // Fake DbContext dependency
    public class MyDbContext
    {
        public MyDbContext()
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }
    }
}
