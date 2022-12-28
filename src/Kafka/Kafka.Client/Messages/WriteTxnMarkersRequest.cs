using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using WritableTxnMarkerTopic = Kafka.Client.Messages.WriteTxnMarkersRequest.WritableTxnMarker.WritableTxnMarkerTopic;
using WritableTxnMarker = Kafka.Client.Messages.WriteTxnMarkersRequest.WritableTxnMarker;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="MarkersField">The transaction markers to be written.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record WriteTxnMarkersRequest (
        ImmutableArray<WritableTxnMarker> MarkersField
    ) : Request(27,0,1,1)
    {
        public static WriteTxnMarkersRequest Empty { get; } = new(
            ImmutableArray<WritableTxnMarker>.Empty
        );
        /// <summary>
        /// <param name="ProducerIdField">The current producer ID.</param>
        /// <param name="ProducerEpochField">The current epoch associated with the producer ID.</param>
        /// <param name="TransactionResultField">The result of the transaction to write to the partitions (false = ABORT, true = COMMIT).</param>
        /// <param name="TopicsField">Each topic that we want to write transaction marker(s) for.</param>
        /// <param name="CoordinatorEpochField">Epoch associated with the transaction state partition hosted by this transaction coordinator</param>
        /// </summary>
        public sealed record WritableTxnMarker (
            long ProducerIdField,
            short ProducerEpochField,
            bool TransactionResultField,
            ImmutableArray<WritableTxnMarkerTopic> TopicsField,
            int CoordinatorEpochField
        )
        {
            public static WritableTxnMarker Empty { get; } = new(
                default(long),
                default(short),
                default(bool),
                ImmutableArray<WritableTxnMarkerTopic>.Empty,
                default(int)
            );
            /// <summary>
            /// <param name="NameField">The topic name.</param>
            /// <param name="PartitionIndexesField">The indexes of the partitions to write transaction markers for.</param>
            /// </summary>
            public sealed record WritableTxnMarkerTopic (
                string NameField,
                ImmutableArray<int> PartitionIndexesField
            )
            {
                public static WritableTxnMarkerTopic Empty { get; } = new(
                    "",
                    ImmutableArray<int>.Empty
                );
            };
        };
    };
}