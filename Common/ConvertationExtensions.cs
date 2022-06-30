namespace Hermer29.ObservableExtensions
{
    public static class ConvertationExtensions
    {
        public static IAsyncEnumerable<T> AsAsyncEnumerable<T>(this IObservable<T> observable)
        {
            return new AsAsyncEnumerableHelper<T>(observable);
        }
    }
}
