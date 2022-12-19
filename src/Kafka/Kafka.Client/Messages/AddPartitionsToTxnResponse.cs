using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using AddPartitionsToTxnPartitionResult = Kafka.Client.Messages.AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult.AddPartitionsToTxnPartitionResult;
using AddPartitionsToTxnTopicResult = Kafka.Client.Messages.AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ResultsField">The results for each topic.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AddPartitionsToTxnResponse (
        int ThrottleTimeMsField,
        ImmutableArray<AddPartitionsToTxnTopicResult> ResultsField
    ) : Response(24)
    {
        public static AddPartitionsToTxnResponse Empty { get; } = new(
            default(int),
            ImmutableArray<AddPartitionsToTxnTopicResult>.Empty
        );
        public static short FlexibleVersion { get; } = 3;
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="ResultsField">The results for each partition</param>
        /// </summary>
        public sealed record AddPartitionsToTxnTopicResult (
            string NameField,
            ImmutableArray<AddPartitionsToTxnPartitionResult> ResultsField
        )
        {
            public static AddPartitionsToTxnTopicResult Empty { get; } = new(
                "",
                ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition indexes.</param>
            /// <param name="ErrorCodeField">The response error code.</param>
            /// </summary>
            public sealed record AddPartitionsToTxnPartitionResult (
                int PartitionIndexField,
                short ErrorCodeField
            )
            {
                public static AddPartitionsToTxnPartitionResult Empty { get; } = new(
                    default(int),
                    default(short)
                );
            };
        };
    };
}