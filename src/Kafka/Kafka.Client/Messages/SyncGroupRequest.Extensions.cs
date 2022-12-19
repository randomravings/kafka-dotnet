using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using SyncGroupRequestAssignment = Kafka.Client.Messages.SyncGroupRequest.SyncGroupRequestAssignment;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SyncGroupRequestSerde
    {
        private static readonly DecodeDelegate<SyncGroupRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
        };
        private static readonly EncodeDelegate<SyncGroupRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
        };
        public static SyncGroupRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, SyncGroupRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static SyncGroupRequest ReadV00(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = Decoder.ReadArray<SyncGroupRequestAssignment>(buffer, ref index, SyncGroupRequestAssignmentSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolNameField,
                assignmentsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, SyncGroupRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV00);
            return index;
        }
        private static SyncGroupRequest ReadV01(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = Decoder.ReadArray<SyncGroupRequestAssignment>(buffer, ref index, SyncGroupRequestAssignmentSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolNameField,
                assignmentsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, SyncGroupRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV01);
            return index;
        }
        private static SyncGroupRequest ReadV02(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = Decoder.ReadArray<SyncGroupRequestAssignment>(buffer, ref index, SyncGroupRequestAssignmentSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolNameField,
                assignmentsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, SyncGroupRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV02);
            return index;
        }
        private static SyncGroupRequest ReadV03(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = Decoder.ReadNullableString(buffer, ref index);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = Decoder.ReadArray<SyncGroupRequestAssignment>(buffer, ref index, SyncGroupRequestAssignmentSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolNameField,
                assignmentsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, SyncGroupRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
            index = Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV03);
            return index;
        }
        private static SyncGroupRequest ReadV04(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadCompactString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadCompactString(buffer, ref index);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = Decoder.ReadCompactArray<SyncGroupRequestAssignment>(buffer, ref index, SyncGroupRequestAssignmentSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolNameField,
                assignmentsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, SyncGroupRequest message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = Encoder.WriteCompactArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV04);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static SyncGroupRequest ReadV05(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadCompactString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadCompactString(buffer, ref index);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var protocolTypeField = Decoder.ReadCompactNullableString(buffer, ref index);
            var protocolNameField = Decoder.ReadCompactNullableString(buffer, ref index);
            var assignmentsField = Decoder.ReadCompactArray<SyncGroupRequestAssignment>(buffer, ref index, SyncGroupRequestAssignmentSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolNameField,
                assignmentsField
            );
        }
        private static int WriteV05(byte[] buffer, int index, SyncGroupRequest message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolTypeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolNameField);
            index = Encoder.WriteCompactArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV05);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class SyncGroupRequestAssignmentSerde
        {
            public static SyncGroupRequestAssignment ReadV00(byte[] buffer, ref int index)
            {
                var memberIdField = Decoder.ReadString(buffer, ref index);
                var assignmentField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static int WriteV00(byte[] buffer, int index, SyncGroupRequestAssignment message)
            {
                index = Encoder.WriteString(buffer, index, message.MemberIdField);
                index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
                return index;
            }
            public static SyncGroupRequestAssignment ReadV01(byte[] buffer, ref int index)
            {
                var memberIdField = Decoder.ReadString(buffer, ref index);
                var assignmentField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static int WriteV01(byte[] buffer, int index, SyncGroupRequestAssignment message)
            {
                index = Encoder.WriteString(buffer, index, message.MemberIdField);
                index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
                return index;
            }
            public static SyncGroupRequestAssignment ReadV02(byte[] buffer, ref int index)
            {
                var memberIdField = Decoder.ReadString(buffer, ref index);
                var assignmentField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static int WriteV02(byte[] buffer, int index, SyncGroupRequestAssignment message)
            {
                index = Encoder.WriteString(buffer, index, message.MemberIdField);
                index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
                return index;
            }
            public static SyncGroupRequestAssignment ReadV03(byte[] buffer, ref int index)
            {
                var memberIdField = Decoder.ReadString(buffer, ref index);
                var assignmentField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static int WriteV03(byte[] buffer, int index, SyncGroupRequestAssignment message)
            {
                index = Encoder.WriteString(buffer, index, message.MemberIdField);
                index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
                return index;
            }
            public static SyncGroupRequestAssignment ReadV04(byte[] buffer, ref int index)
            {
                var memberIdField = Decoder.ReadCompactString(buffer, ref index);
                var assignmentField = Decoder.ReadCompactBytes(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static int WriteV04(byte[] buffer, int index, SyncGroupRequestAssignment message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = Encoder.WriteCompactBytes(buffer, index, message.AssignmentField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static SyncGroupRequestAssignment ReadV05(byte[] buffer, ref int index)
            {
                var memberIdField = Decoder.ReadCompactString(buffer, ref index);
                var assignmentField = Decoder.ReadCompactBytes(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static int WriteV05(byte[] buffer, int index, SyncGroupRequestAssignment message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = Encoder.WriteCompactBytes(buffer, index, message.AssignmentField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}