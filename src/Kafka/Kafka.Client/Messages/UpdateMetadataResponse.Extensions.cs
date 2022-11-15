using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UpdateMetadataResponseSerde
    {
        private static readonly Func<Stream, UpdateMetadataResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
            b => ReadV07(b),
        };
        private static readonly Action<Stream, UpdateMetadataResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
        };
        public static UpdateMetadataResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, UpdateMetadataResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static UpdateMetadataResponse ReadV00(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            return new(
                errorCodeField
            );
        }
        private static void WriteV00(Stream buffer, UpdateMetadataResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static UpdateMetadataResponse ReadV01(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            return new(
                errorCodeField
            );
        }
        private static void WriteV01(Stream buffer, UpdateMetadataResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static UpdateMetadataResponse ReadV02(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            return new(
                errorCodeField
            );
        }
        private static void WriteV02(Stream buffer, UpdateMetadataResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static UpdateMetadataResponse ReadV03(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            return new(
                errorCodeField
            );
        }
        private static void WriteV03(Stream buffer, UpdateMetadataResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static UpdateMetadataResponse ReadV04(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            return new(
                errorCodeField
            );
        }
        private static void WriteV04(Stream buffer, UpdateMetadataResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static UpdateMetadataResponse ReadV05(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            return new(
                errorCodeField
            );
        }
        private static void WriteV05(Stream buffer, UpdateMetadataResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static UpdateMetadataResponse ReadV06(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                errorCodeField
            );
        }
        private static void WriteV06(Stream buffer, UpdateMetadataResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static UpdateMetadataResponse ReadV07(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                errorCodeField
            );
        }
        private static void WriteV07(Stream buffer, UpdateMetadataResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}