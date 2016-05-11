using System;
using System.Collections.Generic;

namespace CQRS.Talk.Sample1.SeparateReadsFromWrites
{
    public class DictinarySample
    {
        Dictionary<String, String> dictionary;

        public DictinarySample()
        {
            dictionary = new Dictionary<string, string>();
        }


        /// <summary>
        /// CQS is not always applicable. Operations with Dictionary have a prime example of TryGetValue:
        /// returns boolean for success and populates out-variable with value.
        /// </summary>
        public void CQS_Violation()
        {
            String result;

            if (dictionary.TryGetValue("someKey", out result))
            {
                // key found, `result` is populated
            }
        }

		/// <summary>
        /// This is CQS compliant version that does the same thing as above.
        /// </summary>
        public void CQS_Compliant()
        {
            if (dictionary.ContainsKey("SomeKey"))
            {
                var result = dictionary["someKey"];
            }
        }

		/**
		 * Reason for TryGetValue - performance. Second version of the code does the lookup twice.
		 * So CQS is not always applicable, sometimes performance is more important than readability.
		 */
    }
}
