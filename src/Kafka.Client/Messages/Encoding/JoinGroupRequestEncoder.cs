using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using JoinGroupRequestProtocol = Kafka.Client.Messages.JoinGroupRequestData.JoinGroupRequestProtocol;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class JoinGroupRequestEncoder : 
        RequestEncoder<RequestHeaderData, JoinGroupRequestData>
    {
        public JoinGroupRequestEncoder() :
            base(
                ApiKey.JoinGroup,
                new(0, 9),
                new(6, 32767),
                RequestHeaderEncoder.WriteV0,
                WriteV0
            )
        { }
        protected override EncodeDelegate<RequestHeaderData> GetHeaderEncoder(short apiVersion)
        {
            if (_flexibleVersions.Includes(apiVersion))
                return RequestHeaderEncoder.WriteV2;
            else
                return RequestHeaderEncoder.WriteV1;
        }
        protected override EncodeDelegate<JoinGroupRequestData> GetMessageEncoder(short apiVersion) =>
            apiVersion switch
            {
                0 => WriteV0,
                1 => WriteV1,
                2 => WriteV2,
                3 => WriteV3,
                4 => WriteV4,
                5 => WriteV5,
                6 => WriteV6,
                7 => WriteV7,
                8 => WriteV8,
                9 => WriteV9,
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0(byte[] buffer, int index, JoinGroupRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV0);
            return index;
        }
        private static int WriteV1(byte[] buffer, int index, JoinGroupRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV1);
            return index;
        }
        private static int WriteV2(byte[] buffer, int index, JoinGroupRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV2);
            return index;
        }
        private static int WriteV3(byte[] buffer, int index, JoinGroupRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV3);
            return index;
        }
        private static int WriteV4(byte[] buffer, int index, JoinGroupRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV4);
            return index;
        }
        private static int WriteV5(byte[] buffer, int index, JoinGroupRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV5);
            return index;
        }
        private static int WriteV6(byte[] buffer, int index, JoinGroupRequestData message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV6);
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
        private static int WriteV7(byte[] buffer, int index, JoinGroupRequestData message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV7);
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
        private static int WriteV8(byte[] buffer, int index, JoinGroupRequestData message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV8);
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
        private static int WriteV9(byte[] buffer, int index, JoinGroupRequestData message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV9);
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
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class JoinGroupRequestProtocolEncoder
        {
            public static int WriteV0(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static int WriteV1(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static int WriteV2(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static int WriteV3(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static int WriteV4(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static int WriteV5(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
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
        }
    }
}
