using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using CreatePartitionsTopic = Kafka.Client.Messages.CreatePartitionsRequest.CreatePartitionsTopic;
using CreatePartitionsAssignment = Kafka.Client.Messages.CreatePartitionsRequest.CreatePartitionsTopic.CreatePartitionsAssignment;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreatePartitionsRequestSerde
    {
        private static readonly Func<Stream, CreatePartitionsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, CreatePartitionsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static CreatePartitionsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, CreatePartitionsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static CreatePartitionsRequest ReadV00(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<CreatePartitionsTopic>(buffer, b => CreatePartitionsTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static void WriteV00(Stream buffer, CreatePartitionsRequest message)
        {
            Encoder.WriteArray<CreatePartitionsTopic>(buffer, message.TopicsField, (b, i) => CreatePartitionsTopicSerde.WriteV00(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
        }
        private static CreatePartitionsRequest ReadV01(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<CreatePartitionsTopic>(buffer, b => CreatePartitionsTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static void WriteV01(Stream buffer, CreatePartitionsRequest message)
        {
            Encoder.WriteArray<CreatePartitionsTopic>(buffer, message.TopicsField, (b, i) => CreatePartitionsTopicSerde.WriteV01(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
        }
        private static CreatePartitionsRequest ReadV02(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<CreatePartitionsTopic>(buffer, b => CreatePartitionsTopicSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static void WriteV02(Stream buffer, CreatePartitionsRequest message)
        {
            Encoder.WriteCompactArray<CreatePartitionsTopic>(buffer, message.TopicsField, (b, i) => CreatePartitionsTopicSerde.WriteV02(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static CreatePartitionsRequest ReadV03(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<CreatePartitionsTopic>(buffer, b => CreatePartitionsTopicSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static void WriteV03(Stream buffer, CreatePartitionsRequest message)
        {
            Encoder.WriteCompactArray<CreatePartitionsTopic>(buffer, message.TopicsField, (b, i) => CreatePartitionsTopicSerde.WriteV03(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class CreatePartitionsTopicSerde
        {
            public static CreatePartitionsTopic ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var countField = Decoder.ReadInt32(buffer);
                var assignmentsField = Decoder.ReadArray<CreatePartitionsAssignment>(buffer, b => CreatePartitionsAssignmentSerde.ReadV00(b));
                return new(
                    nameField,
                    countField,
                    assignmentsField
                );
            }
            public static void WriteV00(Stream buffer, CreatePartitionsTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt32(buffer, message.CountField);
                Encoder.WriteArray<CreatePartitionsAssignment>(buffer, message.AssignmentsField, (b, i) => CreatePartitionsAssignmentSerde.WriteV00(b, i));
            }
            public static CreatePartitionsTopic ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var countField = Decoder.ReadInt32(buffer);
                var assignmentsField = Decoder.ReadArray<CreatePartitionsAssignment>(buffer, b => CreatePartitionsAssignmentSerde.ReadV01(b));
                return new(
                    nameField,
                    countField,
                    assignmentsField
                );
            }
            public static void WriteV01(Stream buffer, CreatePartitionsTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt32(buffer, message.CountField);
                Encoder.WriteArray<CreatePartitionsAssignment>(buffer, message.AssignmentsField, (b, i) => CreatePartitionsAssignmentSerde.WriteV01(b, i));
            }
            public static CreatePartitionsTopic ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var countField = Decoder.ReadInt32(buffer);
                var assignmentsField = Decoder.ReadCompactArray<CreatePartitionsAssignment>(buffer, b => CreatePartitionsAssignmentSerde.ReadV02(b));
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    countField,
                    assignmentsField
                );
            }
            public static void WriteV02(Stream buffer, CreatePartitionsTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt32(buffer, message.CountField);
                Encoder.WriteCompactArray<CreatePartitionsAssignment>(buffer, message.AssignmentsField, (b, i) => CreatePartitionsAssignmentSerde.WriteV02(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static CreatePartitionsTopic ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var countField = Decoder.ReadInt32(buffer);
                var assignmentsField = Decoder.ReadCompactArray<CreatePartitionsAssignment>(buffer, b => CreatePartitionsAssignmentSerde.ReadV03(b));
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    countField,
                    assignmentsField
                );
            }
            public static void WriteV03(Stream buffer, CreatePartitionsTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt32(buffer, message.CountField);
                Encoder.WriteCompactArray<CreatePartitionsAssignment>(buffer, message.AssignmentsField, (b, i) => CreatePartitionsAssignmentSerde.WriteV03(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class CreatePartitionsAssignmentSerde
            {
                public static CreatePartitionsAssignment ReadV00(Stream buffer)
                {
                    var brokerIdsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        brokerIdsField
                    );
                }
                public static void WriteV00(Stream buffer, CreatePartitionsAssignment message)
                {
                    Encoder.WriteArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static CreatePartitionsAssignment ReadV01(Stream buffer)
                {
                    var brokerIdsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        brokerIdsField
                    );
                }
                public static void WriteV01(Stream buffer, CreatePartitionsAssignment message)
                {
                    Encoder.WriteArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static CreatePartitionsAssignment ReadV02(Stream buffer)
                {
                    var brokerIdsField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        brokerIdsField
                    );
                }
                public static void WriteV02(Stream buffer, CreatePartitionsAssignment message)
                {
                    Encoder.WriteCompactArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static CreatePartitionsAssignment ReadV03(Stream buffer)
                {
                    var brokerIdsField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        brokerIdsField
                    );
                }
                public static void WriteV03(Stream buffer, CreatePartitionsAssignment message)
                {
                    Encoder.WriteCompactArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}