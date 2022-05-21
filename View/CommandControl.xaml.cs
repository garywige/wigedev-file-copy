using System.Windows.Controls;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.View
{
    /// <summary>
    /// Interaction logic for CommandControl.xaml
    /// </summary>
    public partial class CommandControl : UserControl
    {
        public CommandControl()
        {
            InitializeComponent();
        }

        public void SetViewModel(ICommandControlViewModel viewModel)
        {
            this.DataContext = viewModel;
        }
    }
}
