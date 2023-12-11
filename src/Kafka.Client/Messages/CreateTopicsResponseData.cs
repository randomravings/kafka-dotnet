using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using CreatableTopicConfigs = Kafka.Client.Messages.CreateTopicsResponseData.CreatableTopicResult.CreatableTopicConfigs;
using CreatableTopicResult = Kafka.Client.Messages.CreateTopicsResponseData.CreatableTopicResult;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="TopicsField">Results for each topic we tried to create.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record CreateTopicsResponseData (
        int ThrottleTimeMsField,
        ImmutableArray<CreatableTopicResult> TopicsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        internal static CreateTopicsResponseData Empty { get; } = new(
            default(int),
            ImmutableArray<CreatableTopicResult>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="TopicIdField">The unique topic ID</param>
        /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
        /// <param name="ErrorMessageField">The error message, or null if there was no error.</param>
        /// <param name="TopicConfigErrorCodeField">Optional topic config error returned if configs are not returned in the response.</param>
        /// <param name="NumPartitionsField">Number of partitions of the topic.</param>
        /// <param name="ReplicationFactorField">Replication factor of the topic.</param>
        /// <param name="ConfigsField">Configuration of the topic.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record CreatableTopicResult (
            string NameField,
            Guid TopicIdField,
            short ErrorCodeField,
            string? ErrorMessageField,
            short TopicConfigErrorCodeField,
            int NumPartitionsField,
            short ReplicationFactorField,
            ImmutableArray<CreatableTopicConfigs> ConfigsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static CreatableTopicResult Empty { get; } = new(
                "",
                default(Guid),
                default(short),
                default(string?),
                default(short),
                default(int),
                default(short),
                default(ImmutableArray<CreatableTopicConfigs>),
                ImmutableArray<TaggedField>.Empty
            );
            /// <summary>
            /// <param name="NameField">The configuration name.</param>
            /// <param name="ValueField">The configuration value.</param>
            /// <param name="ReadOnlyField">True if the configuration is read-only.</param>
            /// <param name="ConfigSourceField">The configuration source.</param>
            /// <param name="IsSensitiveField">True if this configuration is sensitive.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            internal sealed record CreatableTopicConfigs (
                string NameField,
                string? ValueField,
                bool ReadOnlyField,
                sbyte ConfigSourceField,
                bool IsSensitiveField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                internal static CreatableTopicConfigs Empty { get; } = new(
                    "",
                    default(string?),
                    default(bool),
                    default(sbyte),
                    default(bool),
                    ImmutableArray<TaggedField>.Empty
                );
            };
        };
    };
}
