using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.Validation.Interfaces;
using System.Windows;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class AddJobAddCommandExecuteInitializer : IInitializer<Action>
    {
        protected IValidator validator;
        protected Window? window;
        protected ITextField source;
        protected ITextField dest;
        protected IList<ICopyJobControlViewModel> jobList;

        public AddJobAddCommandExecuteInitializer(
            IValidator validator, 
            Window window,
            ITextField source,
            ITextField dest,
            IList<ICopyJobControlViewModel> jobList)
        {
            this.validator = validator;
            this.window = window;
            this.source = source;
            this.dest = dest;
            this.jobList = jobList;
        }

        public Action Initialize()
        {
            return () =>
            {
                var deleteCommand = new SetExecuteCommand(new Command(() => true, () => { }));

                var editCommand = new Command(() => validator.IsValid,
                    null // TODO
                    );

                window?.Close();
                var copyJobVM = new CopyJobControlViewModel(source.Text, dest.Text, editCommand, deleteCommand);
                jobList.Add(copyJobVM);

                deleteCommand.SetExecute(() => jobList.Remove(copyJobVM));
            };
        }
    }
}
