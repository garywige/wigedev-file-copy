using System.Windows;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Copier.Interfaces;

namespace WigeDev.View
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow(IFolderSelectionControlViewModel sourceViewModel, IFolderSelectionControlViewModel destViewModel, ICommandControlViewModel commandViewModel, IOutputViewModel outputViewModel, ISelectControlViewModel<ICopyStrategy> overwriteVM)
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
