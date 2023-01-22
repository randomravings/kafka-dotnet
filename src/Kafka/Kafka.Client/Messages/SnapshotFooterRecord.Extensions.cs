using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class SnapshotFooterRecordSerde
   {
       private static readonly DecodeDelegate<SnapshotFooterRecord>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<SnapshotFooterRecord>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, SnapshotFooterRecord Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, SnapshotFooterRecord message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, SnapshotFooterRecord Value) ReadV00(byte[] buffer, int index)
       {
           (index, var versionField) = Decoder.ReadInt16(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               versionField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, SnapshotFooterRecord message)
       {
           index = Encoder.WriteInt16(buffer, index, message.VersionField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}