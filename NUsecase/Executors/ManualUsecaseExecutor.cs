using System;
using System.Collections.Generic;

namespace NUsecase.Executors
{
    public class ManualUsecaseExecutor : IUsecaseExecutor
    {
        private readonly IDictionary<Type, object> _usecases = new Dictionary<Type, object>();

        protected ManualUsecaseExecutor()
        {
        }

        public TResponse Execute<TRequest, TResponse>(TRequest request)
        {
            IUsecase<TRequest, TResponse> registeredUsecase;
            if (!IsRegistered(out registeredUsecase))
                throw new ArgumentException($"Unable to find a suitable usecase for request {request}. Did you forget to register the usecase by its request?");
            return registeredUsecase.Execute(request);
        }

        protected void Register(Type requestType, object usecase)
        {
            _usecases.Add(requestType, usecase);
        }

        private bool IsRegistered<TRequest, TResponse>(out IUsecase<TRequest, TResponse> usecase)
        {
            object untypedUsecase;
            var isRegistered = _usecases.TryGetValue(typeof(TRequest), out untypedUsecase);
            usecase = (IUsecase<TRequest, TResponse>) (isRegistered ? untypedUsecase : null);

            return isRegistered;
        }
    }
}