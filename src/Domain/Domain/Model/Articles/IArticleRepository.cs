using Domain.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Model.Articles
{
    public interface IArticleRepository
    {
        Article Find(ArticleId id);
        IEnumerable<Article> FindByAuther(UserId autherId);
        void Save(Article article);
        ArticleId GenerateId();
    }
}
