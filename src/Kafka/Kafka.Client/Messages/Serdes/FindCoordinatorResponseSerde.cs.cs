using Coordinator = Kafka.Client.Messages.FindCoordinatorResponse.Coordinator;
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
    public static class FindCoordinatorResponseSerde
    {
        private static readonly ApiKey API_KEY = new(10);
        private static readonly VersionRange API_VERSIONS = new(0, 4);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (3, 32767);
        public static IEncoder<ResponseHeader, FindCoordinatorResponse> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 4 ? apiVersion : new Version(4);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = ResponseHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<ResponseHeader, FindCoordinatorResponse>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<ResponseHeader, FindCoordinatorResponse>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<ResponseHeader, FindCoordinatorResponse>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<ResponseHeader, FindCoordinatorResponse>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<ResponseHeader, FindCoordinatorResponse>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<ResponseHeader, FindCoordinatorResponse> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 4 ? apiVersion : new Version(4);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = ResponseHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<ResponseHeader, FindCoordinatorResponse>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<ResponseHeader, FindCoordinatorResponse>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<ResponseHeader, FindCoordinatorResponse>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<ResponseHeader, FindCoordinatorResponse>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<ResponseHeader, FindCoordinatorResponse>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, FindCoordinatorResponse message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.HostField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
            return index;
        }
        private static (int Offset, FindCoordinatorResponse Value) ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, hostField) = BinaryDecoder.ReadString(buffer, index);
            (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, FindCoordinatorResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.ErrorMessageField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.HostField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
            return index;
        }
        private static (int Offset, FindCoordinatorResponse Value) ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, hostField) = BinaryDecoder.ReadString(buffer, index);
            (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, FindCoordinatorResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.ErrorMessageField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.HostField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
            return index;
        }
        private static (int Offset, FindCoordinatorResponse Value) ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, hostField) = BinaryDecoder.ReadString(buffer, index);
            (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, FindCoordinatorResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.HostField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
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
        private static (int Offset, FindCoordinatorResponse Value) ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, hostField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
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
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, FindCoordinatorResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<Coordinator>(buffer, index, message.CoordinatorsField, CoordinatorSerde.WriteV4);
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
        private static (int Offset, FindCoordinatorResponse Value) ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _coordinatorsField_) = BinaryDecoder.ReadCompactArray<Coordinator>(buffer, index, CoordinatorSerde.ReadV4);
            if (_coordinatorsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Coordinators'");
            else
                coordinatorsField = _coordinatorsField_.Value;
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
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class CoordinatorSerde
        {
            public static int WriteV0(byte[] buffer, int index, Coordinator message)
            {
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
            public static (int Offset, Coordinator Value) ReadV0(byte[] buffer, int index)
            {
                var keyField = "";
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, Coordinator message)
            {
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
            public static (int Offset, Coordinator Value) ReadV1(byte[] buffer, int index)
            {
                var keyField = "";
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, Coordinator message)
            {
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
            public static (int Offset, Coordinator Value) ReadV2(byte[] buffer, int index)
            {
                var keyField = "";
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, Coordinator message)
            {
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
            public static (int Offset, Coordinator Value) ReadV3(byte[] buffer, int index)
            {
                var keyField = "";
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
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
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, Coordinator message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.KeyField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
                index = BinaryEncoder.WriteCompactString(buffer, index, message.HostField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
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
            public static (int Offset, Coordinator Value) ReadV4(byte[] buffer, int index)
            {
                var keyField = "";
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, keyField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
        }
    }
}