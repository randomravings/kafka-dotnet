using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using CreatableTopic = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic;
using CreateableTopicConfig = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic.CreateableTopicConfig;
using CreatableReplicaAssignment = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic.CreatableReplicaAssignment;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateTopicsRequestSerde
    {
        private static readonly DecodeDelegate<CreateTopicsRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
        };
        private static readonly EncodeDelegate<CreateTopicsRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
        };
        public static CreateTopicsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, CreateTopicsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static CreateTopicsRequest ReadV00(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<CreatableTopic>(buffer, ref index, CreatableTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var validateOnlyField = default(bool);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static int WriteV00(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = Encoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV00);
            index = Encoder.WriteInt32(buffer, index, message.timeoutMsField);
            return index;
        }
        private static CreateTopicsRequest ReadV01(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<CreatableTopic>(buffer, ref index, CreatableTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static int WriteV01(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = Encoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV01);
            index = Encoder.WriteInt32(buffer, index, message.timeoutMsField);
            index = Encoder.WriteBoolean(buffer, index, message.validateOnlyField);
            return index;
        }
        private static CreateTopicsRequest ReadV02(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<CreatableTopic>(buffer, ref index, CreatableTopicSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static int WriteV02(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = Encoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV02);
            index = Encoder.WriteInt32(buffer, index, message.timeoutMsField);
            index = Encoder.WriteBoolean(buffer, index, message.validateOnlyField);
            return index;
        }
        private static CreateTopicsRequest ReadV03(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<CreatableTopic>(buffer, ref index, CreatableTopicSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static int WriteV03(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = Encoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV03);
            index = Encoder.WriteInt32(buffer, index, message.timeoutMsField);
            index = Encoder.WriteBoolean(buffer, index, message.validateOnlyField);
            return index;
        }
        private static CreateTopicsRequest ReadV04(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<CreatableTopic>(buffer, ref index, CreatableTopicSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static int WriteV04(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = Encoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV04);
            index = Encoder.WriteInt32(buffer, index, message.timeoutMsField);
            index = Encoder.WriteBoolean(buffer, index, message.validateOnlyField);
            return index;
        }
        private static CreateTopicsRequest ReadV05(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadCompactArray<CreatableTopic>(buffer, ref index, CreatableTopicSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static int WriteV05(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = Encoder.WriteCompactArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV05);
            index = Encoder.WriteInt32(buffer, index, message.timeoutMsField);
            index = Encoder.WriteBoolean(buffer, index, message.validateOnlyField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static CreateTopicsRequest ReadV06(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadCompactArray<CreatableTopic>(buffer, ref index, CreatableTopicSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static int WriteV06(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = Encoder.WriteCompactArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV06);
            index = Encoder.WriteInt32(buffer, index, message.timeoutMsField);
            index = Encoder.WriteBoolean(buffer, index, message.validateOnlyField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static CreateTopicsRequest ReadV07(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadCompactArray<CreatableTopic>(buffer, ref index, CreatableTopicSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static int WriteV07(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = Encoder.WriteCompactArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV07);
            index = Encoder.WriteInt32(buffer, index, message.timeoutMsField);
            index = Encoder.WriteBoolean(buffer, index, message.validateOnlyField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class CreatableTopicSerde
        {
            public static CreatableTopic ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var numPartitionsField = Decoder.ReadInt32(buffer, ref index);
                var replicationFactorField = Decoder.ReadInt16(buffer, ref index);
                var assignmentsField = Decoder.ReadArray<CreatableReplicaAssignment>(buffer, ref index, CreatableReplicaAssignmentSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadArray<CreateableTopicConfig>(buffer, ref index, CreateableTopicConfigSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, CreatableTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = Encoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV00);
                index = Encoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV00);
                return index;
            }
            public static CreatableTopic ReadV01(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var numPartitionsField = Decoder.ReadInt32(buffer, ref index);
                var replicationFactorField = Decoder.ReadInt16(buffer, ref index);
                var assignmentsField = Decoder.ReadArray<CreatableReplicaAssignment>(buffer, ref index, CreatableReplicaAssignmentSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadArray<CreateableTopicConfig>(buffer, ref index, CreateableTopicConfigSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, CreatableTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = Encoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV01);
                index = Encoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV01);
                return index;
            }
            public static CreatableTopic ReadV02(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var numPartitionsField = Decoder.ReadInt32(buffer, ref index);
                var replicationFactorField = Decoder.ReadInt16(buffer, ref index);
                var assignmentsField = Decoder.ReadArray<CreatableReplicaAssignment>(buffer, ref index, CreatableReplicaAssignmentSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadArray<CreateableTopicConfig>(buffer, ref index, CreateableTopicConfigSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, CreatableTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = Encoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV02);
                index = Encoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV02);
                return index;
            }
            public static CreatableTopic ReadV03(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var numPartitionsField = Decoder.ReadInt32(buffer, ref index);
                var replicationFactorField = Decoder.ReadInt16(buffer, ref index);
                var assignmentsField = Decoder.ReadArray<CreatableReplicaAssignment>(buffer, ref index, CreatableReplicaAssignmentSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadArray<CreateableTopicConfig>(buffer, ref index, CreateableTopicConfigSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, CreatableTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = Encoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV03);
                index = Encoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV03);
                return index;
            }
            public static CreatableTopic ReadV04(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var numPartitionsField = Decoder.ReadInt32(buffer, ref index);
                var replicationFactorField = Decoder.ReadInt16(buffer, ref index);
                var assignmentsField = Decoder.ReadArray<CreatableReplicaAssignment>(buffer, ref index, CreatableReplicaAssignmentSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadArray<CreateableTopicConfig>(buffer, ref index, CreateableTopicConfigSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static int WriteV04(byte[] buffer, int index, CreatableTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = Encoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV04);
                index = Encoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV04);
                return index;
            }
            public static CreatableTopic ReadV05(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var numPartitionsField = Decoder.ReadInt32(buffer, ref index);
                var replicationFactorField = Decoder.ReadInt16(buffer, ref index);
                var assignmentsField = Decoder.ReadCompactArray<CreatableReplicaAssignment>(buffer, ref index, CreatableReplicaAssignmentSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadCompactArray<CreateableTopicConfig>(buffer, ref index, CreateableTopicConfigSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static int WriteV05(byte[] buffer, int index, CreatableTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = Encoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV05);
                index = Encoder.WriteCompactArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV05);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static CreatableTopic ReadV06(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var numPartitionsField = Decoder.ReadInt32(buffer, ref index);
                var replicationFactorField = Decoder.ReadInt16(buffer, ref index);
                var assignmentsField = Decoder.ReadCompactArray<CreatableReplicaAssignment>(buffer, ref index, CreatableReplicaAssignmentSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadCompactArray<CreateableTopicConfig>(buffer, ref index, CreateableTopicConfigSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static int WriteV06(byte[] buffer, int index, CreatableTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = Encoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV06);
                index = Encoder.WriteCompactArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV06);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static CreatableTopic ReadV07(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var numPartitionsField = Decoder.ReadInt32(buffer, ref index);
                var replicationFactorField = Decoder.ReadInt16(buffer, ref index);
                var assignmentsField = Decoder.ReadCompactArray<CreatableReplicaAssignment>(buffer, ref index, CreatableReplicaAssignmentSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadCompactArray<CreateableTopicConfig>(buffer, ref index, CreateableTopicConfigSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static int WriteV07(byte[] buffer, int index, CreatableTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = Encoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV07);
                index = Encoder.WriteCompactArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV07);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class CreateableTopicConfigSerde
            {
                public static CreateableTopicConfig ReadV00(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadString(buffer, ref index);
                    var valueField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                    return index;
                }
                public static CreateableTopicConfig ReadV01(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadString(buffer, ref index);
                    var valueField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                    return index;
                }
                public static CreateableTopicConfig ReadV02(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadString(buffer, ref index);
                    var valueField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                    return index;
                }
                public static CreateableTopicConfig ReadV03(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadString(buffer, ref index);
                    var valueField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                    return index;
                }
                public static CreateableTopicConfig ReadV04(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadString(buffer, ref index);
                    var valueField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                    return index;
                }
                public static CreateableTopicConfig ReadV05(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadCompactString(buffer, ref index);
                    var valueField = Decoder.ReadCompactNullableString(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static int WriteV05(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static CreateableTopicConfig ReadV06(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadCompactString(buffer, ref index);
                    var valueField = Decoder.ReadCompactNullableString(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static int WriteV06(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static CreateableTopicConfig ReadV07(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadCompactString(buffer, ref index);
                    var valueField = Decoder.ReadCompactNullableString(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static int WriteV07(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
            private static class CreatableReplicaAssignmentSerde
            {
                public static CreatableReplicaAssignment ReadV00(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var brokerIdsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                    return index;
                }
                public static CreatableReplicaAssignment ReadV01(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var brokerIdsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                    return index;
                }
                public static CreatableReplicaAssignment ReadV02(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var brokerIdsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                    return index;
                }
                public static CreatableReplicaAssignment ReadV03(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var brokerIdsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                    return index;
                }
                public static CreatableReplicaAssignment ReadV04(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var brokerIdsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                    return index;
                }
                public static CreatableReplicaAssignment ReadV05(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var brokerIdsField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static int WriteV05(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static CreatableReplicaAssignment ReadV06(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var brokerIdsField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static int WriteV06(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static CreatableReplicaAssignment ReadV07(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var brokerIdsField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static int WriteV07(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.BrokerIdsField, Encoder.WriteInt32);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}