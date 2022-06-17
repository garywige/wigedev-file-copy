using System.Windows;
using WigeDev.Init.Interfaces;
using WigeDev.Validation.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class AddJobAddCommandExecuteInitializer : IInitializer<Action>
    {
        protected IValidator validator;
        protected Window window;
        protected ITextField source;
        protected ITextField dest;
        protected IList<ICopyJobControlViewModel> jobList;
        protected IJobStatus jobStatus;
        protected Func<ICopyJobControlViewModel, Action> editCommandExecute;

        public AddJobAddCommandExecuteInitializer(
            IValidator validator,
            Window window,
            ITextField source,
            ITextField dest,
            IList<ICopyJobControlViewModel> jobList,
            IJobStatus jobStatus,
            Func<ICopyJobControlViewModel, Action> editCommandExecute)
        {
            this.validator = validator;
            this.window = window;
            this.source = source;
            this.dest = dest;
            this.jobList = jobList;
            this.jobStatus = jobStatus;
            this.editCommandExecute = editCommandExecute;
        }

        public Action Initialize()
        {
            jobStatus.PropertyChanged += (s, e) => jobStatusPropertyChanged?.Invoke(this, new EventArgs());
            return () => jobList.Add(initCopyJobVM());
        }

        protected ICopyJobControlViewModel initCopyJobVM()
        {
            window.Close();
            var deleteCommand = initCommand();
            var editCommand = initCommand();
            var copyJobVM = new CopyJobControlViewModel(source.Text, dest.Text, editCommand, deleteCommand);
            editCommand.SetExecute(editCommandExecute(copyJobVM));
            deleteCommand.SetExecute(deleteCommandExecute(copyJobVM));
            return copyJobVM;
        }

        protected SetExecuteCommand initCommand()
        {
            return new SetExecuteCommand(
                    new CECCommand(
                        new Command(
                            () => !jobStatus.IsCopying,
                            () => { }),
                        ref jobStatusPropertyChanged));
        }

        protected Action deleteCommandExecute(ICopyJobControlViewModel copyJob) =>
            () => jobList.Remove(copyJob);

        protected EventHandler jobStatusPropertyChanged;
    }
}
