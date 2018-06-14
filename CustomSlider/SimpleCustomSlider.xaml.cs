using CustomSlider.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomSlider
{
    public partial class SimpleSlider : UserControl
    {

        #region Constructors
        public SimpleSlider()
        {
            InitializeComponent();

            DataContext = new ViewModel(this);

            SetBindings();
        }
        #endregion       

    }
}
