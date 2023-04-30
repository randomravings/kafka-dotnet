using Kafka.Client.Messages;
using Kafka.Common.Model;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    internal static class ProducerProtocol
    {
        public static async Task<MetadataResponse> Metadata(
            IConnection connection,
            IEnumerable<TopicName> topicNames,
            CancellationToken cancellationToken
        )
        {
            var request = new MetadataRequest(
                topicNames.Select(r => new MetadataRequest.MetadataRequestTopic(
                        Guid.Empty,
                        r
                    )
                ).ToImmutableArray(),
                true,
                false,
                false
            );
            return await connection.ExecuteRequest(
                request,
                MetadataRequestSerde.Write,
                MetadataResponseSerde.Read,
                cancellationToken
            );
        }

        internal static async Task<FindCoordinatorResponse> FindCoordinator(
            IConnection connection,
            ProducerConfig config,
            ILogger logger,
            CancellationToken cancellationToken
        )
        {
            var groupId = config.TransactionalId ?? "";
            var request = new FindCoordinatorRequest(
                groupId,
                (sbyte)CoordinatorType.TRANSACTION,
                new[] { groupId }.ToImmutableArray()
            );
            return await RetryHandler.Run(
                connection,
                request,
                FindCoordinatorRequestSerde.Write,
                FindCoordinatorResponseSerde.Read,
                config.Retries,
                config.RetryBackoffMs,
                GetErrorCode,
                (l, e) => l.LogError("{error}", e),
                logger,
                cancellationToken
            );
        }

        public static async Task<ProduceResponse> Produce(
            IConnection connection,
            ProduceRequest request,
            ProducerConfig config,
            ILogger logger,
            CancellationToken cancellationToken
        )
        {
            return await RetryHandler.Run(
                connection,
                request,
                ProduceRequestSerde.Write,
                ProduceResponseSerde.Read,
                config.Retries,
                config.RetryBackoffMs,
                r => 0,
                (l, e) => l.LogError("{error}", e),
                logger,
                cancellationToken
            );
        }

        public static async Task ProduceNoAck(
            IConnection connection,
            ProduceRequest request,
            ProducerConfig config,
            ILogger logger,
            CancellationToken cancellationToken
        )
        {
            await RetryHandler.RunOnWay(
                connection,
                request,
                ProduceRequestSerde.Write,
                config.Retries,
                config.RetryBackoffMs,
                logger,
                cancellationToken
            );
        }

        internal static async Task<InitProducerIdResponse> InitProducerId(
            IConnection connection,
            string transactionalId,
            int transactionTimeoutMs,
            long producerId,
            short producerEpoch,
            CancellationToken cancellationToken
        )
        {
            var initProducerIdRequest = new InitProducerIdRequest(
                transactionalId,
                transactionTimeoutMs,
                producerId,
                producerEpoch
            );
            return await connection.ExecuteRequest(
                initProducerIdRequest,
                InitProducerIdRequestSerde.Write,
                InitProducerIdResponseSerde.Read,
                cancellationToken
            );
        }

        private static short GetErrorCode(FindCoordinatorResponse findCoordinatorResponse)
        {
            if (findCoordinatorResponse.ErrorCodeField != 0)
                return findCoordinatorResponse.ErrorCodeField;
            return
                findCoordinatorResponse.CoordinatorsField.Select(r => r.ErrorCodeField).FirstOrDefault((short)0);
        }
    }
}
