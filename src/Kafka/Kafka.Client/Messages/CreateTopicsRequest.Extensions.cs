using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using CreateableTopicConfig = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic.CreateableTopicConfig;
using CreatableTopic = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic;
using CreatableReplicaAssignment = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic.CreatableReplicaAssignment;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateTopicsRequestSerde
    {
        private static readonly DecodeDelegate<CreateTopicsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV07(ref b),
        };
        private static readonly EncodeDelegate<CreateTopicsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
        };
        public static CreateTopicsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, CreateTopicsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static CreateTopicsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<CreatableTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var validateOnlyField = default(bool);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, CreateTopicsRequest message)
        {
            buffer = Encoder.WriteArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV00(b, i));
            buffer = Encoder.WriteInt32(buffer, message.timeoutMsField);
            return buffer;
        }
        private static CreateTopicsRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<CreatableTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, CreateTopicsRequest message)
        {
            buffer = Encoder.WriteArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV01(b, i));
            buffer = Encoder.WriteInt32(buffer, message.timeoutMsField);
            buffer = Encoder.WriteBoolean(buffer, message.validateOnlyField);
            return buffer;
        }
        private static CreateTopicsRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<CreatableTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, CreateTopicsRequest message)
        {
            buffer = Encoder.WriteArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV02(b, i));
            buffer = Encoder.WriteInt32(buffer, message.timeoutMsField);
            buffer = Encoder.WriteBoolean(buffer, message.validateOnlyField);
            return buffer;
        }
        private static CreateTopicsRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<CreatableTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, CreateTopicsRequest message)
        {
            buffer = Encoder.WriteArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV03(b, i));
            buffer = Encoder.WriteInt32(buffer, message.timeoutMsField);
            buffer = Encoder.WriteBoolean(buffer, message.validateOnlyField);
            return buffer;
        }
        private static CreateTopicsRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<CreatableTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, CreateTopicsRequest message)
        {
            buffer = Encoder.WriteArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV04(b, i));
            buffer = Encoder.WriteInt32(buffer, message.timeoutMsField);
            buffer = Encoder.WriteBoolean(buffer, message.validateOnlyField);
            return buffer;
        }
        private static CreateTopicsRequest ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadCompactArray<CreatableTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, CreateTopicsRequest message)
        {
            buffer = Encoder.WriteCompactArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV05(b, i));
            buffer = Encoder.WriteInt32(buffer, message.timeoutMsField);
            buffer = Encoder.WriteBoolean(buffer, message.validateOnlyField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static CreateTopicsRequest ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadCompactArray<CreatableTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, CreateTopicsRequest message)
        {
            buffer = Encoder.WriteCompactArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV06(b, i));
            buffer = Encoder.WriteInt32(buffer, message.timeoutMsField);
            buffer = Encoder.WriteBoolean(buffer, message.validateOnlyField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static CreateTopicsRequest ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadCompactArray<CreatableTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField,
                timeoutMsField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV07(Memory<byte> buffer, CreateTopicsRequest message)
        {
            buffer = Encoder.WriteCompactArray<CreatableTopic>(buffer, message.TopicsField, (b, i) => CreatableTopicSerde.WriteV07(b, i));
            buffer = Encoder.WriteInt32(buffer, message.timeoutMsField);
            buffer = Encoder.WriteBoolean(buffer, message.validateOnlyField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class CreatableTopicSerde
        {
            public static CreatableTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var numPartitionsField = Decoder.ReadInt32(ref buffer);
                var replicationFactorField = Decoder.ReadInt16(ref buffer);
                var assignmentsField = Decoder.ReadArray<CreatableReplicaAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableReplicaAssignmentSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadArray<CreateableTopicConfig>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreateableTopicConfigSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, CreatableTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt32(buffer, message.NumPartitionsField);
                buffer = Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                buffer = Encoder.WriteArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV00(b, i));
                buffer = Encoder.WriteArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV00(b, i));
                return buffer;
            }
            public static CreatableTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var numPartitionsField = Decoder.ReadInt32(ref buffer);
                var replicationFactorField = Decoder.ReadInt16(ref buffer);
                var assignmentsField = Decoder.ReadArray<CreatableReplicaAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableReplicaAssignmentSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadArray<CreateableTopicConfig>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreateableTopicConfigSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, CreatableTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt32(buffer, message.NumPartitionsField);
                buffer = Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                buffer = Encoder.WriteArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV01(b, i));
                buffer = Encoder.WriteArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV01(b, i));
                return buffer;
            }
            public static CreatableTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var numPartitionsField = Decoder.ReadInt32(ref buffer);
                var replicationFactorField = Decoder.ReadInt16(ref buffer);
                var assignmentsField = Decoder.ReadArray<CreatableReplicaAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableReplicaAssignmentSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadArray<CreateableTopicConfig>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreateableTopicConfigSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, CreatableTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt32(buffer, message.NumPartitionsField);
                buffer = Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                buffer = Encoder.WriteArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV02(b, i));
                buffer = Encoder.WriteArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV02(b, i));
                return buffer;
            }
            public static CreatableTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var numPartitionsField = Decoder.ReadInt32(ref buffer);
                var replicationFactorField = Decoder.ReadInt16(ref buffer);
                var assignmentsField = Decoder.ReadArray<CreatableReplicaAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableReplicaAssignmentSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadArray<CreateableTopicConfig>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreateableTopicConfigSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, CreatableTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt32(buffer, message.NumPartitionsField);
                buffer = Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                buffer = Encoder.WriteArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV03(b, i));
                buffer = Encoder.WriteArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV03(b, i));
                return buffer;
            }
            public static CreatableTopic ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var numPartitionsField = Decoder.ReadInt32(ref buffer);
                var replicationFactorField = Decoder.ReadInt16(ref buffer);
                var assignmentsField = Decoder.ReadArray<CreatableReplicaAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableReplicaAssignmentSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadArray<CreateableTopicConfig>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreateableTopicConfigSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, CreatableTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt32(buffer, message.NumPartitionsField);
                buffer = Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                buffer = Encoder.WriteArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV04(b, i));
                buffer = Encoder.WriteArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV04(b, i));
                return buffer;
            }
            public static CreatableTopic ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var numPartitionsField = Decoder.ReadInt32(ref buffer);
                var replicationFactorField = Decoder.ReadInt16(ref buffer);
                var assignmentsField = Decoder.ReadCompactArray<CreatableReplicaAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableReplicaAssignmentSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadCompactArray<CreateableTopicConfig>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreateableTopicConfigSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, CreatableTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteInt32(buffer, message.NumPartitionsField);
                buffer = Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                buffer = Encoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV05(b, i));
                buffer = Encoder.WriteCompactArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV05(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static CreatableTopic ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var numPartitionsField = Decoder.ReadInt32(ref buffer);
                var replicationFactorField = Decoder.ReadInt16(ref buffer);
                var assignmentsField = Decoder.ReadCompactArray<CreatableReplicaAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableReplicaAssignmentSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadCompactArray<CreateableTopicConfig>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreateableTopicConfigSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, CreatableTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteInt32(buffer, message.NumPartitionsField);
                buffer = Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                buffer = Encoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV06(b, i));
                buffer = Encoder.WriteCompactArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV06(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static CreatableTopic ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var numPartitionsField = Decoder.ReadInt32(ref buffer);
                var replicationFactorField = Decoder.ReadInt16(ref buffer);
                var assignmentsField = Decoder.ReadCompactArray<CreatableReplicaAssignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableReplicaAssignmentSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Assignments'");
                var configsField = Decoder.ReadCompactArray<CreateableTopicConfig>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreateableTopicConfigSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, CreatableTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteInt32(buffer, message.NumPartitionsField);
                buffer = Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                buffer = Encoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, message.AssignmentsField, (b, i) => CreatableReplicaAssignmentSerde.WriteV07(b, i));
                buffer = Encoder.WriteCompactArray<CreateableTopicConfig>(buffer, message.ConfigsField, (b, i) => CreateableTopicConfigSerde.WriteV07(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class CreateableTopicConfigSerde
            {
                public static CreateableTopicConfig ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var valueField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, CreateableTopicConfig message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteNullableString(buffer, message.ValueField);
                    return buffer;
                }
                public static CreateableTopicConfig ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var valueField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, CreateableTopicConfig message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteNullableString(buffer, message.ValueField);
                    return buffer;
                }
                public static CreateableTopicConfig ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var valueField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, CreateableTopicConfig message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteNullableString(buffer, message.ValueField);
                    return buffer;
                }
                public static CreateableTopicConfig ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var valueField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, CreateableTopicConfig message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteNullableString(buffer, message.ValueField);
                    return buffer;
                }
                public static CreateableTopicConfig ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var valueField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static Memory<byte> WriteV04(Memory<byte> buffer, CreateableTopicConfig message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteNullableString(buffer, message.ValueField);
                    return buffer;
                }
                public static CreateableTopicConfig ReadV05(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var valueField = Decoder.ReadCompactNullableString(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static Memory<byte> WriteV05(Memory<byte> buffer, CreateableTopicConfig message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static CreateableTopicConfig ReadV06(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var valueField = Decoder.ReadCompactNullableString(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static Memory<byte> WriteV06(Memory<byte> buffer, CreateableTopicConfig message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static CreateableTopicConfig ReadV07(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var valueField = Decoder.ReadCompactNullableString(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static Memory<byte> WriteV07(Memory<byte> buffer, CreateableTopicConfig message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
            private static class CreatableReplicaAssignmentSerde
            {
                public static CreatableReplicaAssignment ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var brokerIdsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, CreatableReplicaAssignment message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static CreatableReplicaAssignment ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var brokerIdsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, CreatableReplicaAssignment message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static CreatableReplicaAssignment ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var brokerIdsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, CreatableReplicaAssignment message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static CreatableReplicaAssignment ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var brokerIdsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, CreatableReplicaAssignment message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static CreatableReplicaAssignment ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var brokerIdsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static Memory<byte> WriteV04(Memory<byte> buffer, CreatableReplicaAssignment message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static CreatableReplicaAssignment ReadV05(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var brokerIdsField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static Memory<byte> WriteV05(Memory<byte> buffer, CreatableReplicaAssignment message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static CreatableReplicaAssignment ReadV06(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var brokerIdsField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static Memory<byte> WriteV06(Memory<byte> buffer, CreatableReplicaAssignment message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static CreatableReplicaAssignment ReadV07(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var brokerIdsField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        brokerIdsField
                    );
                }
                public static Memory<byte> WriteV07(Memory<byte> buffer, CreatableReplicaAssignment message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.BrokerIdsField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}