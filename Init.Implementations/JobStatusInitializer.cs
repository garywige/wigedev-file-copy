using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;

namespace WigeDev.Init.Implementations
{
    public class JobStatusInitializer : IInitializer<IJobStatus>
    {
        public IJobStatus Initialize() => new JobStatus();
    }
}
