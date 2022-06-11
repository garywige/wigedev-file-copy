using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.Output.Interfaces;

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
