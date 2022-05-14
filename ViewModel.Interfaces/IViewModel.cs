using System.Windows.Input;
using WigeDev.Model.Interfaces;

namespace WigeDev.ViewModel.Interfaces
{
    public interface IViewModel
    {
        public ITextField Source { get; set; }
        public ITextField Destination { get; set; }
        public ICommand CopyCancelCommand { get; set; }
        public IList<string> Output { get; set; }
    }
}