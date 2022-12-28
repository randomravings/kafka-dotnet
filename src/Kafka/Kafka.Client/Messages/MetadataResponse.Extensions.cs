using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using MetadataResponsePartition = Kafka.Client.Messages.MetadataResponse.MetadataResponseTopic.MetadataResponsePartition;
using MetadataResponseTopic = Kafka.Client.Messages.MetadataResponse.MetadataResponseTopic;
using MetadataResponseBroker = Kafka.Client.Messages.MetadataResponse.MetadataResponseBroker;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class MetadataResponseSerde
    {
        private static readonly DecodeDelegate<MetadataResponse>[] READ_VERSIONS = {
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
            ReadV10,
            ReadV11,
            ReadV12,
        };
        private static readonly EncodeDelegate<MetadataResponse>[] WRITE_VERSIONS = {
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
            WriteV10,
            WriteV11,
            WriteV12,
        };
        public static MetadataResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, MetadataResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static MetadataResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, ref index, MetadataResponseBrokerSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, ref index, MetadataResponseTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, MetadataResponse message)
        {
            index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV00);
            index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV00);
            return index;
        }
        private static MetadataResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, ref index, MetadataResponseBrokerSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = default(string?);
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, ref index, MetadataResponseTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, MetadataResponse message)
        {
            index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV01);
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV01);
            return index;
        }
        private static MetadataResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, ref index, MetadataResponseBrokerSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(buffer, ref index);
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, ref index, MetadataResponseTopicSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, MetadataResponse message)
        {
            index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV02);
            index = Encoder.WriteNullableString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV02);
            return index;
        }
        private static MetadataResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, ref index, MetadataResponseBrokerSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(buffer, ref index);
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, ref index, MetadataResponseTopicSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, MetadataResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV03);
            index = Encoder.WriteNullableString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV03);
            return index;
        }
        private static MetadataResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, ref index, MetadataResponseBrokerSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(buffer, ref index);
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, ref index, MetadataResponseTopicSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, MetadataResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV04);
            index = Encoder.WriteNullableString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV04);
            return index;
        }
        private static MetadataResponse ReadV05(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, ref index, MetadataResponseBrokerSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(buffer, ref index);
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, ref index, MetadataResponseTopicSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static int WriteV05(byte[] buffer, int index, MetadataResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV05);
            index = Encoder.WriteNullableString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV05);
            return index;
        }
        private static MetadataResponse ReadV06(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, ref index, MetadataResponseBrokerSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(buffer, ref index);
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, ref index, MetadataResponseTopicSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static int WriteV06(byte[] buffer, int index, MetadataResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV06);
            index = Encoder.WriteNullableString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV06);
            return index;
        }
        private static MetadataResponse ReadV07(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, ref index, MetadataResponseBrokerSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(buffer, ref index);
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, ref index, MetadataResponseTopicSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static int WriteV07(byte[] buffer, int index, MetadataResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV07);
            index = Encoder.WriteNullableString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV07);
            return index;
        }
        private static MetadataResponse ReadV08(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var brokersField = Decoder.ReadArray<MetadataResponseBroker>(buffer, ref index, MetadataResponseBrokerSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadNullableString(buffer, ref index);
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<MetadataResponseTopic>(buffer, ref index, MetadataResponseTopicSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static int WriteV08(byte[] buffer, int index, MetadataResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV08);
            index = Encoder.WriteNullableString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV08);
            index = Encoder.WriteInt32(buffer, index, message.ClusterAuthorizedOperationsField);
            return index;
        }
        private static MetadataResponse ReadV09(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var brokersField = Decoder.ReadCompactArray<MetadataResponseBroker>(buffer, ref index, MetadataResponseBrokerSerde.ReadV09) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<MetadataResponseTopic>(buffer, ref index, MetadataResponseTopicSerde.ReadV09) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = Decoder.ReadInt32(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static int WriteV09(byte[] buffer, int index, MetadataResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV09);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV09);
            index = Encoder.WriteInt32(buffer, index, message.ClusterAuthorizedOperationsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static MetadataResponse ReadV10(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var brokersField = Decoder.ReadCompactArray<MetadataResponseBroker>(buffer, ref index, MetadataResponseBrokerSerde.ReadV10) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<MetadataResponseTopic>(buffer, ref index, MetadataResponseTopicSerde.ReadV10) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = Decoder.ReadInt32(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static int WriteV10(byte[] buffer, int index, MetadataResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV10);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV10);
            index = Encoder.WriteInt32(buffer, index, message.ClusterAuthorizedOperationsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static MetadataResponse ReadV11(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var brokersField = Decoder.ReadCompactArray<MetadataResponseBroker>(buffer, ref index, MetadataResponseBrokerSerde.ReadV11) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<MetadataResponseTopic>(buffer, ref index, MetadataResponseTopicSerde.ReadV11) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static int WriteV11(byte[] buffer, int index, MetadataResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV11);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV11);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static MetadataResponse ReadV12(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var brokersField = Decoder.ReadCompactArray<MetadataResponseBroker>(buffer, ref index, MetadataResponseBrokerSerde.ReadV12) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<MetadataResponseTopic>(buffer, ref index, MetadataResponseTopicSerde.ReadV12) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var clusterAuthorizedOperationsField = default(int);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField
            );
        }
        private static int WriteV12(byte[] buffer, int index, MetadataResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV12);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV12);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class MetadataResponseTopicSerde
        {
            public static MetadataResponseTopic ReadV00(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var NameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var IsInternalField = default(bool);
                var PartitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, ref index, MetadataResponsePartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var TopicAuthorizedOperationsField = default(int);
                return new(
                    ErrorCodeField,
                    NameField,
                    TopicIdField,
                    IsInternalField,
                    PartitionsField,
                    TopicAuthorizedOperationsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV00);
                return index;
            }
            public static MetadataResponseTopic ReadV01(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var NameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var IsInternalField = Decoder.ReadBoolean(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, ref index, MetadataResponsePartitionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var TopicAuthorizedOperationsField = default(int);
                return new(
                    ErrorCodeField,
                    NameField,
                    TopicIdField,
                    IsInternalField,
                    PartitionsField,
                    TopicAuthorizedOperationsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV01);
                return index;
            }
            public static MetadataResponseTopic ReadV02(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var NameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var IsInternalField = Decoder.ReadBoolean(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, ref index, MetadataResponsePartitionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var TopicAuthorizedOperationsField = default(int);
                return new(
                    ErrorCodeField,
                    NameField,
                    TopicIdField,
                    IsInternalField,
                    PartitionsField,
                    TopicAuthorizedOperationsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV02);
                return index;
            }
            public static MetadataResponseTopic ReadV03(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var NameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var IsInternalField = Decoder.ReadBoolean(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, ref index, MetadataResponsePartitionSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var TopicAuthorizedOperationsField = default(int);
                return new(
                    ErrorCodeField,
                    NameField,
                    TopicIdField,
                    IsInternalField,
                    PartitionsField,
                    TopicAuthorizedOperationsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV03);
                return index;
            }
            public static MetadataResponseTopic ReadV04(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var NameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var IsInternalField = Decoder.ReadBoolean(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, ref index, MetadataResponsePartitionSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var TopicAuthorizedOperationsField = default(int);
                return new(
                    ErrorCodeField,
                    NameField,
                    TopicIdField,
                    IsInternalField,
                    PartitionsField,
                    TopicAuthorizedOperationsField
                );
            }
            public static int WriteV04(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV04);
                return index;
            }
            public static MetadataResponseTopic ReadV05(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var NameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var IsInternalField = Decoder.ReadBoolean(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, ref index, MetadataResponsePartitionSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var TopicAuthorizedOperationsField = default(int);
                return new(
                    ErrorCodeField,
                    NameField,
                    TopicIdField,
                    IsInternalField,
                    PartitionsField,
                    TopicAuthorizedOperationsField
                );
            }
            public static int WriteV05(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV05);
                return index;
            }
            public static MetadataResponseTopic ReadV06(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var NameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var IsInternalField = Decoder.ReadBoolean(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, ref index, MetadataResponsePartitionSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var TopicAuthorizedOperationsField = default(int);
                return new(
                    ErrorCodeField,
                    NameField,
                    TopicIdField,
                    IsInternalField,
                    PartitionsField,
                    TopicAuthorizedOperationsField
                );
            }
            public static int WriteV06(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV06);
                return index;
            }
            public static MetadataResponseTopic ReadV07(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var NameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var IsInternalField = Decoder.ReadBoolean(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, ref index, MetadataResponsePartitionSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var TopicAuthorizedOperationsField = default(int);
                return new(
                    ErrorCodeField,
                    NameField,
                    TopicIdField,
                    IsInternalField,
                    PartitionsField,
                    TopicAuthorizedOperationsField
                );
            }
            public static int WriteV07(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV07);
                return index;
            }
            public static MetadataResponseTopic ReadV08(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var NameField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var IsInternalField = Decoder.ReadBoolean(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<MetadataResponsePartition>(buffer, ref index, MetadataResponsePartitionSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var TopicAuthorizedOperationsField = Decoder.ReadInt32(buffer, ref index);
                return new(
                    ErrorCodeField,
                    NameField,
                    TopicIdField,
                    IsInternalField,
                    PartitionsField,
                    TopicAuthorizedOperationsField
                );
            }
            public static int WriteV08(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV08);
                index = Encoder.WriteInt32(buffer, index, message.TopicAuthorizedOperationsField);
                return index;
            }
            public static MetadataResponseTopic ReadV09(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var TopicIdField = default(Guid);
                var IsInternalField = Decoder.ReadBoolean(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<MetadataResponsePartition>(buffer, ref index, MetadataResponsePartitionSerde.ReadV09) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var TopicAuthorizedOperationsField = Decoder.ReadInt32(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ErrorCodeField,
                    NameField,
                    TopicIdField,
                    IsInternalField,
                    PartitionsField,
                    TopicAuthorizedOperationsField
                );
            }
            public static int WriteV09(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV09);
                index = Encoder.WriteInt32(buffer, index, message.TopicAuthorizedOperationsField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static MetadataResponseTopic ReadV10(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var TopicIdField = Decoder.ReadUuid(buffer, ref index);
                var IsInternalField = Decoder.ReadBoolean(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<MetadataResponsePartition>(buffer, ref index, MetadataResponsePartitionSerde.ReadV10) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var TopicAuthorizedOperationsField = Decoder.ReadInt32(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ErrorCodeField,
                    NameField,
                    TopicIdField,
                    IsInternalField,
                    PartitionsField,
                    TopicAuthorizedOperationsField
                );
            }
            public static int WriteV10(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV10);
                index = Encoder.WriteInt32(buffer, index, message.TopicAuthorizedOperationsField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static MetadataResponseTopic ReadV11(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var TopicIdField = Decoder.ReadUuid(buffer, ref index);
                var IsInternalField = Decoder.ReadBoolean(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<MetadataResponsePartition>(buffer, ref index, MetadataResponsePartitionSerde.ReadV11) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var TopicAuthorizedOperationsField = Decoder.ReadInt32(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ErrorCodeField,
                    NameField,
                    TopicIdField,
                    IsInternalField,
                    PartitionsField,
                    TopicAuthorizedOperationsField
                );
            }
            public static int WriteV11(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV11);
                index = Encoder.WriteInt32(buffer, index, message.TopicAuthorizedOperationsField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static MetadataResponseTopic ReadV12(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var NameField = Decoder.ReadCompactNullableString(buffer, ref index);
                var TopicIdField = Decoder.ReadUuid(buffer, ref index);
                var IsInternalField = Decoder.ReadBoolean(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<MetadataResponsePartition>(buffer, ref index, MetadataResponsePartitionSerde.ReadV12) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                var TopicAuthorizedOperationsField = Decoder.ReadInt32(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ErrorCodeField,
                    NameField,
                    TopicIdField,
                    IsInternalField,
                    PartitionsField,
                    TopicAuthorizedOperationsField
                );
            }
            public static int WriteV12(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.NameField);
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV12);
                index = Encoder.WriteInt32(buffer, index, message.TopicAuthorizedOperationsField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class MetadataResponsePartitionSerde
            {
                public static MetadataResponsePartition ReadV00(byte[] buffer, ref int index)
                {
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = default(int);
                    var ReplicaNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var IsrNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var OfflineReplicasField = ImmutableArray<int>.Empty;
                    return new(
                        ErrorCodeField,
                        PartitionIndexField,
                        LeaderIdField,
                        LeaderEpochField,
                        ReplicaNodesField,
                        IsrNodesField,
                        OfflineReplicasField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                    return index;
                }
                public static MetadataResponsePartition ReadV01(byte[] buffer, ref int index)
                {
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = default(int);
                    var ReplicaNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var IsrNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var OfflineReplicasField = ImmutableArray<int>.Empty;
                    return new(
                        ErrorCodeField,
                        PartitionIndexField,
                        LeaderIdField,
                        LeaderEpochField,
                        ReplicaNodesField,
                        IsrNodesField,
                        OfflineReplicasField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                    return index;
                }
                public static MetadataResponsePartition ReadV02(byte[] buffer, ref int index)
                {
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = default(int);
                    var ReplicaNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var IsrNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var OfflineReplicasField = ImmutableArray<int>.Empty;
                    return new(
                        ErrorCodeField,
                        PartitionIndexField,
                        LeaderIdField,
                        LeaderEpochField,
                        ReplicaNodesField,
                        IsrNodesField,
                        OfflineReplicasField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                    return index;
                }
                public static MetadataResponsePartition ReadV03(byte[] buffer, ref int index)
                {
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = default(int);
                    var ReplicaNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var IsrNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var OfflineReplicasField = ImmutableArray<int>.Empty;
                    return new(
                        ErrorCodeField,
                        PartitionIndexField,
                        LeaderIdField,
                        LeaderEpochField,
                        ReplicaNodesField,
                        IsrNodesField,
                        OfflineReplicasField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                    return index;
                }
                public static MetadataResponsePartition ReadV04(byte[] buffer, ref int index)
                {
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = default(int);
                    var ReplicaNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var IsrNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var OfflineReplicasField = ImmutableArray<int>.Empty;
                    return new(
                        ErrorCodeField,
                        PartitionIndexField,
                        LeaderIdField,
                        LeaderEpochField,
                        ReplicaNodesField,
                        IsrNodesField,
                        OfflineReplicasField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                    return index;
                }
                public static MetadataResponsePartition ReadV05(byte[] buffer, ref int index)
                {
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = default(int);
                    var ReplicaNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var IsrNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var OfflineReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    return new(
                        ErrorCodeField,
                        PartitionIndexField,
                        LeaderIdField,
                        LeaderEpochField,
                        ReplicaNodesField,
                        IsrNodesField,
                        OfflineReplicasField
                    );
                }
                public static int WriteV05(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                    return index;
                }
                public static MetadataResponsePartition ReadV06(byte[] buffer, ref int index)
                {
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = default(int);
                    var ReplicaNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var IsrNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var OfflineReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    return new(
                        ErrorCodeField,
                        PartitionIndexField,
                        LeaderIdField,
                        LeaderEpochField,
                        ReplicaNodesField,
                        IsrNodesField,
                        OfflineReplicasField
                    );
                }
                public static int WriteV06(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                    return index;
                }
                public static MetadataResponsePartition ReadV07(byte[] buffer, ref int index)
                {
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var ReplicaNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var IsrNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var OfflineReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    return new(
                        ErrorCodeField,
                        PartitionIndexField,
                        LeaderIdField,
                        LeaderEpochField,
                        ReplicaNodesField,
                        IsrNodesField,
                        OfflineReplicasField
                    );
                }
                public static int WriteV07(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                    return index;
                }
                public static MetadataResponsePartition ReadV08(byte[] buffer, ref int index)
                {
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var ReplicaNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var IsrNodesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var OfflineReplicasField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    return new(
                        ErrorCodeField,
                        PartitionIndexField,
                        LeaderIdField,
                        LeaderEpochField,
                        ReplicaNodesField,
                        IsrNodesField,
                        OfflineReplicasField
                    );
                }
                public static int WriteV08(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                    return index;
                }
                public static MetadataResponsePartition ReadV09(byte[] buffer, ref int index)
                {
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var ReplicaNodesField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var IsrNodesField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var OfflineReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        ErrorCodeField,
                        PartitionIndexField,
                        LeaderIdField,
                        LeaderEpochField,
                        ReplicaNodesField,
                        IsrNodesField,
                        OfflineReplicasField
                    );
                }
                public static int WriteV09(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static MetadataResponsePartition ReadV10(byte[] buffer, ref int index)
                {
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var ReplicaNodesField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var IsrNodesField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var OfflineReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        ErrorCodeField,
                        PartitionIndexField,
                        LeaderIdField,
                        LeaderEpochField,
                        ReplicaNodesField,
                        IsrNodesField,
                        OfflineReplicasField
                    );
                }
                public static int WriteV10(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static MetadataResponsePartition ReadV11(byte[] buffer, ref int index)
                {
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var ReplicaNodesField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var IsrNodesField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var OfflineReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        ErrorCodeField,
                        PartitionIndexField,
                        LeaderIdField,
                        LeaderEpochField,
                        ReplicaNodesField,
                        IsrNodesField,
                        OfflineReplicasField
                    );
                }
                public static int WriteV11(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static MetadataResponsePartition ReadV12(byte[] buffer, ref int index)
                {
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var ReplicaNodesField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    var IsrNodesField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    var OfflineReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        ErrorCodeField,
                        PartitionIndexField,
                        LeaderIdField,
                        LeaderEpochField,
                        ReplicaNodesField,
                        IsrNodesField,
                        OfflineReplicasField
                    );
                }
                public static int WriteV12(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
        private static class MetadataResponseBrokerSerde
        {
            public static MetadataResponseBroker ReadV00(byte[] buffer, ref int index)
            {
                var NodeIdField = Decoder.ReadInt32(buffer, ref index);
                var HostField = Decoder.ReadString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                var RackField = default(string?);
                return new(
                    NodeIdField,
                    HostField,
                    PortField,
                    RackField
                );
            }
            public static int WriteV00(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
                index = Encoder.WriteString(buffer, index, message.HostField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                return index;
            }
            public static MetadataResponseBroker ReadV01(byte[] buffer, ref int index)
            {
                var NodeIdField = Decoder.ReadInt32(buffer, ref index);
                var HostField = Decoder.ReadString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                var RackField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    NodeIdField,
                    HostField,
                    PortField,
                    RackField
                );
            }
            public static int WriteV01(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
                index = Encoder.WriteString(buffer, index, message.HostField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteNullableString(buffer, index, message.RackField);
                return index;
            }
            public static MetadataResponseBroker ReadV02(byte[] buffer, ref int index)
            {
                var NodeIdField = Decoder.ReadInt32(buffer, ref index);
                var HostField = Decoder.ReadString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                var RackField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    NodeIdField,
                    HostField,
                    PortField,
                    RackField
                );
            }
            public static int WriteV02(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
                index = Encoder.WriteString(buffer, index, message.HostField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteNullableString(buffer, index, message.RackField);
                return index;
            }
            public static MetadataResponseBroker ReadV03(byte[] buffer, ref int index)
            {
                var NodeIdField = Decoder.ReadInt32(buffer, ref index);
                var HostField = Decoder.ReadString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                var RackField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    NodeIdField,
                    HostField,
                    PortField,
                    RackField
                );
            }
            public static int WriteV03(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
                index = Encoder.WriteString(buffer, index, message.HostField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteNullableString(buffer, index, message.RackField);
                return index;
            }
            public static MetadataResponseBroker ReadV04(byte[] buffer, ref int index)
            {
                var NodeIdField = Decoder.ReadInt32(buffer, ref index);
                var HostField = Decoder.ReadString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                var RackField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    NodeIdField,
                    HostField,
                    PortField,
                    RackField
                );
            }
            public static int WriteV04(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
                index = Encoder.WriteString(buffer, index, message.HostField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteNullableString(buffer, index, message.RackField);
                return index;
            }
            public static MetadataResponseBroker ReadV05(byte[] buffer, ref int index)
            {
                var NodeIdField = Decoder.ReadInt32(buffer, ref index);
                var HostField = Decoder.ReadString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                var RackField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    NodeIdField,
                    HostField,
                    PortField,
                    RackField
                );
            }
            public static int WriteV05(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
                index = Encoder.WriteString(buffer, index, message.HostField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteNullableString(buffer, index, message.RackField);
                return index;
            }
            public static MetadataResponseBroker ReadV06(byte[] buffer, ref int index)
            {
                var NodeIdField = Decoder.ReadInt32(buffer, ref index);
                var HostField = Decoder.ReadString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                var RackField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    NodeIdField,
                    HostField,
                    PortField,
                    RackField
                );
            }
            public static int WriteV06(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
                index = Encoder.WriteString(buffer, index, message.HostField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteNullableString(buffer, index, message.RackField);
                return index;
            }
            public static MetadataResponseBroker ReadV07(byte[] buffer, ref int index)
            {
                var NodeIdField = Decoder.ReadInt32(buffer, ref index);
                var HostField = Decoder.ReadString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                var RackField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    NodeIdField,
                    HostField,
                    PortField,
                    RackField
                );
            }
            public static int WriteV07(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
                index = Encoder.WriteString(buffer, index, message.HostField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteNullableString(buffer, index, message.RackField);
                return index;
            }
            public static MetadataResponseBroker ReadV08(byte[] buffer, ref int index)
            {
                var NodeIdField = Decoder.ReadInt32(buffer, ref index);
                var HostField = Decoder.ReadString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                var RackField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    NodeIdField,
                    HostField,
                    PortField,
                    RackField
                );
            }
            public static int WriteV08(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
                index = Encoder.WriteString(buffer, index, message.HostField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteNullableString(buffer, index, message.RackField);
                return index;
            }
            public static MetadataResponseBroker ReadV09(byte[] buffer, ref int index)
            {
                var NodeIdField = Decoder.ReadInt32(buffer, ref index);
                var HostField = Decoder.ReadCompactString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                var RackField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NodeIdField,
                    HostField,
                    PortField,
                    RackField
                );
            }
            public static int WriteV09(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
                index = Encoder.WriteCompactString(buffer, index, message.HostField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static MetadataResponseBroker ReadV10(byte[] buffer, ref int index)
            {
                var NodeIdField = Decoder.ReadInt32(buffer, ref index);
                var HostField = Decoder.ReadCompactString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                var RackField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NodeIdField,
                    HostField,
                    PortField,
                    RackField
                );
            }
            public static int WriteV10(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
                index = Encoder.WriteCompactString(buffer, index, message.HostField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static MetadataResponseBroker ReadV11(byte[] buffer, ref int index)
            {
                var NodeIdField = Decoder.ReadInt32(buffer, ref index);
                var HostField = Decoder.ReadCompactString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                var RackField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NodeIdField,
                    HostField,
                    PortField,
                    RackField
                );
            }
            public static int WriteV11(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
                index = Encoder.WriteCompactString(buffer, index, message.HostField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static MetadataResponseBroker ReadV12(byte[] buffer, ref int index)
            {
                var NodeIdField = Decoder.ReadInt32(buffer, ref index);
                var HostField = Decoder.ReadCompactString(buffer, ref index);
                var PortField = Decoder.ReadInt32(buffer, ref index);
                var RackField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NodeIdField,
                    HostField,
                    PortField,
                    RackField
                );
            }
            public static int WriteV12(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
                index = Encoder.WriteCompactString(buffer, index, message.HostField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}