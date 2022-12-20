using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OffsetFetchRequestGroup = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestGroup;
using OffsetFetchRequestTopics = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestGroup.OffsetFetchRequestTopics;
using OffsetFetchRequestTopic = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetFetchRequestSerde
    {
        private static readonly DecodeDelegate<OffsetFetchRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
            ReadV08,
        };
        private static readonly EncodeDelegate<OffsetFetchRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
            WriteV08,
        };
        public static OffsetFetchRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, OffsetFetchRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static OffsetFetchRequest ReadV00(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, ref index, OffsetFetchRequestTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static int WriteV00(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            index = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV00);
            return index;
        }
        private static OffsetFetchRequest ReadV01(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, ref index, OffsetFetchRequestTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static int WriteV01(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            index = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV01);
            return index;
        }
        private static OffsetFetchRequest ReadV02(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, ref index, OffsetFetchRequestTopicSerde.ReadV02);
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static int WriteV02(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV02);
            return index;
        }
        private static OffsetFetchRequest ReadV03(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, ref index, OffsetFetchRequestTopicSerde.ReadV03);
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static int WriteV03(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV03);
            return index;
        }
        private static OffsetFetchRequest ReadV04(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, ref index, OffsetFetchRequestTopicSerde.ReadV04);
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static int WriteV04(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV04);
            return index;
        }
        private static OffsetFetchRequest ReadV05(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetFetchRequestTopic>(buffer, ref index, OffsetFetchRequestTopicSerde.ReadV05);
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static int WriteV05(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV05);
            return index;
        }
        private static OffsetFetchRequest ReadV06(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadCompactString(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<OffsetFetchRequestTopic>(buffer, ref index, OffsetFetchRequestTopicSerde.ReadV06);
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static int WriteV06(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = Encoder.WriteCompactArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV06);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static OffsetFetchRequest ReadV07(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadCompactString(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<OffsetFetchRequestTopic>(buffer, ref index, OffsetFetchRequestTopicSerde.ReadV07);
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static int WriteV07(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = Encoder.WriteCompactArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV07);
            index = Encoder.WriteBoolean(buffer, index, message.RequireStableField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static OffsetFetchRequest ReadV08(byte[] buffer, ref int index)
        {
            var groupIdField = "";
            var topicsField = ImmutableArray<OffsetFetchRequestTopic>.Empty;
            var groupsField = Decoder.ReadCompactArray<OffsetFetchRequestGroup>(buffer, ref index, OffsetFetchRequestGroupSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            var requireStableField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField
            );
        }
        private static int WriteV08(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = Encoder.WriteCompactArray<OffsetFetchRequestGroup>(buffer, index, message.GroupsField, OffsetFetchRequestGroupSerde.WriteV08);
            index = Encoder.WriteBoolean(buffer, index, message.RequireStableField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class OffsetFetchRequestGroupSerde
        {
            public static OffsetFetchRequestGroup ReadV08(byte[] buffer, ref int index)
            {
                var groupIdField = Decoder.ReadCompactString(buffer, ref index);
                var topicsField = Decoder.ReadCompactArray<OffsetFetchRequestTopics>(buffer, ref index, OffsetFetchRequestTopicsSerde.ReadV08);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    groupIdField,
                    topicsField
                );
            }
            public static int WriteV08(byte[] buffer, int index, OffsetFetchRequestGroup message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.groupIdField);
                index = Encoder.WriteCompactArray<OffsetFetchRequestTopics>(buffer, index, message.TopicsField, OffsetFetchRequestTopicsSerde.WriteV08);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class OffsetFetchRequestTopicsSerde
            {
                public static OffsetFetchRequestTopics ReadV08(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadCompactString(buffer, ref index);
                    var partitionIndexesField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        nameField,
                        partitionIndexesField
                    );
                }
                public static int WriteV08(byte[] buffer, int index, OffsetFetchRequestTopics message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
        private static class OffsetFetchRequestTopicSerde
        {
            public static OffsetFetchRequestTopic ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionIndexesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static int WriteV00(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                return index;
            }
            public static OffsetFetchRequestTopic ReadV01(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionIndexesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static int WriteV01(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                return index;
            }
            public static OffsetFetchRequestTopic ReadV02(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionIndexesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static int WriteV02(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                return index;
            }
            public static OffsetFetchRequestTopic ReadV03(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionIndexesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static int WriteV03(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                return index;
            }
            public static OffsetFetchRequestTopic ReadV04(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionIndexesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static int WriteV04(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                return index;
            }
            public static OffsetFetchRequestTopic ReadV05(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionIndexesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static int WriteV05(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                return index;
            }
            public static OffsetFetchRequestTopic ReadV06(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionIndexesField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static int WriteV06(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static OffsetFetchRequestTopic ReadV07(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionIndexesField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static int WriteV07(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}