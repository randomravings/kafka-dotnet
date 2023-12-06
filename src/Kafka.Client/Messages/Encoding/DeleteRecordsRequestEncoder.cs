using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using DeleteRecordsPartition = Kafka.Client.Messages.DeleteRecordsRequestData.DeleteRecordsTopic.DeleteRecordsPartition;
using DeleteRecordsTopic = Kafka.Client.Messages.DeleteRecordsRequestData.DeleteRecordsTopic;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class DeleteRecordsRequestEncoder : 
        RequestEncoder<RequestHeaderData, DeleteRecordsRequestData>
    {
        internal DeleteRecordsRequestEncoder() :
            base(
                ApiKey.DeleteRecords,
                new(0, 2),
                new(2, 32767),
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
        protected override EncodeValue<DeleteRecordsRequestData> GetMessageEncoder(short apiVersion) =>
            apiVersion switch
            {
                0 => WriteV0,
                1 => WriteV1,
                2 => WriteV2,
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteRecordsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<DeleteRecordsTopic>(buffer, i, message.TopicsField, DeleteRecordsTopicEncoder.WriteV0);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteRecordsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<DeleteRecordsTopic>(buffer, i, message.TopicsField, DeleteRecordsTopicEncoder.WriteV1);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteRecordsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<DeleteRecordsTopic>(buffer, i, message.TopicsField, DeleteRecordsTopicEncoder.WriteV2);
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
        private static class DeleteRecordsTopicEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteRecordsTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<DeleteRecordsPartition>(buffer, i, message.PartitionsField, DeleteRecordsPartitionEncoder.WriteV0);
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteRecordsTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<DeleteRecordsPartition>(buffer, i, message.PartitionsField, DeleteRecordsPartitionEncoder.WriteV1);
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteRecordsTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactArray<DeleteRecordsPartition>(buffer, i, message.PartitionsField, DeleteRecordsPartitionEncoder.WriteV2);
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
            private static class DeleteRecordsPartitionEncoder
            {
                public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteRecordsPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.OffsetField);
                    return i;
                }
                public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteRecordsPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.OffsetField);
                    return i;
                }
                public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteRecordsPartition message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteInt64(buffer, i, message.OffsetField);
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
