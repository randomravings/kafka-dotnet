using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using SupportedFeatureKey = Kafka.Client.Messages.ApiVersionsResponse.SupportedFeatureKey;
using ApiVersion = Kafka.Client.Messages.ApiVersionsResponse.ApiVersion;
using FinalizedFeatureKey = Kafka.Client.Messages.ApiVersionsResponse.FinalizedFeatureKey;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ErrorCodeField">The top-level error code.</param>
    /// <param name="ApiKeysField">The APIs supported by the broker.</param>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="SupportedFeaturesField">Features supported by the broker.</param>
    /// <param name="FinalizedFeaturesEpochField">The monotonically increasing epoch for the finalized features information. Valid values are >= 0. A value of -1 is special and represents unknown epoch.</param>
    /// <param name="FinalizedFeaturesField">List of cluster-wide finalized features. The information is valid only if FinalizedFeaturesEpoch >= 0.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ApiVersionsResponse (
        short ErrorCodeField,
        ImmutableArray<ApiVersion> ApiKeysField,
        int ThrottleTimeMsField,
        ImmutableArray<SupportedFeatureKey> SupportedFeaturesField,
        long FinalizedFeaturesEpochField,
        ImmutableArray<FinalizedFeatureKey> FinalizedFeaturesField
    ) : Response(18)
    {
        public static ApiVersionsResponse Empty { get; } = new(
            default(short),
            ImmutableArray<ApiVersion>.Empty,
            default(int),
            ImmutableArray<SupportedFeatureKey>.Empty,
            default(long),
            ImmutableArray<FinalizedFeatureKey>.Empty
        );
        /// <summary>
        /// <param name="NameField">The name of the feature.</param>
        /// <param name="MinVersionField">The minimum supported version for the feature.</param>
        /// <param name="MaxVersionField">The maximum supported version for the feature.</param>
        /// </summary>
        public sealed record SupportedFeatureKey (
            string NameField,
            short MinVersionField,
            short MaxVersionField
        )
        {
            public static SupportedFeatureKey Empty { get; } = new(
                "",
                default(short),
                default(short)
            );
        };
        /// <summary>
        /// <param name="ApiKeyField">The API index.</param>
        /// <param name="MinVersionField">The minimum supported version, inclusive.</param>
        /// <param name="MaxVersionField">The maximum supported version, inclusive.</param>
        /// </summary>
        public sealed record ApiVersion (
            short ApiKeyField,
            short MinVersionField,
            short MaxVersionField
        )
        {
            public static ApiVersion Empty { get; } = new(
                default(short),
                default(short),
                default(short)
            );
        };
        /// <summary>
        /// <param name="NameField">The name of the feature.</param>
        /// <param name="MaxVersionLevelField">The cluster-wide finalized max version level for the feature.</param>
        /// <param name="MinVersionLevelField">The cluster-wide finalized min version level for the feature.</param>
        /// </summary>
        public sealed record FinalizedFeatureKey (
            string NameField,
            short MaxVersionLevelField,
            short MinVersionLevelField
        )
        {
            public static FinalizedFeatureKey Empty { get; } = new(
                "",
                default(short),
                default(short)
            );
        };
    };
}