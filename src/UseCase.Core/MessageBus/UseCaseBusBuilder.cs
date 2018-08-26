using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;

namespace UseCase.Core.MessageBus
{
    public class UseCaseBusBuilder
    {
        private readonly Container _Container;
        private readonly UseCaseBus _Bus;

        public UseCaseBusBuilder(Container container)
        {
            _Container = container;
            _Bus = new UseCaseBus();
        }

        public UseCaseBus Build()
        {
            _Bus.Setup(_Container);

            return _Bus;
        }

        public void RegisterUseCase<TRequest, TImplement>()
            where TRequest : IRequest<IResponse>
            where TImplement : class, IUseCase<TRequest, IResponse>
        {
            _Container.RegisterSingleton<TImplement>();
            _Bus.Register<TRequest, TImplement>();
        }
    }
}
