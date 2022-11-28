using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UnregisterBrokerRequestSerde
    {
        private static readonly DecodeDelegate<UnregisterBrokerRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<UnregisterBrokerRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static UnregisterBrokerRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, UnregisterBrokerRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static UnregisterBrokerRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var brokerIdField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                brokerIdField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, UnregisterBrokerRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}