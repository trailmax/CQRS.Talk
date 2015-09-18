using System;
using System.Collections.Generic;
using System.Linq;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;
using CQRS.Talk.Refactoring2.Queries;
using CQRS.Talk.Refactoring2.Queries._3.Interfaces;
using PetaPoco;


namespace CQRS.Talk.Refactoring2.Commands._4.Validators
{
    public interface ICommandValidator<TCommand> where TCommand : ICommand
    {
	    List<String> GetErrorList(TCommand command);
    }


	public class AddDelegateToSessionCommandValidator : ICommandValidator<AddDelegateToSessionCommand>
	{
	    private readonly Database database;


	    public AddDelegateToSessionCommandValidator(Database database)
	    {
	        this.database = database;
	    }


	    public List<string> GetErrorList(AddDelegateToSessionCommand command)
	    {
			var errors = new List<String>();

	        var sql = "select * from sessionDelegate where courseSessionId = @0 and personId = @1";
	        var existingDelegates = database.Query<SessionDelegate>(sql, command.CourseSessionId, command.PersonId).ToList();

	        if (existingDelegates.Any())
	        {
	            errors.Add("Unable to book this person on this session as the booking already exists");
	        }

	        return errors;
	    }
	}
}
