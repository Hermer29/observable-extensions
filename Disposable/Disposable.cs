namespace Hermer29.ObservableExtensions
{
    public static class Disposable
    {
        public static IDisposable Create(Action onDispose)
        {
            return new DisposableHelper(onDispose);
        }

        public static IDisposable Create(object id, Action<object> onDispose)
        {
            return new DisposableHelperWithId(id, (o, args) => onDispose(o));
        }

        public static IDisposable Create(object id, EventHandler onDispose)
        {
            return new DisposableHelperWithId(id, onDispose);
        }
    }
}
