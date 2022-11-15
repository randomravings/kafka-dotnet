using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListGroupsRequestSerde
    {
        private static readonly Func<Stream, ListGroupsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
        };
        private static readonly Action<Stream, ListGroupsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static ListGroupsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ListGroupsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ListGroupsRequest ReadV00(Stream buffer)
        {
            var statesFilterField = ImmutableArray<string>.Empty;
            return new(
                statesFilterField
            );
        }
        private static void WriteV00(Stream buffer, ListGroupsRequest message)
        {
        }
        private static ListGroupsRequest ReadV01(Stream buffer)
        {
            var statesFilterField = ImmutableArray<string>.Empty;
            return new(
                statesFilterField
            );
        }
        private static void WriteV01(Stream buffer, ListGroupsRequest message)
        {
        }
        private static ListGroupsRequest ReadV02(Stream buffer)
        {
            var statesFilterField = ImmutableArray<string>.Empty;
            return new(
                statesFilterField
            );
        }
        private static void WriteV02(Stream buffer, ListGroupsRequest message)
        {
        }
        private static ListGroupsRequest ReadV03(Stream buffer)
        {
            var statesFilterField = ImmutableArray<string>.Empty;
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                statesFilterField
            );
        }
        private static void WriteV03(Stream buffer, ListGroupsRequest message)
        {
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static ListGroupsRequest ReadV04(Stream buffer)
        {
            var statesFilterField = Decoder.ReadCompactArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'StatesFilter'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                statesFilterField
            );
        }
        private static void WriteV04(Stream buffer, ListGroupsRequest message)
        {
            Encoder.WriteCompactArray<string>(buffer, message.StatesFilterField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}