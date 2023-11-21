using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using SupportedFeatureKey = Kafka.Client.Messages.ApiVersionsResponseData.SupportedFeatureKey;
using ApiVersion = Kafka.Client.Messages.ApiVersionsResponseData.ApiVersion;
using FinalizedFeatureKey = Kafka.Client.Messages.ApiVersionsResponseData.FinalizedFeatureKey;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ErrorCodeField">The top-level error code.</param>
    /// <param name="ApiKeysField">The APIs supported by the broker.</param>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="SupportedFeaturesField">Features supported by the broker.</param>
    /// <param name="FinalizedFeaturesEpochField">The monotonically increasing epoch for the finalized features information. Valid values are >= 0. A value of -1 is special and represents unknown epoch.</param>
    /// <param name="FinalizedFeaturesField">List of cluster-wide finalized features. The information is valid only if FinalizedFeaturesEpoch >= 0.</param>
    /// <param name="ZkMigrationReadyField">Set by a KRaft controller if the required configurations for ZK migration are present</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ApiVersionsResponseData (
        short ErrorCodeField,
        ImmutableArray<ApiVersion> ApiKeysField,
        int ThrottleTimeMsField,
        ImmutableArray<SupportedFeatureKey> SupportedFeaturesField,
        long FinalizedFeaturesEpochField,
        ImmutableArray<FinalizedFeatureKey> FinalizedFeaturesField,
        bool ZkMigrationReadyField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        public static ApiVersionsResponseData Empty { get; } = new(
            default(short),
            ImmutableArray<ApiVersion>.Empty,
            default(int),
            ImmutableArray<SupportedFeatureKey>.Empty,
            default(long),
            ImmutableArray<FinalizedFeatureKey>.Empty,
            default(bool),
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="ApiKeyField">The API index.</param>
        /// <param name="MinVersionField">The minimum supported version, inclusive.</param>
        /// <param name="MaxVersionField">The maximum supported version, inclusive.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record ApiVersion (
            short ApiKeyField,
            short MinVersionField,
            short MaxVersionField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static ApiVersion Empty { get; } = new(
                default(short),
                default(short),
                default(short),
                ImmutableArray<TaggedField>.Empty
            );
        };
        /// <summary>
        /// <param name="NameField">The name of the feature.</param>
        /// <param name="MaxVersionLevelField">The cluster-wide finalized max version level for the feature.</param>
        /// <param name="MinVersionLevelField">The cluster-wide finalized min version level for the feature.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record FinalizedFeatureKey (
            string NameField,
            short MaxVersionLevelField,
            short MinVersionLevelField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static FinalizedFeatureKey Empty { get; } = new(
                "",
                default(short),
                default(short),
                ImmutableArray<TaggedField>.Empty
            );
        };
        /// <summary>
        /// <param name="NameField">The name of the feature.</param>
        /// <param name="MinVersionField">The minimum supported version for the feature.</param>
        /// <param name="MaxVersionField">The maximum supported version for the feature.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record SupportedFeatureKey (
            string NameField,
            short MinVersionField,
            short MaxVersionField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static SupportedFeatureKey Empty { get; } = new(
                "",
                default(short),
                default(short),
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
