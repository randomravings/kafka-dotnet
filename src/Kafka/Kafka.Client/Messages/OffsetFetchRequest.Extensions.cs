using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OffsetFetchRequestTopics = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestGroup.OffsetFetchRequestTopics;
using OffsetFetchRequestGroup = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestGroup;
using OffsetFetchRequestTopic = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetFetchRequestSerde
    {
        private static readonly DecodeDelegate<OffsetFetchRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV07(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV08(ref b),
        };
        private static readonly EncodeDelegate<OffsetFetchRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
            (b, m) => WriteV08(b, m),
        };
        public static OffsetFetchRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, OffsetFetchRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static OffsetFetchRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchRequestTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, OffsetFetchRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            buffer = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV00(b, i));
            return buffer;
        }
        private static OffsetFetchRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchRequestTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, OffsetFetchRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            buffer = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV01(b, i));
            return buffer;
        }
        private static OffsetFetchRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchRequestTopicSerde.ReadV02(ref b));
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, OffsetFetchRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV02(b, i));
            return buffer;
        }
        private static OffsetFetchRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchRequestTopicSerde.ReadV03(ref b));
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, OffsetFetchRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV03(b, i));
            return buffer;
        }
        private static OffsetFetchRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchRequestTopicSerde.ReadV04(ref b));
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, OffsetFetchRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV04(b, i));
            return buffer;
        }
        private static OffsetFetchRequest ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchRequestTopicSerde.ReadV05(ref b));
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, OffsetFetchRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV05(b, i));
            return buffer;
        }
        private static OffsetFetchRequest ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadCompactString(ref buffer);
            var topicsField = Decoder.ReadCompactArray<OffsetFetchRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchRequestTopicSerde.ReadV06(ref b));
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, OffsetFetchRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
            buffer = Encoder.WriteCompactArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV06(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static OffsetFetchRequest ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadCompactString(ref buffer);
            var topicsField = Decoder.ReadCompactArray<OffsetFetchRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchRequestTopicSerde.ReadV07(ref b));
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static Memory<byte> WriteV07(Memory<byte> buffer, OffsetFetchRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
            buffer = Encoder.WriteCompactArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV07(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.RequireStableField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static OffsetFetchRequest ReadV08(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = "";
            var topicsField = ImmutableArray<OffsetFetchRequestTopic>.Empty;
            var groupsField = Decoder.ReadCompactArray<OffsetFetchRequestGroup>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchRequestGroupSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            var requireStableField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static Memory<byte> WriteV08(Memory<byte> buffer, OffsetFetchRequest message)
        {
            buffer = Encoder.WriteCompactArray<OffsetFetchRequestGroup>(buffer, message.GroupsField, (b, i) => OffsetFetchRequestGroupSerde.WriteV08(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.RequireStableField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class OffsetFetchRequestGroupSerde
        {
            public static OffsetFetchRequestGroup ReadV08(ref ReadOnlyMemory<byte> buffer)
            {
                var groupIdField = Decoder.ReadCompactString(ref buffer);
                var topicsField = Decoder.ReadCompactArray<OffsetFetchRequestTopics>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchRequestTopicsSerde.ReadV08(ref b));
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    groupIdField,
                    topicsField
                );
            }
            public static Memory<byte> WriteV08(Memory<byte> buffer, OffsetFetchRequestGroup message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.groupIdField);
                buffer = Encoder.WriteCompactArray<OffsetFetchRequestTopics>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicsSerde.WriteV08(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class OffsetFetchRequestTopicsSerde
            {
                public static OffsetFetchRequestTopics ReadV08(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var partitionIndexesField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        partitionIndexesField
                    );
                }
                public static Memory<byte> WriteV08(Memory<byte> buffer, OffsetFetchRequestTopics message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
        private static class OffsetFetchRequestTopicSerde
        {
            public static OffsetFetchRequestTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionIndexesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, OffsetFetchRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static OffsetFetchRequestTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionIndexesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, OffsetFetchRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static OffsetFetchRequestTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionIndexesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, OffsetFetchRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static OffsetFetchRequestTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionIndexesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, OffsetFetchRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static OffsetFetchRequestTopic ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionIndexesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, OffsetFetchRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static OffsetFetchRequestTopic ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionIndexesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, OffsetFetchRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static OffsetFetchRequestTopic ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionIndexesField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, OffsetFetchRequestTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static OffsetFetchRequestTopic ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionIndexesField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, OffsetFetchRequestTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}