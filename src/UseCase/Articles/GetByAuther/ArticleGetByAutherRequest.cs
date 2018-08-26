using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Core;

namespace UseCase.Articles.GetByAuther
{
    public class ArticleGetByAutherRequest : IRequest<ArticleGetByAutherResponse>
    {
        public ArticleGetByAutherRequest(long autherId)
        {
            AutherId = autherId;
        }

        public long AutherId { get; }
    }
}
