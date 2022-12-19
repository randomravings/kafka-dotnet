using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using CreatableTopicResult = Kafka.Client.Messages.CreateTopicsResponse.CreatableTopicResult;
using CreatableTopicConfigs = Kafka.Client.Messages.CreateTopicsResponse.CreatableTopicResult.CreatableTopicConfigs;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="TopicsField">Results for each topic we tried to create.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreateTopicsResponse (
        int ThrottleTimeMsField,
        ImmutableArray<CreatableTopicResult> TopicsField
    ) : Response(19)
    {
        public static CreateTopicsResponse Empty { get; } = new(
            default(int),
            ImmutableArray<CreatableTopicResult>.Empty
        );
        public static short FlexibleVersion { get; } = 5;
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
        public sealed record CreatableTopicResult (
            string NameField,
            Guid TopicIdField,
            short ErrorCodeField,
            string? ErrorMessageField,
            short TopicConfigErrorCodeField,
            int NumPartitionsField,
            short ReplicationFactorField,
            ImmutableArray<CreatableTopicConfigs>? ConfigsField
        )
        {
            public static CreatableTopicResult Empty { get; } = new(
                "",
                default(Guid),
                default(short),
                default(string?),
                default(short),
                default(int),
                default(short),
                default(ImmutableArray<CreatableTopicConfigs>?)
            );
            /// <summary>
            /// <param name="NameField">The configuration name.</param>
            /// <param name="ValueField">The configuration value.</param>
            /// <param name="ReadOnlyField">True if the configuration is read-only.</param>
            /// <param name="ConfigSourceField">The configuration source.</param>
            /// <param name="IsSensitiveField">True if this configuration is sensitive.</param>
            /// </summary>
            public sealed record CreatableTopicConfigs (
                string NameField,
                string? ValueField,
                bool ReadOnlyField,
                sbyte ConfigSourceField,
                bool IsSensitiveField
            )
            {
                public static CreatableTopicConfigs Empty { get; } = new(
                    "",
                    default(string?),
                    default(bool),
                    default(sbyte),
                    default(bool)
                );
            };
        };
    };
}