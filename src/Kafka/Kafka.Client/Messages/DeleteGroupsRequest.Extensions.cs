using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteGroupsRequestSerde
    {
        private static readonly Func<Stream, DeleteGroupsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, DeleteGroupsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static DeleteGroupsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DeleteGroupsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DeleteGroupsRequest ReadV00(Stream buffer)
        {
            var groupsNamesField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'GroupsNames'");
            return new(
                groupsNamesField
            );
        }
        private static void WriteV00(Stream buffer, DeleteGroupsRequest message)
        {
            Encoder.WriteArray<string>(buffer, message.GroupsNamesField, (b, i) => Encoder.WriteCompactString(b, i));
        }
        private static DeleteGroupsRequest ReadV01(Stream buffer)
        {
            var groupsNamesField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'GroupsNames'");
            return new(
                groupsNamesField
            );
        }
        private static void WriteV01(Stream buffer, DeleteGroupsRequest message)
        {
            Encoder.WriteArray<string>(buffer, message.GroupsNamesField, (b, i) => Encoder.WriteCompactString(b, i));
        }
        private static DeleteGroupsRequest ReadV02(Stream buffer)
        {
            var groupsNamesField = Decoder.ReadCompactArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'GroupsNames'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                groupsNamesField
            );
        }
        private static void WriteV02(Stream buffer, DeleteGroupsRequest message)
        {
            Encoder.WriteCompactArray<string>(buffer, message.GroupsNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}