using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record UpdateFeaturesResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string ErrorMessageField,
        UpdateFeaturesResponse.UpdatableFeatureResult[] ResultsField
    )
    {
        public sealed record UpdatableFeatureResult (
            string FeatureField,
            short ErrorCodeField,
            string ErrorMessageField
        );
    };
}
