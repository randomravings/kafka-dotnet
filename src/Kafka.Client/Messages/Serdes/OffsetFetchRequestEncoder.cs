using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using OffsetFetchRequestTopics = Kafka.Client.Messages.OffsetFetchRequestData.OffsetFetchRequestGroup.OffsetFetchRequestTopics;
using OffsetFetchRequestGroup = Kafka.Client.Messages.OffsetFetchRequestData.OffsetFetchRequestGroup;
using OffsetFetchRequestTopic = Kafka.Client.Messages.OffsetFetchRequestData.OffsetFetchRequestTopic;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class OffsetFetchRequestEncoder : 
        RequestEncoder<RequestHeaderData, OffsetFetchRequestData>
    {
        public OffsetFetchRequestEncoder() :
            base(
                ApiKey.OffsetFetch,
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
        protected override EncodeDelegate<OffsetFetchRequestData> GetMessageEncoder(short apiVersion) =>
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
        private static int WriteV0(byte[] buffer, int index, OffsetFetchRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            index = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV0);
            return index;
        }
        private static int WriteV1(byte[] buffer, int index, OffsetFetchRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            index = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV1);
            return index;
        }
        private static int WriteV2(byte[] buffer, int index, OffsetFetchRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV2);
            return index;
        }
        private static int WriteV3(byte[] buffer, int index, OffsetFetchRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV3);
            return index;
        }
        private static int WriteV4(byte[] buffer, int index, OffsetFetchRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV4);
            return index;
        }
        private static int WriteV5(byte[] buffer, int index, OffsetFetchRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV5);
            return index;
        }
        private static int WriteV6(byte[] buffer, int index, OffsetFetchRequestData message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteCompactArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV6);
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
        private static int WriteV7(byte[] buffer, int index, OffsetFetchRequestData message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteCompactArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV7);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.RequireStableField);
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
        private static int WriteV8(byte[] buffer, int index, OffsetFetchRequestData message)
        {
            index = BinaryEncoder.WriteCompactArray<OffsetFetchRequestGroup>(buffer, index, message.GroupsField, OffsetFetchRequestGroupEncoder.WriteV8);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.RequireStableField);
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
        private static class OffsetFetchRequestGroupEncoder
        {
            public static int WriteV0(byte[] buffer, int index, OffsetFetchRequestGroup message)
            {
                return index;
            }
            public static int WriteV1(byte[] buffer, int index, OffsetFetchRequestGroup message)
            {
                return index;
            }
            public static int WriteV2(byte[] buffer, int index, OffsetFetchRequestGroup message)
            {
                return index;
            }
            public static int WriteV3(byte[] buffer, int index, OffsetFetchRequestGroup message)
            {
                return index;
            }
            public static int WriteV4(byte[] buffer, int index, OffsetFetchRequestGroup message)
            {
                return index;
            }
            public static int WriteV5(byte[] buffer, int index, OffsetFetchRequestGroup message)
            {
                return index;
            }
            public static int WriteV6(byte[] buffer, int index, OffsetFetchRequestGroup message)
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
            public static int WriteV7(byte[] buffer, int index, OffsetFetchRequestGroup message)
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
            public static int WriteV8(byte[] buffer, int index, OffsetFetchRequestGroup message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
                index = BinaryEncoder.WriteCompactArray<OffsetFetchRequestTopics>(buffer, index, message.TopicsField, OffsetFetchRequestTopicsEncoder.WriteV8);
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
            private static class OffsetFetchRequestTopicsEncoder
            {
                public static int WriteV0(byte[] buffer, int index, OffsetFetchRequestTopics message)
                {
                    return index;
                }
                public static int WriteV1(byte[] buffer, int index, OffsetFetchRequestTopics message)
                {
                    return index;
                }
                public static int WriteV2(byte[] buffer, int index, OffsetFetchRequestTopics message)
                {
                    return index;
                }
                public static int WriteV3(byte[] buffer, int index, OffsetFetchRequestTopics message)
                {
                    return index;
                }
                public static int WriteV4(byte[] buffer, int index, OffsetFetchRequestTopics message)
                {
                    return index;
                }
                public static int WriteV5(byte[] buffer, int index, OffsetFetchRequestTopics message)
                {
                    return index;
                }
                public static int WriteV6(byte[] buffer, int index, OffsetFetchRequestTopics message)
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
                public static int WriteV7(byte[] buffer, int index, OffsetFetchRequestTopics message)
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
                public static int WriteV8(byte[] buffer, int index, OffsetFetchRequestTopics message)
                {
                    index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
        private static class OffsetFetchRequestTopicEncoder
        {
            public static int WriteV0(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
                return index;
            }
            public static int WriteV1(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
                return index;
            }
            public static int WriteV2(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
                return index;
            }
            public static int WriteV3(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
                return index;
            }
            public static int WriteV4(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
                return index;
            }
            public static int WriteV5(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
                return index;
            }
            public static int WriteV6(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
            public static int WriteV7(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
            public static int WriteV8(byte[] buffer, int index, OffsetFetchRequestTopic message)
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
        }
    }
}
