using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AlterReplicaLogDir = Kafka.Client.Messages.AlterReplicaLogDirsRequest.AlterReplicaLogDir;
using AlterReplicaLogDirTopic = Kafka.Client.Messages.AlterReplicaLogDirsRequest.AlterReplicaLogDir.AlterReplicaLogDirTopic;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class AlterReplicaLogDirsRequestSerde
   {
       private static readonly DecodeDelegate<AlterReplicaLogDirsRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<AlterReplicaLogDirsRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, AlterReplicaLogDirsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, AlterReplicaLogDirsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, AlterReplicaLogDirsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var dirsField) = Decoder.ReadArray<AlterReplicaLogDir>(buffer, index, AlterReplicaLogDirSerde.ReadV00);
           if (dirsField == null)
               throw new NullReferenceException("Null not allowed for 'Dirs'");
           return (index, new(
               dirsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, AlterReplicaLogDirsRequest message)
       {
           index = Encoder.WriteArray<AlterReplicaLogDir>(buffer, index, message.DirsField, AlterReplicaLogDirSerde.WriteV00);
           return index;
       }
       private static (int Offset, AlterReplicaLogDirsRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var dirsField) = Decoder.ReadArray<AlterReplicaLogDir>(buffer, index, AlterReplicaLogDirSerde.ReadV01);
           if (dirsField == null)
               throw new NullReferenceException("Null not allowed for 'Dirs'");
           return (index, new(
               dirsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, AlterReplicaLogDirsRequest message)
       {
           index = Encoder.WriteArray<AlterReplicaLogDir>(buffer, index, message.DirsField, AlterReplicaLogDirSerde.WriteV01);
           return index;
       }
       private static (int Offset, AlterReplicaLogDirsRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var dirsField) = Decoder.ReadCompactArray<AlterReplicaLogDir>(buffer, index, AlterReplicaLogDirSerde.ReadV02);
           if (dirsField == null)
               throw new NullReferenceException("Null not allowed for 'Dirs'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               dirsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, AlterReplicaLogDirsRequest message)
       {
           index = Encoder.WriteCompactArray<AlterReplicaLogDir>(buffer, index, message.DirsField, AlterReplicaLogDirSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class AlterReplicaLogDirSerde
       {
           public static (int Offset, AlterReplicaLogDir Value) ReadV00(byte[] buffer, int index)
           {
               (index, var pathField) = Decoder.ReadString(buffer, index);
               (index, var topicsField) = Decoder.ReadArray<AlterReplicaLogDirTopic>(buffer, index, AlterReplicaLogDirTopicSerde.ReadV00);
               if (topicsField == null)
                   throw new NullReferenceException("Null not allowed for 'Topics'");
               return (index, new(
                   pathField,
                   topicsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, AlterReplicaLogDir message)
           {
               index = Encoder.WriteString(buffer, index, message.PathField);
               index = Encoder.WriteArray<AlterReplicaLogDirTopic>(buffer, index, message.TopicsField, AlterReplicaLogDirTopicSerde.WriteV00);
               return index;
           }
           public static (int Offset, AlterReplicaLogDir Value) ReadV01(byte[] buffer, int index)
           {
               (index, var pathField) = Decoder.ReadString(buffer, index);
               (index, var topicsField) = Decoder.ReadArray<AlterReplicaLogDirTopic>(buffer, index, AlterReplicaLogDirTopicSerde.ReadV01);
               if (topicsField == null)
                   throw new NullReferenceException("Null not allowed for 'Topics'");
               return (index, new(
                   pathField,
                   topicsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, AlterReplicaLogDir message)
           {
               index = Encoder.WriteString(buffer, index, message.PathField);
               index = Encoder.WriteArray<AlterReplicaLogDirTopic>(buffer, index, message.TopicsField, AlterReplicaLogDirTopicSerde.WriteV01);
               return index;
           }
           public static (int Offset, AlterReplicaLogDir Value) ReadV02(byte[] buffer, int index)
           {
               (index, var pathField) = Decoder.ReadCompactString(buffer, index);
               (index, var topicsField) = Decoder.ReadCompactArray<AlterReplicaLogDirTopic>(buffer, index, AlterReplicaLogDirTopicSerde.ReadV02);
               if (topicsField == null)
                   throw new NullReferenceException("Null not allowed for 'Topics'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   pathField,
                   topicsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, AlterReplicaLogDir message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.PathField);
               index = Encoder.WriteCompactArray<AlterReplicaLogDirTopic>(buffer, index, message.TopicsField, AlterReplicaLogDirTopicSerde.WriteV02);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class AlterReplicaLogDirTopicSerde
           {
               public static (int Offset, AlterReplicaLogDirTopic Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var partitionsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (partitionsField == null)
                       throw new NullReferenceException("Null not allowed for 'Partitions'");
                   return (index, new(
                       nameField,
                       partitionsField.Value
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, AlterReplicaLogDirTopic message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, AlterReplicaLogDirTopic Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadString(buffer, index);
                   (index, var partitionsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (partitionsField == null)
                       throw new NullReferenceException("Null not allowed for 'Partitions'");
                   return (index, new(
                       nameField,
                       partitionsField.Value
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, AlterReplicaLogDirTopic message)
               {
                   index = Encoder.WriteString(buffer, index, message.NameField);
                   index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, AlterReplicaLogDirTopic Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var partitionsField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (partitionsField == null)
                       throw new NullReferenceException("Null not allowed for 'Partitions'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       partitionsField.Value
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, AlterReplicaLogDirTopic message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.NameField);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}