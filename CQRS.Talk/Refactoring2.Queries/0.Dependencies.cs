using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Talk.Refactoring2.Queries
{
    public class CreateWorkMovementCommand
    {
    }


    public class DomainException : Exception
    {
        public DomainException(string movementTypeTrainingIsNotFoundPleaseCreateIt)
        {
            throw new NotImplementedException();
        }
    }



    public class SessionDelegate
    {
        public SessionDelegate(ISessionDelegateCreate delegateData)
        {
            throw new NotImplementedException();
        }


        public int SessionDelegateId { get; set; }
        public int PersonId { get; set; }


        public void Update(ISessionDelegateUpdate delegateData)
        {
            throw new NotImplementedException();
        }
    }



    public interface IWorkMovementService
    {
        void UpdateWorkMovementComment(int sessionDelegateId, string trainingSessionIsMarkedAsNoShow);
        void DeleteTrainingMovement(object sessionDelegateId);
        void CreateWorkMovement(CreateWorkMovementCommand createWorkMovementCommand);
    }

    public class TrainingCourseAccommodationBooking
    {
        public int SessionDelegateId { get; set; }
        public int TrainingCourseAccommodationBookingId { get; set; }
        public string Notes { get; set; }
    }

    public interface ITrainingCourseAccommodationBookingRepository
    {
        void Save();
        void Update(object accommodationBooking);
        IEnumerable<TrainingCourseAccommodationBooking> All { get; }
        void Delete(int trainingCourseAccommodationBookingId);
    }


    public interface IPersonRepository
    {
        SessionDelegate Find(int personId);
    }


    public class CourseSession
    {
        public int CourseSessionId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public interface ICourseSessionRepository
    {
        IEnumerable<CourseSession> All { get; set; }
    }


    public interface IMovementTypeRepository
    {
        IEnumerable<MovementType> All { get; }
    }
    public class MovementType {
        public String Name { get; set; }
    }



    public interface ISessionDelegateRepository
    {
        void Insert(SessionDelegate sessionDelegate);
        void Save();
        SessionDelegate Find(int sessionDelegateId);
        void Update(SessionDelegate sessionDelegate);
    }

    public interface ISessionDelegateUpdate : ISessionDelegateCreate
    {
        int SessionDelegateId { get; set; }
    }


    public interface ISessionDelegateCreate
    {
        int CourseSessionId { get; set; }
        int PersonId { get; set; }
    }
}
