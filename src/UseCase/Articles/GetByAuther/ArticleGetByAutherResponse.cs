using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Articles.Common;
using UseCase.Core;

namespace UseCase.Articles.GetByAuther
{
    public class ArticleGetByAutherResponse : IResponse
    {
        public ArticleGetByAutherResponse(IEnumerable<ArticleDto> articles)
        {
            Articles = articles.ToArray();
        }

        public ArticleDto[] Articles { get; }
    }
}
