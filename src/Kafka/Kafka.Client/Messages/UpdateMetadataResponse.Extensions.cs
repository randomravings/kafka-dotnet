using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UpdateMetadataResponseSerde
    {
        private static readonly DecodeDelegate<UpdateMetadataResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV07(ref b),
        };
        private static readonly EncodeDelegate<UpdateMetadataResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
        };
        public static UpdateMetadataResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, UpdateMetadataResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static UpdateMetadataResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            return new(
                errorCodeField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, UpdateMetadataResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            return buffer;
        }
        private static UpdateMetadataResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            return new(
                errorCodeField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, UpdateMetadataResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            return buffer;
        }
        private static UpdateMetadataResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            return new(
                errorCodeField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, UpdateMetadataResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            return buffer;
        }
        private static UpdateMetadataResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            return new(
                errorCodeField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, UpdateMetadataResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            return buffer;
        }
        private static UpdateMetadataResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            return new(
                errorCodeField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, UpdateMetadataResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            return buffer;
        }
        private static UpdateMetadataResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            return new(
                errorCodeField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, UpdateMetadataResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            return buffer;
        }
        private static UpdateMetadataResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, UpdateMetadataResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static UpdateMetadataResponse ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField
            );
        }
        private static Memory<byte> WriteV07(Memory<byte> buffer, UpdateMetadataResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}