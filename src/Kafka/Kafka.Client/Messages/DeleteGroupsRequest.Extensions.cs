using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteGroupsRequestSerde
    {
        private static readonly DecodeDelegate<DeleteGroupsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
        };
        private static readonly EncodeDelegate<DeleteGroupsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static DeleteGroupsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DeleteGroupsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DeleteGroupsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var groupsNamesField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'GroupsNames'");
            return new(
                groupsNamesField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DeleteGroupsRequest message)
        {
            buffer = Encoder.WriteArray<string>(buffer, message.GroupsNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            return buffer;
        }
        private static DeleteGroupsRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var groupsNamesField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'GroupsNames'");
            return new(
                groupsNamesField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DeleteGroupsRequest message)
        {
            buffer = Encoder.WriteArray<string>(buffer, message.GroupsNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            return buffer;
        }
        private static DeleteGroupsRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var groupsNamesField = Decoder.ReadCompactArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'GroupsNames'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                groupsNamesField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, DeleteGroupsRequest message)
        {
            buffer = Encoder.WriteCompactArray<string>(buffer, message.GroupsNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}