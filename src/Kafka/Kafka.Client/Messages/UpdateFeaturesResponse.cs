using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using UpdatableFeatureResult = Kafka.Client.Messages.UpdateFeaturesResponse.UpdatableFeatureResult;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The top-level error code, or `0` if there was no top-level error.</param>
    /// <param name="ErrorMessageField">The top-level error message, or `null` if there was no top-level error.</param>
    /// <param name="ResultsField">Results for each feature update.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record UpdateFeaturesResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string? ErrorMessageField,
        ImmutableArray<UpdatableFeatureResult> ResultsField
    ) : Response(57)
    {
        public static UpdateFeaturesResponse Empty { get; } = new(
            default(int),
            default(short),
            default(string?),
            ImmutableArray<UpdatableFeatureResult>.Empty
        );
        public static short FlexibleVersion { get; } = 0;
        /// <summary>
        /// <param name="FeatureField">The name of the finalized feature.</param>
        /// <param name="ErrorCodeField">The feature update error code or `0` if the feature update succeeded.</param>
        /// <param name="ErrorMessageField">The feature update error, or `null` if the feature update succeeded.</param>
        /// </summary>
        public sealed record UpdatableFeatureResult (
            string FeatureField,
            short ErrorCodeField,
            string? ErrorMessageField
        )
        {
            public static UpdatableFeatureResult Empty { get; } = new(
                "",
                default(short),
                default(string?)
            );
        };
    };
}