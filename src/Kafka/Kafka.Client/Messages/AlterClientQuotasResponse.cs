using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using EntryData = Kafka.Client.Messages.AlterClientQuotasResponse.EntryData;
using EntityData = Kafka.Client.Messages.AlterClientQuotasResponse.EntryData.EntityData;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="EntriesField">The quota configuration entries to alter.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterClientQuotasResponse (
        int ThrottleTimeMsField,
        ImmutableArray<EntryData> EntriesField
    ) : Response(49)
    {
        public static AlterClientQuotasResponse Empty { get; } = new(
            default(int),
            ImmutableArray<EntryData>.Empty
        );
        public static short FlexibleVersion { get; } = 1;
        /// <summary>
        /// <param name="ErrorCodeField">The error code, or `0` if the quota alteration succeeded.</param>
        /// <param name="ErrorMessageField">The error message, or `null` if the quota alteration succeeded.</param>
        /// <param name="EntityField">The quota entity to alter.</param>
        /// </summary>
        public sealed record EntryData (
            short ErrorCodeField,
            string? ErrorMessageField,
            ImmutableArray<EntityData> EntityField
        )
        {
            public static EntryData Empty { get; } = new(
                default(short),
                default(string?),
                ImmutableArray<EntityData>.Empty
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
        };
    };
}