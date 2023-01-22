using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using PartitionData = Kafka.Client.Messages.AlterPartitionRequest.TopicData.PartitionData;
using TopicData = Kafka.Client.Messages.AlterPartitionRequest.TopicData;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="BrokerIdField">The ID of the requesting broker</param>
    /// <param name="BrokerEpochField">The epoch of the requesting broker</param>
    /// <param name="TopicsField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterPartitionRequest (
        int BrokerIdField,
        long BrokerEpochField,
        ImmutableArray<TopicData> TopicsField
    ) : Request(56,0,2,0)
    {
        public static AlterPartitionRequest Empty { get; } = new(
            default(int),
            default(long),
            ImmutableArray<TopicData>.Empty
        );
        /// <summary>
        /// <param name="TopicNameField">The name of the topic to alter ISRs for</param>
        /// <param name="TopicIdField">The ID of the topic to alter ISRs for</param>
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
            /// <param name="LeaderEpochField">The leader epoch of this partition</param>
            /// <param name="NewIsrField">The ISR for this partition</param>
            /// <param name="LeaderRecoveryStateField">1 if the partition is recovering from an unclean leader election; 0 otherwise.</param>
            /// <param name="PartitionEpochField">The expected epoch of the partition which is being updated. For legacy cluster this is the ZkVersion in the LeaderAndIsr request.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            public sealed record PartitionData (
                int PartitionIndexField,
                int LeaderEpochField,
                ImmutableArray<int> NewIsrField,
                sbyte LeaderRecoveryStateField,
                int PartitionEpochField
            )
            {
                public static PartitionData Empty { get; } = new(
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