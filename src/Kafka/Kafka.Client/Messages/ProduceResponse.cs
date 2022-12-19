using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using BatchIndexAndErrorMessage = Kafka.Client.Messages.ProduceResponse.TopicProduceResponse.PartitionProduceResponse.BatchIndexAndErrorMessage;
using PartitionProduceResponse = Kafka.Client.Messages.ProduceResponse.TopicProduceResponse.PartitionProduceResponse;
using TopicProduceResponse = Kafka.Client.Messages.ProduceResponse.TopicProduceResponse;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ResponsesField">Each produce response</param>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ProduceResponse (
        ImmutableArray<TopicProduceResponse> ResponsesField,
        int ThrottleTimeMsField
    ) : Response(0)
    {
        public static ProduceResponse Empty { get; } = new(
            ImmutableArray<TopicProduceResponse>.Empty,
            default(int)
        );
        public static short FlexibleVersion { get; } = 9;
        /// <summary>
        /// <param name="NameField">The topic name</param>
        /// <param name="PartitionResponsesField">Each partition that we produced to within the topic.</param>
        /// </summary>
        public sealed record TopicProduceResponse (
            string NameField,
            ImmutableArray<PartitionProduceResponse> PartitionResponsesField
        )
        {
            public static TopicProduceResponse Empty { get; } = new(
                "",
                ImmutableArray<PartitionProduceResponse>.Empty
            );
            /// <summary>
            /// <param name="IndexField">The partition index.</param>
            /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
            /// <param name="BaseOffsetField">The base offset.</param>
            /// <param name="LogAppendTimeMsField">The timestamp returned by broker after appending the messages. If CreateTime is used for the topic, the timestamp will be -1.  If LogAppendTime is used for the topic, the timestamp will be the broker local time when the messages are appended.</param>
            /// <param name="LogStartOffsetField">The log start offset.</param>
            /// <param name="RecordErrorsField">The batch indices of records that caused the batch to be dropped</param>
            /// <param name="ErrorMessageField">The global error message summarizing the common root cause of the records that caused the batch to be dropped</param>
            /// </summary>
            public sealed record PartitionProduceResponse (
                int IndexField,
                short ErrorCodeField,
                long BaseOffsetField,
                long LogAppendTimeMsField,
                long LogStartOffsetField,
                ImmutableArray<BatchIndexAndErrorMessage> RecordErrorsField,
                string? ErrorMessageField
            )
            {
                public static PartitionProduceResponse Empty { get; } = new(
                    default(int),
                    default(short),
                    default(long),
                    default(long),
                    default(long),
                    ImmutableArray<BatchIndexAndErrorMessage>.Empty,
                    default(string?)
                );
                /// <summary>
                /// <param name="BatchIndexField">The batch index of the record that cause the batch to be dropped</param>
                /// <param name="BatchIndexErrorMessageField">The error message of the record that caused the batch to be dropped</param>
                /// </summary>
                public sealed record BatchIndexAndErrorMessage (
                    int BatchIndexField,
                    string? BatchIndexErrorMessageField
                )
                {
                    public static BatchIndexAndErrorMessage Empty { get; } = new(
                        default(int),
                        default(string?)
                    );
                };
            };
        };
    };
}