using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using UserName = Kafka.Client.Messages.DescribeUserScramCredentialsRequest.UserName;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeUserScramCredentialsRequestSerde
    {
        private static readonly Func<Stream, DescribeUserScramCredentialsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, DescribeUserScramCredentialsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DescribeUserScramCredentialsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeUserScramCredentialsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeUserScramCredentialsRequest ReadV00(Stream buffer)
        {
            var usersField = Decoder.ReadCompactArray<UserName>(buffer, b => UserNameSerde.ReadV00(b));
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                usersField
            );
        }
        private static void WriteV00(Stream buffer, DescribeUserScramCredentialsRequest message)
        {
            Encoder.WriteCompactArray<UserName>(buffer, message.UsersField, (b, i) => UserNameSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class UserNameSerde
        {
            public static UserName ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField
                );
            }
            public static void WriteV00(Stream buffer, UserName message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}