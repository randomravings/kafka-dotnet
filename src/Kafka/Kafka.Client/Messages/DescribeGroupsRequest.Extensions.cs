using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeGroupsRequestSerde
    {
        private static readonly DecodeDelegate<DescribeGroupsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
        };
        private static readonly EncodeDelegate<DescribeGroupsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
        };
        public static DescribeGroupsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeGroupsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeGroupsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var groupsField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            var includeAuthorizedOperationsField = default(bool);
            return new(
                groupsField,
                includeAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeGroupsRequest message)
        {
            buffer = Encoder.WriteArray<string>(buffer, message.GroupsField, (b, i) => Encoder.WriteCompactString(b, i));
            return buffer;
        }
        private static DescribeGroupsRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var groupsField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            var includeAuthorizedOperationsField = default(bool);
            return new(
                groupsField,
                includeAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DescribeGroupsRequest message)
        {
            buffer = Encoder.WriteArray<string>(buffer, message.GroupsField, (b, i) => Encoder.WriteCompactString(b, i));
            return buffer;
        }
        private static DescribeGroupsRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var groupsField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            var includeAuthorizedOperationsField = default(bool);
            return new(
                groupsField,
                includeAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, DescribeGroupsRequest message)
        {
            buffer = Encoder.WriteArray<string>(buffer, message.GroupsField, (b, i) => Encoder.WriteCompactString(b, i));
            return buffer;
        }
        private static DescribeGroupsRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var groupsField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            var includeAuthorizedOperationsField = Decoder.ReadBoolean(ref buffer);
            return new(
                groupsField,
                includeAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, DescribeGroupsRequest message)
        {
            buffer = Encoder.WriteArray<string>(buffer, message.GroupsField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.IncludeAuthorizedOperationsField);
            return buffer;
        }
        private static DescribeGroupsRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var groupsField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            var includeAuthorizedOperationsField = Decoder.ReadBoolean(ref buffer);
            return new(
                groupsField,
                includeAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, DescribeGroupsRequest message)
        {
            buffer = Encoder.WriteArray<string>(buffer, message.GroupsField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.IncludeAuthorizedOperationsField);
            return buffer;
        }
        private static DescribeGroupsRequest ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var groupsField = Decoder.ReadCompactArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            var includeAuthorizedOperationsField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                groupsField,
                includeAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, DescribeGroupsRequest message)
        {
            buffer = Encoder.WriteCompactArray<string>(buffer, message.GroupsField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.IncludeAuthorizedOperationsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}