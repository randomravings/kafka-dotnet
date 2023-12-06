using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using ForgottenTopic = Kafka.Client.Messages.FetchRequestData.ForgottenTopic;
using FetchTopic = Kafka.Client.Messages.FetchRequestData.FetchTopic;
using ReplicaState = Kafka.Client.Messages.FetchRequestData.ReplicaState;
using FetchPartition = Kafka.Client.Messages.FetchRequestData.FetchTopic.FetchPartition;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class FetchRequestEncoder : 
        RequestEncoder<RequestHeaderData, FetchRequestData>
    {
        internal FetchRequestEncoder() :
            base(
                ApiKey.Fetch,
                new(0, 16),
                new(12, 32767),
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
        protected override EncodeValue<FetchRequestData> GetMessageEncoder(short apiVersion) =>
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
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV0);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV1);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV2);
            return i;
        }
        private static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxBytesField);
            i = BinaryEncoder.WriteArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV3);
            return i;
        }
        private static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxBytesField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV4);
            return i;
        }
        private static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxBytesField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV5);
            return i;
        }
        private static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxBytesField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV6);
            return i;
        }
        private static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxBytesField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionEpochField);
            i = BinaryEncoder.WriteArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV7);
            i = BinaryEncoder.WriteArray<ForgottenTopic>(buffer, i, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV7);
            return i;
        }
        private static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxBytesField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionEpochField);
            i = BinaryEncoder.WriteArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV8);
            i = BinaryEncoder.WriteArray<ForgottenTopic>(buffer, i, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV8);
            return i;
        }
        private static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxBytesField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionEpochField);
            i = BinaryEncoder.WriteArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV9);
            i = BinaryEncoder.WriteArray<ForgottenTopic>(buffer, i, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV9);
            return i;
        }
        private static int WriteV10([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxBytesField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionEpochField);
            i = BinaryEncoder.WriteArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV10);
            i = BinaryEncoder.WriteArray<ForgottenTopic>(buffer, i, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV10);
            return i;
        }
        private static int WriteV11([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxBytesField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionEpochField);
            i = BinaryEncoder.WriteArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV11);
            i = BinaryEncoder.WriteArray<ForgottenTopic>(buffer, i, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV11);
            i = BinaryEncoder.WriteString(buffer, i, message.RackIdField);
            return i;
        }
        private static int WriteV12([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxBytesField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionEpochField);
            i = BinaryEncoder.WriteCompactArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV12);
            i = BinaryEncoder.WriteCompactArray<ForgottenTopic>(buffer, i, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV12);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.RackIdField);
            var taggedFieldsCount = 0u;
            var previousTagged = 0;
            if(message.ClusterIdField != null)
                taggedFieldsCount++;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
            if(message.ClusterIdField != null)
            {
                i = BinaryEncoder.WriteVarInt32(buffer, i, 0);
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.ClusterIdField);
            }
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 0");
                i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
            }
            return i;
        }
        private static int WriteV13([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxBytesField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionEpochField);
            i = BinaryEncoder.WriteCompactArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV13);
            i = BinaryEncoder.WriteCompactArray<ForgottenTopic>(buffer, i, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV13);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.RackIdField);
            var taggedFieldsCount = 0u;
            var previousTagged = 0;
            if(message.ClusterIdField != null)
                taggedFieldsCount++;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
            if(message.ClusterIdField != null)
            {
                i = BinaryEncoder.WriteVarInt32(buffer, i, 0);
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.ClusterIdField);
            }
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 0");
                i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
            }
            return i;
        }
        private static int WriteV14([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxBytesField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionEpochField);
            i = BinaryEncoder.WriteCompactArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV14);
            i = BinaryEncoder.WriteCompactArray<ForgottenTopic>(buffer, i, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV14);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.RackIdField);
            var taggedFieldsCount = 0u;
            var previousTagged = 0;
            if(message.ClusterIdField != null)
                taggedFieldsCount++;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
            if(message.ClusterIdField != null)
            {
                i = BinaryEncoder.WriteVarInt32(buffer, i, 0);
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.ClusterIdField);
            }
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 0");
                i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
            }
            return i;
        }
        private static int WriteV15([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxBytesField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionEpochField);
            i = BinaryEncoder.WriteCompactArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV15);
            i = BinaryEncoder.WriteCompactArray<ForgottenTopic>(buffer, i, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV15);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.RackIdField);
            var taggedFieldsCount = 1u;
            var previousTagged = 1;
            if(message.ClusterIdField != null)
                taggedFieldsCount++;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
            if(message.ClusterIdField != null)
            {
                i = BinaryEncoder.WriteVarInt32(buffer, i, 0);
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.ClusterIdField);
            }
            {
                i = BinaryEncoder.WriteVarInt32(buffer, i, 1);
                i = ReplicaStateEncoder.WriteV15(buffer, i, message.ReplicaStateField);
            }
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 1");
                i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
            }
            return i;
        }
        private static int WriteV16([NotNull] in byte[] buffer, in int index, [NotNull] in FetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxWaitMsField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MinBytesField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.MaxBytesField);
            i = BinaryEncoder.WriteInt8(buffer, i, message.IsolationLevelField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionIdField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.SessionEpochField);
            i = BinaryEncoder.WriteCompactArray<FetchTopic>(buffer, i, message.TopicsField, FetchTopicEncoder.WriteV16);
            i = BinaryEncoder.WriteCompactArray<ForgottenTopic>(buffer, i, message.ForgottenTopicsDataField, ForgottenTopicEncoder.WriteV16);
            i = BinaryEncoder.WriteCompactString(buffer, i, message.RackIdField);
            var taggedFieldsCount = 1u;
            var previousTagged = 1;
            if(message.ClusterIdField != null)
                taggedFieldsCount++;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
            if(message.ClusterIdField != null)
            {
                i = BinaryEncoder.WriteVarInt32(buffer, i, 0);
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.ClusterIdField);
            }
            {
                i = BinaryEncoder.WriteVarInt32(buffer, i, 1);
                i = ReplicaStateEncoder.WriteV16(buffer, i, message.ReplicaStateField);
            }
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 1");
                i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
            }
            return i;
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class FetchTopicEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV0);
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV1);
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV2);
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV3);
                return i;
            }
            public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV4);
                return i;
            }
            public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV5);
                return i;
            }
            public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV6);
                return i;
            }
            public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV7);
                return i;
            }
            public static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV8);
                return i;
            }
            public static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV9);
                return i;
            }
            public static int WriteV10([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV10);
                return i;
            }
            public static int WriteV11([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV11);
                return i;
            }
            public static int WriteV12([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteCompactArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV12);
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
            public static int WriteV13([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteUuid(buffer, i, message.TopicIdField);
                i = BinaryEncoder.WriteCompactArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV13);
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
            public static int WriteV14([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteUuid(buffer, i, message.TopicIdField);
                i = BinaryEncoder.WriteCompactArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV14);
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
            public static int WriteV15([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteUuid(buffer, i, message.TopicIdField);
                i = BinaryEncoder.WriteCompactArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV15);
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
            public static int WriteV16([NotNull] in byte[] buffer, in int index, [NotNull] in FetchTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteUuid(buffer, i, message.TopicIdField);
                i = BinaryEncoder.WriteCompactArray<FetchPartition>(buffer, i, message.PartitionsField, FetchPartitionEncoder.WriteV16);
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
            private static class FetchPartitionEncoder
            {
                public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
                    return i;
                }
                public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
                    return i;
                }
                public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
                    return i;
                }
                public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
                    return i;
                }
                public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
                    return i;
                }
                public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.LogStartOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
                    return i;
                }
                public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.LogStartOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
                    return i;
                }
                public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.LogStartOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
                    return i;
                }
                public static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.LogStartOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
                    return i;
                }
                public static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CurrentLeaderEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.LogStartOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
                    return i;
                }
                public static int WriteV10([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CurrentLeaderEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.LogStartOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
                    return i;
                }
                public static int WriteV11([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CurrentLeaderEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.LogStartOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
                    return i;
                }
                public static int WriteV12([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CurrentLeaderEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.LastFetchedEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.LogStartOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
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
                public static int WriteV13([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CurrentLeaderEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.LastFetchedEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.LogStartOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
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
                public static int WriteV14([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CurrentLeaderEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.LastFetchedEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.LogStartOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
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
                public static int WriteV15([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CurrentLeaderEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.LastFetchedEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.LogStartOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
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
                public static int WriteV16([NotNull] in byte[] buffer, in int index, [NotNull] in FetchPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.CurrentLeaderEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.FetchOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.LastFetchedEpochField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.LogStartOffsetField);
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionMaxBytesField);
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
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class ForgottenTopicEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                return i;
            }
            public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                return i;
            }
            public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                return i;
            }
            public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                return i;
            }
            public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<int>(buffer, i, message.PartitionsField, BinaryEncoder.WriteInt32);
                return i;
            }
            public static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<int>(buffer, i, message.PartitionsField, BinaryEncoder.WriteInt32);
                return i;
            }
            public static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<int>(buffer, i, message.PartitionsField, BinaryEncoder.WriteInt32);
                return i;
            }
            public static int WriteV10([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<int>(buffer, i, message.PartitionsField, BinaryEncoder.WriteInt32);
                return i;
            }
            public static int WriteV11([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteArray<int>(buffer, i, message.PartitionsField, BinaryEncoder.WriteInt32);
                return i;
            }
            public static int WriteV12([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.TopicField);
                i = BinaryEncoder.WriteCompactArray<int>(buffer, i, message.PartitionsField, BinaryEncoder.WriteInt32);
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
            public static int WriteV13([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteUuid(buffer, i, message.TopicIdField);
                i = BinaryEncoder.WriteCompactArray<int>(buffer, i, message.PartitionsField, BinaryEncoder.WriteInt32);
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
            public static int WriteV14([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteUuid(buffer, i, message.TopicIdField);
                i = BinaryEncoder.WriteCompactArray<int>(buffer, i, message.PartitionsField, BinaryEncoder.WriteInt32);
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
            public static int WriteV15([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteUuid(buffer, i, message.TopicIdField);
                i = BinaryEncoder.WriteCompactArray<int>(buffer, i, message.PartitionsField, BinaryEncoder.WriteInt32);
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
            public static int WriteV16([NotNull] in byte[] buffer, in int index, [NotNull] in ForgottenTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteUuid(buffer, i, message.TopicIdField);
                i = BinaryEncoder.WriteCompactArray<int>(buffer, i, message.PartitionsField, BinaryEncoder.WriteInt32);
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
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class ReplicaStateEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV10([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV11([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV12([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
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
            public static int WriteV13([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
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
            public static int WriteV14([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
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
            public static int WriteV15([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
                i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
                i = BinaryEncoder.WriteInt64(buffer, i, message.ReplicaEpochField);
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
            public static int WriteV16([NotNull] in byte[] buffer, in int index, [NotNull] in ReplicaState message)
            {
                var i = index;
                i = BinaryEncoder.WriteInt32(buffer, i, message.ReplicaIdField);
                i = BinaryEncoder.WriteInt64(buffer, i, message.ReplicaEpochField);
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
