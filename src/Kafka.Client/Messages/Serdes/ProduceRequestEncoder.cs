using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using TopicProduceData = Kafka.Client.Messages.ProduceRequestData.TopicProduceData;
using PartitionProduceData = Kafka.Client.Messages.ProduceRequestData.TopicProduceData.PartitionProduceData;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class ProduceRequestEncoder : 
        RequestEncoder<RequestHeaderData, ProduceRequestData>
    {
        public ProduceRequestEncoder() :
            base(
                ApiKey.Produce,
                new(0, 9),
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
        protected override EncodeDelegate<ProduceRequestData> GetMessageEncoder(short apiVersion) =>
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
        private static int WriteV0(byte[] buffer, int index, ProduceRequestData message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataEncoder.WriteV0);
            return index;
        }
        private static int WriteV1(byte[] buffer, int index, ProduceRequestData message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataEncoder.WriteV1);
            return index;
        }
        private static int WriteV2(byte[] buffer, int index, ProduceRequestData message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataEncoder.WriteV2);
            return index;
        }
        private static int WriteV3(byte[] buffer, int index, ProduceRequestData message)
        {
            index = BinaryEncoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataEncoder.WriteV3);
            return index;
        }
        private static int WriteV4(byte[] buffer, int index, ProduceRequestData message)
        {
            index = BinaryEncoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataEncoder.WriteV4);
            return index;
        }
        private static int WriteV5(byte[] buffer, int index, ProduceRequestData message)
        {
            index = BinaryEncoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataEncoder.WriteV5);
            return index;
        }
        private static int WriteV6(byte[] buffer, int index, ProduceRequestData message)
        {
            index = BinaryEncoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataEncoder.WriteV6);
            return index;
        }
        private static int WriteV7(byte[] buffer, int index, ProduceRequestData message)
        {
            index = BinaryEncoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataEncoder.WriteV7);
            return index;
        }
        private static int WriteV8(byte[] buffer, int index, ProduceRequestData message)
        {
            index = BinaryEncoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataEncoder.WriteV8);
            return index;
        }
        private static int WriteV9(byte[] buffer, int index, ProduceRequestData message)
        {
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteCompactArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataEncoder.WriteV9);
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
        private static class TopicProduceDataEncoder
        {
            public static int WriteV0(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataEncoder.WriteV0);
                return index;
            }
            public static int WriteV1(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataEncoder.WriteV1);
                return index;
            }
            public static int WriteV2(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataEncoder.WriteV2);
                return index;
            }
            public static int WriteV3(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataEncoder.WriteV3);
                return index;
            }
            public static int WriteV4(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataEncoder.WriteV4);
                return index;
            }
            public static int WriteV5(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataEncoder.WriteV5);
                return index;
            }
            public static int WriteV6(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataEncoder.WriteV6);
                return index;
            }
            public static int WriteV7(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataEncoder.WriteV7);
                return index;
            }
            public static int WriteV8(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataEncoder.WriteV8);
                return index;
            }
            public static int WriteV9(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataEncoder.WriteV9);
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
            private static class PartitionProduceDataEncoder
            {
                public static int WriteV0(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static int WriteV1(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static int WriteV2(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static int WriteV3(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static int WriteV4(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static int WriteV5(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static int WriteV6(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static int WriteV7(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static int WriteV8(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static int WriteV9(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteCompactRecords(buffer, index, message.RecordsField);
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
