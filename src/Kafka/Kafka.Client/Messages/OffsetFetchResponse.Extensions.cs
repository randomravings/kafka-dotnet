using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OffsetFetchResponseTopic = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseTopic;
using OffsetFetchResponsePartition = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseTopic.OffsetFetchResponsePartition;
using OffsetFetchResponseGroup = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup;
using OffsetFetchResponseTopics = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup.OffsetFetchResponseTopics;
using OffsetFetchResponsePartitions = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup.OffsetFetchResponseTopics.OffsetFetchResponsePartitions;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetFetchResponseSerde
    {
        private static readonly DecodeDelegate<OffsetFetchResponse>[] READ_VERSIONS = {
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
        private static readonly EncodeDelegate<OffsetFetchResponse>[] WRITE_VERSIONS = {
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
        public static OffsetFetchResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, OffsetFetchResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static OffsetFetchResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, ref index, OffsetFetchResponseTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV00);
            return index;
        }
        private static OffsetFetchResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, ref index, OffsetFetchResponseTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV01);
            return index;
        }
        private static OffsetFetchResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, ref index, OffsetFetchResponseTopicSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV02);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static OffsetFetchResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, ref index, OffsetFetchResponseTopicSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV03);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static OffsetFetchResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, ref index, OffsetFetchResponseTopicSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV04);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static OffsetFetchResponse ReadV05(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetFetchResponseTopic>(buffer, ref index, OffsetFetchResponseTopicSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static int WriteV05(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV05);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static OffsetFetchResponse ReadV06(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<OffsetFetchResponseTopic>(buffer, ref index, OffsetFetchResponseTopicSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static int WriteV06(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV06);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static OffsetFetchResponse ReadV07(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<OffsetFetchResponseTopic>(buffer, ref index, OffsetFetchResponseTopicSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static int WriteV07(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV07);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static OffsetFetchResponse ReadV08(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = Decoder.ReadCompactArray<OffsetFetchResponseGroup>(buffer, ref index, OffsetFetchResponseGroupSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField
            );
        }
        private static int WriteV08(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<OffsetFetchResponseGroup>(buffer, index, message.GroupsField, OffsetFetchResponseGroupSerde.WriteV08);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class OffsetFetchResponseTopicSerde
        {
            public static OffsetFetchResponseTopic ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, ref index, OffsetFetchResponsePartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV00);
                return index;
            }
            public static OffsetFetchResponseTopic ReadV01(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, ref index, OffsetFetchResponsePartitionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV01);
                return index;
            }
            public static OffsetFetchResponseTopic ReadV02(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, ref index, OffsetFetchResponsePartitionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV02);
                return index;
            }
            public static OffsetFetchResponseTopic ReadV03(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, ref index, OffsetFetchResponsePartitionSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV03);
                return index;
            }
            public static OffsetFetchResponseTopic ReadV04(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, ref index, OffsetFetchResponsePartitionSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV04(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV04);
                return index;
            }
            public static OffsetFetchResponseTopic ReadV05(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetFetchResponsePartition>(buffer, ref index, OffsetFetchResponsePartitionSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV05(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV05);
                return index;
            }
            public static OffsetFetchResponseTopic ReadV06(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<OffsetFetchResponsePartition>(buffer, ref index, OffsetFetchResponsePartitionSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV06(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV06);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static OffsetFetchResponseTopic ReadV07(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<OffsetFetchResponsePartition>(buffer, ref index, OffsetFetchResponsePartitionSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV07(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV07);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class OffsetFetchResponsePartitionSerde
            {
                public static OffsetFetchResponsePartition ReadV00(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = default(int);
                    var MetadataField = Decoder.ReadNullableString(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        MetadataField,
                        ErrorCodeField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteNullableString(buffer, index, message.MetadataField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static OffsetFetchResponsePartition ReadV01(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = default(int);
                    var MetadataField = Decoder.ReadNullableString(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        MetadataField,
                        ErrorCodeField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteNullableString(buffer, index, message.MetadataField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static OffsetFetchResponsePartition ReadV02(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = default(int);
                    var MetadataField = Decoder.ReadNullableString(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        MetadataField,
                        ErrorCodeField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteNullableString(buffer, index, message.MetadataField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static OffsetFetchResponsePartition ReadV03(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = default(int);
                    var MetadataField = Decoder.ReadNullableString(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        MetadataField,
                        ErrorCodeField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteNullableString(buffer, index, message.MetadataField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static OffsetFetchResponsePartition ReadV04(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = default(int);
                    var MetadataField = Decoder.ReadNullableString(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        MetadataField,
                        ErrorCodeField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteNullableString(buffer, index, message.MetadataField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static OffsetFetchResponsePartition ReadV05(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var MetadataField = Decoder.ReadNullableString(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        MetadataField,
                        ErrorCodeField
                    );
                }
                public static int WriteV05(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = Encoder.WriteNullableString(buffer, index, message.MetadataField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static OffsetFetchResponsePartition ReadV06(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var MetadataField = Decoder.ReadCompactNullableString(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        MetadataField,
                        ErrorCodeField
                    );
                }
                public static int WriteV06(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.MetadataField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static OffsetFetchResponsePartition ReadV07(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var MetadataField = Decoder.ReadCompactNullableString(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        MetadataField,
                        ErrorCodeField
                    );
                }
                public static int WriteV07(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.MetadataField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
        private static class OffsetFetchResponseGroupSerde
        {
            public static OffsetFetchResponseGroup ReadV08(byte[] buffer, ref int index)
            {
                var GroupIdField = Decoder.ReadCompactString(buffer, ref index);
                var TopicsField = Decoder.ReadCompactArray<OffsetFetchResponseTopics>(buffer, ref index, OffsetFetchResponseTopicsSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    GroupIdField,
                    TopicsField,
                    ErrorCodeField
                );
            }
            public static int WriteV08(byte[] buffer, int index, OffsetFetchResponseGroup message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
                index = Encoder.WriteCompactArray<OffsetFetchResponseTopics>(buffer, index, message.TopicsField, OffsetFetchResponseTopicsSerde.WriteV08);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class OffsetFetchResponseTopicsSerde
            {
                public static OffsetFetchResponseTopics ReadV08(byte[] buffer, ref int index)
                {
                    var NameField = Decoder.ReadCompactString(buffer, ref index);
                    var PartitionsField = Decoder.ReadCompactArray<OffsetFetchResponsePartitions>(buffer, ref index, OffsetFetchResponsePartitionsSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        NameField,
                        PartitionsField
                    );
                }
                public static int WriteV08(byte[] buffer, int index, OffsetFetchResponseTopics message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactArray<OffsetFetchResponsePartitions>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionsSerde.WriteV08);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                private static class OffsetFetchResponsePartitionsSerde
                {
                    public static OffsetFetchResponsePartitions ReadV08(byte[] buffer, ref int index)
                    {
                        var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                        var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                        var CommittedLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                        var MetadataField = Decoder.ReadCompactNullableString(buffer, ref index);
                        var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            PartitionIndexField,
                            CommittedOffsetField,
                            CommittedLeaderEpochField,
                            MetadataField,
                            ErrorCodeField
                        );
                    }
                    public static int WriteV08(byte[] buffer, int index, OffsetFetchResponsePartitions message)
                    {
                        index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                        index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                        index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                        index = Encoder.WriteCompactNullableString(buffer, index, message.MetadataField);
                        index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                }
            }
        }
    }
}