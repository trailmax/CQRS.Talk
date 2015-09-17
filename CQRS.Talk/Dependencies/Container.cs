using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Talk.Dependencies
{
    // Fake DI container
    public class Container
    {
        public object GetInstance(Type handlerType)
        {
            throw new NotImplementedException();
        }
    }
}
