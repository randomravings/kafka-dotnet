using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using OffsetCommitRequestTopic = Kafka.Client.Messages.OffsetCommitRequestData.OffsetCommitRequestTopic;
using OffsetCommitRequestPartition = Kafka.Client.Messages.OffsetCommitRequestData.OffsetCommitRequestTopic.OffsetCommitRequestPartition;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class OffsetCommitRequestEncoder : 
        RequestEncoder<RequestHeaderData, OffsetCommitRequestData>
    {
        public OffsetCommitRequestEncoder() :
            base(
                ApiKey.OffsetCommit,
                new(0, 9),
                new(8, 32767),
                RequestHeaderEncoder.WriteV0,
                WriteV0
            )
        { }
        protected override EncodeDelegate<RequestHeaderData> GetHeaderEncoder(short apiVersion)
        {
            if (_flexibleVersions.Includes(apiVersion))
                return RequestHeaderEncoder.WriteV2;
            else
                return RequestHeaderEncoder.WriteV1;
        }
        protected override EncodeDelegate<OffsetCommitRequestData> GetMessageEncoder(short apiVersion) =>
            apiVersion switch
            {
                0 => WriteV0,
                1 => WriteV1,
                2 => WriteV2,
                3 => WriteV3,
                4 => WriteV4,
                5 => WriteV5,
                6 => WriteV6,
                7 => WriteV7,
                8 => WriteV8,
                9 => WriteV9,
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0(byte[] buffer, int index, OffsetCommitRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV0);
            return index;
        }
        private static int WriteV1(byte[] buffer, int index, OffsetCommitRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdOrMemberEpochField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV1);
            return index;
        }
        private static int WriteV2(byte[] buffer, int index, OffsetCommitRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdOrMemberEpochField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteInt64(buffer, index, message.RetentionTimeMsField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV2);
            return index;
        }
        private static int WriteV3(byte[] buffer, int index, OffsetCommitRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdOrMemberEpochField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteInt64(buffer, index, message.RetentionTimeMsField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV3);
            return index;
        }
        private static int WriteV4(byte[] buffer, int index, OffsetCommitRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdOrMemberEpochField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteInt64(buffer, index, message.RetentionTimeMsField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV4);
            return index;
        }
        private static int WriteV5(byte[] buffer, int index, OffsetCommitRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdOrMemberEpochField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV5);
            return index;
        }
        private static int WriteV6(byte[] buffer, int index, OffsetCommitRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdOrMemberEpochField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV6);
            return index;
        }
        private static int WriteV7(byte[] buffer, int index, OffsetCommitRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdOrMemberEpochField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV7);
            return index;
        }
        private static int WriteV8(byte[] buffer, int index, OffsetCommitRequestData message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdOrMemberEpochField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteCompactArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV8);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static int WriteV9(byte[] buffer, int index, OffsetCommitRequestData message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdOrMemberEpochField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteCompactArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV9);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class OffsetCommitRequestTopicEncoder
        {
            public static int WriteV0(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV0);
                return index;
            }
            public static int WriteV1(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV1);
                return index;
            }
            public static int WriteV2(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV2);
                return index;
            }
            public static int WriteV3(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV3);
                return index;
            }
            public static int WriteV4(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV4);
                return index;
            }
            public static int WriteV5(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV5);
                return index;
            }
            public static int WriteV6(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV6);
                return index;
            }
            public static int WriteV7(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV7);
                return index;
            }
            public static int WriteV8(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV8);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static int WriteV9(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV9);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class OffsetCommitRequestPartitionEncoder
            {
                public static int WriteV0(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static int WriteV1(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommitTimestampField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static int WriteV2(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static int WriteV3(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static int WriteV4(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static int WriteV5(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static int WriteV6(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static int WriteV7(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static int WriteV8(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.CommittedMetadataField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static int WriteV9(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.CommittedMetadataField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
            }
        }
    }
}
