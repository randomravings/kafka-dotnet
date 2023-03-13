using Kafka.Common.Model;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.Clients.Producer.Logging
{
    public static partial class ProducerLog
    {
        [LoggerMessage(EventId = 2000, Level = LogLevel.Warning, Message = "Topic: {topic}, Error: {error}", SkipEnabledCheck = true)]
        public static partial void ProducePartitionError(ILogger logger, string topic, Error error);





        [LoggerMessage(EventId = 9000, Level = LogLevel.Trace, Message = "Record Builder dequeued {recordCount} records")]
        public static partial void ProduceCommandDequeue(ILogger logger, int recordCount);
    }
}
