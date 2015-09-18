using System.Linq;


namespace CQRS.Talk.Refactoring2.Queries._2.BasicCommands
{
    public class AddDelegateToSessionCommand
    {
        private readonly ISessionDelegateRepository sessionDelegateRepository;
        private readonly IWorkMovementService workMovementService;
        private readonly ICourseSessionRepository sessionRepository;
        private readonly IPersonRepository personRepository;
        private readonly IMovementTypeRepository movementTypeRepository;

        public AddDelegateToSessionCommand(ISessionDelegateRepository sessionDelegateRepository, IWorkMovementService workMovementService, ICourseSessionRepository sessionRepository, IPersonRepository personRepository, IMovementTypeRepository movementTypeRepository)
        {
            this.sessionDelegateRepository = sessionDelegateRepository;
            this.workMovementService = workMovementService;
            this.sessionRepository = sessionRepository;
            this.personRepository = personRepository;
            this.movementTypeRepository = movementTypeRepository;
        }


        public void AddDelegateToSession(ISessionDelegateCreate delegateData)
        {
            var sessionDelegate = new SessionDelegate(delegateData);
            sessionDelegateRepository.Insert(sessionDelegate);
            sessionDelegateRepository.Save();

            var createWorkMovementCommand = CreateWorkMovementCommand(delegateData, sessionDelegate);

            workMovementService.CreateWorkMovement(createWorkMovementCommand);
        }


        private CreateWorkMovementCommand CreateWorkMovementCommand(ISessionDelegateCreate delegateData, SessionDelegate sessionDelegate)
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


    public class UpdateDelegateFromSessionCommand
    {
        private readonly ISessionDelegateRepository sessionDelegateRepository;
        private readonly IWorkMovementService workMovementService;


        public UpdateDelegateFromSessionCommand(ISessionDelegateRepository sessionDelegateRepository, IWorkMovementService workMovementService)
        {
            this.sessionDelegateRepository = sessionDelegateRepository;
            this.workMovementService = workMovementService;
        }


        public void UpdateDelegateFromSession(ISessionDelegateUpdate delegateData)
        {
            var sessionDelegate = sessionDelegateRepository.Find(delegateData.SessionDelegateId);
            sessionDelegate.Update(delegateData);
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
