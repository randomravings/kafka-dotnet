using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ControlledShutdownRequestSerde
    {
        private static readonly Func<Stream, ControlledShutdownRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, ControlledShutdownRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static ControlledShutdownRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ControlledShutdownRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ControlledShutdownRequest ReadV00(Stream buffer)
        {
            var brokerIdField = Decoder.ReadInt32(buffer);
            var brokerEpochField = default(long);
            return new(
                brokerIdField,
                brokerEpochField
            );
        }
        private static void WriteV00(Stream buffer, ControlledShutdownRequest message)
        {
            Encoder.WriteInt32(buffer, message.BrokerIdField);
        }
        private static ControlledShutdownRequest ReadV01(Stream buffer)
        {
            var brokerIdField = Decoder.ReadInt32(buffer);
            var brokerEpochField = default(long);
            return new(
                brokerIdField,
                brokerEpochField
            );
        }
        private static void WriteV01(Stream buffer, ControlledShutdownRequest message)
        {
            Encoder.WriteInt32(buffer, message.BrokerIdField);
        }
        private static ControlledShutdownRequest ReadV02(Stream buffer)
        {
            var brokerIdField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            return new(
                brokerIdField,
                brokerEpochField
            );
        }
        private static void WriteV02(Stream buffer, ControlledShutdownRequest message)
        {
            Encoder.WriteInt32(buffer, message.BrokerIdField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
        }
        private static ControlledShutdownRequest ReadV03(Stream buffer)
        {
            var brokerIdField = Decoder.ReadInt32(buffer);
            var brokerEpochField = Decoder.ReadInt64(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                brokerIdField,
                brokerEpochField
            );
        }
        private static void WriteV03(Stream buffer, ControlledShutdownRequest message)
        {
            Encoder.WriteInt32(buffer, message.BrokerIdField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}