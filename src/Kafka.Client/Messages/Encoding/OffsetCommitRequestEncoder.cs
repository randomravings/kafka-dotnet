using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using OffsetCommitRequestTopic = Kafka.Client.Messages.OffsetCommitRequestData.OffsetCommitRequestTopic;
using OffsetCommitRequestPartition = Kafka.Client.Messages.OffsetCommitRequestData.OffsetCommitRequestTopic.OffsetCommitRequestPartition;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class OffsetCommitRequestEncoder : 
        RequestEncoder<RequestHeaderData, OffsetCommitRequestData>
    {
        internal OffsetCommitRequestEncoder() :
            base(
                ApiKey.OffsetCommit,
                new(0, 9),
                new(8, 32767),
                RequestHeaderEncoder.WriteV0,
                WriteV0
            )
        { }
        protected override EncodeValue<RequestHeaderData> GetHeaderEncoder(short apiVersion)
        {
            if (FlexibleVersions.Includes(apiVersion))
                return RequestHeaderEncoder.WriteV2;
            else
                return RequestHeaderEncoder.WriteV1;
        }
        protected override EncodeValue<OffsetCommitRequestData> GetMessageEncoder(short apiVersion) =>
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
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, i, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV0);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.GenerationIdOrMemberEpochField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, i, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV1);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.GenerationIdOrMemberEpochField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteInt64(buffer, i, message.RetentionTimeMsField);
            i = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, i, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV2);
            return i;
        }
        private static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.GenerationIdOrMemberEpochField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteInt64(buffer, i, message.RetentionTimeMsField);
            i = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, i, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV3);
            return i;
        }
        private static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.GenerationIdOrMemberEpochField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteInt64(buffer, i, message.RetentionTimeMsField);
            i = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, i, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV4);
            return i;
        }
        private static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.GenerationIdOrMemberEpochField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, i, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV5);
            return i;
        }
        private static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.GenerationIdOrMemberEpochField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, i, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV6);
            return i;
        }
        private static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.GenerationIdOrMemberEpochField);
            i = BinaryEncoder.WriteString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteNullableString(buffer, i, message.GroupInstanceIdField);
            i = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, i, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV7);
            return i;
        }
        private static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.GenerationIdOrMemberEpochField);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.GroupInstanceIdField);
            i = BinaryEncoder.WriteCompactArray<OffsetCommitRequestTopic>(buffer, i, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV8);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
            }
            return i;
        }
        private static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.GenerationIdOrMemberEpochField);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.MemberIdField);
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.GroupInstanceIdField);
            i = BinaryEncoder.WriteCompactArray<OffsetCommitRequestTopic>(buffer, i, message.TopicsField, OffsetCommitRequestTopicEncoder.WriteV9);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
            }
            return i;
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class OffsetCommitRequestTopicEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, i, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV0);
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, i, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV1);
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, i, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV2);
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, i, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV3);
                return i;
            }
            public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, i, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV4);
                return i;
            }
            public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, i, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV5);
                return i;
            }
            public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, i, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV6);
                return i;
            }
            public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, i, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV7);
                return i;
            }
            public static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactArray<OffsetCommitRequestPartition>(buffer, i, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV8);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                    i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
                }
                return i;
            }
            public static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactArray<OffsetCommitRequestPartition>(buffer, i, message.PartitionsField, OffsetCommitRequestPartitionEncoder.WriteV9);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                    i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
                }
                return i;
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class OffsetCommitRequestPartitionEncoder
            {
                public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.CommittedOffsetField);
                    i = BinaryEncoder.WriteNullableString(buffer, i, message.CommittedMetadataField);
                    return i;
                }
                public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.CommittedOffsetField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.CommitTimestampField);
                    i = BinaryEncoder.WriteNullableString(buffer, i, message.CommittedMetadataField);
                    return i;
                }
                public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.CommittedOffsetField);
                    i = BinaryEncoder.WriteNullableString(buffer, i, message.CommittedMetadataField);
                    return i;
                }
                public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.CommittedOffsetField);
                    i = BinaryEncoder.WriteNullableString(buffer, i, message.CommittedMetadataField);
                    return i;
                }
                public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.CommittedOffsetField);
                    i = BinaryEncoder.WriteNullableString(buffer, i, message.CommittedMetadataField);
                    return i;
                }
                public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.CommittedOffsetField);
                    i = BinaryEncoder.WriteNullableString(buffer, i, message.CommittedMetadataField);
                    return i;
                }
                public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.CommittedOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CommittedLeaderEpochField);
                    i = BinaryEncoder.WriteNullableString(buffer, i, message.CommittedMetadataField);
                    return i;
                }
                public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.CommittedOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CommittedLeaderEpochField);
                    i = BinaryEncoder.WriteNullableString(buffer, i, message.CommittedMetadataField);
                    return i;
                }
                public static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.CommittedOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CommittedLeaderEpochField);
                    i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.CommittedMetadataField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                        i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
                    }
                    return i;
                }
                public static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetCommitRequestPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.CommittedOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CommittedLeaderEpochField);
                    i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.CommittedMetadataField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                        i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
                    }
                    return i;
                }
            }
        }
    }
}
