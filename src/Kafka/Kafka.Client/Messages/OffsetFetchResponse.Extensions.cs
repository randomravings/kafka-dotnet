using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OffsetFetchResponseGroup = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup;
using OffsetFetchResponsePartition = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseTopic.OffsetFetchResponsePartition;
using OffsetFetchResponseTopic = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseTopic;
using OffsetFetchResponseTopics = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup.OffsetFetchResponseTopics;
using OffsetFetchResponsePartitions = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup.OffsetFetchResponseTopics.OffsetFetchResponsePartitions;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetFetchResponseSerde
    {
        private static readonly DecodeDelegate<OffsetFetchResponse>[] READ_VERSIONS = {
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
        private static readonly EncodeDelegate<OffsetFetchResponse>[] WRITE_VERSIONS = {
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
        public static OffsetFetchResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, OffsetFetchResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static OffsetFetchResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponseTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, OffsetFetchResponse message)
        {
            buffer = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV00(b, i));
            return buffer;
        }
        private static OffsetFetchResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponseTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, OffsetFetchResponse message)
        {
            buffer = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV01(b, i));
            return buffer;
        }
        private static OffsetFetchResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponseTopicSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, OffsetFetchResponse message)
        {
            buffer = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV02(b, i));
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            return buffer;
        }
        private static OffsetFetchResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponseTopicSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, OffsetFetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV03(b, i));
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            return buffer;
        }
        private static OffsetFetchResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponseTopicSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, OffsetFetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV04(b, i));
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            return buffer;
        }
        private static OffsetFetchResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponseTopicSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, OffsetFetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV05(b, i));
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            return buffer;
        }
        private static OffsetFetchResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<OffsetFetchResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponseTopicSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, OffsetFetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV06(b, i));
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static OffsetFetchResponse ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<OffsetFetchResponseTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponseTopicSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static Memory<byte> WriteV07(Memory<byte> buffer, OffsetFetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<OffsetFetchResponseTopic>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicSerde.WriteV07(b, i));
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static OffsetFetchResponse ReadV08(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = Decoder.ReadCompactArray<OffsetFetchResponseGroup>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponseGroupSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static Memory<byte> WriteV08(Memory<byte> buffer, OffsetFetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<OffsetFetchResponseGroup>(buffer, message.GroupsField, (b, i) => OffsetFetchResponseGroupSerde.WriteV08(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class OffsetFetchResponseGroupSerde
        {
            public static OffsetFetchResponseGroup ReadV08(ref ReadOnlyMemory<byte> buffer)
            {
                var groupIdField = Decoder.ReadCompactString(ref buffer);
                var topicsField = Decoder.ReadCompactArray<OffsetFetchResponseTopics>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponseTopicsSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    groupIdField,
                    topicsField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV08(Memory<byte> buffer, OffsetFetchResponseGroup message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.groupIdField);
                buffer = Encoder.WriteCompactArray<OffsetFetchResponseTopics>(buffer, message.TopicsField, (b, i) => OffsetFetchResponseTopicsSerde.WriteV08(b, i));
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class OffsetFetchResponseTopicsSerde
            {
                public static OffsetFetchResponseTopics ReadV08(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var partitionsField = Decoder.ReadCompactArray<OffsetFetchResponsePartitions>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponsePartitionsSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static Memory<byte> WriteV08(Memory<byte> buffer, OffsetFetchResponseTopics message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactArray<OffsetFetchResponsePartitions>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionsSerde.WriteV08(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                private static class OffsetFetchResponsePartitionsSerde
                {
                    public static OffsetFetchResponsePartitions ReadV08(ref ReadOnlyMemory<byte> buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(ref buffer);
                        var committedOffsetField = Decoder.ReadInt64(ref buffer);
                        var committedLeaderEpochField = Decoder.ReadInt32(ref buffer);
                        var metadataField = Decoder.ReadCompactNullableString(ref buffer);
                        var errorCodeField = Decoder.ReadInt16(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField
                        );
                    }
                    public static Memory<byte> WriteV08(Memory<byte> buffer, OffsetFetchResponsePartitions message)
                    {
                        buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                        buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                        buffer = Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                        buffer = Encoder.WriteCompactNullableString(buffer, message.MetadataField);
                        buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                }
            }
        }
        private static class OffsetFetchResponseTopicSerde
        {
            public static OffsetFetchResponseTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponsePartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, OffsetFetchResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV00(b, i));
                return buffer;
            }
            public static OffsetFetchResponseTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponsePartitionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, OffsetFetchResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV01(b, i));
                return buffer;
            }
            public static OffsetFetchResponseTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponsePartitionSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, OffsetFetchResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV02(b, i));
                return buffer;
            }
            public static OffsetFetchResponseTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponsePartitionSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, OffsetFetchResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV03(b, i));
                return buffer;
            }
            public static OffsetFetchResponseTopic ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponsePartitionSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, OffsetFetchResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV04(b, i));
                return buffer;
            }
            public static OffsetFetchResponseTopic ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponsePartitionSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, OffsetFetchResponseTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV05(b, i));
                return buffer;
            }
            public static OffsetFetchResponseTopic ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<OffsetFetchResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponsePartitionSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, OffsetFetchResponseTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV06(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static OffsetFetchResponseTopic ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<OffsetFetchResponsePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetFetchResponsePartitionSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, OffsetFetchResponseTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<OffsetFetchResponsePartition>(buffer, message.PartitionsField, (b, i) => OffsetFetchResponsePartitionSerde.WriteV07(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class OffsetFetchResponsePartitionSerde
            {
                public static OffsetFetchResponsePartition ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = default(int);
                    var metadataField = Decoder.ReadNullableString(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, OffsetFetchResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteNullableString(buffer, message.MetadataField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static OffsetFetchResponsePartition ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = default(int);
                    var metadataField = Decoder.ReadNullableString(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, OffsetFetchResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteNullableString(buffer, message.MetadataField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static OffsetFetchResponsePartition ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = default(int);
                    var metadataField = Decoder.ReadNullableString(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, OffsetFetchResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteNullableString(buffer, message.MetadataField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static OffsetFetchResponsePartition ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = default(int);
                    var metadataField = Decoder.ReadNullableString(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, OffsetFetchResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteNullableString(buffer, message.MetadataField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static OffsetFetchResponsePartition ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = default(int);
                    var metadataField = Decoder.ReadNullableString(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV04(Memory<byte> buffer, OffsetFetchResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteNullableString(buffer, message.MetadataField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static OffsetFetchResponsePartition ReadV05(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var metadataField = Decoder.ReadNullableString(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV05(Memory<byte> buffer, OffsetFetchResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    buffer = Encoder.WriteNullableString(buffer, message.MetadataField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static OffsetFetchResponsePartition ReadV06(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var metadataField = Decoder.ReadCompactNullableString(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV06(Memory<byte> buffer, OffsetFetchResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.MetadataField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static OffsetFetchResponsePartition ReadV07(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var metadataField = Decoder.ReadCompactNullableString(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV07(Memory<byte> buffer, OffsetFetchResponsePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.MetadataField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}