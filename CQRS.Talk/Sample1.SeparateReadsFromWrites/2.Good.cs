using System;


namespace CQRS.Talk.Sample1.SeparateReadsFromWrites
{
    /// <summary>
    /// The solution to the previous problem is to separate command from a query.
    /// Query if the attribute exists;
    /// then update the value - as 2 different operations
    /// </summary>
    public class Separate
    {
        // Query
        public bool AttributeExists(String attributeName)
        {
            // need implementation
            return true;
        }

        // Command
        public void SetAttribute(String attributeName, String value)
        {
            // need implementation
        }



        public void Consumer()
        {
            // Now here there is no ambiguity when reading
            if (AttributeExists("href"))
            {
                SetAttribute("href", "https://localhost:4300");
            }
        }
    }
}

// Code sample is from book Clean Code by Uncle Bob Martin. Page 45-46