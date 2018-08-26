using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Articles.Common;
using UseCase.Core;

namespace UseCase.Articles.GetDetail
{
    public class ArticleGetDetailResponse : IResponse
    {
        public ArticleGetDetailResponse(ArticleDto article)
        {
            Article = article;
        }

        public ArticleDto Article { get; }
    }
}
