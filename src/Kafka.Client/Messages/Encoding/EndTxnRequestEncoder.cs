using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class EndTxnRequestEncoder : 
        RequestEncoder<RequestHeaderData, EndTxnRequestData>
    {
        internal EndTxnRequestEncoder() :
            base(
                ApiKey.EndTxn,
                new(0, 3),
                new(3, 32767),
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
        protected override EncodeValue<EndTxnRequestData> GetMessageEncoder(short apiVersion) =>
            apiVersion switch
            {
                0 => WriteV0,
                1 => WriteV1,
                2 => WriteV2,
                3 => WriteV3,
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in EndTxnRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt64(buffer, i, message.ProducerIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.ProducerEpochField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.CommittedField);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in EndTxnRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt64(buffer, i, message.ProducerIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.ProducerEpochField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.CommittedField);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in EndTxnRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt64(buffer, i, message.ProducerIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.ProducerEpochField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.CommittedField);
            return i;
        }
        private static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in EndTxnRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt64(buffer, i, message.ProducerIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.ProducerEpochField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.CommittedField);
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
