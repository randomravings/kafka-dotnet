using Microsoft.Extensions.Logging;

namespace Kafka.Client
{
    public interface IWriteStreamBuilder
    {
        IWriteStreamBuilder WithLogger(
            ILogger<IWriteStream> logger
        );
        IWriteStream Build();
    }
}
