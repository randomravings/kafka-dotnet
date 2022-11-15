using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UnregisterBrokerRequestSerde
    {
        private static readonly Func<Stream, UnregisterBrokerRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, UnregisterBrokerRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static UnregisterBrokerRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, UnregisterBrokerRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static UnregisterBrokerRequest ReadV00(Stream buffer)
        {
            var brokerIdField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                brokerIdField
            );
        }
        private static void WriteV00(Stream buffer, UnregisterBrokerRequest message)
        {
            Encoder.WriteInt32(buffer, message.BrokerIdField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}