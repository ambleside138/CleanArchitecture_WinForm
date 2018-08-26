using Presentation.Models.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Articles.Create;
using UseCase.Core.MessageBus;

namespace Presentation.Models
{
    class ArticleEditorModel
    {
        private readonly UseCaseBus _Bus;

        public ArticleEditorModel(UseCaseBus bus)
        {
            _Bus = bus;
        }

        public void AddConfirm(ArticleEditModel model)
        {
            var param = new ArticleCreateRequest(model.Title, model.Body, myId());
            var response = _Bus.Handle(param);
        }

        // Temporary implementation
        private long myId()
        {
            return 1;
        }
    }
}
