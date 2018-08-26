using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Core
{
    public interface IRequest<out TResponse> where TResponse : IResponse
    {
    }
}
