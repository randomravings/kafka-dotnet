using System.CodeDom.Compiler;
using System.Collections.Immutable;
using ValueData = Kafka.Client.Messages.DescribeClientQuotasResponse.EntryData.ValueData;
using EntryData = Kafka.Client.Messages.DescribeClientQuotasResponse.EntryData;
using EntityData = Kafka.Client.Messages.DescribeClientQuotasResponse.EntryData.EntityData;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or `0` if the quota description succeeded.</param>
    /// <param name="ErrorMessageField">The error message, or `null` if the quota description succeeded.</param>
    /// <param name="EntriesField">A result entry.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeClientQuotasResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string? ErrorMessageField,
        ImmutableArray<EntryData>? EntriesField
    )
    {
        public static DescribeClientQuotasResponse Empty { get; } = new(
            default(int),
            default(short),
            default(string?),
            default(ImmutableArray<EntryData>?)
        );
        /// <summary>
        /// <param name="EntityField">The quota entity description.</param>
        /// <param name="ValuesField">The quota values for the entity.</param>
        /// </summary>
        public sealed record EntryData (
            ImmutableArray<EntityData> EntityField,
            ImmutableArray<ValueData> ValuesField
        )
        {
            public static EntryData Empty { get; } = new(
                ImmutableArray<EntityData>.Empty,
                ImmutableArray<ValueData>.Empty
            );
            /// <summary>
            /// <param name="KeyField">The quota configuration key.</param>
            /// <param name="ValueField">The quota configuration value.</param>
            /// </summary>
            public sealed record ValueData (
                string KeyField,
                double ValueField
            )
            {
                public static ValueData Empty { get; } = new(
                    "",
                    default(double)
                );
            };
            /// <summary>
            /// <param name="EntityTypeField">The entity type.</param>
            /// <param name="EntityNameField">The entity name, or null if the default.</param>
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