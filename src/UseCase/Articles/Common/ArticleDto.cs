using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Articles.Common
{
    public class ArticleDto
    {
        public ArticleDto(long articleId, string title, string body)
        {
            Id = articleId;
            Title = title;
            Body = body;
        }

        public long Id { get; }
        public string Title { get; }
        public string Body { get; }
    }

    // Null-Object Pattern Impl
    public class NullArticleDto : ArticleDto
    {
        public NullArticleDto(long id)
         : base(id, "[Not Found]", "[Not Found]") { }
    }
}
