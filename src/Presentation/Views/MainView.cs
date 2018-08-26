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
    public partial class MainView : Form
    {
        private readonly MainPresenter _Presenter;

        public MainView()
        {
            InitializeComponent();

            _Presenter = new MainPresenter(this);
        }
    }
}
