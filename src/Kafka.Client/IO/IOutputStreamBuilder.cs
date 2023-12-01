using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO
{
    public interface IOutputStreamBuilder
    {
        IOutputStreamBuilder WithLogger(
            ILogger<IOutputStream> logger
        );
        IOutputStream Build();
    }
}
