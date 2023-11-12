using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using DeleteTopicState = Kafka.Client.Messages.DeleteTopicsRequestData.DeleteTopicState;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class DeleteTopicsRequestEncoder : 
        RequestEncoder<RequestHeaderData, DeleteTopicsRequestData>
    {
        public DeleteTopicsRequestEncoder() :
            base(
                ApiKey.DeleteTopics,
                new(0, 6),
                new(4, 32767),
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
        protected override EncodeDelegate<DeleteTopicsRequestData> GetMessageEncoder(short apiVersion) =>
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
        private static int WriteV0(byte[] buffer, int index, DeleteTopicsRequestData message)
        {
            index = BinaryEncoder.WriteArray<string>(buffer, index, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static int WriteV1(byte[] buffer, int index, DeleteTopicsRequestData message)
        {
            index = BinaryEncoder.WriteArray<string>(buffer, index, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static int WriteV2(byte[] buffer, int index, DeleteTopicsRequestData message)
        {
            index = BinaryEncoder.WriteArray<string>(buffer, index, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static int WriteV3(byte[] buffer, int index, DeleteTopicsRequestData message)
        {
            index = BinaryEncoder.WriteArray<string>(buffer, index, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static int WriteV4(byte[] buffer, int index, DeleteTopicsRequestData message)
        {
            index = BinaryEncoder.WriteCompactArray<string>(buffer, index, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
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
        private static int WriteV5(byte[] buffer, int index, DeleteTopicsRequestData message)
        {
            index = BinaryEncoder.WriteCompactArray<string>(buffer, index, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
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
        private static int WriteV6(byte[] buffer, int index, DeleteTopicsRequestData message)
        {
            index = BinaryEncoder.WriteCompactArray<DeleteTopicState>(buffer, index, message.TopicsField, DeleteTopicStateEncoder.WriteV6);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
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
        private static class DeleteTopicStateEncoder
        {
            public static int WriteV0(byte[] buffer, int index, DeleteTopicState message)
            {
                return index;
            }
            public static int WriteV1(byte[] buffer, int index, DeleteTopicState message)
            {
                return index;
            }
            public static int WriteV2(byte[] buffer, int index, DeleteTopicState message)
            {
                return index;
            }
            public static int WriteV3(byte[] buffer, int index, DeleteTopicState message)
            {
                return index;
            }
            public static int WriteV4(byte[] buffer, int index, DeleteTopicState message)
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
            public static int WriteV5(byte[] buffer, int index, DeleteTopicState message)
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
            public static int WriteV6(byte[] buffer, int index, DeleteTopicState message)
            {
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
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
