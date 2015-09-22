 
namespace CQRS.Talk.Refactoring2.Commands._3.Interfaces
{
    public class AddDelegateCommand : ICommand
    {
        public int CourseSessionId { get; set; }

        public int PersonId { get; set ;}
    }

    public class AddDelegateCommandHandler : 
        ICommandHandler<AddDelegateCommand>
    {
        private readonly IDelegateRepository delegateRepository;
        public AddDelegateCommandHandler(IDelegateRepository delegateRepository)
        {
            this.delegateRepository = delegateRepository;
        }

        public void Handle(AddDelegateCommand command)
        {
            var sessionDelegate = new SessionDelegate(command);
            delegateRepository.Insert(sessionDelegate);
            delegateRepository.Save();
        }
    }



    public class UpdateDelegateCommand : ICommand
    {
        public int SessionDelegateId { get; set; }
        public int CourseSessionId { get; set; }
        public int PersonId { get; set; }
    }

    public class UpdateDelegateCommandHandler :
        ICommandHandler<UpdateDelegateCommand>
    {
        private readonly IDelegateRepository delegateRepository;

        public UpdateDelegateCommandHandler(IDelegateRepository delegateRepository)
        {
            this.delegateRepository = delegateRepository;
        }

        public void Handle(UpdateDelegateCommand command)
        {
            var sessionDelegate = delegateRepository.Find(command.SessionDelegateId);
            sessionDelegate.Update(command);
            delegateRepository.Update(sessionDelegate);
            delegateRepository.Save();
        }
    }
}
