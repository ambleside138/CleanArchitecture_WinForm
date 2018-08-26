using Presentation.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Views
{
    public partial class ArticleEditorView : Form
    {
        private readonly ArticleEditorPresenter _Presenter;

        public ArticleEditorView()
        {
            InitializeComponent();

            _Presenter = new ArticleEditorPresenter(this);
        }
    }
}
