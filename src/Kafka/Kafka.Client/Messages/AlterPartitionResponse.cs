using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using PartitionData = Kafka.Client.Messages.AlterPartitionResponse.TopicData.PartitionData;
using TopicData = Kafka.Client.Messages.AlterPartitionResponse.TopicData;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The top level response error code</param>
    /// <param name="TopicsField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterPartitionResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        ImmutableArray<TopicData> TopicsField
    ) : Response(56)
    {
        public static AlterPartitionResponse Empty { get; } = new(
            default(int),
            default(short),
            ImmutableArray<TopicData>.Empty
        );
        /// <summary>
        /// <param name="TopicNameField">The name of the topic</param>
        /// <param name="TopicIdField">The ID of the topic</param>
        /// <param name="PartitionsField"></param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record TopicData (
            string TopicNameField,
            Guid TopicIdField,
            ImmutableArray<PartitionData> PartitionsField
        )
        {
            public static TopicData Empty { get; } = new(
                "",
                default(Guid),
                ImmutableArray<PartitionData>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index</param>
            /// <param name="ErrorCodeField">The partition level error code</param>
            /// <param name="LeaderIdField">The broker ID of the leader.</param>
            /// <param name="LeaderEpochField">The leader epoch.</param>
            /// <param name="IsrField">The in-sync replica IDs.</param>
            /// <param name="LeaderRecoveryStateField">1 if the partition is recovering from an unclean leader election; 0 otherwise.</param>
            /// <param name="PartitionEpochField">The current epoch for the partition for KRaft controllers. The current ZK version for the legacy controllers.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            public sealed record PartitionData (
                int PartitionIndexField,
                short ErrorCodeField,
                int LeaderIdField,
                int LeaderEpochField,
                ImmutableArray<int> IsrField,
                sbyte LeaderRecoveryStateField,
                int PartitionEpochField
            )
            {
                public static PartitionData Empty { get; } = new(
                    default(int),
                    default(short),
                    default(int),
                    default(int),
                    ImmutableArray<int>.Empty,
                    default(sbyte),
                    default(int)
                );
            };
        };
    };
}