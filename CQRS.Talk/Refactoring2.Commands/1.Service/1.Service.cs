using System;
using System.Linq;


namespace CQRS.Talk.Refactoring2.Commands._1.Service
{
    public interface ITrainingService
    {
        void AddDelegateToSession(ISessionDelegateCreate delegateData);
        void UpdateDelegateFromSession(ISessionDelegateUpdate delegateData);
        void CancelDelegateFromSession(int delegateId);
        void SessionDelegateNoShow(int sessionDelegateId);
    }


    public class TrainingService : ITrainingService
    {
        private readonly ISessionDelegateRepository sessionDelegateRepository;
        private readonly IWorkMovementService workMovementService;


        public TrainingService(
            ISessionDelegateRepository sessionDelegateRepository,
            IWorkMovementService workMovementService)
        {
            this.sessionDelegateRepository = sessionDelegateRepository;
            this.workMovementService = workMovementService;
        }


        public void AddDelegateToSession(ISessionDelegateCreate delegateData)
        {
            var sessionDelegate = new SessionDelegate(delegateData);
            sessionDelegateRepository.Insert(sessionDelegate);
            sessionDelegateRepository.Save();
        }



        public void UpdateDelegateFromSession(ISessionDelegateUpdate delegateData)
        {
            var sessionDelegate = sessionDelegateRepository.Find(delegateData.SessionDelegateId);
            sessionDelegate.Update(delegateData);
            sessionDelegateRepository.Update(sessionDelegate);
            sessionDelegateRepository.Save();
        }


        public void CancelDelegateFromSession(int delegateId)
        {
            var sessionDelegate = sessionDelegateRepository.Find(delegateId);

            if (sessionDelegate == null)
            {
                return;
            }
        }


        public void SessionDelegateNoShow(int sessionDelegateId)
        {
            workMovementService.UpdateWorkMovementComment(sessionDelegateId, "Training session is marked as No Show");
        }
    }
}
