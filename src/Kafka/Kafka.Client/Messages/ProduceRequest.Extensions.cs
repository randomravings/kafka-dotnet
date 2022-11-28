using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using Kafka.Common.Records;
using PartitionProduceData = Kafka.Client.Messages.ProduceRequest.TopicProduceData.PartitionProduceData;
using TopicProduceData = Kafka.Client.Messages.ProduceRequest.TopicProduceData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ProduceRequestSerde
    {
        private static readonly DecodeDelegate<ProduceRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV07(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV08(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV09(ref b),
        };
        private static readonly EncodeDelegate<ProduceRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
            (b, m) => WriteV08(b, m),
            (b, m) => WriteV09(b, m),
        };
        public static ProduceRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ProduceRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ProduceRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = default(string?);
            var acksField = Decoder.ReadInt16(ref buffer);
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ProduceRequest message)
        {
            buffer = Encoder.WriteInt16(buffer, message.AcksField);
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV00(b, i));
            return buffer;
        }
        private static ProduceRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = default(string?);
            var acksField = Decoder.ReadInt16(ref buffer);
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceDataSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ProduceRequest message)
        {
            buffer = Encoder.WriteInt16(buffer, message.AcksField);
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV01(b, i));
            return buffer;
        }
        private static ProduceRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = default(string?);
            var acksField = Decoder.ReadInt16(ref buffer);
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceDataSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, ProduceRequest message)
        {
            buffer = Encoder.WriteInt16(buffer, message.AcksField);
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV02(b, i));
            return buffer;
        }
        private static ProduceRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(ref buffer);
            var acksField = Decoder.ReadInt16(ref buffer);
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceDataSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, ProduceRequest message)
        {
            buffer = Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt16(buffer, message.AcksField);
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV03(b, i));
            return buffer;
        }
        private static ProduceRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(ref buffer);
            var acksField = Decoder.ReadInt16(ref buffer);
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceDataSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, ProduceRequest message)
        {
            buffer = Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt16(buffer, message.AcksField);
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV04(b, i));
            return buffer;
        }
        private static ProduceRequest ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(ref buffer);
            var acksField = Decoder.ReadInt16(ref buffer);
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceDataSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, ProduceRequest message)
        {
            buffer = Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt16(buffer, message.AcksField);
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV05(b, i));
            return buffer;
        }
        private static ProduceRequest ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(ref buffer);
            var acksField = Decoder.ReadInt16(ref buffer);
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceDataSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, ProduceRequest message)
        {
            buffer = Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt16(buffer, message.AcksField);
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV06(b, i));
            return buffer;
        }
        private static ProduceRequest ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(ref buffer);
            var acksField = Decoder.ReadInt16(ref buffer);
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceDataSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static Memory<byte> WriteV07(Memory<byte> buffer, ProduceRequest message)
        {
            buffer = Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt16(buffer, message.AcksField);
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV07(b, i));
            return buffer;
        }
        private static ProduceRequest ReadV08(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(ref buffer);
            var acksField = Decoder.ReadInt16(ref buffer);
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceDataSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static Memory<byte> WriteV08(Memory<byte> buffer, ProduceRequest message)
        {
            buffer = Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt16(buffer, message.AcksField);
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV08(b, i));
            return buffer;
        }
        private static ProduceRequest ReadV09(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadCompactNullableString(ref buffer);
            var acksField = Decoder.ReadInt16(ref buffer);
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var topicDataField = Decoder.ReadCompactArray<TopicProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicProduceDataSerde.ReadV09(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static Memory<byte> WriteV09(Memory<byte> buffer, ProduceRequest message)
        {
            buffer = Encoder.WriteCompactNullableString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteInt16(buffer, message.AcksField);
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteCompactArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV09(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class TopicProduceDataSerde
        {
            public static TopicProduceData ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, TopicProduceData message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV00(b, i));
                return buffer;
            }
            public static TopicProduceData ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceDataSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, TopicProduceData message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV01(b, i));
                return buffer;
            }
            public static TopicProduceData ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceDataSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, TopicProduceData message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV02(b, i));
                return buffer;
            }
            public static TopicProduceData ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceDataSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, TopicProduceData message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV03(b, i));
                return buffer;
            }
            public static TopicProduceData ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceDataSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, TopicProduceData message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV04(b, i));
                return buffer;
            }
            public static TopicProduceData ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceDataSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, TopicProduceData message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV05(b, i));
                return buffer;
            }
            public static TopicProduceData ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceDataSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, TopicProduceData message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV06(b, i));
                return buffer;
            }
            public static TopicProduceData ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceDataSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, TopicProduceData message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV07(b, i));
                return buffer;
            }
            public static TopicProduceData ReadV08(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceDataSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static Memory<byte> WriteV08(Memory<byte> buffer, TopicProduceData message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV08(b, i));
                return buffer;
            }
            public static TopicProduceData ReadV09(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionDataField = Decoder.ReadCompactArray<PartitionProduceData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionProduceDataSerde.ReadV09(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static Memory<byte> WriteV09(Memory<byte> buffer, TopicProduceData message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV09(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class PartitionProduceDataSerde
            {
                public static PartitionProduceData ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, PartitionProduceData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionProduceData ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, PartitionProduceData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionProduceData ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, PartitionProduceData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionProduceData ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, PartitionProduceData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionProduceData ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static Memory<byte> WriteV04(Memory<byte> buffer, PartitionProduceData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionProduceData ReadV05(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static Memory<byte> WriteV05(Memory<byte> buffer, PartitionProduceData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionProduceData ReadV06(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static Memory<byte> WriteV06(Memory<byte> buffer, PartitionProduceData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionProduceData ReadV07(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static Memory<byte> WriteV07(Memory<byte> buffer, PartitionProduceData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionProduceData ReadV08(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static Memory<byte> WriteV08(Memory<byte> buffer, PartitionProduceData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionProduceData ReadV09(ref ReadOnlyMemory<byte> buffer)
                {
                    var indexField = Decoder.ReadInt32(ref buffer);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static Memory<byte> WriteV09(Memory<byte> buffer, PartitionProduceData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.IndexField);
                    buffer = Encoder.WriteCompactRecords(buffer, message.RecordsField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}