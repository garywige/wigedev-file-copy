using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.Execute.Implementations;
using WigeDev.View.Implementations;

namespace WigeDev.Init.Implementations
{
    public class AddJobCCVMInitializer : IInitializer<ICommandControlViewModel>
    {
        protected Func<object?, bool?> showDialog;
        protected Action close;
        protected IList<ICopyJobControlViewModel> jobList;
        protected IJobStatus jobStatus;

        public AddJobCCVMInitializer(
            Func<object?, bool?> showDialog,
            Action close,
            IList<ICopyJobControlViewModel> jobList,
            IJobStatus jobStatus)
        {
            this.showDialog = showDialog;
            this.close = close;
            this.jobList = jobList;
            this.jobStatus = jobStatus;
        }

        public ICommandControlViewModel Initialize()
        {
            jobStatus.PropertyChanged += (s, e) => jobStatusPropertyChanged?.Invoke(this, new EventArgs());

            return new CommandControlViewModel("Add Job", new CECCommand(new Command(() => !jobStatus.IsCopying, () => (new AddJobExecute(new OutputWindowFactory(
                o => { },
                showDialog,
                close),
                jobList)).Execute()), ref jobStatusPropertyChanged));
        }

        protected EventHandler jobStatusPropertyChanged;
    }
}
