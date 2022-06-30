namespace Hermer29.ObservableExtensions
{
    internal class AsAsyncEnumerableHelper<T> : IAsyncEnumerable<T>
    {
        private readonly IObservable<T> _observable;

        public AsAsyncEnumerableHelper(IObservable<T> observable)
        {
            _observable = observable;
        }

        public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            bool newValueAppeared = false;
            T newValue = default;
            _observable.Subscribe(x =>
            {
                newValue = x;
                newValueAppeared = true;
            });

            while (true)
            {
                await Task.Run(() =>
                {
                    while (newValueAppeared == false)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            return;
                    }
                    newValueAppeared = false;
                });
                if (cancellationToken.IsCancellationRequested)
                    yield break;
                yield return newValue;
            }
        }
    }
}
