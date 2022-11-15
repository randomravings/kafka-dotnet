using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class HeartbeatResponseSerde
    {
        private static readonly Func<Stream, HeartbeatResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
        };
        private static readonly Action<Stream, HeartbeatResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static HeartbeatResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, HeartbeatResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static HeartbeatResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField
            );
        }
        private static void WriteV00(Stream buffer, HeartbeatResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static HeartbeatResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField
            );
        }
        private static void WriteV01(Stream buffer, HeartbeatResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static HeartbeatResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField
            );
        }
        private static void WriteV02(Stream buffer, HeartbeatResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static HeartbeatResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField
            );
        }
        private static void WriteV03(Stream buffer, HeartbeatResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static HeartbeatResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField
            );
        }
        private static void WriteV04(Stream buffer, HeartbeatResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}