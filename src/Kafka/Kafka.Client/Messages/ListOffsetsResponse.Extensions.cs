using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ListOffsetsPartitionResponse = Kafka.Client.Messages.ListOffsetsResponse.ListOffsetsTopicResponse.ListOffsetsPartitionResponse;
using ListOffsetsTopicResponse = Kafka.Client.Messages.ListOffsetsResponse.ListOffsetsTopicResponse;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ListOffsetsResponseSerde
   {
       private static readonly DecodeDelegate<ListOffsetsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
           ReadV06,
           ReadV07,
       };
       private static readonly EncodeDelegate<ListOffsetsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
           WriteV06,
           WriteV07,
};
       public static (int Offset, ListOffsetsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ListOffsetsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ListOffsetsResponse Value) ReadV00(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var topicsField) = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ListOffsetsResponse message)
       {
           index = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV00);
           return index;
       }
       private static (int Offset, ListOffsetsResponse Value) ReadV01(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var topicsField) = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, ListOffsetsResponse message)
       {
           index = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV01);
           return index;
       }
       private static (int Offset, ListOffsetsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, ListOffsetsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV02);
           return index;
       }
       private static (int Offset, ListOffsetsResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV03);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, ListOffsetsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV03);
           return index;
       }
       private static (int Offset, ListOffsetsResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV04);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, ListOffsetsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV04);
           return index;
       }
       private static (int Offset, ListOffsetsResponse Value) ReadV05(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV05);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, ListOffsetsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV05);
           return index;
       }
       private static (int Offset, ListOffsetsResponse Value) ReadV06(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV06);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV06(byte[] buffer, int index, ListOffsetsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV06);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, ListOffsetsResponse Value) ReadV07(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV07);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV07(byte[] buffer, int index, ListOffsetsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV07);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class ListOffsetsTopicResponseSerde
       {
           public static (int Offset, ListOffsetsTopicResponse Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, ListOffsetsTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV00);
               return index;
           }
           public static (int Offset, ListOffsetsTopicResponse Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, ListOffsetsTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV01);
               return index;
           }
           public static (int Offset, ListOffsetsTopicResponse Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, ListOffsetsTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV02);
               return index;
           }
           public static (int Offset, ListOffsetsTopicResponse Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV03);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, ListOffsetsTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV03);
               return index;
           }
           public static (int Offset, ListOffsetsTopicResponse Value) ReadV04(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV04);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, ListOffsetsTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV04);
               return index;
           }
           public static (int Offset, ListOffsetsTopicResponse Value) ReadV05(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV05);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV05(byte[] buffer, int index, ListOffsetsTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV05);
               return index;
           }
           public static (int Offset, ListOffsetsTopicResponse Value) ReadV06(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV06);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV06(byte[] buffer, int index, ListOffsetsTopicResponse message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV06);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, ListOffsetsTopicResponse Value) ReadV07(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV07);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV07(byte[] buffer, int index, ListOffsetsTopicResponse message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV07);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class ListOffsetsPartitionResponseSerde
           {
               public static (int Offset, ListOffsetsPartitionResponse Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var oldStyleOffsetsField) = Decoder.ReadArray<long>(buffer, index, Decoder.ReadInt64);
                   if (oldStyleOffsetsField == null)
                       throw new NullReferenceException("Null not allowed for 'OldStyleOffsets'");
                   var timestampField = default(long);
                   var offsetField = default(long);
                   var leaderEpochField = default(int);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       oldStyleOffsetsField.Value,
                       timestampField,
                       offsetField,
                       leaderEpochField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, ListOffsetsPartitionResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteArray<long>(buffer, index, message.OldStyleOffsetsField, Encoder.WriteInt64);
                   return index;
               }
               public static (int Offset, ListOffsetsPartitionResponse Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                   (index, var timestampField) = Decoder.ReadInt64(buffer, index);
                   (index, var offsetField) = Decoder.ReadInt64(buffer, index);
                   var leaderEpochField = default(int);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       oldStyleOffsetsField,
                       timestampField,
                       offsetField,
                       leaderEpochField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, ListOffsetsPartitionResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                   index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                   return index;
               }
               public static (int Offset, ListOffsetsPartitionResponse Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                   (index, var timestampField) = Decoder.ReadInt64(buffer, index);
                   (index, var offsetField) = Decoder.ReadInt64(buffer, index);
                   var leaderEpochField = default(int);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       oldStyleOffsetsField,
                       timestampField,
                       offsetField,
                       leaderEpochField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, ListOffsetsPartitionResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                   index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                   return index;
               }
               public static (int Offset, ListOffsetsPartitionResponse Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                   (index, var timestampField) = Decoder.ReadInt64(buffer, index);
                   (index, var offsetField) = Decoder.ReadInt64(buffer, index);
                   var leaderEpochField = default(int);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       oldStyleOffsetsField,
                       timestampField,
                       offsetField,
                       leaderEpochField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, ListOffsetsPartitionResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                   index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                   return index;
               }
               public static (int Offset, ListOffsetsPartitionResponse Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                   (index, var timestampField) = Decoder.ReadInt64(buffer, index);
                   (index, var offsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       oldStyleOffsetsField,
                       timestampField,
                       offsetField,
                       leaderEpochField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, ListOffsetsPartitionResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                   index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   return index;
               }
               public static (int Offset, ListOffsetsPartitionResponse Value) ReadV05(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                   (index, var timestampField) = Decoder.ReadInt64(buffer, index);
                   (index, var offsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       oldStyleOffsetsField,
                       timestampField,
                       offsetField,
                       leaderEpochField
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, ListOffsetsPartitionResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                   index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   return index;
               }
               public static (int Offset, ListOffsetsPartitionResponse Value) ReadV06(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                   (index, var timestampField) = Decoder.ReadInt64(buffer, index);
                   (index, var offsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       oldStyleOffsetsField,
                       timestampField,
                       offsetField,
                       leaderEpochField
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, ListOffsetsPartitionResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                   index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, ListOffsetsPartitionResponse Value) ReadV07(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                   (index, var timestampField) = Decoder.ReadInt64(buffer, index);
                   (index, var offsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       oldStyleOffsetsField,
                       timestampField,
                       offsetField,
                       leaderEpochField
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, ListOffsetsPartitionResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                   index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}