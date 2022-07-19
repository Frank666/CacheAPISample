namespace Cache.Utils
{
    public interface ICacheKey<TItem>
    {
        string CacheKey { get; }
    }
}
