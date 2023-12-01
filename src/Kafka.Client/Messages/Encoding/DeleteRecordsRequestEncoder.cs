using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using DeleteRecordsTopic = Kafka.Client.Messages.DeleteRecordsRequestData.DeleteRecordsTopic;
using DeleteRecordsPartition = Kafka.Client.Messages.DeleteRecordsRequestData.DeleteRecordsTopic.DeleteRecordsPartition;

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
        protected override EncodeDelegate<RequestHeaderData> GetHeaderEncoder(short apiVersion)
        {
            if (_flexibleVersions.Includes(apiVersion))
                return RequestHeaderEncoder.WriteV2;
            else
                return RequestHeaderEncoder.WriteV1;
        }
        protected override EncodeDelegate<DeleteRecordsRequestData> GetMessageEncoder(short apiVersion) =>
            apiVersion switch
            {
                0 => WriteV0,
                1 => WriteV1,
                2 => WriteV2,
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0(byte[] buffer, int index, DeleteRecordsRequestData message)
        {
            index = BinaryEncoder.WriteArray<DeleteRecordsTopic>(buffer, index, message.TopicsField, DeleteRecordsTopicEncoder.WriteV0);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static int WriteV1(byte[] buffer, int index, DeleteRecordsRequestData message)
        {
            index = BinaryEncoder.WriteArray<DeleteRecordsTopic>(buffer, index, message.TopicsField, DeleteRecordsTopicEncoder.WriteV1);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static int WriteV2(byte[] buffer, int index, DeleteRecordsRequestData message)
        {
            index = BinaryEncoder.WriteCompactArray<DeleteRecordsTopic>(buffer, index, message.TopicsField, DeleteRecordsTopicEncoder.WriteV2);
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
        private static class DeleteRecordsTopicEncoder
        {
            public static int WriteV0(byte[] buffer, int index, DeleteRecordsTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<DeleteRecordsPartition>(buffer, index, message.PartitionsField, DeleteRecordsPartitionEncoder.WriteV0);
                return index;
            }
            public static int WriteV1(byte[] buffer, int index, DeleteRecordsTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<DeleteRecordsPartition>(buffer, index, message.PartitionsField, DeleteRecordsPartitionEncoder.WriteV1);
                return index;
            }
            public static int WriteV2(byte[] buffer, int index, DeleteRecordsTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<DeleteRecordsPartition>(buffer, index, message.PartitionsField, DeleteRecordsPartitionEncoder.WriteV2);
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
            private static class DeleteRecordsPartitionEncoder
            {
                public static int WriteV0(byte[] buffer, int index, DeleteRecordsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.OffsetField);
                    return index;
                }
                public static int WriteV1(byte[] buffer, int index, DeleteRecordsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.OffsetField);
                    return index;
                }
                public static int WriteV2(byte[] buffer, int index, DeleteRecordsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.OffsetField);
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
