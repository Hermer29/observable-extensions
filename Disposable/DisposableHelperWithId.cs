namespace Hermer29.ObservableExtensions
{
    internal class DisposableHelperWithId : IDisposable
    {
        private readonly object _id;
        private readonly EventHandler _onDispose;

        public DisposableHelperWithId(object id, EventHandler onDispose)
        {
            _id = id;
            _onDispose = onDispose;
        }

        public void Dispose()
        {
            _onDispose?.Invoke(_id, new EventArgs());
        }
    }
}
