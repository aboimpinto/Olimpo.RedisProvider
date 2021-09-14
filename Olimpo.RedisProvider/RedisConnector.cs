using System;
using StackExchange.Redis;

namespace Olimpo.RedisProvider
{
    public class RedisConnector
    {
        private Lazy<ConnectionMultiplexer> _lazyConnectionMultiplexer;
        private readonly int _databaseId;

        public IDatabase CurrentDatabase => this._lazyConnectionMultiplexer.Value.GetDatabase(this._databaseId);

        public ConnectionMultiplexer ConnectionMultiplexer => this._lazyConnectionMultiplexer.Value;

        public RedisConnector(string configuration, int databaseId = 0)
        {
            this._lazyConnectionMultiplexer = new Lazy<ConnectionMultiplexer>(() => 
            {
                var connection = ConnectionMultiplexer.Connect(configuration);
                return connection;
            });
            this._databaseId = databaseId;
        }
    }
}
