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
        protected IList<ICopyJobControlViewModel> jobList;

        public AddJobCCVMInitializer(
            Func<object?, bool?> showDialog,
            IList<ICopyJobControlViewModel> jobList)
        {
            this.showDialog = showDialog;
            this.jobList = jobList;
        }

        public ICommandControlViewModel Initialize()
        {
            return new CommandControlViewModel("Add Job", new Command(() => true, () => (new AddJobExecute(new OutputWindowFactory(
                o => { },
                showDialog),
                jobList)).Execute()));
        }
    }
}
