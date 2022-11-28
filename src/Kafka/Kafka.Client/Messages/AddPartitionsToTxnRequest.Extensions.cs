using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AddPartitionsToTxnTopic = Kafka.Client.Messages.AddPartitionsToTxnRequest.AddPartitionsToTxnTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AddPartitionsToTxnRequestSerde
    {
        private static readonly DecodeDelegate<AddPartitionsToTxnRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<AddPartitionsToTxnRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static AddPartitionsToTxnRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, AddPartitionsToTxnRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static AddPartitionsToTxnRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadString(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            var topicsField = Decoder.ReadArray<AddPartitionsToTxnTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => AddPartitionsToTxnTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, AddPartitionsToTxnRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteArray<AddPartitionsToTxnTopic>(buffer, message.TopicsField, (b, i) => AddPartitionsToTxnTopicSerde.WriteV00(b, i));
            return buffer;
        }
        private static AddPartitionsToTxnRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadString(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            var topicsField = Decoder.ReadArray<AddPartitionsToTxnTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => AddPartitionsToTxnTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                topicsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, AddPartitionsToTxnRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteArray<AddPartitionsToTxnTopic>(buffer, message.TopicsField, (b, i) => AddPartitionsToTxnTopicSerde.WriteV01(b, i));
            return buffer;
        }
        private static AddPartitionsToTxnRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadString(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            var topicsField = Decoder.ReadArray<AddPartitionsToTxnTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => AddPartitionsToTxnTopicSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                topicsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, AddPartitionsToTxnRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteArray<AddPartitionsToTxnTopic>(buffer, message.TopicsField, (b, i) => AddPartitionsToTxnTopicSerde.WriteV02(b, i));
            return buffer;
        }
        private static AddPartitionsToTxnRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadCompactString(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            var topicsField = Decoder.ReadCompactArray<AddPartitionsToTxnTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => AddPartitionsToTxnTopicSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                topicsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, AddPartitionsToTxnRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteCompactArray<AddPartitionsToTxnTopic>(buffer, message.TopicsField, (b, i) => AddPartitionsToTxnTopicSerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class AddPartitionsToTxnTopicSerde
        {
            public static AddPartitionsToTxnTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, AddPartitionsToTxnTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static AddPartitionsToTxnTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, AddPartitionsToTxnTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static AddPartitionsToTxnTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, AddPartitionsToTxnTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static AddPartitionsToTxnTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, AddPartitionsToTxnTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}