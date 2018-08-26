using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Core;

namespace UseCase.Articles.Create
{
    public class ArticleCreateResponse : IResponse
    {
        public long CreatedArticleId { get; }

        public ArticleCreateResponse(long createdArticleId)
        {
            CreatedArticleId = createdArticleId;
        }
    }
}
