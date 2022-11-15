using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OffsetFetchRequestTopic = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestTopic;
using OffsetFetchRequestTopics = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestGroup.OffsetFetchRequestTopics;
using OffsetFetchRequestGroup = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestGroup;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetFetchRequestSerde
    {
        private static readonly Func<Stream, OffsetFetchRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
            b => ReadV07(b),
            b => ReadV08(b),
        };
        private static readonly Action<Stream, OffsetFetchRequest>[] WRITE_VERSIONS = {
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
        public static OffsetFetchRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, OffsetFetchRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static OffsetFetchRequest ReadV00(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, b => OffsetFetchRequestTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static void WriteV00(Stream buffer, OffsetFetchRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV00(b, i));
        }
        private static OffsetFetchRequest ReadV01(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, b => OffsetFetchRequestTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static void WriteV01(Stream buffer, OffsetFetchRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV01(b, i));
        }
        private static OffsetFetchRequest ReadV02(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, b => OffsetFetchRequestTopicSerde.ReadV02(b));
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static void WriteV02(Stream buffer, OffsetFetchRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV02(b, i));
        }
        private static OffsetFetchRequest ReadV03(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, b => OffsetFetchRequestTopicSerde.ReadV03(b));
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static void WriteV03(Stream buffer, OffsetFetchRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV03(b, i));
        }
        private static OffsetFetchRequest ReadV04(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, b => OffsetFetchRequestTopicSerde.ReadV04(b));
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static void WriteV04(Stream buffer, OffsetFetchRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV04(b, i));
        }
        private static OffsetFetchRequest ReadV05(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, b => OffsetFetchRequestTopicSerde.ReadV05(b));
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static void WriteV05(Stream buffer, OffsetFetchRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV05(b, i));
        }
        private static OffsetFetchRequest ReadV06(Stream buffer)
        {
            var groupIdField = Decoder.ReadCompactString(buffer);
            var topicsField = Decoder.ReadCompactArray<OffsetFetchRequestTopic>(buffer, b => OffsetFetchRequestTopicSerde.ReadV06(b));
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static void WriteV06(Stream buffer, OffsetFetchRequest message)
        {
            Encoder.WriteCompactString(buffer, message.GroupIdField);
            Encoder.WriteCompactArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV06(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static OffsetFetchRequest ReadV07(Stream buffer)
        {
            var groupIdField = Decoder.ReadCompactString(buffer);
            var topicsField = Decoder.ReadCompactArray<OffsetFetchRequestTopic>(buffer, b => OffsetFetchRequestTopicSerde.ReadV07(b));
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static void WriteV07(Stream buffer, OffsetFetchRequest message)
        {
            Encoder.WriteCompactString(buffer, message.GroupIdField);
            Encoder.WriteCompactArray<OffsetFetchRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicSerde.WriteV07(b, i));
            Encoder.WriteBoolean(buffer, message.RequireStableField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static OffsetFetchRequest ReadV08(Stream buffer)
        {
            var groupIdField = "";
            var topicsField = ImmutableArray<OffsetFetchRequestTopic>.Empty;
            var groupsField = Decoder.ReadCompactArray<OffsetFetchRequestGroup>(buffer, b => OffsetFetchRequestGroupSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            var requireStableField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static void WriteV08(Stream buffer, OffsetFetchRequest message)
        {
            Encoder.WriteCompactArray<OffsetFetchRequestGroup>(buffer, message.GroupsField, (b, i) => OffsetFetchRequestGroupSerde.WriteV08(b, i));
            Encoder.WriteBoolean(buffer, message.RequireStableField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class OffsetFetchRequestTopicSerde
        {
            public static OffsetFetchRequestTopic ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionIndexesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static void WriteV00(Stream buffer, OffsetFetchRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static OffsetFetchRequestTopic ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionIndexesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static void WriteV01(Stream buffer, OffsetFetchRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static OffsetFetchRequestTopic ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionIndexesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static void WriteV02(Stream buffer, OffsetFetchRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static OffsetFetchRequestTopic ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionIndexesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static void WriteV03(Stream buffer, OffsetFetchRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static OffsetFetchRequestTopic ReadV04(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionIndexesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static void WriteV04(Stream buffer, OffsetFetchRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static OffsetFetchRequestTopic ReadV05(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionIndexesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static void WriteV05(Stream buffer, OffsetFetchRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static OffsetFetchRequestTopic ReadV06(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionIndexesField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static void WriteV06(Stream buffer, OffsetFetchRequestTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static OffsetFetchRequestTopic ReadV07(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionIndexesField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static void WriteV07(Stream buffer, OffsetFetchRequestTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
        private static class OffsetFetchRequestGroupSerde
        {
            public static OffsetFetchRequestGroup ReadV08(Stream buffer)
            {
                var groupIdField = Decoder.ReadCompactString(buffer);
                var topicsField = Decoder.ReadCompactArray<OffsetFetchRequestTopics>(buffer, b => OffsetFetchRequestTopicsSerde.ReadV08(b));
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    groupIdField,
                    topicsField
                );
            }
            public static void WriteV08(Stream buffer, OffsetFetchRequestGroup message)
            {
                Encoder.WriteCompactString(buffer, message.groupIdField);
                Encoder.WriteCompactArray<OffsetFetchRequestTopics>(buffer, message.TopicsField, (b, i) => OffsetFetchRequestTopicsSerde.WriteV08(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class OffsetFetchRequestTopicsSerde
            {
                public static OffsetFetchRequestTopics ReadV08(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var partitionIndexesField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        nameField,
                        partitionIndexesField
                    );
                }
                public static void WriteV08(Stream buffer, OffsetFetchRequestTopics message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}