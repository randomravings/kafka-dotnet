using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using Kafka.Common.Records;
using TopicProduceData = Kafka.Client.Messages.ProduceRequest.TopicProduceData;
using PartitionProduceData = Kafka.Client.Messages.ProduceRequest.TopicProduceData.PartitionProduceData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ProduceRequestSerde
    {
        private static readonly Func<Stream, ProduceRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
            b => ReadV07(b),
            b => ReadV08(b),
            b => ReadV09(b),
        };
        private static readonly Action<Stream, ProduceRequest>[] WRITE_VERSIONS = {
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
        public static ProduceRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ProduceRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ProduceRequest ReadV00(Stream buffer)
        {
            var transactionalIdField = default(string?);
            var acksField = Decoder.ReadInt16(buffer);
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, b => TopicProduceDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static void WriteV00(Stream buffer, ProduceRequest message)
        {
            Encoder.WriteInt16(buffer, message.AcksField);
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV00(b, i));
        }
        private static ProduceRequest ReadV01(Stream buffer)
        {
            var transactionalIdField = default(string?);
            var acksField = Decoder.ReadInt16(buffer);
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, b => TopicProduceDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static void WriteV01(Stream buffer, ProduceRequest message)
        {
            Encoder.WriteInt16(buffer, message.AcksField);
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV01(b, i));
        }
        private static ProduceRequest ReadV02(Stream buffer)
        {
            var transactionalIdField = default(string?);
            var acksField = Decoder.ReadInt16(buffer);
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, b => TopicProduceDataSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static void WriteV02(Stream buffer, ProduceRequest message)
        {
            Encoder.WriteInt16(buffer, message.AcksField);
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV02(b, i));
        }
        private static ProduceRequest ReadV03(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer);
            var acksField = Decoder.ReadInt16(buffer);
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, b => TopicProduceDataSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static void WriteV03(Stream buffer, ProduceRequest message)
        {
            Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            Encoder.WriteInt16(buffer, message.AcksField);
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV03(b, i));
        }
        private static ProduceRequest ReadV04(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer);
            var acksField = Decoder.ReadInt16(buffer);
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, b => TopicProduceDataSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static void WriteV04(Stream buffer, ProduceRequest message)
        {
            Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            Encoder.WriteInt16(buffer, message.AcksField);
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV04(b, i));
        }
        private static ProduceRequest ReadV05(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer);
            var acksField = Decoder.ReadInt16(buffer);
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, b => TopicProduceDataSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static void WriteV05(Stream buffer, ProduceRequest message)
        {
            Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            Encoder.WriteInt16(buffer, message.AcksField);
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV05(b, i));
        }
        private static ProduceRequest ReadV06(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer);
            var acksField = Decoder.ReadInt16(buffer);
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, b => TopicProduceDataSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static void WriteV06(Stream buffer, ProduceRequest message)
        {
            Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            Encoder.WriteInt16(buffer, message.AcksField);
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV06(b, i));
        }
        private static ProduceRequest ReadV07(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer);
            var acksField = Decoder.ReadInt16(buffer);
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, b => TopicProduceDataSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static void WriteV07(Stream buffer, ProduceRequest message)
        {
            Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            Encoder.WriteInt16(buffer, message.AcksField);
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV07(b, i));
        }
        private static ProduceRequest ReadV08(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer);
            var acksField = Decoder.ReadInt16(buffer);
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, b => TopicProduceDataSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static void WriteV08(Stream buffer, ProduceRequest message)
        {
            Encoder.WriteNullableString(buffer, message.TransactionalIdField);
            Encoder.WriteInt16(buffer, message.AcksField);
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV08(b, i));
        }
        private static ProduceRequest ReadV09(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadCompactNullableString(buffer);
            var acksField = Decoder.ReadInt16(buffer);
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var topicDataField = Decoder.ReadCompactArray<TopicProduceData>(buffer, b => TopicProduceDataSerde.ReadV09(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static void WriteV09(Stream buffer, ProduceRequest message)
        {
            Encoder.WriteCompactNullableString(buffer, message.TransactionalIdField);
            Encoder.WriteInt16(buffer, message.AcksField);
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteCompactArray<TopicProduceData>(buffer, message.TopicDataField, (b, i) => TopicProduceDataSerde.WriteV09(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class TopicProduceDataSerde
        {
            public static TopicProduceData ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, b => PartitionProduceDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static void WriteV00(Stream buffer, TopicProduceData message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV00(b, i));
            }
            public static TopicProduceData ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, b => PartitionProduceDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static void WriteV01(Stream buffer, TopicProduceData message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV01(b, i));
            }
            public static TopicProduceData ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, b => PartitionProduceDataSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static void WriteV02(Stream buffer, TopicProduceData message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV02(b, i));
            }
            public static TopicProduceData ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, b => PartitionProduceDataSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static void WriteV03(Stream buffer, TopicProduceData message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV03(b, i));
            }
            public static TopicProduceData ReadV04(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, b => PartitionProduceDataSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static void WriteV04(Stream buffer, TopicProduceData message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV04(b, i));
            }
            public static TopicProduceData ReadV05(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, b => PartitionProduceDataSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static void WriteV05(Stream buffer, TopicProduceData message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV05(b, i));
            }
            public static TopicProduceData ReadV06(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, b => PartitionProduceDataSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static void WriteV06(Stream buffer, TopicProduceData message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV06(b, i));
            }
            public static TopicProduceData ReadV07(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, b => PartitionProduceDataSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static void WriteV07(Stream buffer, TopicProduceData message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV07(b, i));
            }
            public static TopicProduceData ReadV08(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, b => PartitionProduceDataSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static void WriteV08(Stream buffer, TopicProduceData message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV08(b, i));
            }
            public static TopicProduceData ReadV09(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionDataField = Decoder.ReadCompactArray<PartitionProduceData>(buffer, b => PartitionProduceDataSerde.ReadV09(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static void WriteV09(Stream buffer, TopicProduceData message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<PartitionProduceData>(buffer, message.PartitionDataField, (b, i) => PartitionProduceDataSerde.WriteV09(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class PartitionProduceDataSerde
            {
                public static PartitionProduceData ReadV00(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static void WriteV00(Stream buffer, PartitionProduceData message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionProduceData ReadV01(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static void WriteV01(Stream buffer, PartitionProduceData message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionProduceData ReadV02(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static void WriteV02(Stream buffer, PartitionProduceData message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionProduceData ReadV03(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static void WriteV03(Stream buffer, PartitionProduceData message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionProduceData ReadV04(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static void WriteV04(Stream buffer, PartitionProduceData message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionProduceData ReadV05(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static void WriteV05(Stream buffer, PartitionProduceData message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionProduceData ReadV06(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static void WriteV06(Stream buffer, PartitionProduceData message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionProduceData ReadV07(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static void WriteV07(Stream buffer, PartitionProduceData message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionProduceData ReadV08(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static void WriteV08(Stream buffer, PartitionProduceData message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionProduceData ReadV09(Stream buffer)
                {
                    var indexField = Decoder.ReadInt32(buffer);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static void WriteV09(Stream buffer, PartitionProduceData message)
                {
                    Encoder.WriteInt32(buffer, message.IndexField);
                    Encoder.WriteCompactRecords(buffer, message.RecordsField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}