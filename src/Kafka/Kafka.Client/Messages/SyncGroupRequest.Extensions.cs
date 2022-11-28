using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using SyncGroupRequestAssignment = Kafka.Client.Messages.SyncGroupRequest.SyncGroupRequestAssignment;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SyncGroupRequestSerde
    {
        private static readonly DecodeDelegate<SyncGroupRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
        };
        private static readonly EncodeDelegate<SyncGroupRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
        };
        public static SyncGroupRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, SyncGroupRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static SyncGroupRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = Decoder.ReadArray<SyncGroupRequestAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => SyncGroupRequestAssignmentSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
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
        private static Memory<byte> WriteV00(Memory<byte> buffer, SyncGroupRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, message.AssignmentsField, (b, i) => SyncGroupRequestAssignmentSerde.WriteV00(b, i));
            return buffer;
        }
        private static SyncGroupRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = Decoder.ReadArray<SyncGroupRequestAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => SyncGroupRequestAssignmentSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
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
        private static Memory<byte> WriteV01(Memory<byte> buffer, SyncGroupRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, message.AssignmentsField, (b, i) => SyncGroupRequestAssignmentSerde.WriteV01(b, i));
            return buffer;
        }
        private static SyncGroupRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = Decoder.ReadArray<SyncGroupRequestAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => SyncGroupRequestAssignmentSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
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
        private static Memory<byte> WriteV02(Memory<byte> buffer, SyncGroupRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, message.AssignmentsField, (b, i) => SyncGroupRequestAssignmentSerde.WriteV02(b, i));
            return buffer;
        }
        private static SyncGroupRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = Decoder.ReadNullableString(ref buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = Decoder.ReadArray<SyncGroupRequestAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => SyncGroupRequestAssignmentSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
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
        private static Memory<byte> WriteV03(Memory<byte> buffer, SyncGroupRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
            buffer = Encoder.WriteArray<SyncGroupRequestAssignment>(buffer, message.AssignmentsField, (b, i) => SyncGroupRequestAssignmentSerde.WriteV03(b, i));
            return buffer;
        }
        private static SyncGroupRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadCompactString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadCompactString(ref buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = Decoder.ReadCompactArray<SyncGroupRequestAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => SyncGroupRequestAssignmentSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV04(Memory<byte> buffer, SyncGroupRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            buffer = Encoder.WriteCompactArray<SyncGroupRequestAssignment>(buffer, message.AssignmentsField, (b, i) => SyncGroupRequestAssignmentSerde.WriteV04(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static SyncGroupRequest ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadCompactString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadCompactString(ref buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
            var protocolTypeField = Decoder.ReadCompactNullableString(ref buffer);
            var protocolNameField = Decoder.ReadCompactNullableString(ref buffer);
            var assignmentsField = Decoder.ReadCompactArray<SyncGroupRequestAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => SyncGroupRequestAssignmentSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV05(Memory<byte> buffer, SyncGroupRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ProtocolTypeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ProtocolNameField);
            buffer = Encoder.WriteCompactArray<SyncGroupRequestAssignment>(buffer, message.AssignmentsField, (b, i) => SyncGroupRequestAssignmentSerde.WriteV05(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class SyncGroupRequestAssignmentSerde
        {
            public static SyncGroupRequestAssignment ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadString(ref buffer);
                var assignmentField = Decoder.ReadBytes(ref buffer);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, SyncGroupRequestAssignment message)
            {
                buffer = Encoder.WriteString(buffer, message.MemberIdField);
                buffer = Encoder.WriteBytes(buffer, message.AssignmentField);
                return buffer;
            }
            public static SyncGroupRequestAssignment ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadString(ref buffer);
                var assignmentField = Decoder.ReadBytes(ref buffer);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, SyncGroupRequestAssignment message)
            {
                buffer = Encoder.WriteString(buffer, message.MemberIdField);
                buffer = Encoder.WriteBytes(buffer, message.AssignmentField);
                return buffer;
            }
            public static SyncGroupRequestAssignment ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadString(ref buffer);
                var assignmentField = Decoder.ReadBytes(ref buffer);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, SyncGroupRequestAssignment message)
            {
                buffer = Encoder.WriteString(buffer, message.MemberIdField);
                buffer = Encoder.WriteBytes(buffer, message.AssignmentField);
                return buffer;
            }
            public static SyncGroupRequestAssignment ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadString(ref buffer);
                var assignmentField = Decoder.ReadBytes(ref buffer);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, SyncGroupRequestAssignment message)
            {
                buffer = Encoder.WriteString(buffer, message.MemberIdField);
                buffer = Encoder.WriteBytes(buffer, message.AssignmentField);
                return buffer;
            }
            public static SyncGroupRequestAssignment ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadCompactString(ref buffer);
                var assignmentField = Decoder.ReadCompactBytes(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, SyncGroupRequestAssignment message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
                buffer = Encoder.WriteCompactBytes(buffer, message.AssignmentField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static SyncGroupRequestAssignment ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadCompactString(ref buffer);
                var assignmentField = Decoder.ReadCompactBytes(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    memberIdField,
                    assignmentField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, SyncGroupRequestAssignment message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
                buffer = Encoder.WriteCompactBytes(buffer, message.AssignmentField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}