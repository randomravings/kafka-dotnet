using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using CreatableTopic = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic;
using CreatableReplicaAssignment = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic.CreatableReplicaAssignment;
using CreateableTopicConfig = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic.CreateableTopicConfig;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateTopicsRequestSerde
    {
        private static readonly Func<Stream, CreateTopicsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
            b => ReadV07(b),
        };
        private static readonly Action<Stream, CreateTopicsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
        };
        public static CreateTopicsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, CreateTopicsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static CreateTopicsRequest ReadV00(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<CreatableTopic>(buffer, b => CreatableTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var validateOnlyField = default(bool);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static void WriteV00(Stream buffer, CreateTopicsRequest message)
        {
            Encoder.WriteArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV00(b, i));
            Encoder.WriteInt32(buffer, message.timeoutMsField);
        }
        private static CreateTopicsRequest ReadV01(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<CreatableTopic>(buffer, b => CreatableTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static void WriteV01(Stream buffer, CreateTopicsRequest message)
        {
            Encoder.WriteArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV01(b, i));
            Encoder.WriteInt32(buffer, message.timeoutMsField);
            Encoder.WriteBoolean(buffer, message.validateOnlyField);
        }
        private static CreateTopicsRequest ReadV02(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<CreatableTopic>(buffer, b => CreatableTopicSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static void WriteV02(Stream buffer, CreateTopicsRequest message)
        {
            Encoder.WriteArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV02(b, i));
            Encoder.WriteInt32(buffer, message.timeoutMsField);
            Encoder.WriteBoolean(buffer, message.validateOnlyField);
        }
        private static CreateTopicsRequest ReadV03(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<CreatableTopic>(buffer, b => CreatableTopicSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static void WriteV03(Stream buffer, CreateTopicsRequest message)
        {
            Encoder.WriteArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV03(b, i));
            Encoder.WriteInt32(buffer, message.timeoutMsField);
            Encoder.WriteBoolean(buffer, message.validateOnlyField);
        }
        private static CreateTopicsRequest ReadV04(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<CreatableTopic>(buffer, b => CreatableTopicSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static void WriteV04(Stream buffer, CreateTopicsRequest message)
        {
            Encoder.WriteArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV04(b, i));
            Encoder.WriteInt32(buffer, message.timeoutMsField);
            Encoder.WriteBoolean(buffer, message.validateOnlyField);
        }
        private static CreateTopicsRequest ReadV05(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<CreatableTopic>(buffer, b => CreatableTopicSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static void WriteV05(Stream buffer, CreateTopicsRequest message)
        {
            Encoder.WriteCompactArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV05(b, i));
            Encoder.WriteInt32(buffer, message.timeoutMsField);
            Encoder.WriteBoolean(buffer, message.validateOnlyField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static CreateTopicsRequest ReadV06(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<CreatableTopic>(buffer, b => CreatableTopicSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static void WriteV06(Stream buffer, CreateTopicsRequest message)
        {
            Encoder.WriteCompactArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV06(b, i));
            Encoder.WriteInt32(buffer, message.timeoutMsField);
            Encoder.WriteBoolean(buffer, message.validateOnlyField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static CreateTopicsRequest ReadV07(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<CreatableTopic>(buffer, b => CreatableTopicSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static void WriteV07(Stream buffer, CreateTopicsRequest message)
        {
            Encoder.WriteCompactArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV07(b, i));
            Encoder.WriteInt32(buffer, message.timeoutMsField);
            Encoder.WriteBoolean(buffer, message.validateOnlyField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class CreatableTopicSerde
        {
            public static CreatableTopic ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var numPartitionsField = Decoder.ReadInt32(buffer);
                var replicationFactorField = Decoder.ReadInt16(buffer);
                var assignmentsField = Decoder.ReadArray<CreatableReplicaAssignment>(buffer, b => CreatableReplicaAssignmentSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadArray<CreateableTopicConfig>(buffer, b => CreateableTopicConfigSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static void WriteV00(Stream buffer, CreatableTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt32(buffer, message.NumPartitionsField);
                Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                Encoder.WriteArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV00(b, i));
                Encoder.WriteArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV00(b, i));
            }
            public static CreatableTopic ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var numPartitionsField = Decoder.ReadInt32(buffer);
                var replicationFactorField = Decoder.ReadInt16(buffer);
                var assignmentsField = Decoder.ReadArray<CreatableReplicaAssignment>(buffer, b => CreatableReplicaAssignmentSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadArray<CreateableTopicConfig>(buffer, b => CreateableTopicConfigSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static void WriteV01(Stream buffer, CreatableTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt32(buffer, message.NumPartitionsField);
                Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                Encoder.WriteArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV01(b, i));
                Encoder.WriteArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV01(b, i));
            }
            public static CreatableTopic ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var numPartitionsField = Decoder.ReadInt32(buffer);
                var replicationFactorField = Decoder.ReadInt16(buffer);
                var assignmentsField = Decoder.ReadArray<CreatableReplicaAssignment>(buffer, b => CreatableReplicaAssignmentSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadArray<CreateableTopicConfig>(buffer, b => CreateableTopicConfigSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static void WriteV02(Stream buffer, CreatableTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt32(buffer, message.NumPartitionsField);
                Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                Encoder.WriteArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV02(b, i));
                Encoder.WriteArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV02(b, i));
            }
            public static CreatableTopic ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var numPartitionsField = Decoder.ReadInt32(buffer);
                var replicationFactorField = Decoder.ReadInt16(buffer);
                var assignmentsField = Decoder.ReadArray<CreatableReplicaAssignment>(buffer, b => CreatableReplicaAssignmentSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadArray<CreateableTopicConfig>(buffer, b => CreateableTopicConfigSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static void WriteV03(Stream buffer, CreatableTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt32(buffer, message.NumPartitionsField);
                Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                Encoder.WriteArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV03(b, i));
                Encoder.WriteArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV03(b, i));
            }
            public static CreatableTopic ReadV04(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var numPartitionsField = Decoder.ReadInt32(buffer);
                var replicationFactorField = Decoder.ReadInt16(buffer);
                var assignmentsField = Decoder.ReadArray<CreatableReplicaAssignment>(buffer, b => CreatableReplicaAssignmentSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadArray<CreateableTopicConfig>(buffer, b => CreateableTopicConfigSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static void WriteV04(Stream buffer, CreatableTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt32(buffer, message.NumPartitionsField);
                Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                Encoder.WriteArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV04(b, i));
                Encoder.WriteArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV04(b, i));
            }
            public static CreatableTopic ReadV05(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var numPartitionsField = Decoder.ReadInt32(buffer);
                var replicationFactorField = Decoder.ReadInt16(buffer);
                var assignmentsField = Decoder.ReadCompactArray<CreatableReplicaAssignment>(buffer, b => CreatableReplicaAssignmentSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadCompactArray<CreateableTopicConfig>(buffer, b => CreateableTopicConfigSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static void WriteV05(Stream buffer, CreatableTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt32(buffer, message.NumPartitionsField);
                Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                Encoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV05(b, i));
                Encoder.WriteCompactArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV05(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static CreatableTopic ReadV06(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var numPartitionsField = Decoder.ReadInt32(buffer);
                var replicationFactorField = Decoder.ReadInt16(buffer);
                var assignmentsField = Decoder.ReadCompactArray<CreatableReplicaAssignment>(buffer, b => CreatableReplicaAssignmentSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadCompactArray<CreateableTopicConfig>(buffer, b => CreateableTopicConfigSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static void WriteV06(Stream buffer, CreatableTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt32(buffer, message.NumPartitionsField);
                Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                Encoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV06(b, i));
                Encoder.WriteCompactArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV06(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static CreatableTopic ReadV07(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var numPartitionsField = Decoder.ReadInt32(buffer);
                var replicationFactorField = Decoder.ReadInt16(buffer);
                var assignmentsField = Decoder.ReadCompactArray<CreatableReplicaAssignment>(buffer, b => CreatableReplicaAssignmentSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadCompactArray<CreateableTopicConfig>(buffer, b => CreateableTopicConfigSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static void WriteV07(Stream buffer, CreatableTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt32(buffer, message.NumPartitionsField);
                Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                Encoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV07(b, i));
                Encoder.WriteCompactArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV07(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class CreatableReplicaAssignmentSerde
            {
                public static CreatableReplicaAssignment ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var brokerIdsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static void WriteV00(Stream buffer, CreatableReplicaAssignment message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static CreatableReplicaAssignment ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var brokerIdsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static void WriteV01(Stream buffer, CreatableReplicaAssignment message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static CreatableReplicaAssignment ReadV02(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var brokerIdsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static void WriteV02(Stream buffer, CreatableReplicaAssignment message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static CreatableReplicaAssignment ReadV03(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var brokerIdsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static void WriteV03(Stream buffer, CreatableReplicaAssignment message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static CreatableReplicaAssignment ReadV04(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var brokerIdsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static void WriteV04(Stream buffer, CreatableReplicaAssignment message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static CreatableReplicaAssignment ReadV05(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var brokerIdsField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static void WriteV05(Stream buffer, CreatableReplicaAssignment message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteCompactArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static CreatableReplicaAssignment ReadV06(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var brokerIdsField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static void WriteV06(Stream buffer, CreatableReplicaAssignment message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteCompactArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static CreatableReplicaAssignment ReadV07(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var brokerIdsField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static void WriteV07(Stream buffer, CreatableReplicaAssignment message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteCompactArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
            private static class CreateableTopicConfigSerde
            {
                public static CreateableTopicConfig ReadV00(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var valueField = Decoder.ReadNullableString(buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static void WriteV00(Stream buffer, CreateableTopicConfig message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteNullableString(buffer, message.ValueField);
                }
                public static CreateableTopicConfig ReadV01(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var valueField = Decoder.ReadNullableString(buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static void WriteV01(Stream buffer, CreateableTopicConfig message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteNullableString(buffer, message.ValueField);
                }
                public static CreateableTopicConfig ReadV02(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var valueField = Decoder.ReadNullableString(buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static void WriteV02(Stream buffer, CreateableTopicConfig message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteNullableString(buffer, message.ValueField);
                }
                public static CreateableTopicConfig ReadV03(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var valueField = Decoder.ReadNullableString(buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static void WriteV03(Stream buffer, CreateableTopicConfig message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteNullableString(buffer, message.ValueField);
                }
                public static CreateableTopicConfig ReadV04(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var valueField = Decoder.ReadNullableString(buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static void WriteV04(Stream buffer, CreateableTopicConfig message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteNullableString(buffer, message.ValueField);
                }
                public static CreateableTopicConfig ReadV05(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var valueField = Decoder.ReadCompactNullableString(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static void WriteV05(Stream buffer, CreateableTopicConfig message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static CreateableTopicConfig ReadV06(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var valueField = Decoder.ReadCompactNullableString(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static void WriteV06(Stream buffer, CreateableTopicConfig message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static CreateableTopicConfig ReadV07(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var valueField = Decoder.ReadCompactNullableString(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static void WriteV07(Stream buffer, CreateableTopicConfig message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}