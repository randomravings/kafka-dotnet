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
    public static class RequestHeaderSerde
    {
        public static EncodeDelegate<RequestHeader> CreateEncoder(bool flexible) =>
            flexible ? WriteV2 : WriteV1
        ;
        public static DecodeDelegate<RequestHeader> CreateDecoder(bool flexible) =>
            flexible ? ReadV2 : ReadV1
        ;
        private static int WriteV0(byte[] buffer, int index, RequestHeader message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiKeyField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiVersionField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.CorrelationIdField);
            return index;
        }
        private static (int Offset, RequestHeader Value) ReadV0(byte[] buffer, int index)
        {
            var requestApiKeyField = default(short);
            var requestApiVersionField = default(short);
            var correlationIdField = default(int);
            var clientIdField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, requestApiKeyField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, requestApiVersionField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, correlationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                requestApiKeyField,
                requestApiVersionField,
                correlationIdField,
                clientIdField,
                taggedFields
            ));
        }
        private static int WriteUntaggedV0(byte[] buffer, int index, RequestHeader message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiKeyField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiVersionField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.CorrelationIdField);
            return index;
        }
        private static (int Offset, RequestHeader Value) ReadUntaggedV0(byte[] buffer, int index)
        {
            var requestApiKeyField = default(short);
            var requestApiVersionField = default(short);
            var correlationIdField = default(int);
            var clientIdField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, requestApiKeyField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, requestApiVersionField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, correlationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                requestApiKeyField,
                requestApiVersionField,
                correlationIdField,
                clientIdField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, RequestHeader message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiKeyField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiVersionField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.CorrelationIdField);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.ClientIdField);
            return index;
        }
        private static (int Offset, RequestHeader Value) ReadV1(byte[] buffer, int index)
        {
            var requestApiKeyField = default(short);
            var requestApiVersionField = default(short);
            var correlationIdField = default(int);
            var clientIdField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, requestApiKeyField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, requestApiVersionField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, correlationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, clientIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            return (index, new(
                requestApiKeyField,
                requestApiVersionField,
                correlationIdField,
                clientIdField,
                taggedFields
            ));
        }
        private static int WriteUntaggedV1(byte[] buffer, int index, RequestHeader message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiKeyField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiVersionField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.CorrelationIdField);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.ClientIdField);
            return index;
        }
        private static (int Offset, RequestHeader Value) ReadUntaggedV1(byte[] buffer, int index)
        {
            var requestApiKeyField = default(short);
            var requestApiVersionField = default(short);
            var correlationIdField = default(int);
            var clientIdField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, requestApiKeyField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, requestApiVersionField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, correlationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, clientIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            return (index, new(
                requestApiKeyField,
                requestApiVersionField,
                correlationIdField,
                clientIdField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, RequestHeader message)
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
        private static (int Offset, RequestHeader Value) ReadV2(byte[] buffer, int index)
        {
            var requestApiKeyField = default(short);
            var requestApiVersionField = default(short);
            var correlationIdField = default(int);
            var clientIdField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, requestApiKeyField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, requestApiVersionField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, correlationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, clientIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                requestApiKeyField,
                requestApiVersionField,
                correlationIdField,
                clientIdField,
                taggedFields
            ));
        }
        private static int WriteUntaggedV2(byte[] buffer, int index, RequestHeader message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiKeyField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.RequestApiVersionField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.CorrelationIdField);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.ClientIdField);
            return index;
        }
        private static (int Offset, RequestHeader Value) ReadUntaggedV2(byte[] buffer, int index)
        {
            var requestApiKeyField = default(short);
            var requestApiVersionField = default(short);
            var correlationIdField = default(int);
            var clientIdField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, requestApiKeyField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, requestApiVersionField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, correlationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, clientIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            return (index, new(
                requestApiKeyField,
                requestApiVersionField,
                correlationIdField,
                clientIdField,
                taggedFields
            ));
        }
    }
}