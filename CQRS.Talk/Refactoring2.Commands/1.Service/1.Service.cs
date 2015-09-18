using System;
using System.Linq;


namespace CQRS.Talk.Refactoring2.Queries._1.Service
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
        private readonly IMovementTypeRepository movementTypeRepository;
        private readonly ICourseSessionRepository sessionRepository;
        private readonly IPersonRepository personRepository;
        private readonly ITrainingCourseAccommodationBookingRepository accommodationBookingRepository;
        private readonly IWorkMovementService workMovementService;


        public TrainingService(
            ISessionDelegateRepository sessionDelegateRepository,
            IMovementTypeRepository movementTypeRepository,
            ICourseSessionRepository sessionRepository,
            IPersonRepository personRepository,
            IWorkMovementService workMovementService,
            ITrainingCourseAccommodationBookingRepository accommodationBookingRepository)
        {
            this.sessionDelegateRepository = sessionDelegateRepository;
            this.movementTypeRepository = movementTypeRepository;
            this.sessionRepository = sessionRepository;
            this.personRepository = personRepository;
            this.workMovementService = workMovementService;
            this.accommodationBookingRepository = accommodationBookingRepository;
        }


        public void AddDelegateToSession(ISessionDelegateCreate delegateData)
        {
            var sessionDelegate = new SessionDelegate(delegateData);
            sessionDelegateRepository.Insert(sessionDelegate);
            sessionDelegateRepository.Save();

            var createWorkMovementCommand = this.CreateWorkMovementCommand(delegateData, sessionDelegate);

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


        public void UpdateDelegateFromSession(ISessionDelegateUpdate delegateData)
        {
            var sessionDelegate = sessionDelegateRepository.Find(delegateData.SessionDelegateId);
            sessionDelegate.Update(delegateData);
            sessionDelegateRepository.Update(sessionDelegate);
            sessionDelegateRepository.Save();

            var createWorkMovementCommand = this.CreateWorkMovementCommand(delegateData, sessionDelegate);
            workMovementService.CreateWorkMovement(createWorkMovementCommand);
        }


        public void CancelDelegateFromSession(int delegateId)
        {
            var sessionDelegate = sessionDelegateRepository.Find(delegateId);

            if (sessionDelegate == null)
            {
                return;
            }

            workMovementService.DeleteTrainingMovement(sessionDelegate.SessionDelegateId);

            // remove booked accommodation
            var accommodationBooking = accommodationBookingRepository.All.FirstOrDefault(b => b.SessionDelegateId == sessionDelegate.SessionDelegateId);
            if (accommodationBooking != null)
            {
                accommodationBookingRepository.Delete(accommodationBooking.TrainingCourseAccommodationBookingId);
            }
        }


        public void SessionDelegateNoShow(int sessionDelegateId)
        {
            workMovementService.UpdateWorkMovementComment(sessionDelegateId, "Training session is marked as No Show");

            // update accommodation booking note
            var accommodationBooking = accommodationBookingRepository.All.FirstOrDefault(b => b.SessionDelegateId == sessionDelegateId);
            if (accommodationBooking != null)
            {
                accommodationBooking.Notes = String.Format("{0}{1}{1}{2}", "Session Delegate is marked as No Show",
                                                           Environment.NewLine, accommodationBooking.Notes);
                accommodationBookingRepository.Update(accommodationBooking);
                accommodationBookingRepository.Save();
            }
        }
    }
}
