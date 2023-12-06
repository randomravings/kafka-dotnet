using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using JoinGroupRequestProtocol = Kafka.Client.Messages.JoinGroupRequestData.JoinGroupRequestProtocol;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class JoinGroupRequestEncoder : 
        RequestEncoder<RequestHeaderData, JoinGroupRequestData>
    {
        internal JoinGroupRequestEncoder() :
            base(
                ApiKey.JoinGroup,
                new(0, 9),
                new(6, 32767),
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
        protected override EncodeValue<JoinGroupRequestData> GetMessageEncoder(short apiVersion) =>
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
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionTimeoutMsField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteString(buffer, i, message.ProtocolTypeField);
            i = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, i, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV0);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionTimeoutMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.RebalanceTimeoutMsField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteString(buffer, i, message.ProtocolTypeField);
            i = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, i, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV1);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionTimeoutMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.RebalanceTimeoutMsField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteString(buffer, i, message.ProtocolTypeField);
            i = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, i, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV2);
            return i;
        }
        private static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionTimeoutMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.RebalanceTimeoutMsField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteString(buffer, i, message.ProtocolTypeField);
            i = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, i, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV3);
            return i;
        }
        private static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionTimeoutMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.RebalanceTimeoutMsField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteString(buffer, i, message.ProtocolTypeField);
            i = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, i, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV4);
            return i;
        }
        private static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionTimeoutMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.RebalanceTimeoutMsField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteNullableString(buffer, i, message.GroupInstanceIdField);
            i = BinaryEncoder.WriteString(buffer, i, message.ProtocolTypeField);
            i = BinaryEncoder.WriteArray<JoinGroupRequestProtocol>(buffer, i, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV5);
            return i;
        }
        private static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionTimeoutMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.RebalanceTimeoutMsField);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.GroupInstanceIdField);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.ProtocolTypeField);
            i = BinaryEncoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, i, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV6);
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
        private static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionTimeoutMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.RebalanceTimeoutMsField);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.GroupInstanceIdField);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.ProtocolTypeField);
            i = BinaryEncoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, i, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV7);
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
        private static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionTimeoutMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.RebalanceTimeoutMsField);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.GroupInstanceIdField);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.ProtocolTypeField);
            i = BinaryEncoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, i, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV8);
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.ReasonField);
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
        private static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionTimeoutMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.RebalanceTimeoutMsField);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.GroupInstanceIdField);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.ProtocolTypeField);
            i = BinaryEncoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, i, message.ProtocolsField, JoinGroupRequestProtocolEncoder.WriteV9);
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.ReasonField);
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
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class JoinGroupRequestProtocolEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestProtocol message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteBytes(buffer, i, message.MetadataField);
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestProtocol message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteBytes(buffer, i, message.MetadataField);
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestProtocol message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteBytes(buffer, i, message.MetadataField);
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestProtocol message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteBytes(buffer, i, message.MetadataField);
                return i;
            }
            public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestProtocol message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteBytes(buffer, i, message.MetadataField);
                return i;
            }
            public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestProtocol message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteBytes(buffer, i, message.MetadataField);
                return i;
            }
            public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestProtocol message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, message.MetadataField);
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
            public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestProtocol message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, message.MetadataField);
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
            public static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestProtocol message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, message.MetadataField);
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
            public static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in JoinGroupRequestProtocol message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, message.MetadataField);
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
}
