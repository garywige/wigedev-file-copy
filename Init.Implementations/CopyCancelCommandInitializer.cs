using System.Windows.Input;
using WigeDev.Cancellation.Implementations;
using WigeDev.Copier.Implementations;
using WigeDev.Execute.Implementations;
using WigeDev.Init.Interfaces;
using WigeDev.Output.Interfaces;
using WigeDev.Settings.Interfaces;
using WigeDev.Validation.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class CopyCancelCommandInitializer : IInitializer<ICommand>
    {
        protected IValidator validator;
        protected ISettingsManager settingsManager;
        protected ITextField source;
        protected ITextField dest;
        protected IOutput output;
        protected IJobStatus jobStatus;

        public CopyCancelCommandInitializer(
            IValidator validator,
            ISettingsManager settingsManager,
            ITextField source,
            ITextField dest,
            IOutput output,
            IJobStatus jobStatus)
        {
            this.validator = validator;
            this.settingsManager = settingsManager;
            this.source = source;
            this.dest = dest;
            this.output = output;
            this.jobStatus = jobStatus;
        }

        public ICommand Initialize()
        {
            var copyCancelCommand = new CopyCancelCommand(
                validator,
                new CopyCancelExecute(
                    new Copier.Implementations.Copier(
                    new FileEnumerator(settingsManager),
                    source,
                    dest,
                    output,
                    new PathConstructor(),
                    new CancellationManager(),
                    jobStatus),
                    jobStatus));

            source.PropertyChanged += (s, e) => copyCancelCommand.TestCanExecute();
            dest.PropertyChanged += (s, e) => copyCancelCommand.TestCanExecute();

            return copyCancelCommand;
        }
    }
}
