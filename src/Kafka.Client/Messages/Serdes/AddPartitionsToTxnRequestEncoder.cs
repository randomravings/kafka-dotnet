using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using AddPartitionsToTxnTransaction = Kafka.Client.Messages.AddPartitionsToTxnRequestData.AddPartitionsToTxnTransaction;
using AddPartitionsToTxnTopic = Kafka.Client.Messages.AddPartitionsToTxnRequestData.AddPartitionsToTxnTopic;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class AddPartitionsToTxnRequestEncoder : 
        RequestEncoder<RequestHeaderData, AddPartitionsToTxnRequestData>
    {
        public AddPartitionsToTxnRequestEncoder() :
            base(
                ApiKey.AddPartitionsToTxn,
                new(0, 4),
                new(3, 32767),
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
        protected override EncodeDelegate<AddPartitionsToTxnRequestData> GetMessageEncoder(short apiVersion) =>
            apiVersion switch
            {
                0 => WriteV0,
                1 => WriteV1,
                2 => WriteV2,
                3 => WriteV3,
                4 => WriteV4,
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0(byte[] buffer, int index, AddPartitionsToTxnRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.V3AndBelowTransactionalIdField);
            index = BinaryEncoder.WriteInt64(buffer, index, message.V3AndBelowProducerIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.V3AndBelowProducerEpochField);
            index = BinaryEncoder.WriteArray<AddPartitionsToTxnTopic>(buffer, index, message.V3AndBelowTopicsField, AddPartitionsToTxnTopicEncoder.WriteV0);
            return index;
        }
        private static int WriteV1(byte[] buffer, int index, AddPartitionsToTxnRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.V3AndBelowTransactionalIdField);
            index = BinaryEncoder.WriteInt64(buffer, index, message.V3AndBelowProducerIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.V3AndBelowProducerEpochField);
            index = BinaryEncoder.WriteArray<AddPartitionsToTxnTopic>(buffer, index, message.V3AndBelowTopicsField, AddPartitionsToTxnTopicEncoder.WriteV1);
            return index;
        }
        private static int WriteV2(byte[] buffer, int index, AddPartitionsToTxnRequestData message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.V3AndBelowTransactionalIdField);
            index = BinaryEncoder.WriteInt64(buffer, index, message.V3AndBelowProducerIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.V3AndBelowProducerEpochField);
            index = BinaryEncoder.WriteArray<AddPartitionsToTxnTopic>(buffer, index, message.V3AndBelowTopicsField, AddPartitionsToTxnTopicEncoder.WriteV2);
            return index;
        }
        private static int WriteV3(byte[] buffer, int index, AddPartitionsToTxnRequestData message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.V3AndBelowTransactionalIdField);
            index = BinaryEncoder.WriteInt64(buffer, index, message.V3AndBelowProducerIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.V3AndBelowProducerEpochField);
            index = BinaryEncoder.WriteCompactArray<AddPartitionsToTxnTopic>(buffer, index, message.V3AndBelowTopicsField, AddPartitionsToTxnTopicEncoder.WriteV3);
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
        private static int WriteV4(byte[] buffer, int index, AddPartitionsToTxnRequestData message)
        {
            index = BinaryEncoder.WriteCompactArray<AddPartitionsToTxnTransaction>(buffer, index, message.TransactionsField, AddPartitionsToTxnTransactionEncoder.WriteV4);
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
        private static class AddPartitionsToTxnTopicEncoder
        {
            public static int WriteV0(byte[] buffer, int index, AddPartitionsToTxnTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
                return index;
            }
            public static int WriteV1(byte[] buffer, int index, AddPartitionsToTxnTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
                return index;
            }
            public static int WriteV2(byte[] buffer, int index, AddPartitionsToTxnTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
                return index;
            }
            public static int WriteV3(byte[] buffer, int index, AddPartitionsToTxnTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
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
            public static int WriteV4(byte[] buffer, int index, AddPartitionsToTxnTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
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
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class AddPartitionsToTxnTransactionEncoder
        {
            public static int WriteV0(byte[] buffer, int index, AddPartitionsToTxnTransaction message)
            {
                return index;
            }
            public static int WriteV1(byte[] buffer, int index, AddPartitionsToTxnTransaction message)
            {
                return index;
            }
            public static int WriteV2(byte[] buffer, int index, AddPartitionsToTxnTransaction message)
            {
                return index;
            }
            public static int WriteV3(byte[] buffer, int index, AddPartitionsToTxnTransaction message)
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
            public static int WriteV4(byte[] buffer, int index, AddPartitionsToTxnTransaction message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.TransactionalIdField);
                index = BinaryEncoder.WriteInt64(buffer, index, message.ProducerIdField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ProducerEpochField);
                index = BinaryEncoder.WriteBoolean(buffer, index, message.VerifyOnlyField);
                index = BinaryEncoder.WriteCompactArray<AddPartitionsToTxnTopic>(buffer, index, message.TopicsField, AddPartitionsToTxnTopicEncoder.WriteV4);
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
