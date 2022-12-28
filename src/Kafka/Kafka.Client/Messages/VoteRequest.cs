using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using TopicData = Kafka.Client.Messages.VoteRequest.TopicData;
using PartitionData = Kafka.Client.Messages.VoteRequest.TopicData.PartitionData;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ClusterIdField"></param>
    /// <param name="TopicsField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record VoteRequest (
        string? ClusterIdField,
        ImmutableArray<TopicData> TopicsField
    ) : Request(52,0,0,0)
    {
        public static VoteRequest Empty { get; } = new(
            default(string?),
            ImmutableArray<TopicData>.Empty
        );
        /// <summary>
        /// <param name="TopicNameField">The topic name.</param>
        /// <param name="PartitionsField"></param>
        /// </summary>
        public sealed record TopicData (
            string TopicNameField,
            ImmutableArray<PartitionData> PartitionsField
        )
        {
            public static TopicData Empty { get; } = new(
                "",
                ImmutableArray<PartitionData>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="CandidateEpochField">The bumped epoch of the candidate sending the request</param>
            /// <param name="CandidateIdField">The ID of the voter sending the request</param>
            /// <param name="LastOffsetEpochField">The epoch of the last record written to the metadata log</param>
            /// <param name="LastOffsetField">The offset of the last record written to the metadata log</param>
            /// </summary>
            public sealed record PartitionData (
                int PartitionIndexField,
                int CandidateEpochField,
                int CandidateIdField,
                int LastOffsetEpochField,
                long LastOffsetField
            )
            {
                public static PartitionData Empty { get; } = new(
                    default(int),
                    default(int),
                    default(int),
                    default(int),
                    default(long)
                );
            };
        };
    };
}