using System;


public class Confusing
{
    /// <summary>
    /// Sets the attribute and returns true for successfull, 
    /// false if key was not found
    /// </summary>
    public static bool Set(String attributeName, String value)
    {
        //some implementation
        return true; // operation successful
    }



    public void Consumer()
    {
        // Now try reading this code:

        if (Set("href", "https://localhost:4300/")) //<-- what does this do?
        {
            // do something
        }
        /**
        * Is `set` here a verb or an adjective?
        * Does this check if href value was set to localhost before?
        */
    }
}
