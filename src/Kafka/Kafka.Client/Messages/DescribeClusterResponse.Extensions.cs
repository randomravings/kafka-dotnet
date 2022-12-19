using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DescribeClusterBroker = Kafka.Client.Messages.DescribeClusterResponse.DescribeClusterBroker;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeClusterResponseSerde
    {
        private static readonly DecodeDelegate<DescribeClusterResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<DescribeClusterResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static DescribeClusterResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeClusterResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeClusterResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
            var clusterIdField = Decoder.ReadCompactString(buffer, ref index);
            var controllerIdField = Decoder.ReadInt32(buffer, ref index);
            var brokersField = Decoder.ReadCompactArray<DescribeClusterBroker>(buffer, ref index, DescribeClusterBrokerSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterAuthorizedOperationsField = Decoder.ReadInt32(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                clusterIdField,
                controllerIdField,
                brokersField,
                clusterAuthorizedOperationsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeClusterResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteCompactString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = Encoder.WriteCompactArray<DescribeClusterBroker>(buffer, index, message.BrokersField, DescribeClusterBrokerSerde.WriteV00);
            index = Encoder.WriteInt32(buffer, index, message.ClusterAuthorizedOperationsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class DescribeClusterBrokerSerde
        {
            public static DescribeClusterBroker ReadV00(byte[] buffer, ref int index)
            {
                var brokerIdField = Decoder.ReadInt32(buffer, ref index);
                var hostField = Decoder.ReadCompactString(buffer, ref index);
                var portField = Decoder.ReadInt32(buffer, ref index);
                var rackField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    brokerIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static int WriteV00(byte[] buffer, int index, DescribeClusterBroker message)
            {
                index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
                index = Encoder.WriteCompactString(buffer, index, message.HostField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}