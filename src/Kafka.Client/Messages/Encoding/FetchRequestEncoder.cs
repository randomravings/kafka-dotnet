using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using FetchTopic = Kafka.Client.Messages.FetchRequestData.FetchTopic;
using ReplicaState = Kafka.Client.Messages.FetchRequestData.ReplicaState;
using FetchPartition = Kafka.Client.Messages.FetchRequestData.FetchTopic.FetchPartition;
using ForgottenTopic = Kafka.Client.Messages.FetchRequestData.ForgottenTopic;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class FetchRequestEncoder : 
        RequestEncoder<RequestHeaderData, FetchRequestData>
    {
        public FetchRequestEncoder() :
            base(
                ApiKey.Fetch,
                new(0, 16),
                new(12, 32767),
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
        protected override EncodeDelegate<FetchRequestData> GetMessageEncoder(short apiVersion) =>
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
                10 => WriteV10,
                11 => WriteV11,
                12 => WriteV12,
                13 => WriteV13,
                14 => WriteV14,
                15 => WriteV15,
                16 => WriteV16,
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV0);
            return index;
        }
        private static int WriteV1(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV1);
            return index;
        }
        private static int WriteV2(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV2);
            return index;
        }
        private static int WriteV3(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV3);
            return index;
        }
        private static int WriteV4(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV4);
            return index;
        }
        private static int WriteV5(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV5);
            return index;
        }
        private static int WriteV6(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV6);
            return index;
        }
        private static int WriteV7(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV7);
            index = BinaryEncoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV7);
            return index;
        }
        private static int WriteV8(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV8);
            index = BinaryEncoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV8);
            return index;
        }
        private static int WriteV9(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV9);
            index = BinaryEncoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV9);
            return index;
        }
        private static int WriteV10(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV10);
            index = BinaryEncoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV10);
            return index;
        }
        private static int WriteV11(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV11);
            index = BinaryEncoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV11);
            index = BinaryEncoder.WriteString(buffer, index, message.RackIdField);
            return index;
        }
        private static int WriteV12(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteCompactArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV12);
            index = BinaryEncoder.WriteCompactArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV12);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.RackIdField);
            var taggedFieldsCount = 0u;
            var previousTagged = 0;
            if(message.ClusterIdField != null)
                taggedFieldsCount++;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            if(message.ClusterIdField != null)
            {
                index = BinaryEncoder.WriteVarInt32(buffer, index, 0);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            }
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 0");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static int WriteV13(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteCompactArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV13);
            index = BinaryEncoder.WriteCompactArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV13);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.RackIdField);
            var taggedFieldsCount = 0u;
            var previousTagged = 0;
            if(message.ClusterIdField != null)
                taggedFieldsCount++;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            if(message.ClusterIdField != null)
            {
                index = BinaryEncoder.WriteVarInt32(buffer, index, 0);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            }
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 0");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static int WriteV14(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteCompactArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV14);
            index = BinaryEncoder.WriteCompactArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV14);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.RackIdField);
            var taggedFieldsCount = 0u;
            var previousTagged = 0;
            if(message.ClusterIdField != null)
                taggedFieldsCount++;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            if(message.ClusterIdField != null)
            {
                index = BinaryEncoder.WriteVarInt32(buffer, index, 0);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            }
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 0");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static int WriteV15(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteCompactArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV15);
            index = BinaryEncoder.WriteCompactArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV15);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.RackIdField);
            var taggedFieldsCount = 1u;
            var previousTagged = 1;
            if(message.ClusterIdField != null)
                taggedFieldsCount++;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            if(message.ClusterIdField != null)
            {
                index = BinaryEncoder.WriteVarInt32(buffer, index, 0);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            }
            {
                index = BinaryEncoder.WriteVarInt32(buffer, index, 1);
                index = ReplicaStateEncoder.WriteV15(buffer, index, message.ReplicaStateField);
            }
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static int WriteV16(byte[] buffer, int index, FetchRequestData message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteCompactArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicEncoder.WriteV16);
            index = BinaryEncoder.WriteCompactArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV16);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.RackIdField);
            var taggedFieldsCount = 1u;
            var previousTagged = 1;
            if(message.ClusterIdField != null)
                taggedFieldsCount++;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            if(message.ClusterIdField != null)
            {
                index = BinaryEncoder.WriteVarInt32(buffer, index, 0);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            }
            {
                index = BinaryEncoder.WriteVarInt32(buffer, index, 1);
                index = ReplicaStateEncoder.WriteV16(buffer, index, message.ReplicaStateField);
            }
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class FetchTopicEncoder
        {
            public static int WriteV0(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV0);
                return index;
            }
            public static int WriteV1(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV1);
                return index;
            }
            public static int WriteV2(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV2);
                return index;
            }
            public static int WriteV3(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV3);
                return index;
            }
            public static int WriteV4(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV4);
                return index;
            }
            public static int WriteV5(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV5);
                return index;
            }
            public static int WriteV6(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV6);
                return index;
            }
            public static int WriteV7(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV7);
                return index;
            }
            public static int WriteV8(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV8);
                return index;
            }
            public static int WriteV9(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV9);
                return index;
            }
            public static int WriteV10(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV10);
                return index;
            }
            public static int WriteV11(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV11);
                return index;
            }
            public static int WriteV12(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteCompactArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV12);
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
            public static int WriteV13(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV13);
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
            public static int WriteV14(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV14);
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
            public static int WriteV15(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV15);
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
            public static int WriteV16(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionEncoder.WriteV16);
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
            private static class FetchPartitionEncoder
            {
                public static int WriteV0(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static int WriteV1(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static int WriteV2(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static int WriteV3(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static int WriteV4(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static int WriteV5(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static int WriteV6(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static int WriteV7(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static int WriteV8(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static int WriteV9(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static int WriteV10(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static int WriteV11(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static int WriteV12(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LastFetchedEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
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
                public static int WriteV13(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LastFetchedEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
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
                public static int WriteV14(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LastFetchedEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
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
                public static int WriteV15(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LastFetchedEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
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
                public static int WriteV16(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LastFetchedEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
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
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class ForgottenTopicEncoder
        {
            public static int WriteV0(byte[] buffer, int index, ForgottenTopic message)
            {
                return index;
            }
            public static int WriteV1(byte[] buffer, int index, ForgottenTopic message)
            {
                return index;
            }
            public static int WriteV2(byte[] buffer, int index, ForgottenTopic message)
            {
                return index;
            }
            public static int WriteV3(byte[] buffer, int index, ForgottenTopic message)
            {
                return index;
            }
            public static int WriteV4(byte[] buffer, int index, ForgottenTopic message)
            {
                return index;
            }
            public static int WriteV5(byte[] buffer, int index, ForgottenTopic message)
            {
                return index;
            }
            public static int WriteV6(byte[] buffer, int index, ForgottenTopic message)
            {
                return index;
            }
            public static int WriteV7(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
                return index;
            }
            public static int WriteV8(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
                return index;
            }
            public static int WriteV9(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
                return index;
            }
            public static int WriteV10(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
                return index;
            }
            public static int WriteV11(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
                return index;
            }
            public static int WriteV12(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
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
            public static int WriteV13(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
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
            public static int WriteV14(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
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
            public static int WriteV15(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
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
            public static int WriteV16(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
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
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class ReplicaStateEncoder
        {
            public static int WriteV0(byte[] buffer, int index, ReplicaState message)
            {
                return index;
            }
            public static int WriteV1(byte[] buffer, int index, ReplicaState message)
            {
                return index;
            }
            public static int WriteV2(byte[] buffer, int index, ReplicaState message)
            {
                return index;
            }
            public static int WriteV3(byte[] buffer, int index, ReplicaState message)
            {
                return index;
            }
            public static int WriteV4(byte[] buffer, int index, ReplicaState message)
            {
                return index;
            }
            public static int WriteV5(byte[] buffer, int index, ReplicaState message)
            {
                return index;
            }
            public static int WriteV6(byte[] buffer, int index, ReplicaState message)
            {
                return index;
            }
            public static int WriteV7(byte[] buffer, int index, ReplicaState message)
            {
                return index;
            }
            public static int WriteV8(byte[] buffer, int index, ReplicaState message)
            {
                return index;
            }
            public static int WriteV9(byte[] buffer, int index, ReplicaState message)
            {
                return index;
            }
            public static int WriteV10(byte[] buffer, int index, ReplicaState message)
            {
                return index;
            }
            public static int WriteV11(byte[] buffer, int index, ReplicaState message)
            {
                return index;
            }
            public static int WriteV12(byte[] buffer, int index, ReplicaState message)
            {
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
            public static int WriteV13(byte[] buffer, int index, ReplicaState message)
            {
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
            public static int WriteV14(byte[] buffer, int index, ReplicaState message)
            {
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
            public static int WriteV15(byte[] buffer, int index, ReplicaState message)
            {
                index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
                index = BinaryEncoder.WriteInt64(buffer, index, message.ReplicaEpochField);
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
            public static int WriteV16(byte[] buffer, int index, ReplicaState message)
            {
                index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
                index = BinaryEncoder.WriteInt64(buffer, index, message.ReplicaEpochField);
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
