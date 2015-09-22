using System.Linq;


namespace CQRS.Talk.Refactoring2.Commands._3.Interfaces
{
    public class AddDelegateToSessionCommand : ICommand
    {
        public int CourseSessionId { get; set; }

        public int PersonId { get; set ;}
    }

    public class AddDelegateToSessionCommandHandler : 
        ICommandHandler<AddDelegateToSessionCommand>
    {
        private readonly ISessionDelegateRepository sessionDelegateRepository;
        public AddDelegateToSessionCommandHandler(ISessionDelegateRepository sessionDelegateRepository)
        {
            this.sessionDelegateRepository = sessionDelegateRepository;
        }

        public void Handle(AddDelegateToSessionCommand command)
        {
            var sessionDelegate = new SessionDelegate(command);
            sessionDelegateRepository.Insert(sessionDelegate);
            sessionDelegateRepository.Save();
        }
    }



    public class UpdateDelegateFromSessionCommand : ICommand
    {
        public int SessionDelegateId { get; set; }
        public int CourseSessionId { get; set; }
        public int PersonId { get; set; }
    }

    public class UpdateDelegateFromSessionCommandHandler :
        ICommandHandler<UpdateDelegateFromSessionCommand>
    {
        private readonly ISessionDelegateRepository sessionDelegateRepository;

        public UpdateDelegateFromSessionCommandHandler(ISessionDelegateRepository sessionDelegateRepository)
        {
            this.sessionDelegateRepository = sessionDelegateRepository;
        }

        public void Handle(UpdateDelegateFromSessionCommand command)
        {
            var sessionDelegate = sessionDelegateRepository.Find(command.SessionDelegateId);
            sessionDelegate.Update(command);
            sessionDelegateRepository.Update(sessionDelegate);
            sessionDelegateRepository.Save();
        }
    }
}
