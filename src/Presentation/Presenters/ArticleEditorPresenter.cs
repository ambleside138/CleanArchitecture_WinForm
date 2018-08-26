using Presentation.Models;
using Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Core.MessageBus;

namespace Presentation.Presenters
{
    class ArticleEditorPresenter
    {
        private readonly ArticleEditorView _View;
        private readonly ArticleEditorModel _Model;

        public ArticleEditorPresenter(ArticleEditorView view)
        {
            _View = view;
            _Model = new ArticleEditorModel(ContainerHelper.Current.GetInstance<UseCaseBus>());

            SetEvents();
        }

        private void SetEvents()
        {
            _View.btnRegist.Click += (_, __) => Create();

            _View.btnCancel.Click += (_, __) => _View.Close();
        }

        public void Create()
        {
            _Model.AddConfirm(new Models.Article.ArticleEditModel
            {
                Title = _View.tbTitle.Text,
                Body = _View.tbBody.Text,
            });

            _View.Close();
        }

    }
}
