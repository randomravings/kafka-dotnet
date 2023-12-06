using Kafka.Client.Model;
using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO.Read
{
    internal class ApplicationReader :
        Reader,
        IApplicationReader,
        IDisposable
    {
        private protected readonly IApplicationReadStream _applicationStream;
        private protected readonly IReadOnlySet<TopicName> _topics;

        internal ApplicationReader(
            IApplicationReadStream stream,
            IReadOnlySet<TopicName> topics,
            ILogger logger
        ) : base(stream, logger)
        {
            _applicationStream = stream;
            _topics = topics;
        }

        protected override async ValueTask Initialize(CancellationToken cancellationToken)
        {
            await _applicationStream.AddReader(_topics, cancellationToken).ConfigureAwait(false);
            _initialized = true;
        }
    }



    internal class ApplicationReader<TKey, TValue> :
        ApplicationReader,
        IApplicationReader<TKey, TValue>
    {
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;

        internal ApplicationReader(
            IApplicationReadStream stream,
            IReadOnlySet<TopicName> topics,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger logger
        ) : base(stream, topics, logger)
        {
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
        }

        async ValueTask<ReadRecord<TKey, TValue>> IReader<TKey, TValue>.Read(
            CancellationToken cancellationToken
        ) =>
            await Read(_keyDeserializer, _valueDeserializer, cancellationToken)
                .ConfigureAwait(false)
        ;

        async ValueTask<ReadRecord<TKey, TValue>> IReader<TKey, TValue>.Read(
            TimeSpan timeout,
            CancellationToken cancellationToken
        )
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(
                cancellationToken
            );
            cts.CancelAfter(timeout);
            return await Read(_keyDeserializer, _valueDeserializer, cts.Token)
                .ConfigureAwait(false)
            ;
        }

        Task IReader<TKey, TValue>.Close(CancellationToken cancellationToken) =>
            Task.CompletedTask
        ;
    }
}
