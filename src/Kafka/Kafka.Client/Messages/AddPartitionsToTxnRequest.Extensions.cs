using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AddPartitionsToTxnTopic = Kafka.Client.Messages.AddPartitionsToTxnRequest.AddPartitionsToTxnTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AddPartitionsToTxnRequestSerde
    {
        private static readonly DecodeDelegate<AddPartitionsToTxnRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<AddPartitionsToTxnRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static AddPartitionsToTxnRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AddPartitionsToTxnRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AddPartitionsToTxnRequest ReadV00(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadString(buffer, ref index);
            var producerIdField = Decoder.ReadInt64(buffer, ref index);
            var producerEpochField = Decoder.ReadInt16(buffer, ref index);
            var topicsField = Decoder.ReadArray<AddPartitionsToTxnTopic>(buffer, ref index, AddPartitionsToTxnTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AddPartitionsToTxnRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = Encoder.WriteArray<AddPartitionsToTxnTopic>(buffer, index, message.TopicsField, AddPartitionsToTxnTopicSerde.WriteV00);
            return index;
        }
        private static AddPartitionsToTxnRequest ReadV01(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadString(buffer, ref index);
            var producerIdField = Decoder.ReadInt64(buffer, ref index);
            var producerEpochField = Decoder.ReadInt16(buffer, ref index);
            var topicsField = Decoder.ReadArray<AddPartitionsToTxnTopic>(buffer, ref index, AddPartitionsToTxnTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                topicsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, AddPartitionsToTxnRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = Encoder.WriteArray<AddPartitionsToTxnTopic>(buffer, index, message.TopicsField, AddPartitionsToTxnTopicSerde.WriteV01);
            return index;
        }
        private static AddPartitionsToTxnRequest ReadV02(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadString(buffer, ref index);
            var producerIdField = Decoder.ReadInt64(buffer, ref index);
            var producerEpochField = Decoder.ReadInt16(buffer, ref index);
            var topicsField = Decoder.ReadArray<AddPartitionsToTxnTopic>(buffer, ref index, AddPartitionsToTxnTopicSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                topicsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, AddPartitionsToTxnRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = Encoder.WriteArray<AddPartitionsToTxnTopic>(buffer, index, message.TopicsField, AddPartitionsToTxnTopicSerde.WriteV02);
            return index;
        }
        private static AddPartitionsToTxnRequest ReadV03(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadCompactString(buffer, ref index);
            var producerIdField = Decoder.ReadInt64(buffer, ref index);
            var producerEpochField = Decoder.ReadInt16(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<AddPartitionsToTxnTopic>(buffer, ref index, AddPartitionsToTxnTopicSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                topicsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, AddPartitionsToTxnRequest message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = Encoder.WriteCompactArray<AddPartitionsToTxnTopic>(buffer, index, message.TopicsField, AddPartitionsToTxnTopicSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class AddPartitionsToTxnTopicSerde
        {
            public static AddPartitionsToTxnTopic ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, AddPartitionsToTxnTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                return index;
            }
            public static AddPartitionsToTxnTopic ReadV01(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, AddPartitionsToTxnTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                return index;
            }
            public static AddPartitionsToTxnTopic ReadV02(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, AddPartitionsToTxnTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                return index;
            }
            public static AddPartitionsToTxnTopic ReadV03(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, AddPartitionsToTxnTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}