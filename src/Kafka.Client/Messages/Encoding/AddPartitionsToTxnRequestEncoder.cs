using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using AddPartitionsToTxnTopic = Kafka.Client.Messages.AddPartitionsToTxnRequestData.AddPartitionsToTxnTopic;
using AddPartitionsToTxnTransaction = Kafka.Client.Messages.AddPartitionsToTxnRequestData.AddPartitionsToTxnTransaction;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class AddPartitionsToTxnRequestEncoder : 
        RequestEncoder<RequestHeaderData, AddPartitionsToTxnRequestData>
    {
        internal AddPartitionsToTxnRequestEncoder() :
            base(
                ApiKey.AddPartitionsToTxn,
                new(0, 4),
                new(3, 32767),
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
        protected override EncodeValue<AddPartitionsToTxnRequestData> GetMessageEncoder(short apiVersion) =>
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
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in AddPartitionsToTxnRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.V3AndBelowTransactionalIdField);
            i = BinaryEncoder.WriteInt64(buffer, i, message.V3AndBelowProducerIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.V3AndBelowProducerEpochField);
            i = BinaryEncoder.WriteArray<AddPartitionsToTxnTopic>(buffer, i, message.V3AndBelowTopicsField, AddPartitionsToTxnTopicEncoder.WriteV0);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in AddPartitionsToTxnRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.V3AndBelowTransactionalIdField);
            i = BinaryEncoder.WriteInt64(buffer, i, message.V3AndBelowProducerIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.V3AndBelowProducerEpochField);
            i = BinaryEncoder.WriteArray<AddPartitionsToTxnTopic>(buffer, i, message.V3AndBelowTopicsField, AddPartitionsToTxnTopicEncoder.WriteV1);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in AddPartitionsToTxnRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.V3AndBelowTransactionalIdField);
            i = BinaryEncoder.WriteInt64(buffer, i, message.V3AndBelowProducerIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.V3AndBelowProducerEpochField);
            i = BinaryEncoder.WriteArray<AddPartitionsToTxnTopic>(buffer, i, message.V3AndBelowTopicsField, AddPartitionsToTxnTopicEncoder.WriteV2);
            return i;
        }
        private static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in AddPartitionsToTxnRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactString(buffer, i, message.V3AndBelowTransactionalIdField);
            i = BinaryEncoder.WriteInt64(buffer, i, message.V3AndBelowProducerIdField);
            i = BinaryEncoder.WriteInt16(buffer, i, message.V3AndBelowProducerEpochField);
            i = BinaryEncoder.WriteCompactArray<AddPartitionsToTxnTopic>(buffer, i, message.V3AndBelowTopicsField, AddPartitionsToTxnTopicEncoder.WriteV3);
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
        private static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in AddPartitionsToTxnRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<AddPartitionsToTxnTransaction>(buffer, i, message.TransactionsField, AddPartitionsToTxnTransactionEncoder.WriteV4);
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
        private static class AddPartitionsToTxnTopicEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in AddPartitionsToTxnTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<int>(buffer, i, message.PartitionsField, BinaryEncoder.WriteInt32);
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in AddPartitionsToTxnTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<int>(buffer, i, message.PartitionsField, BinaryEncoder.WriteInt32);
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in AddPartitionsToTxnTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteArray<int>(buffer, i, message.PartitionsField, BinaryEncoder.WriteInt32);
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in AddPartitionsToTxnTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactArray<int>(buffer, i, message.PartitionsField, BinaryEncoder.WriteInt32);
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
            public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in AddPartitionsToTxnTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteCompactArray<int>(buffer, i, message.PartitionsField, BinaryEncoder.WriteInt32);
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
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class AddPartitionsToTxnTransactionEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in AddPartitionsToTxnTransaction message)
            {
                var i = index;
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in AddPartitionsToTxnTransaction message)
            {
                var i = index;
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in AddPartitionsToTxnTransaction message)
            {
                var i = index;
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in AddPartitionsToTxnTransaction message)
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
            public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in AddPartitionsToTxnTransaction message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.TransactionalIdField);
                i = BinaryEncoder.WriteInt64(buffer, i, message.ProducerIdField);
                i = BinaryEncoder.WriteInt16(buffer, i, message.ProducerEpochField);
                i = BinaryEncoder.WriteBoolean(buffer, i, message.VerifyOnlyField);
                i = BinaryEncoder.WriteCompactArray<AddPartitionsToTxnTopic>(buffer, i, message.TopicsField, AddPartitionsToTxnTopicEncoder.WriteV4);
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
