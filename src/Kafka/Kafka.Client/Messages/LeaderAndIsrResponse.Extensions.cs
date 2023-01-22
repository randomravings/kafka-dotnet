using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using LeaderAndIsrTopicError = Kafka.Client.Messages.LeaderAndIsrResponse.LeaderAndIsrTopicError;
using LeaderAndIsrPartitionError = Kafka.Client.Messages.LeaderAndIsrResponse.LeaderAndIsrPartitionError;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class LeaderAndIsrResponseSerde
   {
       private static readonly DecodeDelegate<LeaderAndIsrResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
           ReadV06,
           ReadV07,
       };
       private static readonly EncodeDelegate<LeaderAndIsrResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
           WriteV06,
           WriteV07,
};
       public static (int Offset, LeaderAndIsrResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, LeaderAndIsrResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, LeaderAndIsrResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var partitionErrorsField) = Decoder.ReadArray<LeaderAndIsrPartitionError>(buffer, index, LeaderAndIsrPartitionErrorSerde.ReadV00);
           if (partitionErrorsField == null)
               throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
           var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
           return (index, new(
               errorCodeField,
               partitionErrorsField.Value,
               topicsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, LeaderAndIsrResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV00);
           return index;
       }
       private static (int Offset, LeaderAndIsrResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var partitionErrorsField) = Decoder.ReadArray<LeaderAndIsrPartitionError>(buffer, index, LeaderAndIsrPartitionErrorSerde.ReadV01);
           if (partitionErrorsField == null)
               throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
           var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
           return (index, new(
               errorCodeField,
               partitionErrorsField.Value,
               topicsField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, LeaderAndIsrResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV01);
           return index;
       }
       private static (int Offset, LeaderAndIsrResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var partitionErrorsField) = Decoder.ReadArray<LeaderAndIsrPartitionError>(buffer, index, LeaderAndIsrPartitionErrorSerde.ReadV02);
           if (partitionErrorsField == null)
               throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
           var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
           return (index, new(
               errorCodeField,
               partitionErrorsField.Value,
               topicsField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, LeaderAndIsrResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV02);
           return index;
       }
       private static (int Offset, LeaderAndIsrResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var partitionErrorsField) = Decoder.ReadArray<LeaderAndIsrPartitionError>(buffer, index, LeaderAndIsrPartitionErrorSerde.ReadV03);
           if (partitionErrorsField == null)
               throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
           var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
           return (index, new(
               errorCodeField,
               partitionErrorsField.Value,
               topicsField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, LeaderAndIsrResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV03);
           return index;
       }
       private static (int Offset, LeaderAndIsrResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var partitionErrorsField) = Decoder.ReadCompactArray<LeaderAndIsrPartitionError>(buffer, index, LeaderAndIsrPartitionErrorSerde.ReadV04);
           if (partitionErrorsField == null)
               throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
           var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               partitionErrorsField.Value,
               topicsField
           ));
       }
       private static int WriteV04(byte[] buffer, int index, LeaderAndIsrResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV04);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, LeaderAndIsrResponse Value) ReadV05(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var partitionErrorsField = ImmutableArray<LeaderAndIsrPartitionError>.Empty;
           (index, var topicsField) = Decoder.ReadCompactArray<LeaderAndIsrTopicError>(buffer, index, LeaderAndIsrTopicErrorSerde.ReadV05);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               partitionErrorsField,
               topicsField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, LeaderAndIsrResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<LeaderAndIsrTopicError>(buffer, index, message.TopicsField, LeaderAndIsrTopicErrorSerde.WriteV05);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, LeaderAndIsrResponse Value) ReadV06(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var partitionErrorsField = ImmutableArray<LeaderAndIsrPartitionError>.Empty;
           (index, var topicsField) = Decoder.ReadCompactArray<LeaderAndIsrTopicError>(buffer, index, LeaderAndIsrTopicErrorSerde.ReadV06);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               partitionErrorsField,
               topicsField.Value
           ));
       }
       private static int WriteV06(byte[] buffer, int index, LeaderAndIsrResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<LeaderAndIsrTopicError>(buffer, index, message.TopicsField, LeaderAndIsrTopicErrorSerde.WriteV06);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, LeaderAndIsrResponse Value) ReadV07(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var partitionErrorsField = ImmutableArray<LeaderAndIsrPartitionError>.Empty;
           (index, var topicsField) = Decoder.ReadCompactArray<LeaderAndIsrTopicError>(buffer, index, LeaderAndIsrTopicErrorSerde.ReadV07);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               partitionErrorsField,
               topicsField.Value
           ));
       }
       private static int WriteV07(byte[] buffer, int index, LeaderAndIsrResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<LeaderAndIsrTopicError>(buffer, index, message.TopicsField, LeaderAndIsrTopicErrorSerde.WriteV07);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class LeaderAndIsrTopicErrorSerde
       {
           public static (int Offset, LeaderAndIsrTopicError Value) ReadV00(byte[] buffer, int index)
           {
               var topicIdField = default(Guid);
               var partitionErrorsField = ImmutableArray<LeaderAndIsrPartitionError>.Empty;
               return (index, new(
                   topicIdField,
                   partitionErrorsField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, LeaderAndIsrTopicError message)
           {
               return index;
           }
           public static (int Offset, LeaderAndIsrTopicError Value) ReadV01(byte[] buffer, int index)
           {
               var topicIdField = default(Guid);
               var partitionErrorsField = ImmutableArray<LeaderAndIsrPartitionError>.Empty;
               return (index, new(
                   topicIdField,
                   partitionErrorsField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, LeaderAndIsrTopicError message)
           {
               return index;
           }
           public static (int Offset, LeaderAndIsrTopicError Value) ReadV02(byte[] buffer, int index)
           {
               var topicIdField = default(Guid);
               var partitionErrorsField = ImmutableArray<LeaderAndIsrPartitionError>.Empty;
               return (index, new(
                   topicIdField,
                   partitionErrorsField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, LeaderAndIsrTopicError message)
           {
               return index;
           }
           public static (int Offset, LeaderAndIsrTopicError Value) ReadV03(byte[] buffer, int index)
           {
               var topicIdField = default(Guid);
               var partitionErrorsField = ImmutableArray<LeaderAndIsrPartitionError>.Empty;
               return (index, new(
                   topicIdField,
                   partitionErrorsField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, LeaderAndIsrTopicError message)
           {
               return index;
           }
           public static (int Offset, LeaderAndIsrTopicError Value) ReadV04(byte[] buffer, int index)
           {
               var topicIdField = default(Guid);
               var partitionErrorsField = ImmutableArray<LeaderAndIsrPartitionError>.Empty;
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicIdField,
                   partitionErrorsField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, LeaderAndIsrTopicError message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, LeaderAndIsrTopicError Value) ReadV05(byte[] buffer, int index)
           {
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var partitionErrorsField) = Decoder.ReadCompactArray<LeaderAndIsrPartitionError>(buffer, index, LeaderAndIsrPartitionErrorSerde.ReadV05);
               if (partitionErrorsField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicIdField,
                   partitionErrorsField.Value
               ));
           }
           public static int WriteV05(byte[] buffer, int index, LeaderAndIsrTopicError message)
           {
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteCompactArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV05);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, LeaderAndIsrTopicError Value) ReadV06(byte[] buffer, int index)
           {
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var partitionErrorsField) = Decoder.ReadCompactArray<LeaderAndIsrPartitionError>(buffer, index, LeaderAndIsrPartitionErrorSerde.ReadV06);
               if (partitionErrorsField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicIdField,
                   partitionErrorsField.Value
               ));
           }
           public static int WriteV06(byte[] buffer, int index, LeaderAndIsrTopicError message)
           {
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteCompactArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV06);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, LeaderAndIsrTopicError Value) ReadV07(byte[] buffer, int index)
           {
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var partitionErrorsField) = Decoder.ReadCompactArray<LeaderAndIsrPartitionError>(buffer, index, LeaderAndIsrPartitionErrorSerde.ReadV07);
               if (partitionErrorsField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicIdField,
                   partitionErrorsField.Value
               ));
           }
           public static int WriteV07(byte[] buffer, int index, LeaderAndIsrTopicError message)
           {
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteCompactArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV07);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class LeaderAndIsrPartitionErrorSerde
       {
           public static (int Offset, LeaderAndIsrPartitionError Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   errorCodeField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, LeaderAndIsrPartitionError message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               return index;
           }
           public static (int Offset, LeaderAndIsrPartitionError Value) ReadV01(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   errorCodeField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, LeaderAndIsrPartitionError message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               return index;
           }
           public static (int Offset, LeaderAndIsrPartitionError Value) ReadV02(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   errorCodeField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, LeaderAndIsrPartitionError message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               return index;
           }
           public static (int Offset, LeaderAndIsrPartitionError Value) ReadV03(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   errorCodeField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, LeaderAndIsrPartitionError message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               return index;
           }
           public static (int Offset, LeaderAndIsrPartitionError Value) ReadV04(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   errorCodeField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, LeaderAndIsrPartitionError message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, LeaderAndIsrPartitionError Value) ReadV05(byte[] buffer, int index)
           {
               var topicNameField = "";
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   errorCodeField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, LeaderAndIsrPartitionError message)
           {
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, LeaderAndIsrPartitionError Value) ReadV06(byte[] buffer, int index)
           {
               var topicNameField = "";
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   errorCodeField
               ));
           }
           public static int WriteV06(byte[] buffer, int index, LeaderAndIsrPartitionError message)
           {
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, LeaderAndIsrPartitionError Value) ReadV07(byte[] buffer, int index)
           {
               var topicNameField = "";
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   errorCodeField
               ));
           }
           public static int WriteV07(byte[] buffer, int index, LeaderAndIsrPartitionError message)
           {
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}