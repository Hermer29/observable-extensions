namespace Hermer29.ObservableExtensions
{
    internal class SubscribeHelperOnNext<T> : IObserver<T>, IDisposable
    {
        private readonly IObservable<T> _source;
        private readonly Action<T> _onNext;
        private IDisposable _subscription;

        public SubscribeHelperOnNext(IObservable<T> source, Action<T> onNext)
        {
            _source = source;
            _onNext = onNext;

            _subscription = _source.Subscribe(this);
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }

        public void OnCompleted()
        {
            
        }

        public void OnError(Exception error)
        {
            
        }

        public void OnNext(T value)
        {
            _onNext?.Invoke(value);
        }
    }
}