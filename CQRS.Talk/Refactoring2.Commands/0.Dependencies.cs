using System;
using System.Collections.Generic;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;


namespace CQRS.Talk.Refactoring2.Commands
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
        private AddDelegateToSessionCommand command;

        public SessionDelegate(ISessionDelegateCreate delegateData)
        {
            throw new NotImplementedException();
        }

        public SessionDelegate(AddDelegateToSessionCommand command)
        {
            this.command = command;
        }

        public int SessionDelegateId { get; set; }
        public int PersonId { get; set; }


        public void Update(ISessionDelegateUpdate delegateData)
        {
            throw new NotImplementedException();
        }


        public void Update(UpdateDelegateFromSessionCommand delegateData)
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

    public class SessionDelegateCreate : ISessionDelegateCreate
    {
        public int CourseSessionId { get; set; }
        public int PersonId { get; set; }
    }


    public class HttpPostAttribute : Attribute
    {
    }

}
