using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AddPartitionsToTxnTopic = Kafka.Client.Messages.AddPartitionsToTxnRequest.AddPartitionsToTxnTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AddPartitionsToTxnRequestSerde
    {
        private static readonly Func<Stream, AddPartitionsToTxnRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, AddPartitionsToTxnRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static AddPartitionsToTxnRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AddPartitionsToTxnRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AddPartitionsToTxnRequest ReadV00(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var topicsField = Decoder.ReadArray<AddPartitionsToTxnTopic>(buffer, b => AddPartitionsToTxnTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, AddPartitionsToTxnRequest message)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteArray<AddPartitionsToTxnTopic>(buffer, message.TopicsField, (b, i) => AddPartitionsToTxnTopicSerde.WriteV00(b, i));
        }
        private static AddPartitionsToTxnRequest ReadV01(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var topicsField = Decoder.ReadArray<AddPartitionsToTxnTopic>(buffer, b => AddPartitionsToTxnTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, AddPartitionsToTxnRequest message)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteArray<AddPartitionsToTxnTopic>(buffer, message.TopicsField, (b, i) => AddPartitionsToTxnTopicSerde.WriteV01(b, i));
        }
        private static AddPartitionsToTxnRequest ReadV02(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var topicsField = Decoder.ReadArray<AddPartitionsToTxnTopic>(buffer, b => AddPartitionsToTxnTopicSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                topicsField
            );
        }
        private static void WriteV02(Stream buffer, AddPartitionsToTxnRequest message)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteArray<AddPartitionsToTxnTopic>(buffer, message.TopicsField, (b, i) => AddPartitionsToTxnTopicSerde.WriteV02(b, i));
        }
        private static AddPartitionsToTxnRequest ReadV03(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadCompactString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var topicsField = Decoder.ReadCompactArray<AddPartitionsToTxnTopic>(buffer, b => AddPartitionsToTxnTopicSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                topicsField
            );
        }
        private static void WriteV03(Stream buffer, AddPartitionsToTxnRequest message)
        {
            Encoder.WriteCompactString(buffer, message.TransactionalIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteCompactArray<AddPartitionsToTxnTopic>(buffer, message.TopicsField, (b, i) => AddPartitionsToTxnTopicSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class AddPartitionsToTxnTopicSerde
        {
            public static AddPartitionsToTxnTopic ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, AddPartitionsToTxnTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static AddPartitionsToTxnTopic ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, AddPartitionsToTxnTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static AddPartitionsToTxnTopic ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, AddPartitionsToTxnTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static AddPartitionsToTxnTopic ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV03(Stream buffer, AddPartitionsToTxnTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}