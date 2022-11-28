using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ControlledShutdownRequestSerde
    {
        private static readonly DecodeDelegate<ControlledShutdownRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<ControlledShutdownRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static ControlledShutdownRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ControlledShutdownRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ControlledShutdownRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var brokerIdField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = default(long);
            return new(
                brokerIdField,
                brokerEpochField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ControlledShutdownRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
            return buffer;
        }
        private static ControlledShutdownRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var brokerIdField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = default(long);
            return new(
                brokerIdField,
                brokerEpochField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ControlledShutdownRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
            return buffer;
        }
        private static ControlledShutdownRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var brokerIdField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            return new(
                brokerIdField,
                brokerEpochField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, ControlledShutdownRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            return buffer;
        }
        private static ControlledShutdownRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var brokerIdField = Decoder.ReadInt32(ref buffer);
            var brokerEpochField = Decoder.ReadInt64(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                brokerIdField,
                brokerEpochField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, ControlledShutdownRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.BrokerIdField);
            buffer = Encoder.WriteInt64(buffer, message.BrokerEpochField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}