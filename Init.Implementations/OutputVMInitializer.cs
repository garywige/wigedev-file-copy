using WigeDev.Init.Interfaces;
using WigeDev.Output.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class OutputVMInitializer : IInitializer<IOutputViewModel>
    {
        protected IOutput output;
        protected IJobStatus jobStatus;

        public OutputVMInitializer(IOutput output, IJobStatus jobStatus)
        {
            this.output = output;
            this.jobStatus = jobStatus;
        }

        public IOutputViewModel Initialize() => new OutputViewModel(output, jobStatus);
    }
}
