using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using ProducerState = Kafka.Client.Messages.DescribeProducersResponse.TopicResponse.PartitionResponse.ProducerState;
using TopicResponse = Kafka.Client.Messages.DescribeProducersResponse.TopicResponse;
using PartitionResponse = Kafka.Client.Messages.DescribeProducersResponse.TopicResponse.PartitionResponse;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="TopicsField">Each topic in the response.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeProducersResponse (
        int ThrottleTimeMsField,
        ImmutableArray<TopicResponse> TopicsField
    ) : Response(61)
    {
        public static DescribeProducersResponse Empty { get; } = new(
            default(int),
            ImmutableArray<TopicResponse>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name</param>
        /// <param name="PartitionsField">Each partition in the response.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record TopicResponse (
            string NameField,
            ImmutableArray<PartitionResponse> PartitionsField
        )
        {
            public static TopicResponse Empty { get; } = new(
                "",
                ImmutableArray<PartitionResponse>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="ErrorCodeField">The partition error code, or 0 if there was no error.</param>
            /// <param name="ErrorMessageField">The partition error message, which may be null if no additional details are available</param>
            /// <param name="ActiveProducersField"></param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            public sealed record PartitionResponse (
                int PartitionIndexField,
                short ErrorCodeField,
                string? ErrorMessageField,
                ImmutableArray<ProducerState> ActiveProducersField
            )
            {
                public static PartitionResponse Empty { get; } = new(
                    default(int),
                    default(short),
                    default(string?),
                    ImmutableArray<ProducerState>.Empty
                );
                /// <summary>
                /// <param name="ProducerIdField"></param>
                /// <param name="ProducerEpochField"></param>
                /// <param name="LastSequenceField"></param>
                /// <param name="LastTimestampField"></param>
                /// <param name="CoordinatorEpochField"></param>
                /// <param name="CurrentTxnStartOffsetField"></param>
                /// </summary>
                [GeneratedCode("kgen", "1.0.0.0")]
                public sealed record ProducerState (
                    long ProducerIdField,
                    int ProducerEpochField,
                    int LastSequenceField,
                    long LastTimestampField,
                    int CoordinatorEpochField,
                    long CurrentTxnStartOffsetField
                )
                {
                    public static ProducerState Empty { get; } = new(
                        default(long),
                        default(int),
                        default(int),
                        default(long),
                        default(int),
                        default(long)
                    );
                };
            };
        };
    };
}