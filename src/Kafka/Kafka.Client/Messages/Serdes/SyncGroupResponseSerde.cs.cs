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
    public static class SyncGroupResponseSerde
    {
        private static readonly ApiKey API_KEY = new(14);
        private static readonly VersionRange API_VERSIONS = new(0, 5);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (4, 32767);
        public static IEncoder<ResponseHeader, SyncGroupResponse> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 5 ? apiVersion : new Version(5);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = ResponseHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<ResponseHeader, SyncGroupResponse>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<ResponseHeader, SyncGroupResponse>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<ResponseHeader, SyncGroupResponse>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<ResponseHeader, SyncGroupResponse>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<ResponseHeader, SyncGroupResponse>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<ResponseHeader, SyncGroupResponse>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<ResponseHeader, SyncGroupResponse> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 5 ? apiVersion : new Version(5);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = ResponseHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<ResponseHeader, SyncGroupResponse>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<ResponseHeader, SyncGroupResponse>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<ResponseHeader, SyncGroupResponse>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<ResponseHeader, SyncGroupResponse>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<ResponseHeader, SyncGroupResponse>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<ResponseHeader, SyncGroupResponse>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, SyncGroupResponse message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteBytes(buffer, index, message.AssignmentField);
            return index;
        }
        private static (int Offset, SyncGroupResponse Value) ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = ReadOnlyMemory<byte>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, assignmentField) = BinaryDecoder.ReadBytes(buffer, index);
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, SyncGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteBytes(buffer, index, message.AssignmentField);
            return index;
        }
        private static (int Offset, SyncGroupResponse Value) ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = ReadOnlyMemory<byte>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, assignmentField) = BinaryDecoder.ReadBytes(buffer, index);
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, SyncGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteBytes(buffer, index, message.AssignmentField);
            return index;
        }
        private static (int Offset, SyncGroupResponse Value) ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = ReadOnlyMemory<byte>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, assignmentField) = BinaryDecoder.ReadBytes(buffer, index);
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, SyncGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteBytes(buffer, index, message.AssignmentField);
            return index;
        }
        private static (int Offset, SyncGroupResponse Value) ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = ReadOnlyMemory<byte>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, assignmentField) = BinaryDecoder.ReadBytes(buffer, index);
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, SyncGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteCompactBytes(buffer, index, message.AssignmentField);
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
        private static (int Offset, SyncGroupResponse Value) ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = ReadOnlyMemory<byte>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, assignmentField) = BinaryDecoder.ReadCompactBytes(buffer, index);
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
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, SyncGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ProtocolNameField);
            index = BinaryEncoder.WriteCompactBytes(buffer, index, message.AssignmentField);
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
        private static (int Offset, SyncGroupResponse Value) ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = ReadOnlyMemory<byte>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, protocolNameField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, assignmentField) = BinaryDecoder.ReadCompactBytes(buffer, index);
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
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
    }
}