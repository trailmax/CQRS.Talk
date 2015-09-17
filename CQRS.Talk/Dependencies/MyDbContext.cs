using System.Collections.Generic;


namespace CQRS.Talk.Dependencies
{
    public class MyDbContext
    {
        // this is a fake dependency
        public MyDbContext()
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }
    }
}
