using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.Validation.Interfaces;
using System.Windows;
using WigeDev.ViewModel.Interfaces;
using WigeDev.View.Interfaces;
using WigeDev.View.Implementations;

namespace WigeDev.Init.Implementations
{
    public class AddJobAddCommandExecuteInitializer : IInitializer<Action>
    {
        protected IValidator validator;
        protected Window? window;
        protected ITextField source;
        protected ITextField dest;
        protected IList<ICopyJobControlViewModel> jobList;
        protected IWindowFactory<EditJobWindowAdapter> windowFactory;

        public AddJobAddCommandExecuteInitializer(
            IValidator validator, 
            Window window,
            ITextField source,
            ITextField dest,
            IList<ICopyJobControlViewModel> jobList,
            IWindowFactory<EditJobWindowAdapter> windowFactory)
        {
            this.validator = validator;
            this.window = window;
            this.source = source;
            this.dest = dest;
            this.jobList = jobList;
            this.windowFactory = windowFactory;
        }

        public Action Initialize()
        {
            return () =>
            {
                var deleteCommand = new SetExecuteCommand(new Command(() => true, () => { }));

                var editCommand = new SetExecuteCommand(new Command(() => validator.IsValid,
                    () => { }
                    ));

                window?.Close();
                var copyJobVM = new CopyJobControlViewModel(source.Text, dest.Text, editCommand, deleteCommand);
                jobList.Add(copyJobVM);

                editCommand.SetExecute(() =>
                {
                    // Set fields to match job params
                    source.Text = copyJobVM.Source;
                    dest.Text = copyJobVM.Destination;

                    var window = new EditJobWindowInitializer(windowFactory).Initialize();
                    if(window.ShowDialog() == true)
                    {
                        copyJobVM.Source = source.Text;
                        copyJobVM.Destination = dest.Text;
                    }
                });

                deleteCommand.SetExecute(() => jobList.Remove(copyJobVM));
            };
        }
    }
}
