using System.Windows.Controls;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.View
{
    /// <summary>
    /// Interaction logic for FolderSelectionControl.xaml
    /// </summary>
    public sealed partial class FolderSelectionControl : UserControl
    {
        public FolderSelectionControl()
        {
            InitializeComponent();
        }

        public void SetViewModel(IFolderSelectionControlViewModel viewModel)
        {
            this.DataContext = viewModel;
        }
    }
}
