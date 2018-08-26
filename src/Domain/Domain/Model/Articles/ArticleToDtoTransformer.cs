using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Articles.Common;

namespace Domain.Domain.Model.Articles
{
    public class ArticleToDtoTransformer : IArticleDataTransformer<ArticleDto>
    {
        // オリジナルのソースではセッターメソッドを定義しているが
        // プロパティのほうが記述量がすくなくなる

        public long Id { private get; set; }
        public string Title { private get; set; }
        public string Body { private get; set; }

        //private long id;
        //private string title;
        //private string body;

        //public void Id(long id)
        //{
        //    this.id = id;
        //}

        //public void Title(string title)
        //{
        //    this.title = title;
        //}

        //public void Body(string body)
        //{
        //    this.body = body;
        //}

        public ArticleDto Build()
        {
            return new ArticleDto(Id, Title, Body);
        }
    }
}
