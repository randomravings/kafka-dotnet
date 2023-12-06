using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using PartitionProduceResponse = Kafka.Client.Messages.ProduceResponseData.TopicProduceResponse.PartitionProduceResponse;
using TopicProduceResponse = Kafka.Client.Messages.ProduceResponseData.TopicProduceResponse;
using LeaderIdAndEpoch = Kafka.Client.Messages.ProduceResponseData.TopicProduceResponse.PartitionProduceResponse.LeaderIdAndEpoch;
using BatchIndexAndErrorMessage = Kafka.Client.Messages.ProduceResponseData.TopicProduceResponse.PartitionProduceResponse.BatchIndexAndErrorMessage;
using NodeEndpoint = Kafka.Client.Messages.ProduceResponseData.NodeEndpoint;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ResponsesField">Each produce response</param>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="NodeEndpointsField">Endpoints for all current-leaders enumerated in PartitionProduceResponses, with errors NOT_LEADER_OR_FOLLOWER.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record ProduceResponseData (
        ImmutableArray<TopicProduceResponse> ResponsesField,
        int ThrottleTimeMsField,
        ImmutableArray<NodeEndpoint> NodeEndpointsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        internal static ProduceResponseData Empty { get; } = new(
            ImmutableArray<TopicProduceResponse>.Empty,
            default(int),
            ImmutableArray<NodeEndpoint>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="NodeIdField">The ID of the associated node.</param>
        /// <param name="HostField">The node's hostname.</param>
        /// <param name="PortField">The node's port.</param>
        /// <param name="RackField">The rack of the node, or null if it has not been assigned to a rack.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record NodeEndpoint (
            int NodeIdField,
            string HostField,
            int PortField,
            string? RackField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static NodeEndpoint Empty { get; } = new(
                default(int),
                "",
                default(int),
                default(string?),
                ImmutableArray<TaggedField>.Empty
            );
        };
        /// <summary>
        /// <param name="NameField">The topic name</param>
        /// <param name="PartitionResponsesField">Each partition that we produced to within the topic.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record TopicProduceResponse (
            string NameField,
            ImmutableArray<PartitionProduceResponse> PartitionResponsesField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static TopicProduceResponse Empty { get; } = new(
                "",
                ImmutableArray<PartitionProduceResponse>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
            /// <summary>
            /// <param name="IndexField">The partition index.</param>
            /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
            /// <param name="BaseOffsetField">The base offset.</param>
            /// <param name="LogAppendTimeMsField">The timestamp returned by broker after appending the messages. If CreateTime is used for the topic, the timestamp will be -1.  If LogAppendTime is used for the topic, the timestamp will be the broker local time when the messages are appended.</param>
            /// <param name="LogStartOffsetField">The log start offset.</param>
            /// <param name="RecordErrorsField">The batch indices of records that caused the batch to be dropped</param>
            /// <param name="ErrorMessageField">The global error message summarizing the common root cause of the records that caused the batch to be dropped</param>
            /// <param name="CurrentLeaderField"></param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            internal sealed record PartitionProduceResponse (
                int IndexField,
                short ErrorCodeField,
                long BaseOffsetField,
                long LogAppendTimeMsField,
                long LogStartOffsetField,
                ImmutableArray<BatchIndexAndErrorMessage> RecordErrorsField,
                string? ErrorMessageField,
                LeaderIdAndEpoch CurrentLeaderField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                internal static PartitionProduceResponse Empty { get; } = new(
                    default(int),
                    default(short),
                    default(long),
                    default(long),
                    default(long),
                    ImmutableArray<BatchIndexAndErrorMessage>.Empty,
                    default(string?),
                    LeaderIdAndEpoch.Empty,
                    ImmutableArray<TaggedField>.Empty
                );
                /// <summary>
                /// <param name="BatchIndexField">The batch index of the record that cause the batch to be dropped</param>
                /// <param name="BatchIndexErrorMessageField">The error message of the record that caused the batch to be dropped</param>
                /// </summary>
                [GeneratedCode("kgen", "1.0.0.0")]
                internal sealed record BatchIndexAndErrorMessage (
                    int BatchIndexField,
                    string? BatchIndexErrorMessageField,
                    ImmutableArray<TaggedField> TaggedFields
                )
                {
                    internal static BatchIndexAndErrorMessage Empty { get; } = new(
                        default(int),
                        default(string?),
                        ImmutableArray<TaggedField>.Empty
                    );
                };
                /// <summary>
                /// <param name="LeaderIdField">The ID of the current leader or -1 if the leader is unknown.</param>
                /// <param name="LeaderEpochField">The latest known leader epoch</param>
                /// </summary>
                [GeneratedCode("kgen", "1.0.0.0")]
                internal sealed record LeaderIdAndEpoch (
                    int LeaderIdField,
                    int LeaderEpochField,
                    ImmutableArray<TaggedField> TaggedFields
                )
                {
                    internal static LeaderIdAndEpoch Empty { get; } = new(
                        default(int),
                        default(int),
                        ImmutableArray<TaggedField>.Empty
                    );
                };
            };
        };
    };
}
