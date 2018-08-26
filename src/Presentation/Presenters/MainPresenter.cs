using Presentation.Models;
using Presentation.Models.Article;
using Presentation.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UseCase.Articles.Common;
using UseCase.Core.MessageBus;

namespace Presentation.Presenters
{
    class MainPresenter
    {
        private readonly MainView _MainView;
        private readonly MainModel _MainModel;

        public MainPresenter(MainView view)
        {
            _MainView = view;
            _MainModel = new MainModel(ContainerHelper.Current.GetInstance<UseCaseBus>());

            InitializeGrid();

            SetEvents();
        }

        private void InitializeGrid()
        {
            _MainView.dgvArticle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _MainView.dgvArticle.RowHeadersVisible = false;
            _MainView.dgvArticle.MultiSelect = false;
            _MainView.dgvArticle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var bs = new BindingSource();
            bs.DataSource = new BindingList<ArticleListRow>(_MainModel.List);
            _MainView.dgvArticle.DataSource = bs;
        }

        private void SetEvents()
        {
            _MainView.btnAdd.Click += BtnAdd_Click;
            _MainView.Load += (_, __) => UpdateArticleList();
            _MainView.dgvArticle.SelectionChanged += (_, __) => UpdatePreviewArticle();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var dig = new ArticleEditorView())
            {
                dig.ShowDialog();
            }

            UpdateArticleList();
        }

        private void UpdateArticleList()
        {
            _MainModel.UpdateArticleList();
            ((BindingSource)_MainView.dgvArticle.DataSource).ResetBindings(false);
        }

        private void UpdatePreviewArticle()
        {
            if(_MainView.dgvArticle.SelectedRows.Count == 0)
            {
                BindToPreview(new NullArticleDto(0));
                return;
            }

            var target = _MainView.dgvArticle.SelectedRows[0].DataBoundItem as ArticleListRow;

            var detail = _MainModel.GetDetail(target.Id);
            BindToPreview(detail);
        }

        private void BindToPreview(ArticleDto dto)
        {
            _MainView.lbTitle.Text = dto.Title;
            _MainView.lbBody.Text = dto.Body;
        }
    }
}
