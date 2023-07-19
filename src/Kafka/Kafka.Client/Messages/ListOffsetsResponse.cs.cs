using Kafka.Common.Model;
using ListOffsetsPartitionResponse = Kafka.Client.Messages.ListOffsetsResponse.ListOffsetsTopicResponse.ListOffsetsPartitionResponse;
using ListOffsetsTopicResponse = Kafka.Client.Messages.ListOffsetsResponse.ListOffsetsTopicResponse;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="TopicsField">Each topic in the response.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ListOffsetsResponse (
        int ThrottleTimeMsField,
        ImmutableArray<ListOffsetsTopicResponse> TopicsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : IResponse
    {
        public static ListOffsetsResponse Empty { get; } = new(
            default(int),
            ImmutableArray<ListOffsetsTopicResponse>.Empty,
            ImmutableArray<TaggedField>.Empty

        );
        /// <summary>
        /// <param name="NameField">The topic name</param>
        /// <param name="PartitionsField">Each partition in the response.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record ListOffsetsTopicResponse (
            string NameField,
            ImmutableArray<ListOffsetsPartitionResponse> PartitionsField,
            ImmutableArray<TaggedField> TaggedFields
        ) : IResponse
        {
            public static ListOffsetsTopicResponse Empty { get; } = new(
                "",
                ImmutableArray<ListOffsetsPartitionResponse>.Empty,
                ImmutableArray<TaggedField>.Empty

            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="ErrorCodeField">The partition error code, or 0 if there was no error.</param>
            /// <param name="OldStyleOffsetsField">The result offsets.</param>
            /// <param name="TimestampField">The timestamp associated with the returned offset.</param>
            /// <param name="OffsetField">The returned offset.</param>
            /// <param name="LeaderEpochField"></param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            public sealed record ListOffsetsPartitionResponse (
                int PartitionIndexField,
                short ErrorCodeField,
                ImmutableArray<long> OldStyleOffsetsField,
                long TimestampField,
                long OffsetField,
                int LeaderEpochField,
                ImmutableArray<TaggedField> TaggedFields
            ) : IResponse
            {
                public static ListOffsetsPartitionResponse Empty { get; } = new(
                    default(int),
                    default(short),
                    ImmutableArray<long>.Empty,
                    default(long),
                    default(long),
                    default(int),
                    ImmutableArray<TaggedField>.Empty

                );
            };
        };
    };
}