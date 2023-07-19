using Kafka.Common.Model;
using MetadataRequestTopic = Kafka.Client.Messages.MetadataRequest.MetadataRequestTopic;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TopicsField">The topics to fetch metadata for.</param>
    /// <param name="AllowAutoTopicCreationField">If this is true, the broker may auto-create topics that we requested which do not already exist, if it is configured to do so.</param>
    /// <param name="IncludeClusterAuthorizedOperationsField">Whether to include cluster authorized operations.</param>
    /// <param name="IncludeTopicAuthorizedOperationsField">Whether to include topic authorized operations.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record MetadataRequest (
        ImmutableArray<MetadataRequestTopic>? TopicsField,
        bool AllowAutoTopicCreationField,
        bool IncludeClusterAuthorizedOperationsField,
        bool IncludeTopicAuthorizedOperationsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : IRequest
    {
        public static MetadataRequest Empty { get; } = new(
            default(ImmutableArray<MetadataRequestTopic>?),
            default(bool),
            default(bool),
            default(bool),
            ImmutableArray<TaggedField>.Empty

        );
        /// <summary>
        /// <param name="TopicIdField">The topic id.</param>
        /// <param name="NameField">The topic name.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record MetadataRequestTopic (
            Guid TopicIdField,
            string? NameField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static MetadataRequestTopic Empty { get; } = new(
                default(Guid),
                default(string?),
                ImmutableArray<TaggedField>.Empty

            );
        };
    };
}