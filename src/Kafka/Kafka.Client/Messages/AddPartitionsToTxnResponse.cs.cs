using AddPartitionsToTxnPartitionResult = Kafka.Client.Messages.AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult.AddPartitionsToTxnPartitionResult;
using AddPartitionsToTxnTopicResult = Kafka.Client.Messages.AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult;
using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ResultsField">The results for each topic.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AddPartitionsToTxnResponse (
        int ThrottleTimeMsField,
        ImmutableArray<AddPartitionsToTxnTopicResult> ResultsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : IResponse
    {
        public static AddPartitionsToTxnResponse Empty { get; } = new(
            default(int),
            ImmutableArray<AddPartitionsToTxnTopicResult>.Empty,
            ImmutableArray<TaggedField>.Empty

        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="ResultsField">The results for each partition</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record AddPartitionsToTxnTopicResult (
            string NameField,
            ImmutableArray<AddPartitionsToTxnPartitionResult> ResultsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static AddPartitionsToTxnTopicResult Empty { get; } = new(
                "",
                ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty,
                ImmutableArray<TaggedField>.Empty

            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition indexes.</param>
            /// <param name="ErrorCodeField">The response error code.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            public sealed record AddPartitionsToTxnPartitionResult (
                int PartitionIndexField,
                short ErrorCodeField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                public static AddPartitionsToTxnPartitionResult Empty { get; } = new(
                    default(int),
                    default(short),
                    ImmutableArray<TaggedField>.Empty

                );
            };
        };
    };
}