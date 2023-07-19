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
    public static class HeartbeatRequestSerde
    {
        private static readonly ApiKey API_KEY = new(12);
        private static readonly VersionRange API_VERSIONS = new(0, 4);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (4, 32767);
        public static IEncoder<RequestHeader, HeartbeatRequest> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 4 ? apiVersion : new Version(4);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = RequestHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<RequestHeader, HeartbeatRequest>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<RequestHeader, HeartbeatRequest>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<RequestHeader, HeartbeatRequest>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<RequestHeader, HeartbeatRequest>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<RequestHeader, HeartbeatRequest>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<RequestHeader, HeartbeatRequest> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 4 ? apiVersion : new Version(4);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = RequestHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<RequestHeader, HeartbeatRequest>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<RequestHeader, HeartbeatRequest>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<RequestHeader, HeartbeatRequest>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<RequestHeader, HeartbeatRequest>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<RequestHeader, HeartbeatRequest>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, HeartbeatRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            return index;
        }
        private static (int Offset, HeartbeatRequest Value) ReadV0(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, HeartbeatRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            return index;
        }
        private static (int Offset, HeartbeatRequest Value) ReadV1(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, HeartbeatRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            return index;
        }
        private static (int Offset, HeartbeatRequest Value) ReadV2(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, HeartbeatRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
            return index;
        }
        private static (int Offset, HeartbeatRequest Value) ReadV3(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, groupInstanceIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, HeartbeatRequest message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
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
        private static (int Offset, HeartbeatRequest Value) ReadV4(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                taggedFields
            ));
        }
    }
}