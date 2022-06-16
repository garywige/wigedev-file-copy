using System.Windows;
using WigeDev.Init.Interfaces;
using WigeDev.Validation.Interfaces;
using WigeDev.View.Implementations;
using WigeDev.View.Interfaces;
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
        protected IWindowFactory<EditJobWindowAdapter> windowFactory;
        protected IJobStatus jobStatus;

        public AddJobAddCommandExecuteInitializer(
            IValidator validator,
            Window window,
            ITextField source,
            ITextField dest,
            IList<ICopyJobControlViewModel> jobList,
            IWindowFactory<EditJobWindowAdapter> windowFactory,
            IJobStatus jobStatus)
        {
            this.validator = validator;
            this.window = window;
            this.source = source;
            this.dest = dest;
            this.jobList = jobList;
            this.windowFactory = windowFactory;
            this.jobStatus = jobStatus;
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

        protected Action editCommandExecute(ICopyJobControlViewModel copyJob) =>
            () =>
            {
                // Set fields to match job params
                source.Text = copyJob.Source;
                dest.Text = copyJob.Destination;

                var window = new EditJobWindowInitializer(windowFactory).Initialize();
                if (window.ShowDialog() == true)
                {
                    copyJob.Source = source.Text;
                    copyJob.Destination = dest.Text;
                }
            };

        protected EventHandler jobStatusPropertyChanged;
    }
}
