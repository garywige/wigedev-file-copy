using System.Windows.Controls;
using WigeDev.Copier.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.View.Controls
{
    /// <summary>
    /// Interaction logic for SelectControl.xaml
    /// </summary>
    public partial class SelectControl : UserControl
    {
        public SelectControl()
        {
            InitializeComponent();
        }

        public void SetViewModel(ISelectControlViewModel<ICopyStrategy> viewModel)
        {
            this.DataContext = viewModel;
        }
    }
}
