using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using DeleteTopicState = Kafka.Client.Messages.DeleteTopicsRequestData.DeleteTopicState;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class DeleteTopicsRequestEncoder : 
        RequestEncoder<RequestHeaderData, DeleteTopicsRequestData>
    {
        internal DeleteTopicsRequestEncoder() :
            base(
                ApiKey.DeleteTopics,
                new(0, 6),
                new(4, 32767),
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
        protected override EncodeValue<DeleteTopicsRequestData> GetMessageEncoder(short apiVersion) =>
            apiVersion switch
            {
                0 => WriteV0,
                1 => WriteV1,
                2 => WriteV2,
                3 => WriteV3,
                4 => WriteV4,
                5 => WriteV5,
                6 => WriteV6,
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteTopicsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<string>(buffer, i, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteTopicsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<string>(buffer, i, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteTopicsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<string>(buffer, i, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            return i;
        }
        private static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteTopicsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<string>(buffer, i, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            return i;
        }
        private static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteTopicsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<string>(buffer, i, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
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
        private static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteTopicsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<string>(buffer, i, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
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
        private static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteTopicsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<DeleteTopicState>(buffer, i, message.TopicsField, DeleteTopicStateEncoder.WriteV6);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
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
        private static class DeleteTopicStateEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteTopicState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteTopicState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteTopicState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteTopicState message)
            {
                var i = index;
                return i;
            }
            public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteTopicState message)
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
            public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteTopicState message)
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
            public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteTopicState message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteUuid(buffer, i, message.TopicIdField);
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
