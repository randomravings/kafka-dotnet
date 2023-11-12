using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using ListOffsetsTopic = Kafka.Client.Messages.ListOffsetsRequestData.ListOffsetsTopic;
using ListOffsetsPartition = Kafka.Client.Messages.ListOffsetsRequestData.ListOffsetsTopic.ListOffsetsPartition;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class ListOffsetsRequestEncoder : 
        RequestEncoder<RequestHeaderData, ListOffsetsRequestData>
    {
        public ListOffsetsRequestEncoder() :
            base(
                ApiKey.ListOffsets,
                new(0, 8),
                new(6, 32767),
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
        protected override EncodeDelegate<ListOffsetsRequestData> GetMessageEncoder(short apiVersion) =>
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
        private static int WriteV0(byte[] buffer, int index, ListOffsetsRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicEncoder.WriteV0);
            return index;
        }
        private static int WriteV1(byte[] buffer, int index, ListOffsetsRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicEncoder.WriteV1);
            return index;
        }
        private static int WriteV2(byte[] buffer, int index, ListOffsetsRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicEncoder.WriteV2);
            return index;
        }
        private static int WriteV3(byte[] buffer, int index, ListOffsetsRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicEncoder.WriteV3);
            return index;
        }
        private static int WriteV4(byte[] buffer, int index, ListOffsetsRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicEncoder.WriteV4);
            return index;
        }
        private static int WriteV5(byte[] buffer, int index, ListOffsetsRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicEncoder.WriteV5);
            return index;
        }
        private static int WriteV6(byte[] buffer, int index, ListOffsetsRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteCompactArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicEncoder.WriteV6);
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
        private static int WriteV7(byte[] buffer, int index, ListOffsetsRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteCompactArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicEncoder.WriteV7);
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
        private static int WriteV8(byte[] buffer, int index, ListOffsetsRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteCompactArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicEncoder.WriteV8);
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
        private static class ListOffsetsTopicEncoder
        {
            public static int WriteV0(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV0);
                return index;
            }
            public static int WriteV1(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV1);
                return index;
            }
            public static int WriteV2(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV2);
                return index;
            }
            public static int WriteV3(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV3);
                return index;
            }
            public static int WriteV4(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV4);
                return index;
            }
            public static int WriteV5(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV5);
                return index;
            }
            public static int WriteV6(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV6);
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
            public static int WriteV7(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV7);
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
            public static int WriteV8(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionEncoder.WriteV8);
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
            private static class ListOffsetsPartitionEncoder
            {
                public static int WriteV0(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.MaxNumOffsetsField);
                    return index;
                }
                public static int WriteV1(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
                    return index;
                }
                public static int WriteV2(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
                    return index;
                }
                public static int WriteV3(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
                    return index;
                }
                public static int WriteV4(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
                    return index;
                }
                public static int WriteV5(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
                    return index;
                }
                public static int WriteV6(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
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
                public static int WriteV7(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
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
                public static int WriteV8(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
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
