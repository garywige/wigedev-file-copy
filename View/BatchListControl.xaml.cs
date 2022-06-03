using System.Windows.Controls;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.View
{
    /// <summary>
    /// Interaction logic for BatchListControl.xaml
    /// </summary>
    public partial class BatchListControl : UserControl
    {
        public BatchListControl()
        {
            InitializeComponent();
        }

        public void SetViewModel(IBatchListControlViewModel viewModel)
        {
            this.DataContext = viewModel;
        }
    }
}
