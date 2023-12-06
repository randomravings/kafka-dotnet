using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using MetadataRequestTopic = Kafka.Client.Messages.MetadataRequestData.MetadataRequestTopic;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class MetadataRequestEncoder : 
        RequestEncoder<RequestHeaderData, MetadataRequestData>
    {
        internal MetadataRequestEncoder() :
            base(
                ApiKey.Metadata,
                new(0, 12),
                new(9, 32767),
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
        protected override EncodeValue<MetadataRequestData> GetMessageEncoder(short apiVersion) =>
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
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestData message)
        {
            var i = index;
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            i = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, i, message.TopicsField, MetadataRequestTopicEncoder.WriteV0);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, i, message.TopicsField, MetadataRequestTopicEncoder.WriteV1);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, i, message.TopicsField, MetadataRequestTopicEncoder.WriteV2);
            return i;
        }
        private static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, i, message.TopicsField, MetadataRequestTopicEncoder.WriteV3);
            return i;
        }
        private static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, i, message.TopicsField, MetadataRequestTopicEncoder.WriteV4);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.AllowAutoTopicCreationField);
            return i;
        }
        private static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, i, message.TopicsField, MetadataRequestTopicEncoder.WriteV5);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.AllowAutoTopicCreationField);
            return i;
        }
        private static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, i, message.TopicsField, MetadataRequestTopicEncoder.WriteV6);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.AllowAutoTopicCreationField);
            return i;
        }
        private static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, i, message.TopicsField, MetadataRequestTopicEncoder.WriteV7);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.AllowAutoTopicCreationField);
            return i;
        }
        private static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, i, message.TopicsField, MetadataRequestTopicEncoder.WriteV8);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.AllowAutoTopicCreationField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.IncludeClusterAuthorizedOperationsField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.IncludeTopicAuthorizedOperationsField);
            return i;
        }
        private static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<MetadataRequestTopic>(buffer, i, message.TopicsField, MetadataRequestTopicEncoder.WriteV9);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.AllowAutoTopicCreationField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.IncludeClusterAuthorizedOperationsField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.IncludeTopicAuthorizedOperationsField);
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
        private static int WriteV10([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<MetadataRequestTopic>(buffer, i, message.TopicsField, MetadataRequestTopicEncoder.WriteV10);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.AllowAutoTopicCreationField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.IncludeClusterAuthorizedOperationsField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.IncludeTopicAuthorizedOperationsField);
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
        private static int WriteV11([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<MetadataRequestTopic>(buffer, i, message.TopicsField, MetadataRequestTopicEncoder.WriteV11);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.AllowAutoTopicCreationField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.IncludeTopicAuthorizedOperationsField);
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
        private static int WriteV12([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<MetadataRequestTopic>(buffer, i, message.TopicsField, MetadataRequestTopicEncoder.WriteV12);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.AllowAutoTopicCreationField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.IncludeTopicAuthorizedOperationsField);
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
        private static class MetadataRequestTopicEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestTopic message)
            {
                var i = index;
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestTopic message)
            {
                var i = index;
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestTopic message)
            {
                var i = index;
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestTopic message)
            {
                var i = index;
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                return i;
            }
            public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestTopic message)
            {
                var i = index;
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                return i;
            }
            public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestTopic message)
            {
                var i = index;
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                return i;
            }
            public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestTopic message)
            {
                var i = index;
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                return i;
            }
            public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestTopic message)
            {
                var i = index;
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                return i;
            }
            public static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestTopic message)
            {
                var i = index;
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                return i;
            }
            public static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestTopic message)
            {
                var i = index;
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
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
            public static int WriteV10([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteUuid(buffer, i, message.TopicIdField);
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.NameField);
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
            public static int WriteV11([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteUuid(buffer, i, message.TopicIdField);
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.NameField);
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
            public static int WriteV12([NotNull] in byte[] buffer, in int index, [NotNull] in MetadataRequestTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteUuid(buffer, i, message.TopicIdField);
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.NameField);
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
