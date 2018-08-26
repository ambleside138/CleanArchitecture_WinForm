using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Core
{
    public interface IUseCase<in TRequest, out TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IResponse
    {
        TResponse Handle(TRequest request);
    }
}
