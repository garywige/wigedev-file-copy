using System.Windows;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.View.Windows
{
    /// <summary>
    /// Interaction logic for AddJobWindow.xaml
    /// </summary>
    public partial class AddJobWindow : Window
    {
        public AddJobWindow(
            IFolderSelectionControlViewModel sourceVM, 
            IFolderSelectionControlViewModel destVM,
            ICommandControlViewModel addCommandVM,
            ICommandControlViewModel cancelCommandVM)
        {
            InitializeComponent();

            sourceControl.SetViewModel(sourceVM);
            destinationControl.SetViewModel(destVM);
            addCommand.SetViewModel(addCommandVM);
            cancelCommand.SetViewModel(cancelCommandVM);
        }
    }
}
