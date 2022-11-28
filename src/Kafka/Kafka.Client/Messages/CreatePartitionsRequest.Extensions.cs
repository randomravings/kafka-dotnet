using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using CreatePartitionsAssignment = Kafka.Client.Messages.CreatePartitionsRequest.CreatePartitionsTopic.CreatePartitionsAssignment;
using CreatePartitionsTopic = Kafka.Client.Messages.CreatePartitionsRequest.CreatePartitionsTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreatePartitionsRequestSerde
    {
        private static readonly DecodeDelegate<CreatePartitionsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<CreatePartitionsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static CreatePartitionsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, CreatePartitionsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static CreatePartitionsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<CreatePartitionsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatePartitionsTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, CreatePartitionsRequest message)
        {
            buffer = Encoder.WriteArray<CreatePartitionsTopic>(buffer, message.TopicsField, (b, i) => CreatePartitionsTopicSerde.WriteV00(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
            return buffer;
        }
        private static CreatePartitionsRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<CreatePartitionsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatePartitionsTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, CreatePartitionsRequest message)
        {
            buffer = Encoder.WriteArray<CreatePartitionsTopic>(buffer, message.TopicsField, (b, i) => CreatePartitionsTopicSerde.WriteV01(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
            return buffer;
        }
        private static CreatePartitionsRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadCompactArray<CreatePartitionsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatePartitionsTopicSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, CreatePartitionsRequest message)
        {
            buffer = Encoder.WriteCompactArray<CreatePartitionsTopic>(buffer, message.TopicsField, (b, i) => CreatePartitionsTopicSerde.WriteV02(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static CreatePartitionsRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadCompactArray<CreatePartitionsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatePartitionsTopicSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, CreatePartitionsRequest message)
        {
            buffer = Encoder.WriteCompactArray<CreatePartitionsTopic>(buffer, message.TopicsField, (b, i) => CreatePartitionsTopicSerde.WriteV03(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class CreatePartitionsTopicSerde
        {
            public static CreatePartitionsTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var countField = Decoder.ReadInt32(ref buffer);
                var assignmentsField = Decoder.ReadArray<CreatePartitionsAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatePartitionsAssignmentSerde.ReadV00(ref b));
                return new(
                    nameField,
                    countField,
                    assignmentsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, CreatePartitionsTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt32(buffer, message.CountField);
                buffer = Encoder.WriteArray<CreatePartitionsAssignment>(buffer, message.AssignmentsField, (b, i) => CreatePartitionsAssignmentSerde.WriteV00(b, i));
                return buffer;
            }
            public static CreatePartitionsTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var countField = Decoder.ReadInt32(ref buffer);
                var assignmentsField = Decoder.ReadArray<CreatePartitionsAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatePartitionsAssignmentSerde.ReadV01(ref b));
                return new(
                    nameField,
                    countField,
                    assignmentsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, CreatePartitionsTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt32(buffer, message.CountField);
                buffer = Encoder.WriteArray<CreatePartitionsAssignment>(buffer, message.AssignmentsField, (b, i) => CreatePartitionsAssignmentSerde.WriteV01(b, i));
                return buffer;
            }
            public static CreatePartitionsTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var countField = Decoder.ReadInt32(ref buffer);
                var assignmentsField = Decoder.ReadCompactArray<CreatePartitionsAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatePartitionsAssignmentSerde.ReadV02(ref b));
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    countField,
                    assignmentsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, CreatePartitionsTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteInt32(buffer, message.CountField);
                buffer = Encoder.WriteCompactArray<CreatePartitionsAssignment>(buffer, message.AssignmentsField, (b, i) => CreatePartitionsAssignmentSerde.WriteV02(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static CreatePartitionsTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var countField = Decoder.ReadInt32(ref buffer);
                var assignmentsField = Decoder.ReadCompactArray<CreatePartitionsAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatePartitionsAssignmentSerde.ReadV03(ref b));
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    countField,
                    assignmentsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, CreatePartitionsTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteInt32(buffer, message.CountField);
                buffer = Encoder.WriteCompactArray<CreatePartitionsAssignment>(buffer, message.AssignmentsField, (b, i) => CreatePartitionsAssignmentSerde.WriteV03(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class CreatePartitionsAssignmentSerde
            {
                public static CreatePartitionsAssignment ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var brokerIdsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        brokerIdsField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, CreatePartitionsAssignment message)
                {
                    buffer = Encoder.WriteArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static CreatePartitionsAssignment ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var brokerIdsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        brokerIdsField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, CreatePartitionsAssignment message)
                {
                    buffer = Encoder.WriteArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static CreatePartitionsAssignment ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var brokerIdsField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        brokerIdsField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, CreatePartitionsAssignment message)
                {
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static CreatePartitionsAssignment ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var brokerIdsField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        brokerIdsField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, CreatePartitionsAssignment message)
                {
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}