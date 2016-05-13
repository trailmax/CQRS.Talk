using System;
using System.Collections.Generic;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;


namespace CQRS.Talk.Refactoring2.Commands._4.Validators
{
    public interface ICommandValidator<TCommand> where TCommand : ICommand
    {
        List<String> GetErrorList(TCommand command);
    }
}
