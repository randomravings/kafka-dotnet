using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using OffsetCommitRequestTopic = Kafka.Client.Messages.OffsetCommitRequest.OffsetCommitRequestTopic;
using OffsetCommitRequestPartition = Kafka.Client.Messages.OffsetCommitRequest.OffsetCommitRequestTopic.OffsetCommitRequestPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetCommitRequestSerde
    {
        private static readonly DecodeDelegate<OffsetCommitRequest>[] READ_VERSIONS = {
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
        private static readonly EncodeDelegate<OffsetCommitRequest>[] WRITE_VERSIONS = {
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
        public static OffsetCommitRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, OffsetCommitRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static OffsetCommitRequest ReadV00(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, ref index, OffsetCommitRequestTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV00);
            return index;
        }
        private static OffsetCommitRequest ReadV01(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, ref index, OffsetCommitRequestTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV01);
            return index;
        }
        private static OffsetCommitRequest ReadV02(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = Decoder.ReadInt64(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, ref index, OffsetCommitRequestTopicSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteInt64(buffer, index, message.RetentionTimeMsField);
            index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV02);
            return index;
        }
        private static OffsetCommitRequest ReadV03(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = Decoder.ReadInt64(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, ref index, OffsetCommitRequestTopicSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteInt64(buffer, index, message.RetentionTimeMsField);
            index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV03);
            return index;
        }
        private static OffsetCommitRequest ReadV04(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = Decoder.ReadInt64(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, ref index, OffsetCommitRequestTopicSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteInt64(buffer, index, message.RetentionTimeMsField);
            index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV04);
            return index;
        }
        private static OffsetCommitRequest ReadV05(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, ref index, OffsetCommitRequestTopicSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static int WriteV05(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV05);
            return index;
        }
        private static OffsetCommitRequest ReadV06(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, ref index, OffsetCommitRequestTopicSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static int WriteV06(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV06);
            return index;
        }
        private static OffsetCommitRequest ReadV07(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = Decoder.ReadNullableString(buffer, ref index);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadArray<OffsetCommitRequestTopic>(buffer, ref index, OffsetCommitRequestTopicSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static int WriteV07(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
            index = Encoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV07);
            return index;
        }
        private static OffsetCommitRequest ReadV08(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadCompactString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadCompactString(buffer, ref index);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var retentionTimeMsField = default(long);
            var topicsField = Decoder.ReadCompactArray<OffsetCommitRequestTopic>(buffer, ref index, OffsetCommitRequestTopicSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField
            );
        }
        private static int WriteV08(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = Encoder.WriteCompactArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV08);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class OffsetCommitRequestTopicSerde
        {
            public static OffsetCommitRequestTopic ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, ref index, OffsetCommitRequestPartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV00);
                return index;
            }
            public static OffsetCommitRequestTopic ReadV01(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, ref index, OffsetCommitRequestPartitionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV01);
                return index;
            }
            public static OffsetCommitRequestTopic ReadV02(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, ref index, OffsetCommitRequestPartitionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV02);
                return index;
            }
            public static OffsetCommitRequestTopic ReadV03(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, ref index, OffsetCommitRequestPartitionSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV03);
                return index;
            }
            public static OffsetCommitRequestTopic ReadV04(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, ref index, OffsetCommitRequestPartitionSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV04(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV04);
                return index;
            }
            public static OffsetCommitRequestTopic ReadV05(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, ref index, OffsetCommitRequestPartitionSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV05(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV05);
                return index;
            }
            public static OffsetCommitRequestTopic ReadV06(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, ref index, OffsetCommitRequestPartitionSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV06(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV06);
                return index;
            }
            public static OffsetCommitRequestTopic ReadV07(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetCommitRequestPartition>(buffer, ref index, OffsetCommitRequestPartitionSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV07(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV07);
                return index;
            }
            public static OffsetCommitRequestTopic ReadV08(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<OffsetCommitRequestPartition>(buffer, ref index, OffsetCommitRequestPartitionSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV08(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV08);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class OffsetCommitRequestPartitionSerde
            {
                public static OffsetCommitRequestPartition ReadV00(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = default(int);
                    var CommitTimestampField = default(long);
                    var CommittedMetadataField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        CommitTimestampField,
                        CommittedMetadataField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static OffsetCommitRequestPartition ReadV01(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = default(int);
                    var CommitTimestampField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedMetadataField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        CommitTimestampField,
                        CommittedMetadataField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.CommitTimestampField);
                    index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static OffsetCommitRequestPartition ReadV02(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = default(int);
                    var CommitTimestampField = default(long);
                    var CommittedMetadataField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        CommitTimestampField,
                        CommittedMetadataField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static OffsetCommitRequestPartition ReadV03(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = default(int);
                    var CommitTimestampField = default(long);
                    var CommittedMetadataField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        CommitTimestampField,
                        CommittedMetadataField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static OffsetCommitRequestPartition ReadV04(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = default(int);
                    var CommitTimestampField = default(long);
                    var CommittedMetadataField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        CommitTimestampField,
                        CommittedMetadataField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static OffsetCommitRequestPartition ReadV05(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = default(int);
                    var CommitTimestampField = default(long);
                    var CommittedMetadataField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        CommitTimestampField,
                        CommittedMetadataField
                    );
                }
                public static int WriteV05(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static OffsetCommitRequestPartition ReadV06(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var CommitTimestampField = default(long);
                    var CommittedMetadataField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        CommitTimestampField,
                        CommittedMetadataField
                    );
                }
                public static int WriteV06(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static OffsetCommitRequestPartition ReadV07(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var CommitTimestampField = default(long);
                    var CommittedMetadataField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        CommitTimestampField,
                        CommittedMetadataField
                    );
                }
                public static int WriteV07(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static OffsetCommitRequestPartition ReadV08(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var CommitTimestampField = default(long);
                    var CommittedMetadataField = Decoder.ReadCompactNullableString(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        CommitTimestampField,
                        CommittedMetadataField
                    );
                }
                public static int WriteV08(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.CommittedMetadataField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}