using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using FeatureUpdateKey = Kafka.Client.Messages.UpdateFeaturesRequest.FeatureUpdateKey;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="timeoutMsField">How long to wait in milliseconds before timing out the request.</param>
    /// <param name="FeatureUpdatesField">The list of updates to finalized features.</param>
    /// <param name="ValidateOnlyField">True if we should validate the request, but not perform the upgrade or downgrade.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record UpdateFeaturesRequest (
        int timeoutMsField,
        ImmutableArray<FeatureUpdateKey> FeatureUpdatesField,
        bool ValidateOnlyField
    ) : Request(57,0,1,0)
    {
        public static UpdateFeaturesRequest Empty { get; } = new(
            default(int),
            ImmutableArray<FeatureUpdateKey>.Empty,
            default(bool)
        );
        /// <summary>
        /// <param name="FeatureField">The name of the finalized feature to be updated.</param>
        /// <param name="MaxVersionLevelField">The new maximum version level for the finalized feature. A value >= 1 is valid. A value < 1, is special, and can be used to request the deletion of the finalized feature.</param>
        /// <param name="AllowDowngradeField">DEPRECATED in version 1 (see DowngradeType). When set to true, the finalized feature version level is allowed to be downgraded/deleted. The downgrade request will fail if the new maximum version level is a value that's not lower than the existing maximum finalized version level.</param>
        /// <param name="UpgradeTypeField">Determine which type of upgrade will be performed: 1 will perform an upgrade only (default), 2 is safe downgrades only (lossless), 3 is unsafe downgrades (lossy).</param>
        /// </summary>
        public sealed record FeatureUpdateKey (
            string FeatureField,
            short MaxVersionLevelField,
            bool AllowDowngradeField,
            sbyte UpgradeTypeField
        )
        {
            public static FeatureUpdateKey Empty { get; } = new(
                "",
                default(short),
                default(bool),
                default(sbyte)
            );
        };
    };
}