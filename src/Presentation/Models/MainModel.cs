using Presentation.Models.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Articles.Common;
using UseCase.Articles.GetByAuther;
using UseCase.Articles.GetDetail;
using UseCase.Core.MessageBus;

namespace Presentation.Models
{
    class MainModel
    {
        private readonly UseCaseBus _Bus;

        public List<ArticleListRow> List { get; }

        public MainModel(UseCaseBus bus)
        {
            _Bus = bus;
            List = new List<ArticleListRow>();
        }

        public void UpdateArticleList()
        {
            var parameter = new ArticleGetByAutherRequest(myId());
            var response = _Bus.Handle(parameter);

            List.Clear();
            List.AddRange(response.Articles.Select(a => new ArticleListRow(a)));
        }

        public ArticleDto GetDetail(long articleId)
        {
            var parameter = new ArticleGetDetailRequest(articleId);
            var response = _Bus.Handle(parameter);
            return response.Article;
        }

        // Temporary implementation
        private long myId()
        {
            return 1;
        }
    }
}
