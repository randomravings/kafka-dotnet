using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListGroupsRequestSerde
    {
        private static readonly DecodeDelegate<ListGroupsRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
        };
        private static readonly EncodeDelegate<ListGroupsRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
        };
        public static ListGroupsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ListGroupsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ListGroupsRequest ReadV00(byte[] buffer, ref int index)
        {
            var statesFilterField = ImmutableArray<string>.Empty;
            return new(
                statesFilterField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ListGroupsRequest message)
        {
            return index;
        }
        private static ListGroupsRequest ReadV01(byte[] buffer, ref int index)
        {
            var statesFilterField = ImmutableArray<string>.Empty;
            return new(
                statesFilterField
            );
        }
        private static int WriteV01(byte[] buffer, int index, ListGroupsRequest message)
        {
            return index;
        }
        private static ListGroupsRequest ReadV02(byte[] buffer, ref int index)
        {
            var statesFilterField = ImmutableArray<string>.Empty;
            return new(
                statesFilterField
            );
        }
        private static int WriteV02(byte[] buffer, int index, ListGroupsRequest message)
        {
            return index;
        }
        private static ListGroupsRequest ReadV03(byte[] buffer, ref int index)
        {
            var statesFilterField = ImmutableArray<string>.Empty;
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                statesFilterField
            );
        }
        private static int WriteV03(byte[] buffer, int index, ListGroupsRequest message)
        {
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static ListGroupsRequest ReadV04(byte[] buffer, ref int index)
        {
            var statesFilterField = Decoder.ReadCompactArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'StatesFilter'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                statesFilterField
            );
        }
        private static int WriteV04(byte[] buffer, int index, ListGroupsRequest message)
        {
            index = Encoder.WriteCompactArray<string>(buffer, index, message.StatesFilterField, Encoder.WriteCompactString);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}