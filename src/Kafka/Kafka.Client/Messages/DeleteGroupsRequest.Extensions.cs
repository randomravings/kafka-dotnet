using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteGroupsRequestSerde
    {
        private static readonly DecodeDelegate<DeleteGroupsRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<DeleteGroupsRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static DeleteGroupsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DeleteGroupsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DeleteGroupsRequest ReadV00(byte[] buffer, ref int index)
        {
            var groupsNamesField = Decoder.ReadArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'GroupsNames'");
            return new(
                groupsNamesField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DeleteGroupsRequest message)
        {
            index = Encoder.WriteArray<string>(buffer, index, message.GroupsNamesField, Encoder.WriteCompactString);
            return index;
        }
        private static DeleteGroupsRequest ReadV01(byte[] buffer, ref int index)
        {
            var groupsNamesField = Decoder.ReadArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'GroupsNames'");
            return new(
                groupsNamesField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DeleteGroupsRequest message)
        {
            index = Encoder.WriteArray<string>(buffer, index, message.GroupsNamesField, Encoder.WriteCompactString);
            return index;
        }
        private static DeleteGroupsRequest ReadV02(byte[] buffer, ref int index)
        {
            var groupsNamesField = Decoder.ReadCompactArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'GroupsNames'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                groupsNamesField
            );
        }
        private static int WriteV02(byte[] buffer, int index, DeleteGroupsRequest message)
        {
            index = Encoder.WriteCompactArray<string>(buffer, index, message.GroupsNamesField, Encoder.WriteCompactString);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}