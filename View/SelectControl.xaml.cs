using System.Windows.Controls;
using WigeDev.ViewModel.Interfaces;

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

        public void SetViewModel(ISelectControlViewModel<object> viewModel)
        {
            this.DataContext = viewModel;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = DataContext as ISelectControlViewModel<object>;
            viewModel.SelectedItem = e.AddedItems[0];
        }
    }
}
