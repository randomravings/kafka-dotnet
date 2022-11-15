using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OffsetCommitRequestPartition = Kafka.Client.Messages.OffsetCommitRequest.OffsetCommitRequestTopic.OffsetCommitRequestPartition;
using OffsetCommitRequestTopic = Kafka.Client.Messages.OffsetCommitRequest.OffsetCommitRequestTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetCommitRequestSerde
    {
        private static readonly Func<Stream, OffsetCommitRequest>[] READ_VERSIONS = {
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
        private static readonly Action<Stream, OffsetCommitRequest>[] WRITE_VERSIONS = {
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
        public static OffsetCommitRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, OffsetCommitRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static OffsetCommitRequest ReadV00(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, b => OffsetCommitRequestTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, OffsetCommitRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV00(b, i));
        }
        private static OffsetCommitRequest ReadV01(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, b => OffsetCommitRequestTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, OffsetCommitRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV01(b, i));
        }
        private static OffsetCommitRequest ReadV02(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = Decoder.ReadInt64(buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, b => OffsetCommitRequestTopicSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static void WriteV02(Stream buffer, OffsetCommitRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteInt64(buffer, message.RetentionTimeMsField);
            Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV02(b, i));
        }
        private static OffsetCommitRequest ReadV03(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = Decoder.ReadInt64(buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, b => OffsetCommitRequestTopicSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static void WriteV03(Stream buffer, OffsetCommitRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteInt64(buffer, message.RetentionTimeMsField);
            Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV03(b, i));
        }
        private static OffsetCommitRequest ReadV04(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = Decoder.ReadInt64(buffer);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, b => OffsetCommitRequestTopicSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static void WriteV04(Stream buffer, OffsetCommitRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteInt64(buffer, message.RetentionTimeMsField);
            Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV04(b, i));
        }
        private static OffsetCommitRequest ReadV05(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, b => OffsetCommitRequestTopicSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static void WriteV05(Stream buffer, OffsetCommitRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV05(b, i));
        }
        private static OffsetCommitRequest ReadV06(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, b => OffsetCommitRequestTopicSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static void WriteV06(Stream buffer, OffsetCommitRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV06(b, i));
        }
        private static OffsetCommitRequest ReadV07(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = Decoder.ReadNullableString(buffer);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, b => OffsetCommitRequestTopicSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static void WriteV07(Stream buffer, OffsetCommitRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
            Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV07(b, i));
        }
        private static OffsetCommitRequest ReadV08(Stream buffer)
        {
            var groupIdField = Decoder.ReadCompactString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadCompactString(buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadCompactArray<OffsetCommitRequestTopic>(buffer, b => OffsetCommitRequestTopicSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static void WriteV08(Stream buffer, OffsetCommitRequest message)
        {
            Encoder.WriteCompactString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteCompactString(buffer, message.MemberIdField);
            Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            Encoder.WriteCompactArray<OffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => OffsetCommitRequestTopicSerde.WriteV08(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class OffsetCommitRequestTopicSerde
        {
            public static OffsetCommitRequestTopic ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, b => OffsetCommitRequestPartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, OffsetCommitRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV00(b, i));
            }
            public static OffsetCommitRequestTopic ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, b => OffsetCommitRequestPartitionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, OffsetCommitRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV01(b, i));
            }
            public static OffsetCommitRequestTopic ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, b => OffsetCommitRequestPartitionSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, OffsetCommitRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV02(b, i));
            }
            public static OffsetCommitRequestTopic ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, b => OffsetCommitRequestPartitionSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV03(Stream buffer, OffsetCommitRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV03(b, i));
            }
            public static OffsetCommitRequestTopic ReadV04(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, b => OffsetCommitRequestPartitionSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV04(Stream buffer, OffsetCommitRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV04(b, i));
            }
            public static OffsetCommitRequestTopic ReadV05(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, b => OffsetCommitRequestPartitionSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV05(Stream buffer, OffsetCommitRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV05(b, i));
            }
            public static OffsetCommitRequestTopic ReadV06(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, b => OffsetCommitRequestPartitionSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV06(Stream buffer, OffsetCommitRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV06(b, i));
            }
            public static OffsetCommitRequestTopic ReadV07(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, b => OffsetCommitRequestPartitionSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV07(Stream buffer, OffsetCommitRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV07(b, i));
            }
            public static OffsetCommitRequestTopic ReadV08(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<OffsetCommitRequestPartition>(buffer, b => OffsetCommitRequestPartitionSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV08(Stream buffer, OffsetCommitRequestTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<OffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => OffsetCommitRequestPartitionSerde.WriteV08(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class OffsetCommitRequestPartitionSerde
            {
                public static OffsetCommitRequestPartition ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadNullableString(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static void WriteV00(Stream buffer, OffsetCommitRequestPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                }
                public static OffsetCommitRequestPartition ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = Decoder.ReadInt64(buffer);
                    var committedMetadataField = Decoder.ReadNullableString(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static void WriteV01(Stream buffer, OffsetCommitRequestPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteInt64(buffer, message.CommitTimestampField);
                    Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                }
                public static OffsetCommitRequestPartition ReadV02(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadNullableString(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static void WriteV02(Stream buffer, OffsetCommitRequestPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                }
                public static OffsetCommitRequestPartition ReadV03(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadNullableString(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static void WriteV03(Stream buffer, OffsetCommitRequestPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                }
                public static OffsetCommitRequestPartition ReadV04(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadNullableString(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static void WriteV04(Stream buffer, OffsetCommitRequestPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                }
                public static OffsetCommitRequestPartition ReadV05(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadNullableString(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static void WriteV05(Stream buffer, OffsetCommitRequestPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                }
                public static OffsetCommitRequestPartition ReadV06(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(buffer);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadNullableString(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static void WriteV06(Stream buffer, OffsetCommitRequestPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                }
                public static OffsetCommitRequestPartition ReadV07(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(buffer);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadNullableString(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static void WriteV07(Stream buffer, OffsetCommitRequestPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                }
                public static OffsetCommitRequestPartition ReadV08(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(buffer);
                    var commitTimestampField = default(long);
                    var committedMetadataField = Decoder.ReadCompactNullableString(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField
                    );
                }
                public static void WriteV08(Stream buffer, OffsetCommitRequestPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    Encoder.WriteCompactNullableString(buffer, message.CommittedMetadataField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}