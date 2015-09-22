using System;
using System.Collections.Generic;
using System.Linq;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;
using PetaPoco;


namespace CQRS.Talk.Refactoring2.Commands._4.Validators
{
	public class AddDelegateCommandValidator : 
        ICommandValidator<AddDelegateCommand>
	{
	    private readonly Database database;


	    public AddDelegateCommandValidator(Database database)
	    {
	        this.database = database;
	    }


	    public List<string> GetErrorList(AddDelegateCommand command)
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
