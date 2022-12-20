using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using AlterConfigsResource = Kafka.Client.Messages.AlterConfigsRequest.AlterConfigsResource;
using AlterableConfig = Kafka.Client.Messages.AlterConfigsRequest.AlterConfigsResource.AlterableConfig;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ResourcesField">The updates for each resource.</param>
    /// <param name="ValidateOnlyField">True if we should validate the request, but not change the configurations.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterConfigsRequest (
        ImmutableArray<AlterConfigsResource> ResourcesField,
        bool ValidateOnlyField
    ) : Request(33,0,2,2)
    {
        public static AlterConfigsRequest Empty { get; } = new(
            ImmutableArray<AlterConfigsResource>.Empty,
            default(bool)
        );
        /// <summary>
        /// <param name="ResourceTypeField">The resource type.</param>
        /// <param name="ResourceNameField">The resource name.</param>
        /// <param name="ConfigsField">The configurations.</param>
        /// </summary>
        public sealed record AlterConfigsResource (
            sbyte ResourceTypeField,
            string ResourceNameField,
            ImmutableArray<AlterableConfig> ConfigsField
        )
        {
            public static AlterConfigsResource Empty { get; } = new(
                default(sbyte),
                "",
                ImmutableArray<AlterableConfig>.Empty
            );
            /// <summary>
            /// <param name="NameField">The configuration key name.</param>
            /// <param name="ValueField">The value to set for the configuration key.</param>
            /// </summary>
            public sealed record AlterableConfig (
                string NameField,
                string? ValueField
            )
            {
                public static AlterableConfig Empty { get; } = new(
                    "",
                    default(string?)
                );
            };
        };
    };
}