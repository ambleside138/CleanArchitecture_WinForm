using Domain.Domain.Model.Articles;
using Domain.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryDataStore.Articles
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly Dictionary<ArticleId, Article> db = new Dictionary<ArticleId, Article>();

        public Article Find(ArticleId id)
        {
            // オリジナルの実装では戻りの型がOption（Null-Objectパターン実装）
            // となっているがここでは単純にArticleを返す
            // このレベルでNull-Objectパターンを利用すると実装コストが大変そう。。

            if (db.TryGetValue(id, out var article))
            {
                return article;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Article> FindByAuther(UserId autherId)
        {
            return db.Values.Where(x => x.IsWrittenBy(autherId));
        }

        public void Save(Article article)
        {
            db[article.Id] = article;
        }

        public ArticleId GenerateId()
        {
            var maxId = db.Keys.Aggregate(0L, (acc, id) => Math.Max(acc, id.Value));
            return new ArticleId(maxId + 1);
        }
    }
}
