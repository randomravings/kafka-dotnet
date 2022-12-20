using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using WritableTxnMarkerPartitionResult = Kafka.Client.Messages.WriteTxnMarkersResponse.WritableTxnMarkerResult.WritableTxnMarkerTopicResult.WritableTxnMarkerPartitionResult;
using WritableTxnMarkerTopicResult = Kafka.Client.Messages.WriteTxnMarkersResponse.WritableTxnMarkerResult.WritableTxnMarkerTopicResult;
using WritableTxnMarkerResult = Kafka.Client.Messages.WriteTxnMarkersResponse.WritableTxnMarkerResult;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="MarkersField">The results for writing makers.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record WriteTxnMarkersResponse (
        ImmutableArray<WritableTxnMarkerResult> MarkersField
    ) : Response(27)
    {
        public static WriteTxnMarkersResponse Empty { get; } = new(
            ImmutableArray<WritableTxnMarkerResult>.Empty
        );
        /// <summary>
        /// <param name="ProducerIdField">The current producer ID in use by the transactional ID.</param>
        /// <param name="TopicsField">The results by topic.</param>
        /// </summary>
        public sealed record WritableTxnMarkerResult (
            long ProducerIdField,
            ImmutableArray<WritableTxnMarkerTopicResult> TopicsField
        )
        {
            public static WritableTxnMarkerResult Empty { get; } = new(
                default(long),
                ImmutableArray<WritableTxnMarkerTopicResult>.Empty
            );
            /// <summary>
            /// <param name="NameField">The topic name.</param>
            /// <param name="PartitionsField">The results by partition.</param>
            /// </summary>
            public sealed record WritableTxnMarkerTopicResult (
                string NameField,
                ImmutableArray<WritableTxnMarkerPartitionResult> PartitionsField
            )
            {
                public static WritableTxnMarkerTopicResult Empty { get; } = new(
                    "",
                    ImmutableArray<WritableTxnMarkerPartitionResult>.Empty
                );
                /// <summary>
                /// <param name="PartitionIndexField">The partition index.</param>
                /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
                /// </summary>
                public sealed record WritableTxnMarkerPartitionResult (
                    int PartitionIndexField,
                    short ErrorCodeField
                )
                {
                    public static WritableTxnMarkerPartitionResult Empty { get; } = new(
                        default(int),
                        default(short)
                    );
                };
            };
        };
    };
}