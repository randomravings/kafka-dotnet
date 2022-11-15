using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OffsetFetchResponseTopic = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseTopic;
using OffsetFetchResponseGroup = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup;
using OffsetFetchResponsePartitions = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup.OffsetFetchResponseTopics.OffsetFetchResponsePartitions;
using OffsetFetchResponseTopics = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup.OffsetFetchResponseTopics;
using OffsetFetchResponsePartition = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseTopic.OffsetFetchResponsePartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetFetchResponseSerde
    {
        private static readonly Func<Stream, OffsetFetchResponse>[] READ_VERSIONS = {
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
        private static readonly Action<Stream, OffsetFetchResponse>[] WRITE_VERSIONS = {
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
        public static OffsetFetchResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, OffsetFetchResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static OffsetFetchResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, b => OffsetFetchResponseTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static void WriteV00(Stream buffer, OffsetFetchResponse message)
        {
            Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV00(b, i));
        }
        private static OffsetFetchResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, b => OffsetFetchResponseTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static void WriteV01(Stream buffer, OffsetFetchResponse message)
        {
            Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV01(b, i));
        }
        private static OffsetFetchResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, b => OffsetFetchResponseTopicSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(buffer);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static void WriteV02(Stream buffer, OffsetFetchResponse message)
        {
            Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV02(b, i));
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static OffsetFetchResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, b => OffsetFetchResponseTopicSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(buffer);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static void WriteV03(Stream buffer, OffsetFetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV03(b, i));
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static OffsetFetchResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, b => OffsetFetchResponseTopicSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(buffer);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static void WriteV04(Stream buffer, OffsetFetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV04(b, i));
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static OffsetFetchResponse ReadV05(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, b => OffsetFetchResponseTopicSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(buffer);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static void WriteV05(Stream buffer, OffsetFetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV05(b, i));
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static OffsetFetchResponse ReadV06(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<OffsetFetchResponseTopic>(buffer, b => OffsetFetchResponseTopicSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(buffer);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static void WriteV06(Stream buffer, OffsetFetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV06(b, i));
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static OffsetFetchResponse ReadV07(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<OffsetFetchResponseTopic>(buffer, b => OffsetFetchResponseTopicSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(buffer);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static void WriteV07(Stream buffer, OffsetFetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV07(b, i));
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static OffsetFetchResponse ReadV08(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = Decoder.ReadCompactArray<OffsetFetchResponseGroup>(buffer, b => OffsetFetchResponseGroupSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static void WriteV08(Stream buffer, OffsetFetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<OffsetFetchResponseGroup>(buffer, message.GroupsField, (b, i) => OffsetFetchResponseGroupSerde.WriteV08(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class OffsetFetchResponseTopicSerde
        {
            public static OffsetFetchResponseTopic ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, b => OffsetFetchResponsePartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, OffsetFetchResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV00(b, i));
            }
            public static OffsetFetchResponseTopic ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, b => OffsetFetchResponsePartitionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, OffsetFetchResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV01(b, i));
            }
            public static OffsetFetchResponseTopic ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, b => OffsetFetchResponsePartitionSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, OffsetFetchResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV02(b, i));
            }
            public static OffsetFetchResponseTopic ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, b => OffsetFetchResponsePartitionSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV03(Stream buffer, OffsetFetchResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV03(b, i));
            }
            public static OffsetFetchResponseTopic ReadV04(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, b => OffsetFetchResponsePartitionSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV04(Stream buffer, OffsetFetchResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV04(b, i));
            }
            public static OffsetFetchResponseTopic ReadV05(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, b => OffsetFetchResponsePartitionSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV05(Stream buffer, OffsetFetchResponseTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV05(b, i));
            }
            public static OffsetFetchResponseTopic ReadV06(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<OffsetFetchResponsePartition>(buffer, b => OffsetFetchResponsePartitionSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV06(Stream buffer, OffsetFetchResponseTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV06(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static OffsetFetchResponseTopic ReadV07(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<OffsetFetchResponsePartition>(buffer, b => OffsetFetchResponsePartitionSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV07(Stream buffer, OffsetFetchResponseTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV07(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class OffsetFetchResponsePartitionSerde
            {
                public static OffsetFetchResponsePartition ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = default(int);
                    var metadataField = Decoder.ReadNullableString(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static void WriteV00(Stream buffer, OffsetFetchResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteNullableString(buffer, message.MetadataField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static OffsetFetchResponsePartition ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = default(int);
                    var metadataField = Decoder.ReadNullableString(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static void WriteV01(Stream buffer, OffsetFetchResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteNullableString(buffer, message.MetadataField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static OffsetFetchResponsePartition ReadV02(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = default(int);
                    var metadataField = Decoder.ReadNullableString(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static void WriteV02(Stream buffer, OffsetFetchResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteNullableString(buffer, message.MetadataField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static OffsetFetchResponsePartition ReadV03(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = default(int);
                    var metadataField = Decoder.ReadNullableString(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static void WriteV03(Stream buffer, OffsetFetchResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteNullableString(buffer, message.MetadataField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static OffsetFetchResponsePartition ReadV04(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = default(int);
                    var metadataField = Decoder.ReadNullableString(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static void WriteV04(Stream buffer, OffsetFetchResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteNullableString(buffer, message.MetadataField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static OffsetFetchResponsePartition ReadV05(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(buffer);
                    var metadataField = Decoder.ReadNullableString(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static void WriteV05(Stream buffer, OffsetFetchResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    Encoder.WriteNullableString(buffer, message.MetadataField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static OffsetFetchResponsePartition ReadV06(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(buffer);
                    var metadataField = Decoder.ReadCompactNullableString(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static void WriteV06(Stream buffer, OffsetFetchResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    Encoder.WriteCompactNullableString(buffer, message.MetadataField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static OffsetFetchResponsePartition ReadV07(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(buffer);
                    var metadataField = Decoder.ReadCompactNullableString(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static void WriteV07(Stream buffer, OffsetFetchResponsePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    Encoder.WriteCompactNullableString(buffer, message.MetadataField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
        private static class OffsetFetchResponseGroupSerde
        {
            public static OffsetFetchResponseGroup ReadV08(Stream buffer)
            {
                var groupIdField = Decoder.ReadCompactString(buffer);
                var topicsField = Decoder.ReadCompactArray<OffsetFetchResponseTopics>(buffer, b => OffsetFetchResponseTopicsSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var errorCodeField = Decoder.ReadInt16(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    groupIdField,
                    topicsField,
                    errorCodeField
                );
            }
            public static void WriteV08(Stream buffer, OffsetFetchResponseGroup message)
            {
                Encoder.WriteCompactString(buffer, message.groupIdField);
                Encoder.WriteCompactArray<OffsetFetchResponseTopics>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicsSerde.WriteV08(b, i));
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class OffsetFetchResponseTopicsSerde
            {
                public static OffsetFetchResponseTopics ReadV08(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var partitionsField = Decoder.ReadCompactArray<OffsetFetchResponsePartitions>(buffer, b => OffsetFetchResponsePartitionsSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static void WriteV08(Stream buffer, OffsetFetchResponseTopics message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactArray<OffsetFetchResponsePartitions>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionsSerde.WriteV08(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                private static class OffsetFetchResponsePartitionsSerde
                {
                    public static OffsetFetchResponsePartitions ReadV08(Stream buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(buffer);
                        var committedOffsetField = Decoder.ReadInt64(buffer);
                        var committedLeaderEpochField = Decoder.ReadInt32(buffer);
                        var metadataField = Decoder.ReadCompactNullableString(buffer);
                        var errorCodeField = Decoder.ReadInt16(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField
                        );
                    }
                    public static void WriteV08(Stream buffer, OffsetFetchResponsePartitions message)
                    {
                        Encoder.WriteInt32(buffer, message.PartitionIndexField);
                        Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                        Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                        Encoder.WriteCompactNullableString(buffer, message.MetadataField);
                        Encoder.WriteInt16(buffer, message.ErrorCodeField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                }
            }
        }
    }
}