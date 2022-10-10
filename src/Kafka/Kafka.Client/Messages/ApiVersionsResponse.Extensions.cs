using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ApiVersionsResponseExtensions
    {
        public static void Write(this ApiVersionsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray(buffer, message.ApiKeysField, (b, i) =>
            {
                Encoder.WriteInt16(buffer, i.ApiKeyField);
                Encoder.WriteInt16(buffer, i.MinVersionField);
                Encoder.WriteInt16(buffer, i.MaxVersionField);
                return 0;
            });
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.SupportedFeaturesField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteInt16(buffer, i.MinVersionField);
                Encoder.WriteInt16(buffer, i.MaxVersionField);
                return 0;
            });
            Encoder.WriteInt64(buffer, message.FinalizedFeaturesEpochField);
            Encoder.WriteArray(buffer, message.FinalizedFeaturesField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteInt16(buffer, i.MaxVersionLevelField);
                Encoder.WriteInt16(buffer, i.MinVersionLevelField);
                return 0;
            });
        }
    }
}
