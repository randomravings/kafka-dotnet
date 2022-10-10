using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ApiVersionsResponse (
        short ErrorCodeField,
        ApiVersionsResponse.ApiVersion[] ApiKeysField,
        int ThrottleTimeMsField,
        ApiVersionsResponse.SupportedFeatureKey[] SupportedFeaturesField,
        long FinalizedFeaturesEpochField,
        ApiVersionsResponse.FinalizedFeatureKey[] FinalizedFeaturesField
    )
    {
        public sealed record FinalizedFeatureKey (
            string NameField,
            short MaxVersionLevelField,
            short MinVersionLevelField
        );
        public sealed record SupportedFeatureKey (
            string NameField,
            short MinVersionField,
            short MaxVersionField
        );
        public sealed record ApiVersion (
            short ApiKeyField,
            short MinVersionField,
            short MaxVersionField
        );
    };
}
