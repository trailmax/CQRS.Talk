using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Talk.Refactoring1.Queries.Step5.Mediator
{
    public interface ISimpleMediator
    {
        object Process(object query);
    }
}
