namespace Hermer29.ObservableExtensions
{
    public static class CommonExtensions
    {
        public static IDisposable Subscribe<T>(this IObservable<T> observable, Action<T> onNext)
        {
            return new SubscribeHelperOnNext<T>(observable, onNext);
        }
    }
}
