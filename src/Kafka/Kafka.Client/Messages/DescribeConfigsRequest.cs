using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using DescribeConfigsResource = Kafka.Client.Messages.DescribeConfigsRequest.DescribeConfigsResource;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ResourcesField">The resources whose configurations we want to describe.</param>
    /// <param name="IncludeSynonymsField">True if we should include all synonyms.</param>
    /// <param name="IncludeDocumentationField">True if we should include configuration documentation.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeConfigsRequest (
        ImmutableArray<DescribeConfigsResource> ResourcesField,
        bool IncludeSynonymsField,
        bool IncludeDocumentationField
    ) : Request(32)
    {
        public static DescribeConfigsRequest Empty { get; } = new(
            ImmutableArray<DescribeConfigsResource>.Empty,
            default(bool),
            default(bool)
        );
        /// <summary>
        /// <param name="ResourceTypeField">The resource type.</param>
        /// <param name="ResourceNameField">The resource name.</param>
        /// <param name="ConfigurationKeysField">The configuration keys to list, or null to list all configuration keys.</param>
        /// </summary>
        public sealed record DescribeConfigsResource (
            sbyte ResourceTypeField,
            string ResourceNameField,
            ImmutableArray<string>? ConfigurationKeysField
        )
        {
            public static DescribeConfigsResource Empty { get; } = new(
                default(sbyte),
                "",
                default(ImmutableArray<string>?)
            );
        };
    };
}