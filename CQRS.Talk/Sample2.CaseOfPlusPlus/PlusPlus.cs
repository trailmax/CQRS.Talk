using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Talk.Sample2.CaseOfPlusPlus
{
    class PlusPlus
    {
        public void DoSomething()
        {
            for (int i = 0; i < 100; i++)
            {
                // look up here     ^^^^^
                Console.WriteLine("I don't know what I'm talking about: " + i++);

                #region and the shortcut is

                var k = i;
                i = i + 1;

                #endregion

                #region Or is it the other way round?

                i = i + 1;
                var t = i;

                #endregion
            }
        }
    }

    /**
    * Notation i++ is a clear violation of Command Query Separation - it reads and writes. Or writes and reads - I can never remember.
    * 
    * What is the difference between i++ and ++i?
    * 
    * What happens when you do ++i++?
    */
}

// Inspired by Eric Lippert
// http://www.informit.com/articles/article.aspx?p=2425867