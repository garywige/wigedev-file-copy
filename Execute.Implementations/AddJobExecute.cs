using WigeDev.Execute.Interfaces;
using WigeDev.View.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Execute.Implementations
{
    public class AddJobExecute : IExecute
    {
        protected IWindowFactory<IOutputWindowAdapter> windowFactory;
        protected IList<ICopyJobControlViewModel> jobList;

        public AddJobExecute(IWindowFactory<IOutputWindowAdapter> factory, IList<ICopyJobControlViewModel> jobList)
        {
            windowFactory = factory;
            this.jobList = jobList;
        }

        public void Execute()
        {
            var window = windowFactory.CreateWindow();
            if(window.ShowDialog() == true)
            {
                jobList.Add(window.Output as ICopyJobControlViewModel);
            }

            window.Close();
        }
    }
}
