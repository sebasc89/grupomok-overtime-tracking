using Microsoft.Extensions.Caching.Memory;

namespace GrupoMok.OvertimeTracking.Application.Cache
{
    public interface IMemoryCacheManager : IEnumerable<KeyValuePair<object, object>>, IMemoryCache
    {
        void Clear();
    }
}
