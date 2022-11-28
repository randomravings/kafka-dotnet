using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListGroupsRequestSerde
    {
        private static readonly DecodeDelegate<ListGroupsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
        };
        private static readonly EncodeDelegate<ListGroupsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static ListGroupsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ListGroupsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ListGroupsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var statesFilterField = ImmutableArray<string>.Empty;
            return new(
                statesFilterField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ListGroupsRequest message)
        {
            return buffer;
        }
        private static ListGroupsRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var statesFilterField = ImmutableArray<string>.Empty;
            return new(
                statesFilterField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ListGroupsRequest message)
        {
            return buffer;
        }
        private static ListGroupsRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var statesFilterField = ImmutableArray<string>.Empty;
            return new(
                statesFilterField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, ListGroupsRequest message)
        {
            return buffer;
        }
        private static ListGroupsRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var statesFilterField = ImmutableArray<string>.Empty;
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                statesFilterField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, ListGroupsRequest message)
        {
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static ListGroupsRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var statesFilterField = Decoder.ReadCompactArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'StatesFilter'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                statesFilterField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, ListGroupsRequest message)
        {
            buffer = Encoder.WriteCompactArray<string>(buffer, message.StatesFilterField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}