using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using PartitionProduceData = Kafka.Client.Messages.ProduceRequestData.TopicProduceData.PartitionProduceData;
using TopicProduceData = Kafka.Client.Messages.ProduceRequestData.TopicProduceData;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class ProduceRequestEncoder : 
        RequestEncoder<RequestHeaderData, ProduceRequestData>
    {
        internal ProduceRequestEncoder() :
            base(
                ApiKey.Produce,
                new(0, 10),
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
        protected override EncodeValue<ProduceRequestData> GetMessageEncoder(short apiVersion) =>
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
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in ProduceRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt16(buffer, i, message.AcksField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteArray<TopicProduceData>(buffer, i, message.TopicDataField, TopicProduceDataEncoder.WriteV0);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in ProduceRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt16(buffer, i, message.AcksField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteArray<TopicProduceData>(buffer, i, message.TopicDataField, TopicProduceDataEncoder.WriteV1);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in ProduceRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteInt16(buffer, i, message.AcksField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteArray<TopicProduceData>(buffer, i, message.TopicDataField, TopicProduceDataEncoder.WriteV2);
            return i;
        }
        private static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in ProduceRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteNullableString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.AcksField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteArray<TopicProduceData>(buffer, i, message.TopicDataField, TopicProduceDataEncoder.WriteV3);
            return i;
        }
        private static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in ProduceRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteNullableString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.AcksField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteArray<TopicProduceData>(buffer, i, message.TopicDataField, TopicProduceDataEncoder.WriteV4);
            return i;
        }
        private static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in ProduceRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteNullableString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.AcksField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteArray<TopicProduceData>(buffer, i, message.TopicDataField, TopicProduceDataEncoder.WriteV5);
            return i;
        }
        private static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in ProduceRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteNullableString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.AcksField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteArray<TopicProduceData>(buffer, i, message.TopicDataField, TopicProduceDataEncoder.WriteV6);
            return i;
        }
        private static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in ProduceRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteNullableString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.AcksField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteArray<TopicProduceData>(buffer, i, message.TopicDataField, TopicProduceDataEncoder.WriteV7);
            return i;
        }
        private static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in ProduceRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteNullableString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.AcksField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteArray<TopicProduceData>(buffer, i, message.TopicDataField, TopicProduceDataEncoder.WriteV8);
            return i;
        }
        private static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in ProduceRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.AcksField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteCompactArray<TopicProduceData>(buffer, i, message.TopicDataField, TopicProduceDataEncoder.WriteV9);
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
        private static int WriteV10([NotNull] in byte[] buffer, in int index, [NotNull] in ProduceRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.TransactionalIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.AcksField);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteCompactArray<TopicProduceData>(buffer, i, message.TopicDataField, TopicProduceDataEncoder.WriteV10);
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
        private static class TopicProduceDataEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in TopicProduceData message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, i, message.PartitionDataField, PartitionProduceDataEncoder.WriteV0);
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in TopicProduceData message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, i, message.PartitionDataField, PartitionProduceDataEncoder.WriteV1);
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in TopicProduceData message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, i, message.PartitionDataField, PartitionProduceDataEncoder.WriteV2);
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in TopicProduceData message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, i, message.PartitionDataField, PartitionProduceDataEncoder.WriteV3);
                return i;
            }
            public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in TopicProduceData message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, i, message.PartitionDataField, PartitionProduceDataEncoder.WriteV4);
                return i;
            }
            public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in TopicProduceData message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, i, message.PartitionDataField, PartitionProduceDataEncoder.WriteV5);
                return i;
            }
            public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in TopicProduceData message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, i, message.PartitionDataField, PartitionProduceDataEncoder.WriteV6);
                return i;
            }
            public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in TopicProduceData message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, i, message.PartitionDataField, PartitionProduceDataEncoder.WriteV7);
                return i;
            }
            public static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in TopicProduceData message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, i, message.PartitionDataField, PartitionProduceDataEncoder.WriteV8);
                return i;
            }
            public static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in TopicProduceData message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactArray<PartitionProduceData>(buffer, i, message.PartitionDataField, PartitionProduceDataEncoder.WriteV9);
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
            public static int WriteV10([NotNull] in byte[] buffer, in int index, [NotNull] in TopicProduceData message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactArray<PartitionProduceData>(buffer, i, message.PartitionDataField, PartitionProduceDataEncoder.WriteV10);
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
            private static class PartitionProduceDataEncoder
            {
                public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in PartitionProduceData message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.IndexField);
                    i = BinaryEncoder.WriteRecords(buffer, i, message.RecordsField);
                    return i;
                }
                public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in PartitionProduceData message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.IndexField);
                    i = BinaryEncoder.WriteRecords(buffer, i, message.RecordsField);
                    return i;
                }
                public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in PartitionProduceData message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.IndexField);
                    i = BinaryEncoder.WriteRecords(buffer, i, message.RecordsField);
                    return i;
                }
                public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in PartitionProduceData message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.IndexField);
                    i = BinaryEncoder.WriteRecords(buffer, i, message.RecordsField);
                    return i;
                }
                public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in PartitionProduceData message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.IndexField);
                    i = BinaryEncoder.WriteRecords(buffer, i, message.RecordsField);
                    return i;
                }
                public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in PartitionProduceData message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.IndexField);
                    i = BinaryEncoder.WriteRecords(buffer, i, message.RecordsField);
                    return i;
                }
                public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in PartitionProduceData message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.IndexField);
                    i = BinaryEncoder.WriteRecords(buffer, i, message.RecordsField);
                    return i;
                }
                public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in PartitionProduceData message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.IndexField);
                    i = BinaryEncoder.WriteRecords(buffer, i, message.RecordsField);
                    return i;
                }
                public static int WriteV8([NotNull] in byte[] buffer, in int index, [NotNull] in PartitionProduceData message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.IndexField);
                    i = BinaryEncoder.WriteRecords(buffer, i, message.RecordsField);
                    return i;
                }
                public static int WriteV9([NotNull] in byte[] buffer, in int index, [NotNull] in PartitionProduceData message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.IndexField);
                    i = BinaryEncoder.WriteCompactRecords(buffer, i, message.RecordsField);
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
                public static int WriteV10([NotNull] in byte[] buffer, in int index, [NotNull] in PartitionProduceData message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.IndexField);
                    i = BinaryEncoder.WriteCompactRecords(buffer, i, message.RecordsField);
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
