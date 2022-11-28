using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using UserName = Kafka.Client.Messages.DescribeUserScramCredentialsRequest.UserName;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeUserScramCredentialsRequestSerde
    {
        private static readonly DecodeDelegate<DescribeUserScramCredentialsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<DescribeUserScramCredentialsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DescribeUserScramCredentialsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeUserScramCredentialsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeUserScramCredentialsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var usersField = Decoder.ReadCompactArray<UserName>(ref buffer, (ref ReadOnlyMemory<byte> b) => UserNameSerde.ReadV00(ref b));
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                usersField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeUserScramCredentialsRequest message)
        {
            buffer = Encoder.WriteCompactArray<UserName>(buffer, message.UsersField, (b, i) => UserNameSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class UserNameSerde
        {
            public static UserName ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, UserName message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}