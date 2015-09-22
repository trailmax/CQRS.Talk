namespace CQRS.Talk.Refactoring2.Commands._2.BasicCommands
{
    public class AddDelegateToSessionCommand
    {
        private readonly ISessionDelegateRepository sessionDelegateRepository;


        public AddDelegateToSessionCommand(ISessionDelegateRepository sessionDelegateRepository)
        {
            this.sessionDelegateRepository = sessionDelegateRepository;
        }


        public void AddDelegateToSession(ISessionDelegateCreate delegateData)
        {
            var sessionDelegate = new SessionDelegate(delegateData);
            sessionDelegateRepository.Insert(sessionDelegate);
            sessionDelegateRepository.Save();
        }
    }


    public class UpdateDelegateFromSessionCommand
    {
        private readonly ISessionDelegateRepository sessionDelegateRepository;


        public UpdateDelegateFromSessionCommand(ISessionDelegateRepository sessionDelegateRepository)
        {
            this.sessionDelegateRepository = sessionDelegateRepository;
        }


        public void UpdateDelegateFromSession(ISessionDelegateUpdate delegateData)
        {
            var sessionDelegate = sessionDelegateRepository.Find(delegateData.SessionDelegateId);
            sessionDelegate.Update(delegateData);
            sessionDelegateRepository.Update(sessionDelegate);
            sessionDelegateRepository.Save();
        }
    }
}
