using Kafka.Client.Server;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.Clients
{
    public abstract class Client<TConfig> :
        IClient
        where TConfig : notnull, ClientConfig
    {
        protected readonly TConfig _config;
        protected readonly ILogger _logger;

        private bool _disposed;

        protected readonly IConnectionPool _connectionPool;

        protected Client(
            TConfig config,
            ILogger logger
        )
        {
            _config = config;
            _logger = logger;
            _connectionPool = new ConnectionPool(config, logger);
        }

        public async ValueTask Close(CancellationToken cancellationToken)
        {
            await OnClose(cancellationToken);
        }

        protected abstract ValueTask OnClose(CancellationToken cancellationToken);

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
