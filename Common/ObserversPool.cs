namespace Hermer29.ObservableExtensions
{
    public class ObserversPool<T> : IDisposable
    {
        private Dictionary<object, IObserver<T>> _observers = new Dictionary<object, IObserver<T>>();

        public IDisposable AddObserver(IObserver<T> observer)
        {
            var id = new object();
            _observers.Add(id, observer);
            var disposable = Disposable.Create(id, OnSubscriptionDisposed);
            return disposable;
        }

        private void OnSubscriptionDisposed(object id)
        {
            _observers.Remove(id);
        }

        public void Dispose()
        {
            _observers.Clear();
        }

        public void NotifyAll(T value)
        {
            foreach(var subscriber in _observers.Values)
            {
                subscriber.OnNext(value);
            }
        }
    }
}
