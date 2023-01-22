using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ApiVersionsRequestSerde
   {
       private static readonly DecodeDelegate<ApiVersionsRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<ApiVersionsRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, ApiVersionsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ApiVersionsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ApiVersionsRequest Value) ReadV00(byte[] buffer, int index)
       {
           var clientSoftwareNameField = "";
           var clientSoftwareVersionField = "";
           return (index, new(
               clientSoftwareNameField,
               clientSoftwareVersionField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ApiVersionsRequest message)
       {
           return index;
       }
       private static (int Offset, ApiVersionsRequest Value) ReadV01(byte[] buffer, int index)
       {
           var clientSoftwareNameField = "";
           var clientSoftwareVersionField = "";
           return (index, new(
               clientSoftwareNameField,
               clientSoftwareVersionField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, ApiVersionsRequest message)
       {
           return index;
       }
       private static (int Offset, ApiVersionsRequest Value) ReadV02(byte[] buffer, int index)
       {
           var clientSoftwareNameField = "";
           var clientSoftwareVersionField = "";
           return (index, new(
               clientSoftwareNameField,
               clientSoftwareVersionField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, ApiVersionsRequest message)
       {
           return index;
       }
       private static (int Offset, ApiVersionsRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var clientSoftwareNameField) = Decoder.ReadCompactString(buffer, index);
           (index, var clientSoftwareVersionField) = Decoder.ReadCompactString(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               clientSoftwareNameField,
               clientSoftwareVersionField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, ApiVersionsRequest message)
       {
           index = Encoder.WriteCompactString(buffer, index, message.ClientSoftwareNameField);
           index = Encoder.WriteCompactString(buffer, index, message.ClientSoftwareVersionField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}