namespace WigeDev.Copier.Interfaces
{
    public interface ICopier
    {
        public Task Copy();
        public void Cancel();
    }
}