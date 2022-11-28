using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OffsetCommitRequestTopic = Kafka.Client.Messages.OffsetCommitRequest.OffsetCommitRequestTopic;
using OffsetCommitRequestPartition = Kafka.Client.Messages.OffsetCommitRequest.OffsetCommitRequestTopic.OffsetCommitRequestPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetCommitRequestSerde
    {
        private static readonly DecodeDelegate<OffsetCommitRequest>[] READ_VERSIONS = {
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
        private static readonly EncodeDelegate<OffsetCommitRequest>[] WRITE_VERSIONS = {
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
        public static OffsetCommitRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, OffsetCommitRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static OffsetCommitRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, OffsetCommitRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV00(b, i));
            return buffer;
        }
        private static OffsetCommitRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, OffsetCommitRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV01(b, i));
            return buffer;
        }
        private static OffsetCommitRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = Decoder.ReadInt64(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestTopicSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, OffsetCommitRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteInt64(buffer, message.RetentionTimeMsField);
            buffer = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV02(b, i));
            return buffer;
        }
        private static OffsetCommitRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = Decoder.ReadInt64(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestTopicSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, OffsetCommitRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteInt64(buffer, message.RetentionTimeMsField);
            buffer = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV03(b, i));
            return buffer;
        }
        private static OffsetCommitRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = Decoder.ReadInt64(ref buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestTopicSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, OffsetCommitRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteInt64(buffer, message.RetentionTimeMsField);
            buffer = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV04(b, i));
            return buffer;
        }
        private static OffsetCommitRequest ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestTopicSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, OffsetCommitRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV05(b, i));
            return buffer;
        }
        private static OffsetCommitRequest ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestTopicSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, OffsetCommitRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV06(b, i));
            return buffer;
        }
        private static OffsetCommitRequest ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = Decoder.ReadNullableString(ref buffer);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestTopicSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV07(Memory<byte> buffer, OffsetCommitRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
            buffer = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV07(b, i));
            return buffer;
        }
        private static OffsetCommitRequest ReadV08(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadCompactString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadCompactString(ref buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadCompactArray<OffsetCommitRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestTopicSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV08(Memory<byte> buffer, OffsetCommitRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            buffer = Encoder.WriteCompactArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV08(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class OffsetCommitRequestTopicSerde
        {
            public static OffsetCommitRequestTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestPartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, OffsetCommitRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV00(b, i));
                return buffer;
            }
            public static OffsetCommitRequestTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestPartitionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, OffsetCommitRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV01(b, i));
                return buffer;
            }
            public static OffsetCommitRequestTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestPartitionSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, OffsetCommitRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV02(b, i));
                return buffer;
            }
            public static OffsetCommitRequestTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestPartitionSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, OffsetCommitRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV03(b, i));
                return buffer;
            }
            public static OffsetCommitRequestTopic ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestPartitionSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, OffsetCommitRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV04(b, i));
                return buffer;
            }
            public static OffsetCommitRequestTopic ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestPartitionSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, OffsetCommitRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV05(b, i));
                return buffer;
            }
            public static OffsetCommitRequestTopic ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestPartitionSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, OffsetCommitRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV06(b, i));
                return buffer;
            }
            public static OffsetCommitRequestTopic ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestPartitionSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, OffsetCommitRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV07(b, i));
                return buffer;
            }
            public static OffsetCommitRequestTopic ReadV08(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<OffsetCommitRequestPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => OffsetCommitRequestPartitionSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV08(Memory<byte> buffer, OffsetCommitRequestTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV08(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class OffsetCommitRequestPartitionSerde
            {
                public static OffsetCommitRequestPartition ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, OffsetCommitRequestPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                    return buffer;
                }
                public static OffsetCommitRequestPartition ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = Decoder.ReadInt64(ref buffer);
                    var committedMetadataField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, OffsetCommitRequestPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.CommitTimestampField);
                    buffer = Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                    return buffer;
                }
                public static OffsetCommitRequestPartition ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, OffsetCommitRequestPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                    return buffer;
                }
                public static OffsetCommitRequestPartition ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, OffsetCommitRequestPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                    return buffer;
                }
                public static OffsetCommitRequestPartition ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static Memory<byte> WriteV04(Memory<byte> buffer, OffsetCommitRequestPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                    return buffer;
                }
                public static OffsetCommitRequestPartition ReadV05(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static Memory<byte> WriteV05(Memory<byte> buffer, OffsetCommitRequestPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                    return buffer;
                }
                public static OffsetCommitRequestPartition ReadV06(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static Memory<byte> WriteV06(Memory<byte> buffer, OffsetCommitRequestPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    buffer = Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                    return buffer;
                }
                public static OffsetCommitRequestPartition ReadV07(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static Memory<byte> WriteV07(Memory<byte> buffer, OffsetCommitRequestPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    buffer = Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                    return buffer;
                }
                public static OffsetCommitRequestPartition ReadV08(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadCompactNullableString(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static Memory<byte> WriteV08(Memory<byte> buffer, OffsetCommitRequestPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.CommittedMetadataField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}