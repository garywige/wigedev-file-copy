using System.Windows.Input;
using WigeDev.Cancellation.Interfaces;
using WigeDev.Copier.Interfaces;
using WigeDev.Execute.Implementations;
using WigeDev.Init.Interfaces;
using WigeDev.Output.Interfaces;
using WigeDev.Validation.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class CopyCancelCommandInitializer : IInitializer<ICommand>
    {
        protected IValidator validator;
        protected ITextField source;
        protected ITextField dest;
        protected IOutput output;
        protected IJobStatus jobStatus;
        protected ICancellationManager cancellationManager;
        protected IFileEnumerator fileEnumerator;
        protected IPathConstructor pathConstructor;

        public CopyCancelCommandInitializer(
            IValidator validator,
            ITextField source,
            ITextField dest,
            IOutput output,
            IJobStatus jobStatus,
            ICancellationManager cancellationManager,
            IFileEnumerator fileEnumerator,
            IPathConstructor pathConstructor)
        {
            this.validator = validator;
            this.source = source;
            this.dest = dest;
            this.output = output;
            this.jobStatus = jobStatus;
            this.cancellationManager = cancellationManager;
            this.fileEnumerator = fileEnumerator;
            this.pathConstructor = pathConstructor;
        }

        public ICommand Initialize()
        {
            var copyCancelCommand = new CopyCancelCommand(
                validator,
                new CopyCancelExecute(
                    new Copier.Implementations.Copier(
                    fileEnumerator,
                    source,
                    dest,
                    output,
                    pathConstructor,
                    cancellationManager,
                    jobStatus),
                    jobStatus));

            source.PropertyChanged += (s, e) => copyCancelCommand.TestCanExecute();
            dest.PropertyChanged += (s, e) => copyCancelCommand.TestCanExecute();

            return copyCancelCommand;
        }
    }
}
