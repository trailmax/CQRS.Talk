namespace CQRS.Talk.Refactoring2.Commands._1.Service
{
    public interface ITrainingService
    {
        void AddDelegate(DelegateData delegateData);
        void UpdateDelegate(DelegateData delegateData);
        void CancelDelegate(int delegateId);
        void DelegateNoShow(int sessionDelegateId);
    }


    public class TrainingService : ITrainingService
    {
        private readonly IDelegateRepository delegateRepository;


        public TrainingService(IDelegateRepository delegateRepository)
        {
            this.delegateRepository = delegateRepository;
        }


        public void AddDelegate(DelegateData delegateData)
        {
            var sessionDelegate = new SessionDelegate(delegateData);
            delegateRepository.Insert(sessionDelegate);
            delegateRepository.Save();
        }



        public void UpdateDelegate(DelegateData delegateData)
        {
            var sessionDelegate = delegateRepository.Find(delegateData.SessionDelegateId);
            sessionDelegate.Update(delegateData);
            delegateRepository.Update(sessionDelegate);
            delegateRepository.Save();
        }


        public void CancelDelegate(int delegateId)
        {
            // implementation
        }


        public void DelegateNoShow(int sessionDelegateId)
        {
            // implementation
        }
    }
}
