using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeGroupsRequestSerde
    {
        private static readonly Func<Stream, DescribeGroupsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
        };
        private static readonly Action<Stream, DescribeGroupsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
        };
        public static DescribeGroupsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeGroupsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeGroupsRequest ReadV00(Stream buffer)
        {
            var groupsField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            var includeAuthorizedOperationsField = default(bool);
            return new(
                groupsField,
                includeAuthorizedOperationsField
            );
        }
        private static void WriteV00(Stream buffer, DescribeGroupsRequest message)
        {
            Encoder.WriteArray<string>(buffer, message.GroupsField, (b, i) => Encoder.WriteCompactString(b, i));
        }
        private static DescribeGroupsRequest ReadV01(Stream buffer)
        {
            var groupsField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            var includeAuthorizedOperationsField = default(bool);
            return new(
                groupsField,
                includeAuthorizedOperationsField
            );
        }
        private static void WriteV01(Stream buffer, DescribeGroupsRequest message)
        {
            Encoder.WriteArray<string>(buffer, message.GroupsField, (b, i) => Encoder.WriteCompactString(b, i));
        }
        private static DescribeGroupsRequest ReadV02(Stream buffer)
        {
            var groupsField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            var includeAuthorizedOperationsField = default(bool);
            return new(
                groupsField,
                includeAuthorizedOperationsField
            );
        }
        private static void WriteV02(Stream buffer, DescribeGroupsRequest message)
        {
            Encoder.WriteArray<string>(buffer, message.GroupsField, (b, i) => Encoder.WriteCompactString(b, i));
        }
        private static DescribeGroupsRequest ReadV03(Stream buffer)
        {
            var groupsField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            var includeAuthorizedOperationsField = Decoder.ReadBoolean(buffer);
            return new(
                groupsField,
                includeAuthorizedOperationsField
            );
        }
        private static void WriteV03(Stream buffer, DescribeGroupsRequest message)
        {
            Encoder.WriteArray<string>(buffer, message.GroupsField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteBoolean(buffer, message.IncludeAuthorizedOperationsField);
        }
        private static DescribeGroupsRequest ReadV04(Stream buffer)
        {
            var groupsField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            var includeAuthorizedOperationsField = Decoder.ReadBoolean(buffer);
            return new(
                groupsField,
                includeAuthorizedOperationsField
            );
        }
        private static void WriteV04(Stream buffer, DescribeGroupsRequest message)
        {
            Encoder.WriteArray<string>(buffer, message.GroupsField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteBoolean(buffer, message.IncludeAuthorizedOperationsField);
        }
        private static DescribeGroupsRequest ReadV05(Stream buffer)
        {
            var groupsField = Decoder.ReadCompactArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            var includeAuthorizedOperationsField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                groupsField,
                includeAuthorizedOperationsField
            );
        }
        private static void WriteV05(Stream buffer, DescribeGroupsRequest message)
        {
            Encoder.WriteCompactArray<string>(buffer, message.GroupsField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteBoolean(buffer, message.IncludeAuthorizedOperationsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}