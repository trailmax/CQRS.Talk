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
        private readonly IWorkMovementService workMovementService;
        private readonly ICourseSessionRepository sessionRepository;
        private readonly IPersonRepository personRepository;
        private readonly IMovementTypeRepository movementTypeRepository;

        public AddDelegateToSessionCommandHandler(ISessionDelegateRepository sessionDelegateRepository, IWorkMovementService workMovementService, ICourseSessionRepository sessionRepository, IPersonRepository personRepository, IMovementTypeRepository movementTypeRepository)
        {
            this.sessionDelegateRepository = sessionDelegateRepository;
            this.workMovementService = workMovementService;
            this.sessionRepository = sessionRepository;
            this.personRepository = personRepository;
            this.movementTypeRepository = movementTypeRepository;
        }

        public void Handle(AddDelegateToSessionCommand command)
        {
            var sessionDelegate = new SessionDelegate(command);
            sessionDelegateRepository.Insert(sessionDelegate);
            sessionDelegateRepository.Save();

            var createWorkMovementCommand = CreateWorkMovementCommand(command, sessionDelegate);

            workMovementService.CreateWorkMovement(createWorkMovementCommand);
        }


        private CreateWorkMovementCommand CreateWorkMovementCommand(AddDelegateToSessionCommand delegateData, SessionDelegate sessionDelegate)
        {
            var session = sessionRepository.All.FirstOrDefault(s => s.CourseSessionId == delegateData.CourseSessionId);
            var person = personRepository.Find(delegateData.PersonId);
            var movementType = movementTypeRepository.All.FirstOrDefault(t => t.Name == "Training");

            var createWorkMovementCommand = new CreateWorkMovementCommand()
            {
                // do some mapping
            };
            return createWorkMovementCommand;
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
        private readonly IWorkMovementService workMovementService;

        public UpdateDelegateFromSessionCommandHandler(ISessionDelegateRepository sessionDelegateRepository, IWorkMovementService workMovementService)
        {
            this.sessionDelegateRepository = sessionDelegateRepository;
            this.workMovementService = workMovementService;
        }

        public void Handle(UpdateDelegateFromSessionCommand command)
        {
            var sessionDelegate = sessionDelegateRepository.Find(command.SessionDelegateId);
            sessionDelegate.Update(command);
            sessionDelegateRepository.Update(sessionDelegate);
            sessionDelegateRepository.Save();

            var createWorkMovementCommand = new CreateWorkMovementCommand()
            {
                // do some mapping
            };
            workMovementService.CreateWorkMovement(createWorkMovementCommand);
        }
    }
}
