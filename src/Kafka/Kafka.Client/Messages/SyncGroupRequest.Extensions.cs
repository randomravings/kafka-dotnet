using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using SyncGroupRequestAssignment = Kafka.Client.Messages.SyncGroupRequest.SyncGroupRequestAssignment;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SyncGroupRequestSerde
    {
        private static readonly Func<Stream, SyncGroupRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
        };
        private static readonly Action<Stream, SyncGroupRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
        };
        public static SyncGroupRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, SyncGroupRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static SyncGroupRequest ReadV00(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = Decoder.ReadArray<SyncGroupRequestAssignment>(buffer, b => SyncGroupRequestAssignmentSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
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
        private static void WriteV00(Stream buffer, SyncGroupRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, message.AssignmentsField, (b, i) => SyncGroupRequestAssignmentSerde.WriteV00(b, i));
        }
        private static SyncGroupRequest ReadV01(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = Decoder.ReadArray<SyncGroupRequestAssignment>(buffer, b => SyncGroupRequestAssignmentSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
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
        private static void WriteV01(Stream buffer, SyncGroupRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, message.AssignmentsField, (b, i) => SyncGroupRequestAssignmentSerde.WriteV01(b, i));
        }
        private static SyncGroupRequest ReadV02(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = Decoder.ReadArray<SyncGroupRequestAssignment>(buffer, b => SyncGroupRequestAssignmentSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
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
        private static void WriteV02(Stream buffer, SyncGroupRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, message.AssignmentsField, (b, i) => SyncGroupRequestAssignmentSerde.WriteV02(b, i));
        }
        private static SyncGroupRequest ReadV03(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = Decoder.ReadNullableString(buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = Decoder.ReadArray<SyncGroupRequestAssignment>(buffer, b => SyncGroupRequestAssignmentSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
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
        private static void WriteV03(Stream buffer, SyncGroupRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
            Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, message.AssignmentsField, (b, i) => SyncGroupRequestAssignmentSerde.WriteV03(b, i));
        }
        private static SyncGroupRequest ReadV04(Stream buffer)
        {
            var groupIdField = Decoder.ReadCompactString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadCompactString(buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = Decoder.ReadCompactArray<SyncGroupRequestAssignment>(buffer, b => SyncGroupRequestAssignmentSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV04(Stream buffer, SyncGroupRequest message)
        {
            Encoder.WriteCompactString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteCompactString(buffer, message.MemberIdField);
            Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            Encoder.WriteCompactArray<SyncGroupRequestAssignment>(buffer, message.AssignmentsField, (b, i) => SyncGroupRequestAssignmentSerde.WriteV04(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static SyncGroupRequest ReadV05(Stream buffer)
        {
            var groupIdField = Decoder.ReadCompactString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadCompactString(buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
            var protocolTypeField = Decoder.ReadCompactNullableString(buffer);
            var protocolNameField = Decoder.ReadCompactNullableString(buffer);
            var assignmentsField = Decoder.ReadCompactArray<SyncGroupRequestAssignment>(buffer, b => SyncGroupRequestAssignmentSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV05(Stream buffer, SyncGroupRequest message)
        {
            Encoder.WriteCompactString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteCompactString(buffer, message.MemberIdField);
            Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            Encoder.WriteCompactNullableString(buffer, message.ProtocolTypeField);
            Encoder.WriteCompactNullableString(buffer, message.ProtocolNameField);
            Encoder.WriteCompactArray<SyncGroupRequestAssignment>(buffer, message.AssignmentsField, (b, i) => SyncGroupRequestAssignmentSerde.WriteV05(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class SyncGroupRequestAssignmentSerde
        {
            public static SyncGroupRequestAssignment ReadV00(Stream buffer)
            {
                var memberIdField = Decoder.ReadString(buffer);
                var assignmentField = Decoder.ReadBytes(buffer);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static void WriteV00(Stream buffer, SyncGroupRequestAssignment message)
            {
                Encoder.WriteString(buffer, message.MemberIdField);
                Encoder.WriteBytes(buffer, message.AssignmentField);
            }
            public static SyncGroupRequestAssignment ReadV01(Stream buffer)
            {
                var memberIdField = Decoder.ReadString(buffer);
                var assignmentField = Decoder.ReadBytes(buffer);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static void WriteV01(Stream buffer, SyncGroupRequestAssignment message)
            {
                Encoder.WriteString(buffer, message.MemberIdField);
                Encoder.WriteBytes(buffer, message.AssignmentField);
            }
            public static SyncGroupRequestAssignment ReadV02(Stream buffer)
            {
                var memberIdField = Decoder.ReadString(buffer);
                var assignmentField = Decoder.ReadBytes(buffer);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static void WriteV02(Stream buffer, SyncGroupRequestAssignment message)
            {
                Encoder.WriteString(buffer, message.MemberIdField);
                Encoder.WriteBytes(buffer, message.AssignmentField);
            }
            public static SyncGroupRequestAssignment ReadV03(Stream buffer)
            {
                var memberIdField = Decoder.ReadString(buffer);
                var assignmentField = Decoder.ReadBytes(buffer);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static void WriteV03(Stream buffer, SyncGroupRequestAssignment message)
            {
                Encoder.WriteString(buffer, message.MemberIdField);
                Encoder.WriteBytes(buffer, message.AssignmentField);
            }
            public static SyncGroupRequestAssignment ReadV04(Stream buffer)
            {
                var memberIdField = Decoder.ReadCompactString(buffer);
                var assignmentField = Decoder.ReadCompactBytes(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static void WriteV04(Stream buffer, SyncGroupRequestAssignment message)
            {
                Encoder.WriteCompactString(buffer, message.MemberIdField);
                Encoder.WriteCompactBytes(buffer, message.AssignmentField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static SyncGroupRequestAssignment ReadV05(Stream buffer)
            {
                var memberIdField = Decoder.ReadCompactString(buffer);
                var assignmentField = Decoder.ReadCompactBytes(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static void WriteV05(Stream buffer, SyncGroupRequestAssignment message)
            {
                Encoder.WriteCompactString(buffer, message.MemberIdField);
                Encoder.WriteCompactBytes(buffer, message.AssignmentField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}