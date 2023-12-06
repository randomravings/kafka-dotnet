using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO
{
    public interface IWriteStreamBuilder
    {
        IWriteStreamBuilder WithLogger(
            ILogger<IWriteStream> logger
        );
        IWriteStream Build();
    }
}
