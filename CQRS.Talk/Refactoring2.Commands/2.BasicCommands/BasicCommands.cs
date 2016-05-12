namespace CQRS.Talk.Refactoring2.Commands._2.BasicCommands
{
    public class AddDelegateCommand
    {
        int CourseSessionId { get; set; }
        int PersonId { get; set; }
        // other data
    }

    public class AddDelegateCommandHandler
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


    public class UpdateDelegateCommand
    {
        public int SessionDelegateId { get; set; }
        // other data
    }

    public class UpdateDelegateCommandHandler
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
