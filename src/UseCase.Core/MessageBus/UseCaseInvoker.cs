using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Core.MessageBus
{
    public class UseCaseInvoker
    {
        private readonly Type usecaseType;
        private readonly IServiceProvider provider;
        private readonly MethodInfo handleMethod;

        public UseCaseInvoker(Type usecaseType, Type implementsType, IServiceProvider provider)
        {
            this.usecaseType = usecaseType;
            this.provider = provider;

            handleMethod = implementsType.GetMethod("Handle");
        }

        public TResponse Invoke<TResponse>(object request)
            where TResponse : IResponse
        {
            var instance = provider.GetService(usecaseType);

            object responseObject;
            try
            {
                responseObject = handleMethod.Invoke(instance, new[] { request });
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }

            var response = (TResponse)responseObject;

            return response;
        }
    }
}
