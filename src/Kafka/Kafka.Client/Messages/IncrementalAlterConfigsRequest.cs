using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using AlterConfigsResource = Kafka.Client.Messages.IncrementalAlterConfigsRequest.AlterConfigsResource;
using AlterableConfig = Kafka.Client.Messages.IncrementalAlterConfigsRequest.AlterConfigsResource.AlterableConfig;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ResourcesField">The incremental updates for each resource.</param>
    /// <param name="ValidateOnlyField">True if we should validate the request, but not change the configurations.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record IncrementalAlterConfigsRequest (
        ImmutableArray<AlterConfigsResource> ResourcesField,
        bool ValidateOnlyField
    ) : Request(44,0,1,1)
    {
        public static IncrementalAlterConfigsRequest Empty { get; } = new(
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
            /// <param name="ConfigOperationField">The type (Set, Delete, Append, Subtract) of operation.</param>
            /// <param name="ValueField">The value to set for the configuration key.</param>
            /// </summary>
            public sealed record AlterableConfig (
                string NameField,
                sbyte ConfigOperationField,
                string? ValueField
            )
            {
                public static AlterableConfig Empty { get; } = new(
                    "",
                    default(sbyte),
                    default(string?)
                );
            };
        };
    };
}