using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ResponseHeaderSerde
    {
        public static EncodeDelegate<ResponseHeader> CreateEncoder(bool flexible) =>
            flexible ? WriteV1 : WriteV0
        ;
        public static DecodeDelegate<ResponseHeader> CreateDecoder(bool flexible) =>
            flexible ? ReadV1 : ReadV0
        ;
        private static int WriteV0(byte[] buffer, int index, ResponseHeader message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.CorrelationIdField);
            return index;
        }
        private static (int Offset, ResponseHeader Value) ReadV0(byte[] buffer, int index)
        {
            var correlationIdField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, correlationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                correlationIdField,
                taggedFields
            ));
        }
        private static int WriteUntaggedV0(byte[] buffer, int index, ResponseHeader message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.CorrelationIdField);
            return index;
        }
        private static (int Offset, ResponseHeader Value) ReadUntaggedV0(byte[] buffer, int index)
        {
            var correlationIdField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, correlationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                correlationIdField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, ResponseHeader message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.CorrelationIdField);
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
        private static (int Offset, ResponseHeader Value) ReadV1(byte[] buffer, int index)
        {
            var correlationIdField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, correlationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if(taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                    (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                    taggedFieldsBuilder.Add(new(tag, bytes));
                    taggedFieldsCount--;
                }
            }
            return (index, new(
                correlationIdField,
                taggedFields
            ));
        }
        private static int WriteUntaggedV1(byte[] buffer, int index, ResponseHeader message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.CorrelationIdField);
            return index;
        }
        private static (int Offset, ResponseHeader Value) ReadUntaggedV1(byte[] buffer, int index)
        {
            var correlationIdField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, correlationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                correlationIdField,
                taggedFields
            ));
        }
    }
}