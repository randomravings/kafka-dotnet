using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribeClusterBroker = Kafka.Client.Messages.DescribeClusterResponse.DescribeClusterBroker;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeClusterResponseSerde
    {
        private static readonly DecodeDelegate<DescribeClusterResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<DescribeClusterResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DescribeClusterResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeClusterResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeClusterResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
            var clusterIdField = Decoder.ReadCompactString(ref buffer);
            var controllerIdField = Decoder.ReadInt32(ref buffer);
            var brokersField = Decoder.ReadCompactArray<DescribeClusterBroker>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeClusterBrokerSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Brokers'");
            var clusterAuthorizedOperationsField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeClusterResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteCompactString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteInt32(buffer, message.ControllerIdField);
            buffer = Encoder.WriteCompactArray<DescribeClusterBroker>(buffer, message.BrokersField, (b, i) => DescribeClusterBrokerSerde.WriteV00(b, i));
            buffer = Encoder.WriteInt32(buffer, message.ClusterAuthorizedOperationsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class DescribeClusterBrokerSerde
        {
            public static DescribeClusterBroker ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var brokerIdField = Decoder.ReadInt32(ref buffer);
                var hostField = Decoder.ReadCompactString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                var rackField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    brokerIdField,
                    hostField,
                    portField,
                    rackField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, DescribeClusterBroker message)
            {
                buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
                buffer = Encoder.WriteCompactString(buffer, message.HostField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.RackField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}