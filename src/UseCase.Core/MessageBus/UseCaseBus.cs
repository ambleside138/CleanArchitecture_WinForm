using SimpleInjector;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Core.MessageBus
{
    public class UseCaseBus
    {
        private readonly Dictionary<Type, Type> handlerTypes = new Dictionary<Type, Type>();
        private readonly ConcurrentDictionary<Type, UseCaseInvoker> _Invokers = new ConcurrentDictionary<Type, UseCaseInvoker>();

        private IServiceProvider _Provider;

        public void Setup(IServiceProvider container)
        {
            _Provider = container;
        }

        public void Register<TRequest, TUseCase>()
            where TRequest : IRequest<IResponse>
            where TUseCase : IUseCase<TRequest, IResponse>
        {
            if (handlerTypes.ContainsKey(typeof(TRequest)))
            {
                throw new Exception($"Duplicate register(RequestType: { typeof(TRequest).Name }).");
            }

            handlerTypes.Add(typeof(TRequest), typeof(TUseCase));
        }

        public TResponse Handle<TResponse>(IRequest<TResponse> request)
            where TResponse : IResponse
        {
            var invoker = Invoker(request);
            var response = invoker.Invoke<TResponse>(request);

            return response;
        }

        public async Task<TResponse> HandleAsync<TResponse>(IRequest<TResponse> request)
            where TResponse : IResponse
        {
            var invoker = Invoker(request);
            var result = await Task.Run(() => invoker.Invoke<TResponse>(request));

            return result;
        }

        private UseCaseInvoker Invoker<TResponse>(IRequest<TResponse> request)
            where TResponse : IResponse
        {
            var requestType = request.GetType();
            if (_Invokers.TryGetValue(requestType, out var searchedInvoker))
            {
                return searchedInvoker;
            }

            if (!handlerTypes.TryGetValue(requestType, out var handlerType))
            {
                throw new Exception($"Not registered usecase for this request(RequestType: { request.GetType().Name })");
            }

            var invoker = _Invokers.GetOrAdd(requestType, _ => {
                var handlerInstance = _Provider.GetService(handlerType);
                return new UseCaseInvoker(handlerType, handlerInstance.GetType(), _Provider);
            });

            return invoker;
        }
    }
}
