namespace CQRS.Talk.Refactoring2.Commands._1.Service
{
    public interface ITrainingService
    {
        void AddDelegate(ISessionDelegateCreate delegateData);
        void UpdateDelegate(ISessionDelegateUpdate delegateData);
        void CancelDelegate(int delegateId);
        void DelegateNoShow(int sessionDelegateId);
    }


    public class TrainingService : ITrainingService
    {
        private readonly IDelegateRepository delegateRepository;
        private readonly IWorkMovementService workMovementService;


        public TrainingService(
            IDelegateRepository delegateRepository,
            IWorkMovementService workMovementService)
        {
            this.delegateRepository = delegateRepository;
            this.workMovementService = workMovementService;
        }


        public void AddDelegate(ISessionDelegateCreate delegateData)
        {
            var sessionDelegate = new SessionDelegate(delegateData);
            delegateRepository.Insert(sessionDelegate);
            delegateRepository.Save();
        }



        public void UpdateDelegate(ISessionDelegateUpdate delegateData)
        {
            var sessionDelegate = delegateRepository.Find(delegateData.SessionDelegateId);
            sessionDelegate.Update(delegateData);
            delegateRepository.Update(sessionDelegate);
            delegateRepository.Save();
        }


        public void CancelDelegate(int delegateId)
        {
            var sessionDelegate = delegateRepository.Find(delegateId);

            if (sessionDelegate == null)
            {
                return;
            }
        }


        public void DelegateNoShow(int sessionDelegateId)
        {
            workMovementService.UpdateWorkMovementComment(sessionDelegateId, "Training session is marked as No Show");
        }
    }
}
