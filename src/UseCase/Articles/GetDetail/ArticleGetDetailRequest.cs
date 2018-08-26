using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Core;

namespace UseCase.Articles.GetDetail
{
    public class ArticleGetDetailRequest : IRequest<ArticleGetDetailResponse>
    {
        public ArticleGetDetailRequest(long articleId)
        {
            ArticleId = articleId;
        }

        public long ArticleId { get; }
    }
}
