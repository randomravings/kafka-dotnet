using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using SyncGroupRequestAssignment = Kafka.Client.Messages.SyncGroupRequestData.SyncGroupRequestAssignment;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class SyncGroupRequestEncoder : 
        RequestEncoder<RequestHeaderData, SyncGroupRequestData>
    {
        internal SyncGroupRequestEncoder() :
            base(
                ApiKey.SyncGroup,
                new(0, 5),
                new(4, 32767),
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
        protected override EncodeValue<SyncGroupRequestData> GetMessageEncoder(short apiVersion) =>
            apiVersion switch
            {
                0 => WriteV0,
                1 => WriteV1,
                2 => WriteV2,
                3 => WriteV3,
                4 => WriteV4,
                5 => WriteV5,
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in SyncGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.GenerationIdField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteArray<SyncGroupRequestAssignment>(buffer, i, message.AssignmentsField, SyncGroupRequestAssignmentEncoder.WriteV0);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in SyncGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.GenerationIdField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteArray<SyncGroupRequestAssignment>(buffer, i, message.AssignmentsField, SyncGroupRequestAssignmentEncoder.WriteV1);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in SyncGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.GenerationIdField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteArray<SyncGroupRequestAssignment>(buffer, i, message.AssignmentsField, SyncGroupRequestAssignmentEncoder.WriteV2);
            return i;
        }
        private static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in SyncGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.GenerationIdField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteNullableString(buffer, i, message.GroupInstanceIdField);
            i = BinaryEncoder.WriteArray<SyncGroupRequestAssignment>(buffer, i, message.AssignmentsField, SyncGroupRequestAssignmentEncoder.WriteV3);
            return i;
        }
        private static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in SyncGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.GenerationIdField);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.GroupInstanceIdField);
            i = BinaryEncoder.WriteCompactArray<SyncGroupRequestAssignment>(buffer, i, message.AssignmentsField, SyncGroupRequestAssignmentEncoder.WriteV4);
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
        private static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in SyncGroupRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.GenerationIdField);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.GroupInstanceIdField);
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.ProtocolTypeField);
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.ProtocolNameField);
            i = BinaryEncoder.WriteCompactArray<SyncGroupRequestAssignment>(buffer, i, message.AssignmentsField, SyncGroupRequestAssignmentEncoder.WriteV5);
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
        private static class SyncGroupRequestAssignmentEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in SyncGroupRequestAssignment message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
                i = BinaryEncoder.WriteBytes(buffer, i, message.AssignmentField);
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in SyncGroupRequestAssignment message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
                i = BinaryEncoder.WriteBytes(buffer, i, message.AssignmentField);
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in SyncGroupRequestAssignment message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
                i = BinaryEncoder.WriteBytes(buffer, i, message.AssignmentField);
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in SyncGroupRequestAssignment message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
                i = BinaryEncoder.WriteBytes(buffer, i, message.AssignmentField);
                return i;
            }
            public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in SyncGroupRequestAssignment message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.MemberIdField);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, message.AssignmentField);
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
            public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in SyncGroupRequestAssignment message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.MemberIdField);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, message.AssignmentField);
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
