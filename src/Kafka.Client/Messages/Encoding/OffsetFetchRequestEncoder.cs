using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using OffsetFetchRequestGroup = Kafka.Client.Messages.OffsetFetchRequestData.OffsetFetchRequestGroup;
using OffsetFetchRequestTopic = Kafka.Client.Messages.OffsetFetchRequestData.OffsetFetchRequestTopic;
using OffsetFetchRequestTopics = Kafka.Client.Messages.OffsetFetchRequestData.OffsetFetchRequestGroup.OffsetFetchRequestTopics;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class OffsetFetchRequestEncoder : 
        RequestEncoder<RequestHeaderData, OffsetFetchRequestData>
    {
        internal OffsetFetchRequestEncoder() :
            base(
                ApiKey.OffsetFetch,
                new(0, 9),
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
        protected override EncodeValue<OffsetFetchRequestData> GetMessageEncoder(short apiVersion) =>
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
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            i = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, i, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV0);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            i = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, i, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV1);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, i, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV2);
            return i;
        }
        private static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, i, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV3);
            return i;
        }
        private static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, i, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV4);
            return i;
        }
        private static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, i, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV5);
            return i;
        }
        private static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteCompactArray<OffsetFetchRequestTopic>(buffer, i, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV6);
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
        private static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactString(buffer, i, message.GroupIdField);
            i = BinaryEncoder.WriteCompactArray<OffsetFetchRequestTopic>(buffer, i, message.TopicsField, OffsetFetchRequestTopicEncoder.WriteV7);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.RequireStableField);
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
        private static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<OffsetFetchRequestGroup>(buffer, i, message.GroupsField, OffsetFetchRequestGroupEncoder.WriteV8);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.RequireStableField);
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
        private static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<OffsetFetchRequestGroup>(buffer, i, message.GroupsField, OffsetFetchRequestGroupEncoder.WriteV9);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.RequireStableField);
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
        private static class OffsetFetchRequestGroupEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestGroup message)
            {
                var i = index;
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestGroup message)
            {
                var i = index;
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestGroup message)
            {
                var i = index;
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestGroup message)
            {
                var i = index;
                return i;
            }
            public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestGroup message)
            {
                var i = index;
                return i;
            }
            public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestGroup message)
            {
                var i = index;
                return i;
            }
            public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestGroup message)
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
            public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestGroup message)
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
            public static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestGroup message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.GroupIdField);
                i = BinaryEncoder.WriteCompactArray<OffsetFetchRequestTopics>(buffer, i, message.TopicsField, OffsetFetchRequestTopicsEncoder.WriteV8);
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
            public static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestGroup message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.GroupIdField);
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.MemberIdField);
                i = BinaryEncoder.WriteInt32(buffer, i, message.MemberEpochField);
                i = BinaryEncoder.WriteCompactArray<OffsetFetchRequestTopics>(buffer, i, message.TopicsField, OffsetFetchRequestTopicsEncoder.WriteV9);
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
            private static class OffsetFetchRequestTopicsEncoder
            {
                public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopics message)
                {
                    var i = index;
                    return i;
                }
                public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopics message)
                {
                    var i = index;
                    return i;
                }
                public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopics message)
                {
                    var i = index;
                    return i;
                }
                public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopics message)
                {
                    var i = index;
                    return i;
                }
                public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopics message)
                {
                    var i = index;
                    return i;
                }
                public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopics message)
                {
                    var i = index;
                    return i;
                }
                public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopics message)
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
                public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopics message)
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
                public static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopics message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                    i = BinaryEncoder.WriteCompactArray<int>(buffer, i, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
                public static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopics message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                    i = BinaryEncoder.WriteCompactArray<int>(buffer, i, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
        private static class OffsetFetchRequestTopicEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<int>(buffer, i, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<int>(buffer, i, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<int>(buffer, i, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<int>(buffer, i, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
                return i;
            }
            public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<int>(buffer, i, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
                return i;
            }
            public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<int>(buffer, i, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
                return i;
            }
            public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactArray<int>(buffer, i, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
            public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactArray<int>(buffer, i, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
            public static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopic message)
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
            public static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in OffsetFetchRequestTopic message)
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
        }
    }
}
