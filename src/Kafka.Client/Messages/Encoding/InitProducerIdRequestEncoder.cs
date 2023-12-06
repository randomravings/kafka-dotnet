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
    internal class InitProducerIdRequestEncoder : 
        RequestEncoder<RequestHeaderData, InitProducerIdRequestData>
    {
        internal InitProducerIdRequestEncoder() :
            base(
                ApiKey.InitProducerId,
                new(0, 4),
                new(2, 32767),
                RequestHeaderEncoder.WriteV0,
                WriteV0
            )
        { }
        protected override EncodeValue<RequestHeaderData> GetHeaderEncoder(short apiVersion)
        {
            if (FlexibleVersions.Includes(apiVersion))
                return RequestHeaderEncoder.WriteV2;
            else
                return RequestHeaderEncoder.WriteV1;
        }
        protected override EncodeValue<InitProducerIdRequestData> GetMessageEncoder(short apiVersion) =>
            apiVersion switch
            {
                0 => WriteV0,
                1 => WriteV1,
                2 => WriteV2,
                3 => WriteV3,
                4 => WriteV4,
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in InitProducerIdRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteNullableString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TransactionTimeoutMsField);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in InitProducerIdRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteNullableString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TransactionTimeoutMsField);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in InitProducerIdRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TransactionTimeoutMsField);
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
        private static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in InitProducerIdRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TransactionTimeoutMsField);
            i = BinaryEncoder.WriteInt64(buffer, i, message.ProducerIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.ProducerEpochField);
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
        private static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in InitProducerIdRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TransactionTimeoutMsField);
            i = BinaryEncoder.WriteInt64(buffer, i, message.ProducerIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.ProducerEpochField);
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
