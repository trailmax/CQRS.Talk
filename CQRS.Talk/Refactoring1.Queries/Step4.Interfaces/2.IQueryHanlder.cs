using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Talk.Refactoring1.Queries.Step4.Interfaces
{
    public interface IQueryHandler<TQuery, TResult>
    {
        TResult Handle(TQuery queryObject);
    }
}
