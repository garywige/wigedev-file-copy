using System.Windows;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.View
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow(IFolderSelectionControlViewModel sourceViewModel, IFolderSelectionControlViewModel destViewModel, ICommandControlViewModel commandViewModel, IOutputViewModel outputViewModel, ISelectControlViewModel<object> overwriteVM)
        {
            InitializeComponent();
            sourceSelection.SetViewModel(sourceViewModel);
            destinationSelection.SetViewModel(destViewModel);
            commandControl.SetViewModel(commandViewModel);
            outputControl.SetViewModel(outputViewModel);
            overwriteSelectControl.SetViewModel(overwriteVM);
        }
    }
}
