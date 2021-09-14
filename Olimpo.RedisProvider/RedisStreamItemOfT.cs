using System.Linq;
using System.Text.Json;
using StackExchange.Redis;

namespace Olimpo.RedisProvider
{
    public class RedisStreamItem<T>
    {
        public string Id { get; private set; }

        public T Message { get; private set; }

        public RedisStreamItem(StreamEntry entry)
        {
            this.Id = entry.Id;
            this.Message = JsonSerializer.Deserialize<T>(entry.Values.First().Value);        
        }
    }
}
