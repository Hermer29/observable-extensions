namespace Hermer29.ObservableExtensions
{
    internal class DisposableHelper : IDisposable
    {
        private Action? _onDispose;

        public DisposableHelper(Action onDispose)
        {
            _onDispose = onDispose;
        }

        public void Dispose()
        {
            _onDispose?.Invoke();
            _onDispose = null;
        }
    }
}
