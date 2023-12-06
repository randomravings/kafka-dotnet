using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using ListOffsetsPartition = Kafka.Client.Messages.ListOffsetsRequestData.ListOffsetsTopic.ListOffsetsPartition;
using ListOffsetsTopic = Kafka.Client.Messages.ListOffsetsRequestData.ListOffsetsTopic;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class ListOffsetsRequestEncoder : 
        RequestEncoder<RequestHeaderData, ListOffsetsRequestData>
    {
        internal ListOffsetsRequestEncoder() :
            base(
                ApiKey.ListOffsets,
                new(0, 8),
                new(6, 32767),
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
        protected override EncodeValue<ListOffsetsRequestData> GetMessageEncoder(short apiVersion) =>
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
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, i, message.TopicsField, ListOffsetsTopicEncoder.WriteV0);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, i, message.TopicsField, ListOffsetsTopicEncoder.WriteV1);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, i, message.TopicsField, ListOffsetsTopicEncoder.WriteV2);
            return i;
        }
        private static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, i, message.TopicsField, ListOffsetsTopicEncoder.WriteV3);
            return i;
        }
        private static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, i, message.TopicsField, ListOffsetsTopicEncoder.WriteV4);
            return i;
        }
        private static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, i, message.TopicsField, ListOffsetsTopicEncoder.WriteV5);
            return i;
        }
        private static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteCompactArray<ListOffsetsTopic>(buffer, i, message.TopicsField, ListOffsetsTopicEncoder.WriteV6);
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
        private static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteCompactArray<ListOffsetsTopic>(buffer, i, message.TopicsField, ListOffsetsTopicEncoder.WriteV7);
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
        private static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteCompactArray<ListOffsetsTopic>(buffer, i, message.TopicsField, ListOffsetsTopicEncoder.WriteV8);
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
        private static class ListOffsetsTopicEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, i, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV0);
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, i, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV1);
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, i, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV2);
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, i, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV3);
                return i;
            }
            public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, i, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV4);
                return i;
            }
            public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, i, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV5);
                return i;
            }
            public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactArray<ListOffsetsPartition>(buffer, i, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV6);
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
            public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactArray<ListOffsetsPartition>(buffer, i, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV7);
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
            public static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactArray<ListOffsetsPartition>(buffer, i, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV8);
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
            private static class ListOffsetsPartitionEncoder
            {
                public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.TimestampField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.MaxNumOffsetsField);
                    return i;
                }
                public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.TimestampField);
                    return i;
                }
                public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.TimestampField);
                    return i;
                }
                public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.TimestampField);
                    return i;
                }
                public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CurrentLeaderEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.TimestampField);
                    return i;
                }
                public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CurrentLeaderEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.TimestampField);
                    return i;
                }
                public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CurrentLeaderEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.TimestampField);
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
                public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CurrentLeaderEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.TimestampField);
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
                public static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in ListOffsetsPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CurrentLeaderEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.TimestampField);
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
