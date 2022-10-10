using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UpdateFeaturesRequestExtensions
    {
        public static void Write(this UpdateFeaturesRequest message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.timeoutMsField);
            Encoder.WriteArray(buffer, message.FeatureUpdatesField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.FeatureField);
                Encoder.WriteInt16(buffer, i.MaxVersionLevelField);
                Encoder.WriteBoolean(buffer, i.AllowDowngradeField);
                Encoder.WriteInt8(buffer, i.UpgradeTypeField);
                return 0;
            });
            Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
        }
    }
}
