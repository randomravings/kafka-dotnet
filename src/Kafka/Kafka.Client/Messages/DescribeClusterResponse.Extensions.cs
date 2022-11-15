using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribeClusterBroker = Kafka.Client.Messages.DescribeClusterResponse.DescribeClusterBroker;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeClusterResponseSerde
    {
        private static readonly Func<Stream, DescribeClusterResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, DescribeClusterResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DescribeClusterResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeClusterResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeClusterResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer);
            var clusterIdField = Decoder.ReadCompactString(buffer);
            var controllerIdField = Decoder.ReadInt32(buffer);
            var brokersField = Decoder.ReadCompactArray<DescribeClusterBroker>(buffer, b => DescribeClusterBrokerSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterAuthorizedOperationsField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV00(Stream buffer, DescribeClusterResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteCompactString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteCompactArray<DescribeClusterBroker>(buffer, message.BrokersField, (b, i) => DescribeClusterBrokerSerde.WriteV00(b, i));
            Encoder.WriteInt32(buffer, message.ClusterAuthorizedOperationsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DescribeClusterBrokerSerde
        {
            public static DescribeClusterBroker ReadV00(Stream buffer)
            {
                var brokerIdField = Decoder.ReadInt32(buffer);
                var hostField = Decoder.ReadCompactString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                var rackField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    brokerIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static void WriteV00(Stream buffer, DescribeClusterBroker message)
            {
                Encoder.WriteInt32(buffer, message.BrokerIdField);
                Encoder.WriteCompactString(buffer, message.HostField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteCompactNullableString(buffer, message.RackField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}