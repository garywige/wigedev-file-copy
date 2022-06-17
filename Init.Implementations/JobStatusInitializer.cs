using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class JobStatusInitializer : IInitializer<IJobStatus>
    {
        public IJobStatus Initialize() => new JobStatus();
    }
}
