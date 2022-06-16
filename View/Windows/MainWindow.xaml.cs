using System.Windows;
using WigeDev.Copier.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.View.Windows
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow(
            IFolderSelectionControlViewModel sourceViewModel,
            IFolderSelectionControlViewModel destViewModel,
            ICommandControlViewModel copyCommandViewModel,
            IOutputViewModel outputViewModel,
            ISelectControlViewModel<ICopyStrategy> overwriteVM,
            ICommandControlViewModel startBatchCommandControlVM,
            ICommandControlViewModel addJobCommandControlVM,
            IBatchListControlViewModel batchListControlVM,
            ICommandControlViewModel saveCVM,
            ICommandControlViewModel loadCVM)
        {
            InitializeComponent();
            sourceSelection.SetViewModel(sourceViewModel);
            destinationSelection.SetViewModel(destViewModel);
            copyCommandControl.SetViewModel(copyCommandViewModel);
            outputControl.SetViewModel(outputViewModel);
            overwriteSelectControl.SetViewModel(overwriteVM);
            startBatchCommandControl.SetViewModel(startBatchCommandControlVM);
            addJobCommandControl.SetViewModel(addJobCommandControlVM);
            batchListControl.SetViewModel(batchListControlVM);
            saveCommandControl.SetViewModel(saveCVM);
            loadCommandControl.SetViewModel(loadCVM);
        }
    }
}
