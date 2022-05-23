using System.Windows.Controls;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Copier.Interfaces;

namespace WigeDev.View
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
