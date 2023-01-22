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
       public static (int Offset, DescribeUserScramCredentialsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeUserScramCredentialsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeUserScramCredentialsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var usersField) = Decoder.ReadCompactArray<UserName>(buffer, index, UserNameSerde.ReadV00);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               usersField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeUserScramCredentialsRequest message)
       {
           index = Encoder.WriteCompactArray<UserName>(buffer, index, message.UsersField, UserNameSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class UserNameSerde
       {
           public static (int Offset, UserName Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField
               ));
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