using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal static class RequestHeaderEncoder
    {
        internal static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in RequestHeaderData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt16(buffer, i, message.RequestApiKeyField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.RequestApiVersionField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.CorrelationIdField);
            return i;
        }
        internal static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in RequestHeaderData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt16(buffer, i, message.RequestApiKeyField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.RequestApiVersionField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.CorrelationIdField);
            i = BinaryEncoder.WriteNullableString(buffer, i, message.ClientIdField);
            return i;
        }
        internal static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in RequestHeaderData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt16(buffer, i, message.RequestApiKeyField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.RequestApiVersionField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.CorrelationIdField);
            i = BinaryEncoder.WriteNullableString(buffer, i, message.ClientIdField);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
            }
            return i;
        }
    }
}
