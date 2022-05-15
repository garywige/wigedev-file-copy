using WigeDev.Output.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Output.Implementations
{
    public class Output : IOutput
    {
        protected IViewModel viewModel;

        public Output(IViewModel viewModel) =>
            this.viewModel = viewModel;

        public void Write(string message) =>
            this.viewModel.Output.Add(message);
    }
}