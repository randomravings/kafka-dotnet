using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public static class RequestHeaderEncoder
    {
        public static int WriteV0(byte[] buffer, int index, RequestHeaderData message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiKeyField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiVersionField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.CorrelationIdField);
            return index;
        }
        public static int WriteV1(byte[] buffer, int index, RequestHeaderData message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiKeyField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiVersionField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.CorrelationIdField);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.ClientIdField);
            return index;
        }
        public static int WriteV2(byte[] buffer, int index, RequestHeaderData message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiKeyField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiVersionField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.CorrelationIdField);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.ClientIdField);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
    }
}
