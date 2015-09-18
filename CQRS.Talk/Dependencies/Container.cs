using System;


namespace CQRS.Talk.Dependencies
{
    // Fake DI container
    public class Container
    {
        public object GetInstance(Type handlerType)
        {
            throw new NotImplementedException();
        }


        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }
    }
}
