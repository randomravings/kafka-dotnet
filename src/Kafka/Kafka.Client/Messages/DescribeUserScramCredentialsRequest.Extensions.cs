using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using UserName = Kafka.Client.Messages.DescribeUserScramCredentialsRequest.UserName;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeUserScramCredentialsRequestSerde
    {
        private static readonly DecodeDelegate<DescribeUserScramCredentialsRequest>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<DescribeUserScramCredentialsRequest>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static DescribeUserScramCredentialsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeUserScramCredentialsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeUserScramCredentialsRequest ReadV00(byte[] buffer, ref int index)
        {
            var usersField = Decoder.ReadCompactArray<UserName>(buffer, ref index, UserNameSerde.ReadV00);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                usersField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeUserScramCredentialsRequest message)
        {
            index = Encoder.WriteCompactArray<UserName>(buffer, index, message.UsersField, UserNameSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class UserNameSerde
        {
            public static UserName ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField
                );
            }
            public static int WriteV00(byte[] buffer, int index, UserName message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}