using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using Kafka.Common.Records;
using TopicProduceData = Kafka.Client.Messages.ProduceRequest.TopicProduceData;
using PartitionProduceData = Kafka.Client.Messages.ProduceRequest.TopicProduceData.PartitionProduceData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ProduceRequestSerde
    {
        private static readonly DecodeDelegate<ProduceRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
            ReadV08,
            ReadV09,
        };
        private static readonly EncodeDelegate<ProduceRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
            WriteV08,
            WriteV09,
        };
        public static ProduceRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ProduceRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ProduceRequest ReadV00(byte[] buffer, ref int index)
        {
            var transactionalIdField = default(string?);
            var acksField = Decoder.ReadInt16(buffer, ref index);
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, ref index, TopicProduceDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ProduceRequest message)
        {
            index = Encoder.WriteInt16(buffer, index, message.AcksField);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV00);
            return index;
        }
        private static ProduceRequest ReadV01(byte[] buffer, ref int index)
        {
            var transactionalIdField = default(string?);
            var acksField = Decoder.ReadInt16(buffer, ref index);
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, ref index, TopicProduceDataSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static int WriteV01(byte[] buffer, int index, ProduceRequest message)
        {
            index = Encoder.WriteInt16(buffer, index, message.AcksField);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV01);
            return index;
        }
        private static ProduceRequest ReadV02(byte[] buffer, ref int index)
        {
            var transactionalIdField = default(string?);
            var acksField = Decoder.ReadInt16(buffer, ref index);
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, ref index, TopicProduceDataSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static int WriteV02(byte[] buffer, int index, ProduceRequest message)
        {
            index = Encoder.WriteInt16(buffer, index, message.AcksField);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV02);
            return index;
        }
        private static ProduceRequest ReadV03(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer, ref index);
            var acksField = Decoder.ReadInt16(buffer, ref index);
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, ref index, TopicProduceDataSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static int WriteV03(byte[] buffer, int index, ProduceRequest message)
        {
            index = Encoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt16(buffer, index, message.AcksField);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV03);
            return index;
        }
        private static ProduceRequest ReadV04(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer, ref index);
            var acksField = Decoder.ReadInt16(buffer, ref index);
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, ref index, TopicProduceDataSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static int WriteV04(byte[] buffer, int index, ProduceRequest message)
        {
            index = Encoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt16(buffer, index, message.AcksField);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV04);
            return index;
        }
        private static ProduceRequest ReadV05(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer, ref index);
            var acksField = Decoder.ReadInt16(buffer, ref index);
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, ref index, TopicProduceDataSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static int WriteV05(byte[] buffer, int index, ProduceRequest message)
        {
            index = Encoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt16(buffer, index, message.AcksField);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV05);
            return index;
        }
        private static ProduceRequest ReadV06(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer, ref index);
            var acksField = Decoder.ReadInt16(buffer, ref index);
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, ref index, TopicProduceDataSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static int WriteV06(byte[] buffer, int index, ProduceRequest message)
        {
            index = Encoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt16(buffer, index, message.AcksField);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV06);
            return index;
        }
        private static ProduceRequest ReadV07(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer, ref index);
            var acksField = Decoder.ReadInt16(buffer, ref index);
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, ref index, TopicProduceDataSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static int WriteV07(byte[] buffer, int index, ProduceRequest message)
        {
            index = Encoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt16(buffer, index, message.AcksField);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV07);
            return index;
        }
        private static ProduceRequest ReadV08(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadNullableString(buffer, ref index);
            var acksField = Decoder.ReadInt16(buffer, ref index);
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var topicDataField = Decoder.ReadArray<TopicProduceData>(buffer, ref index, TopicProduceDataSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static int WriteV08(byte[] buffer, int index, ProduceRequest message)
        {
            index = Encoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt16(buffer, index, message.AcksField);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV08);
            return index;
        }
        private static ProduceRequest ReadV09(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var acksField = Decoder.ReadInt16(buffer, ref index);
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var topicDataField = Decoder.ReadCompactArray<TopicProduceData>(buffer, ref index, TopicProduceDataSerde.ReadV09) ?? throw new NullReferenceException("Null not allowed for 'TopicData'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField
            );
        }
        private static int WriteV09(byte[] buffer, int index, ProduceRequest message)
        {
            index = Encoder.WriteCompactNullableString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteInt16(buffer, index, message.AcksField);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteCompactArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV09);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class TopicProduceDataSerde
        {
            public static TopicProduceData ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, ref index, PartitionProduceDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static int WriteV00(byte[] buffer, int index, TopicProduceData message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV00);
                return index;
            }
            public static TopicProduceData ReadV01(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, ref index, PartitionProduceDataSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static int WriteV01(byte[] buffer, int index, TopicProduceData message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV01);
                return index;
            }
            public static TopicProduceData ReadV02(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, ref index, PartitionProduceDataSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static int WriteV02(byte[] buffer, int index, TopicProduceData message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV02);
                return index;
            }
            public static TopicProduceData ReadV03(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, ref index, PartitionProduceDataSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static int WriteV03(byte[] buffer, int index, TopicProduceData message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV03);
                return index;
            }
            public static TopicProduceData ReadV04(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, ref index, PartitionProduceDataSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static int WriteV04(byte[] buffer, int index, TopicProduceData message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV04);
                return index;
            }
            public static TopicProduceData ReadV05(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, ref index, PartitionProduceDataSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static int WriteV05(byte[] buffer, int index, TopicProduceData message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV05);
                return index;
            }
            public static TopicProduceData ReadV06(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, ref index, PartitionProduceDataSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static int WriteV06(byte[] buffer, int index, TopicProduceData message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV06);
                return index;
            }
            public static TopicProduceData ReadV07(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, ref index, PartitionProduceDataSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static int WriteV07(byte[] buffer, int index, TopicProduceData message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV07);
                return index;
            }
            public static TopicProduceData ReadV08(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var partitionDataField = Decoder.ReadArray<PartitionProduceData>(buffer, ref index, PartitionProduceDataSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static int WriteV08(byte[] buffer, int index, TopicProduceData message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV08);
                return index;
            }
            public static TopicProduceData ReadV09(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionDataField = Decoder.ReadCompactArray<PartitionProduceData>(buffer, ref index, PartitionProduceDataSerde.ReadV09) ?? throw new NullReferenceException("Null not allowed for 'PartitionData'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    partitionDataField
                );
            }
            public static int WriteV09(byte[] buffer, int index, TopicProduceData message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV09);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class PartitionProduceDataSerde
            {
                public static PartitionProduceData ReadV00(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var recordsField = Decoder.ReadRecords(buffer, ref index) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionProduceData ReadV01(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var recordsField = Decoder.ReadRecords(buffer, ref index) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionProduceData ReadV02(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var recordsField = Decoder.ReadRecords(buffer, ref index) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionProduceData ReadV03(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var recordsField = Decoder.ReadRecords(buffer, ref index) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionProduceData ReadV04(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var recordsField = Decoder.ReadRecords(buffer, ref index) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionProduceData ReadV05(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var recordsField = Decoder.ReadRecords(buffer, ref index) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static int WriteV05(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionProduceData ReadV06(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var recordsField = Decoder.ReadRecords(buffer, ref index) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static int WriteV06(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionProduceData ReadV07(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var recordsField = Decoder.ReadRecords(buffer, ref index) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static int WriteV07(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionProduceData ReadV08(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var recordsField = Decoder.ReadRecords(buffer, ref index) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static int WriteV08(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionProduceData ReadV09(byte[] buffer, ref int index)
                {
                    var indexField = Decoder.ReadInt32(buffer, ref index);
                    var recordsField = Decoder.ReadRecords(buffer, ref index) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        indexField,
                        recordsField
                    );
                }
                public static int WriteV09(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.IndexField);
                    index = Encoder.WriteCompactRecords(buffer, index, message.RecordsField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}