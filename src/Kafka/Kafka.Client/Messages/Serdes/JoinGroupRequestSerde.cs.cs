using JoinGroupRequestProtocol = Kafka.Client.Messages.JoinGroupRequest.JoinGroupRequestProtocol;
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
    public static class JoinGroupRequestSerde
    {
        private static readonly ApiKey API_KEY = new(11);
        private static readonly VersionRange API_VERSIONS = new(0, 9);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (6, 32767);
        public static IEncoder<RequestHeader, JoinGroupRequest> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 9 ? apiVersion : new Version(9);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = RequestHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<RequestHeader, JoinGroupRequest>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<RequestHeader, JoinGroupRequest>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<RequestHeader, JoinGroupRequest>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<RequestHeader, JoinGroupRequest>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<RequestHeader, JoinGroupRequest>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<RequestHeader, JoinGroupRequest>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<RequestHeader, JoinGroupRequest>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                case 7:
                    return new Encoder<RequestHeader, JoinGroupRequest>(API_KEY, 7, flexible, headerEncoder, WriteV7);
                case 8:
                    return new Encoder<RequestHeader, JoinGroupRequest>(API_KEY, 8, flexible, headerEncoder, WriteV8);
                case 9:
                    return new Encoder<RequestHeader, JoinGroupRequest>(API_KEY, 9, flexible, headerEncoder, WriteV9);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<RequestHeader, JoinGroupRequest> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 9 ? apiVersion : new Version(9);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = RequestHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<RequestHeader, JoinGroupRequest>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<RequestHeader, JoinGroupRequest>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<RequestHeader, JoinGroupRequest>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<RequestHeader, JoinGroupRequest>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<RequestHeader, JoinGroupRequest>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<RequestHeader, JoinGroupRequest>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<RequestHeader, JoinGroupRequest>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                case 7:
                    return new Decoder<RequestHeader, JoinGroupRequest>(API_KEY, 7, flexible, headerDecoder, ReadV7);
                case 8:
                    return new Decoder<RequestHeader, JoinGroupRequest>(API_KEY, 8, flexible, headerDecoder, ReadV8);
                case 9:
                    return new Decoder<RequestHeader, JoinGroupRequest>(API_KEY, 9, flexible, headerDecoder, ReadV9);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV0);
            return index;
        }
        private static (int Offset, JoinGroupRequest Value) ReadV0(byte[] buffer, int index)
        {
            var groupIdField = "";
            var sessionTimeoutMsField = default(int);
            var rebalanceTimeoutMsField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = "";
            var protocolsField = ImmutableArray<JoinGroupRequestProtocol>.Empty;
            var reasonField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, sessionTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _protocolsField_) = BinaryDecoder.ReadArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV0);
            if (_protocolsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Protocols'");
            else
                protocolsField = _protocolsField_.Value;
            return (index, new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV1);
            return index;
        }
        private static (int Offset, JoinGroupRequest Value) ReadV1(byte[] buffer, int index)
        {
            var groupIdField = "";
            var sessionTimeoutMsField = default(int);
            var rebalanceTimeoutMsField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = "";
            var protocolsField = ImmutableArray<JoinGroupRequestProtocol>.Empty;
            var reasonField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, sessionTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, rebalanceTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _protocolsField_) = BinaryDecoder.ReadArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV1);
            if (_protocolsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Protocols'");
            else
                protocolsField = _protocolsField_.Value;
            return (index, new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV2);
            return index;
        }
        private static (int Offset, JoinGroupRequest Value) ReadV2(byte[] buffer, int index)
        {
            var groupIdField = "";
            var sessionTimeoutMsField = default(int);
            var rebalanceTimeoutMsField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = "";
            var protocolsField = ImmutableArray<JoinGroupRequestProtocol>.Empty;
            var reasonField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, sessionTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, rebalanceTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _protocolsField_) = BinaryDecoder.ReadArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV2);
            if (_protocolsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Protocols'");
            else
                protocolsField = _protocolsField_.Value;
            return (index, new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV3);
            return index;
        }
        private static (int Offset, JoinGroupRequest Value) ReadV3(byte[] buffer, int index)
        {
            var groupIdField = "";
            var sessionTimeoutMsField = default(int);
            var rebalanceTimeoutMsField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = "";
            var protocolsField = ImmutableArray<JoinGroupRequestProtocol>.Empty;
            var reasonField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, sessionTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, rebalanceTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _protocolsField_) = BinaryDecoder.ReadArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV3);
            if (_protocolsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Protocols'");
            else
                protocolsField = _protocolsField_.Value;
            return (index, new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV4);
            return index;
        }
        private static (int Offset, JoinGroupRequest Value) ReadV4(byte[] buffer, int index)
        {
            var groupIdField = "";
            var sessionTimeoutMsField = default(int);
            var rebalanceTimeoutMsField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = "";
            var protocolsField = ImmutableArray<JoinGroupRequestProtocol>.Empty;
            var reasonField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, sessionTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, rebalanceTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _protocolsField_) = BinaryDecoder.ReadArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV4);
            if (_protocolsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Protocols'");
            else
                protocolsField = _protocolsField_.Value;
            return (index, new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV5);
            return index;
        }
        private static (int Offset, JoinGroupRequest Value) ReadV5(byte[] buffer, int index)
        {
            var groupIdField = "";
            var sessionTimeoutMsField = default(int);
            var rebalanceTimeoutMsField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = "";
            var protocolsField = ImmutableArray<JoinGroupRequestProtocol>.Empty;
            var reasonField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, sessionTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, rebalanceTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, groupInstanceIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _protocolsField_) = BinaryDecoder.ReadArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV5);
            if (_protocolsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Protocols'");
            else
                protocolsField = _protocolsField_.Value;
            return (index, new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV6);
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
        private static (int Offset, JoinGroupRequest Value) ReadV6(byte[] buffer, int index)
        {
            var groupIdField = "";
            var sessionTimeoutMsField = default(int);
            var rebalanceTimeoutMsField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = "";
            var protocolsField = ImmutableArray<JoinGroupRequestProtocol>.Empty;
            var reasonField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, sessionTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, rebalanceTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, var _protocolsField_) = BinaryDecoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV6);
            if (_protocolsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Protocols'");
            else
                protocolsField = _protocolsField_.Value;
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
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField,
                taggedFields
            ));
        }
        private static int WriteV7(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV7);
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
        private static (int Offset, JoinGroupRequest Value) ReadV7(byte[] buffer, int index)
        {
            var groupIdField = "";
            var sessionTimeoutMsField = default(int);
            var rebalanceTimeoutMsField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = "";
            var protocolsField = ImmutableArray<JoinGroupRequestProtocol>.Empty;
            var reasonField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, sessionTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, rebalanceTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, var _protocolsField_) = BinaryDecoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV7);
            if (_protocolsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Protocols'");
            else
                protocolsField = _protocolsField_.Value;
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
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField,
                taggedFields
            ));
        }
        private static int WriteV8(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV8);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ReasonField);
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
        private static (int Offset, JoinGroupRequest Value) ReadV8(byte[] buffer, int index)
        {
            var groupIdField = "";
            var sessionTimeoutMsField = default(int);
            var rebalanceTimeoutMsField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = "";
            var protocolsField = ImmutableArray<JoinGroupRequestProtocol>.Empty;
            var reasonField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, sessionTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, rebalanceTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, var _protocolsField_) = BinaryDecoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV8);
            if (_protocolsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Protocols'");
            else
                protocolsField = _protocolsField_.Value;
            (index, reasonField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField,
                taggedFields
            ));
        }
        private static int WriteV9(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV9);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ReasonField);
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
        private static (int Offset, JoinGroupRequest Value) ReadV9(byte[] buffer, int index)
        {
            var groupIdField = "";
            var sessionTimeoutMsField = default(int);
            var rebalanceTimeoutMsField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = "";
            var protocolsField = ImmutableArray<JoinGroupRequestProtocol>.Empty;
            var reasonField = default(string?);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, sessionTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, rebalanceTimeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, var _protocolsField_) = BinaryDecoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV9);
            if (_protocolsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Protocols'");
            else
                protocolsField = _protocolsField_.Value;
            (index, reasonField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class JoinGroupRequestProtocolSerde
        {
            public static int WriteV0(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupRequestProtocol Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    nameField,
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupRequestProtocol Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    nameField,
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupRequestProtocol Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    nameField,
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupRequestProtocol Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    nameField,
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupRequestProtocol Value) ReadV4(byte[] buffer, int index)
            {
                var nameField = "";
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    nameField,
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupRequestProtocol Value) ReadV5(byte[] buffer, int index)
            {
                var nameField = "";
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    nameField,
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupRequestProtocol Value) ReadV6(byte[] buffer, int index)
            {
                var nameField = "";
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, index);
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
                    nameField,
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV7(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupRequestProtocol Value) ReadV7(byte[] buffer, int index)
            {
                var nameField = "";
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, index);
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
                    nameField,
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV8(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupRequestProtocol Value) ReadV8(byte[] buffer, int index)
            {
                var nameField = "";
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, index);
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
                    nameField,
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV9(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupRequestProtocol Value) ReadV9(byte[] buffer, int index)
            {
                var nameField = "";
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, index);
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
                    nameField,
                    metadataField,
                    taggedFields
                ));
            }
        }
    }
}