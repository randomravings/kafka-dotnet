using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using EntityData = Kafka.Client.Messages.AlterClientQuotasRequest.EntryData.EntityData;
using OpData = Kafka.Client.Messages.AlterClientQuotasRequest.EntryData.OpData;
using EntryData = Kafka.Client.Messages.AlterClientQuotasRequest.EntryData;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="EntriesField">The quota configuration entries to alter.</param>
    /// <param name="ValidateOnlyField">Whether the alteration should be validated, but not performed.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterClientQuotasRequest (
        ImmutableArray<EntryData> EntriesField,
        bool ValidateOnlyField
    ) : Request(49,0,1,1)
    {
        public static AlterClientQuotasRequest Empty { get; } = new(
            ImmutableArray<EntryData>.Empty,
            default(bool)
        );
        /// <summary>
        /// <param name="EntityField">The quota entity to alter.</param>
        /// <param name="OpsField">An individual quota configuration entry to alter.</param>
        /// </summary>
        public sealed record EntryData (
            ImmutableArray<EntityData> EntityField,
            ImmutableArray<OpData> OpsField
        )
        {
            public static EntryData Empty { get; } = new(
                ImmutableArray<EntityData>.Empty,
                ImmutableArray<OpData>.Empty
            );
            /// <summary>
            /// <param name="EntityTypeField">The entity type.</param>
            /// <param name="EntityNameField">The name of the entity, or null if the default.</param>
            /// </summary>
            public sealed record EntityData (
                string EntityTypeField,
                string? EntityNameField
            )
            {
                public static EntityData Empty { get; } = new(
                    "",
                    default(string?)
                );
            };
            /// <summary>
            /// <param name="KeyField">The quota configuration key.</param>
            /// <param name="ValueField">The value to set, otherwise ignored if the value is to be removed.</param>
            /// <param name="RemoveField">Whether the quota configuration value should be removed, otherwise set.</param>
            /// </summary>
            public sealed record OpData (
                string KeyField,
                double ValueField,
                bool RemoveField
            )
            {
                public static OpData Empty { get; } = new(
                    "",
                    default(double),
                    default(bool)
                );
            };
        };
    };
}