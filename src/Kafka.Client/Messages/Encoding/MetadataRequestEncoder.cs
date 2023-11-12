using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using MetadataRequestTopic = Kafka.Client.Messages.MetadataRequestData.MetadataRequestTopic;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class MetadataRequestEncoder : 
        RequestEncoder<RequestHeaderData, MetadataRequestData>
    {
        public MetadataRequestEncoder() :
            base(
                ApiKey.Metadata,
                new(0, 12),
                new(9, 32767),
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
        protected override EncodeDelegate<MetadataRequestData> GetMessageEncoder(short apiVersion) =>
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
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0(byte[] buffer, int index, MetadataRequestData message)
        {
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicEncoder.WriteV0);
            return index;
        }
        private static int WriteV1(byte[] buffer, int index, MetadataRequestData message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicEncoder.WriteV1);
            return index;
        }
        private static int WriteV2(byte[] buffer, int index, MetadataRequestData message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicEncoder.WriteV2);
            return index;
        }
        private static int WriteV3(byte[] buffer, int index, MetadataRequestData message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicEncoder.WriteV3);
            return index;
        }
        private static int WriteV4(byte[] buffer, int index, MetadataRequestData message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicEncoder.WriteV4);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            return index;
        }
        private static int WriteV5(byte[] buffer, int index, MetadataRequestData message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicEncoder.WriteV5);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            return index;
        }
        private static int WriteV6(byte[] buffer, int index, MetadataRequestData message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicEncoder.WriteV6);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            return index;
        }
        private static int WriteV7(byte[] buffer, int index, MetadataRequestData message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicEncoder.WriteV7);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            return index;
        }
        private static int WriteV8(byte[] buffer, int index, MetadataRequestData message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicEncoder.WriteV8);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeClusterAuthorizedOperationsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeTopicAuthorizedOperationsField);
            return index;
        }
        private static int WriteV9(byte[] buffer, int index, MetadataRequestData message)
        {
            index = BinaryEncoder.WriteCompactArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicEncoder.WriteV9);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeClusterAuthorizedOperationsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeTopicAuthorizedOperationsField);
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
        private static int WriteV10(byte[] buffer, int index, MetadataRequestData message)
        {
            index = BinaryEncoder.WriteCompactArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicEncoder.WriteV10);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeClusterAuthorizedOperationsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeTopicAuthorizedOperationsField);
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
        private static int WriteV11(byte[] buffer, int index, MetadataRequestData message)
        {
            index = BinaryEncoder.WriteCompactArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicEncoder.WriteV11);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeTopicAuthorizedOperationsField);
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
        private static int WriteV12(byte[] buffer, int index, MetadataRequestData message)
        {
            index = BinaryEncoder.WriteCompactArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicEncoder.WriteV12);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeTopicAuthorizedOperationsField);
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
        private static class MetadataRequestTopicEncoder
        {
            public static int WriteV0(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static int WriteV1(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static int WriteV2(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static int WriteV3(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static int WriteV4(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static int WriteV5(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static int WriteV6(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static int WriteV7(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static int WriteV8(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static int WriteV9(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
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
            public static int WriteV10(byte[] buffer, int index, MetadataRequestTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.NameField);
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
            public static int WriteV11(byte[] buffer, int index, MetadataRequestTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.NameField);
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
            public static int WriteV12(byte[] buffer, int index, MetadataRequestTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.NameField);
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
