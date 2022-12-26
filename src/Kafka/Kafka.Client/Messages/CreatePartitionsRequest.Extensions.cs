using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using CreatePartitionsAssignment = Kafka.Client.Messages.CreatePartitionsRequest.CreatePartitionsTopic.CreatePartitionsAssignment;
using CreatePartitionsTopic = Kafka.Client.Messages.CreatePartitionsRequest.CreatePartitionsTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreatePartitionsRequestSerde
    {
        private static readonly DecodeDelegate<CreatePartitionsRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<CreatePartitionsRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static CreatePartitionsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, CreatePartitionsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static CreatePartitionsRequest ReadV00(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<CreatePartitionsTopic>(buffer, ref index, CreatePartitionsTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static int WriteV00(byte[] buffer, int index, CreatePartitionsRequest message)
        {
            index = Encoder.WriteArray<CreatePartitionsTopic>(buffer, index, message.TopicsField, CreatePartitionsTopicSerde.WriteV00);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            return index;
        }
        private static CreatePartitionsRequest ReadV01(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<CreatePartitionsTopic>(buffer, ref index, CreatePartitionsTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static int WriteV01(byte[] buffer, int index, CreatePartitionsRequest message)
        {
            index = Encoder.WriteArray<CreatePartitionsTopic>(buffer, index, message.TopicsField, CreatePartitionsTopicSerde.WriteV01);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            return index;
        }
        private static CreatePartitionsRequest ReadV02(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadCompactArray<CreatePartitionsTopic>(buffer, ref index, CreatePartitionsTopicSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static int WriteV02(byte[] buffer, int index, CreatePartitionsRequest message)
        {
            index = Encoder.WriteCompactArray<CreatePartitionsTopic>(buffer, index, message.TopicsField, CreatePartitionsTopicSerde.WriteV02);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static CreatePartitionsRequest ReadV03(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadCompactArray<CreatePartitionsTopic>(buffer, ref index, CreatePartitionsTopicSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static int WriteV03(byte[] buffer, int index, CreatePartitionsRequest message)
        {
            index = Encoder.WriteCompactArray<CreatePartitionsTopic>(buffer, index, message.TopicsField, CreatePartitionsTopicSerde.WriteV03);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class CreatePartitionsTopicSerde
        {
            public static CreatePartitionsTopic ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var CountField = Decoder.ReadInt32(buffer, ref index);
                var AssignmentsField = Decoder.ReadArray<CreatePartitionsAssignment>(buffer, ref index, CreatePartitionsAssignmentSerde.ReadV00);
                return new(
                    NameField,
                    CountField,
                    AssignmentsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, CreatePartitionsTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt32(buffer, index, message.CountField);
                index = Encoder.WriteArray<CreatePartitionsAssignment>(buffer, index, message.AssignmentsField, CreatePartitionsAssignmentSerde.WriteV00);
                return index;
            }
            public static CreatePartitionsTopic ReadV01(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var CountField = Decoder.ReadInt32(buffer, ref index);
                var AssignmentsField = Decoder.ReadArray<CreatePartitionsAssignment>(buffer, ref index, CreatePartitionsAssignmentSerde.ReadV01);
                return new(
                    NameField,
                    CountField,
                    AssignmentsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, CreatePartitionsTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt32(buffer, index, message.CountField);
                index = Encoder.WriteArray<CreatePartitionsAssignment>(buffer, index, message.AssignmentsField, CreatePartitionsAssignmentSerde.WriteV01);
                return index;
            }
            public static CreatePartitionsTopic ReadV02(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var CountField = Decoder.ReadInt32(buffer, ref index);
                var AssignmentsField = Decoder.ReadCompactArray<CreatePartitionsAssignment>(buffer, ref index, CreatePartitionsAssignmentSerde.ReadV02);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    CountField,
                    AssignmentsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, CreatePartitionsTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteInt32(buffer, index, message.CountField);
                index = Encoder.WriteCompactArray<CreatePartitionsAssignment>(buffer, index, message.AssignmentsField, CreatePartitionsAssignmentSerde.WriteV02);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static CreatePartitionsTopic ReadV03(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var CountField = Decoder.ReadInt32(buffer, ref index);
                var AssignmentsField = Decoder.ReadCompactArray<CreatePartitionsAssignment>(buffer, ref index, CreatePartitionsAssignmentSerde.ReadV03);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    CountField,
                    AssignmentsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, CreatePartitionsTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteInt32(buffer, index, message.CountField);
                index = Encoder.WriteCompactArray<CreatePartitionsAssignment>(buffer, index, message.AssignmentsField, CreatePartitionsAssignmentSerde.WriteV03);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class CreatePartitionsAssignmentSerde
            {
                public static CreatePartitionsAssignment ReadV00(byte[] buffer, ref int index)
                {
                    var BrokerIdsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        BrokerIdsField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, CreatePartitionsAssignment message)
                {
                    index = Encoder.WriteArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                    return index;
                }
                public static CreatePartitionsAssignment ReadV01(byte[] buffer, ref int index)
                {
                    var BrokerIdsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        BrokerIdsField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, CreatePartitionsAssignment message)
                {
                    index = Encoder.WriteArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                    return index;
                }
                public static CreatePartitionsAssignment ReadV02(byte[] buffer, ref int index)
                {
                    var BrokerIdsField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        BrokerIdsField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, CreatePartitionsAssignment message)
                {
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static CreatePartitionsAssignment ReadV03(byte[] buffer, ref int index)
                {
                    var BrokerIdsField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        BrokerIdsField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, CreatePartitionsAssignment message)
                {
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}