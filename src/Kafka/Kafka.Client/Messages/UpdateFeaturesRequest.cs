using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record UpdateFeaturesRequest (
        int timeoutMsField,
        UpdateFeaturesRequest.FeatureUpdateKey[] FeatureUpdatesField,
        bool ValidateOnlyField
    )
    {
        public sealed record FeatureUpdateKey (
            string FeatureField,
            short MaxVersionLevelField,
            bool AllowDowngradeField,
            sbyte UpgradeTypeField
        );
    };
}
