

namespace Cache.Utils.Keys
{
    public class DummyBase
    {
    }

    public class Dummy : ICacheKey<DummyBase>
    {
        private readonly int _id;
        public Dummy(int id)
        {
            _id = id;
        }

        public string CacheKey => $"_id_{_id}_{Constants.DummyKey}"; //key from appSettings to get the time
    }
}
