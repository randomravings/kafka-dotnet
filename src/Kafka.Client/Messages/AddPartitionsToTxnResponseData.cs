using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using AddPartitionsToTxnPartitionResult = Kafka.Client.Messages.AddPartitionsToTxnResponseData.AddPartitionsToTxnPartitionResult;
using AddPartitionsToTxnResult = Kafka.Client.Messages.AddPartitionsToTxnResponseData.AddPartitionsToTxnResult;
using AddPartitionsToTxnTopicResult = Kafka.Client.Messages.AddPartitionsToTxnResponseData.AddPartitionsToTxnTopicResult;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The response top level error code.</param>
    /// <param name="ResultsByTransactionField">Results categorized by transactional ID.</param>
    /// <param name="ResultsByTopicV3AndBelowField">The results for each topic.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record AddPartitionsToTxnResponseData (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        ImmutableArray<AddPartitionsToTxnResult> ResultsByTransactionField,
        ImmutableArray<AddPartitionsToTxnTopicResult> ResultsByTopicV3AndBelowField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        internal static AddPartitionsToTxnResponseData Empty { get; } = new(
            default(int),
            default(short),
            ImmutableArray<AddPartitionsToTxnResult>.Empty,
            ImmutableArray<AddPartitionsToTxnTopicResult>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="PartitionIndexField">The partition indexes.</param>
        /// <param name="PartitionErrorCodeField">The response error code.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record AddPartitionsToTxnPartitionResult (
            int PartitionIndexField,
            short PartitionErrorCodeField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static AddPartitionsToTxnPartitionResult Empty { get; } = new(
                default(int),
                default(short),
                ImmutableArray<TaggedField>.Empty
            );
        };
        /// <summary>
        /// <param name="TransactionalIdField">The transactional id corresponding to the transaction.</param>
        /// <param name="TopicResultsField">The results for each topic.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record AddPartitionsToTxnResult (
            string TransactionalIdField,
            ImmutableArray<AddPartitionsToTxnTopicResult> TopicResultsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static AddPartitionsToTxnResult Empty { get; } = new(
                "",
                ImmutableArray<AddPartitionsToTxnTopicResult>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
        };
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="ResultsByPartitionField">The results for each partition</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record AddPartitionsToTxnTopicResult (
            string NameField,
            ImmutableArray<AddPartitionsToTxnPartitionResult> ResultsByPartitionField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static AddPartitionsToTxnTopicResult Empty { get; } = new(
                "",
                ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
