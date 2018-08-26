using Domain.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Model.Articles
{
    public class Article
    {
        private string title;
        private string body;
        private UserId auther;
        private bool isPublish;

        public Article(
            ArticleId id,
            string title,
            string body,
            UserId auther
        )
        {
            Id = id;
            this.title = title;
            this.body = body;
            this.auther = auther;
        }

        public ArticleId Id { get; }

        public void Publish()
        {
            isPublish = true;
        }

        public void Unpublish()
        {
            isPublish = false;
        }

        public bool IsSameId(ArticleId id)
        {
            return Id.Equals(id);
        }

        public bool IsSameArticle(Article article)
        {
            if (ReferenceEquals(null, article))
            {
                return false;
            }

            if (ReferenceEquals(this, article))
            {
                return true;
            }

            if (Id.Equals(article.Id))
            {
                return true;
            }

            return false;
        }

        public bool IsWrittenBy(UserId auther)
        {
            return this.auther.Equals(auther);
        }

        /// <summary>
        /// 任意の型へ変換する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="transformer"></param>
        /// <returns></returns>
        public T Transform<T>(IArticleDataTransformer<T> transformer)
        {
            transformer.Id = Id.Value;
            transformer.Title = title;
            transformer.Body = body;
            return transformer.Build();
        }
    }
}
