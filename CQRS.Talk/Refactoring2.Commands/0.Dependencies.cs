using System;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;


namespace CQRS.Talk.Refactoring2.Commands
{
    public class SessionDelegate
    {
        public SessionDelegate(DelegateData delegateData)
        {
            throw new NotImplementedException();
        }

        public SessionDelegate(AddDelegateCommand command)
        {
            throw new NotImplementedException();
        }


        public SessionDelegate(_2.BasicCommands.AddDelegateCommand delegateData)
        {
            throw new NotImplementedException();
        }


        public void Update(DelegateData delegateData)
        {
            throw new NotImplementedException();
        }


        public void Update(UpdateDelegateCommand delegateData)
        {
            throw new NotImplementedException();
        }


        public void Update(_2.BasicCommands.UpdateDelegateCommand delegateData)
        {
            throw new NotImplementedException();
        }
    }






    public interface IDelegateRepository
    {
        void Insert(SessionDelegate sessionDelegate);
        void Save();
        SessionDelegate Find(int sessionDelegateId);
        void Update(SessionDelegate sessionDelegate);
    }


    public class DelegateData
    {
        public int SessionDelegateId { get; set; }
        public int CourseSessionId { get; set; }
        public int PersonId { get; set; }
    }

    public class SessionDelegateCreate : DelegateData
    {
        public int CourseSessionId { get; set; }
        public int PersonId { get; set; }
    }


    public class HttpPostAttribute : Attribute
    {
    }
}
