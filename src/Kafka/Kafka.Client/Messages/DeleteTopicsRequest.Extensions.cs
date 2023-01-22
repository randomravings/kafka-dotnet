using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DeleteTopicState = Kafka.Client.Messages.DeleteTopicsRequest.DeleteTopicState;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DeleteTopicsRequestSerde
   {
       private static readonly DecodeDelegate<DeleteTopicsRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
           ReadV06,
       };
       private static readonly EncodeDelegate<DeleteTopicsRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
           WriteV06,
};
       public static (int Offset, DeleteTopicsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DeleteTopicsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DeleteTopicsRequest Value) ReadV00(byte[] buffer, int index)
       {
           var topicsField = ImmutableArray<DeleteTopicState>.Empty;
           (index, var topicNamesField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (topicNamesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicNames'");
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               topicsField,
               topicNamesField.Value,
               timeoutMsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DeleteTopicsRequest message)
       {
           index = Encoder.WriteArray<string>(buffer, index, message.TopicNamesField, Encoder.WriteCompactString);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           return index;
       }
       private static (int Offset, DeleteTopicsRequest Value) ReadV01(byte[] buffer, int index)
       {
           var topicsField = ImmutableArray<DeleteTopicState>.Empty;
           (index, var topicNamesField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (topicNamesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicNames'");
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               topicsField,
               topicNamesField.Value,
               timeoutMsField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DeleteTopicsRequest message)
       {
           index = Encoder.WriteArray<string>(buffer, index, message.TopicNamesField, Encoder.WriteCompactString);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           return index;
       }
       private static (int Offset, DeleteTopicsRequest Value) ReadV02(byte[] buffer, int index)
       {
           var topicsField = ImmutableArray<DeleteTopicState>.Empty;
           (index, var topicNamesField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (topicNamesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicNames'");
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               topicsField,
               topicNamesField.Value,
               timeoutMsField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DeleteTopicsRequest message)
       {
           index = Encoder.WriteArray<string>(buffer, index, message.TopicNamesField, Encoder.WriteCompactString);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           return index;
       }
       private static (int Offset, DeleteTopicsRequest Value) ReadV03(byte[] buffer, int index)
       {
           var topicsField = ImmutableArray<DeleteTopicState>.Empty;
           (index, var topicNamesField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (topicNamesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicNames'");
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               topicsField,
               topicNamesField.Value,
               timeoutMsField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, DeleteTopicsRequest message)
       {
           index = Encoder.WriteArray<string>(buffer, index, message.TopicNamesField, Encoder.WriteCompactString);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           return index;
       }
       private static (int Offset, DeleteTopicsRequest Value) ReadV04(byte[] buffer, int index)
       {
           var topicsField = ImmutableArray<DeleteTopicState>.Empty;
           (index, var topicNamesField) = Decoder.ReadCompactArray<string>(buffer, index, Decoder.ReadCompactString);
           if (topicNamesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicNames'");
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               topicsField,
               topicNamesField.Value,
               timeoutMsField
           ));
       }
       private static int WriteV04(byte[] buffer, int index, DeleteTopicsRequest message)
       {
           index = Encoder.WriteCompactArray<string>(buffer, index, message.TopicNamesField, Encoder.WriteCompactString);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, DeleteTopicsRequest Value) ReadV05(byte[] buffer, int index)
       {
           var topicsField = ImmutableArray<DeleteTopicState>.Empty;
           (index, var topicNamesField) = Decoder.ReadCompactArray<string>(buffer, index, Decoder.ReadCompactString);
           if (topicNamesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicNames'");
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               topicsField,
               topicNamesField.Value,
               timeoutMsField
           ));
       }
       private static int WriteV05(byte[] buffer, int index, DeleteTopicsRequest message)
       {
           index = Encoder.WriteCompactArray<string>(buffer, index, message.TopicNamesField, Encoder.WriteCompactString);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, DeleteTopicsRequest Value) ReadV06(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadCompactArray<DeleteTopicState>(buffer, index, DeleteTopicStateSerde.ReadV06);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var topicNamesField = ImmutableArray<string>.Empty;
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               topicsField.Value,
               topicNamesField,
               timeoutMsField
           ));
       }
       private static int WriteV06(byte[] buffer, int index, DeleteTopicsRequest message)
       {
           index = Encoder.WriteCompactArray<DeleteTopicState>(buffer, index, message.TopicsField, DeleteTopicStateSerde.WriteV06);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class DeleteTopicStateSerde
       {
           public static (int Offset, DeleteTopicState Value) ReadV00(byte[] buffer, int index)
           {
               var nameField = default(string?);
               var topicIdField = default(Guid);
               return (index, new(
                   nameField,
                   topicIdField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, DeleteTopicState message)
           {
               return index;
           }
           public static (int Offset, DeleteTopicState Value) ReadV01(byte[] buffer, int index)
           {
               var nameField = default(string?);
               var topicIdField = default(Guid);
               return (index, new(
                   nameField,
                   topicIdField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, DeleteTopicState message)
           {
               return index;
           }
           public static (int Offset, DeleteTopicState Value) ReadV02(byte[] buffer, int index)
           {
               var nameField = default(string?);
               var topicIdField = default(Guid);
               return (index, new(
                   nameField,
                   topicIdField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, DeleteTopicState message)
           {
               return index;
           }
           public static (int Offset, DeleteTopicState Value) ReadV03(byte[] buffer, int index)
           {
               var nameField = default(string?);
               var topicIdField = default(Guid);
               return (index, new(
                   nameField,
                   topicIdField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, DeleteTopicState message)
           {
               return index;
           }
           public static (int Offset, DeleteTopicState Value) ReadV04(byte[] buffer, int index)
           {
               var nameField = default(string?);
               var topicIdField = default(Guid);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   topicIdField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, DeleteTopicState message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, DeleteTopicState Value) ReadV05(byte[] buffer, int index)
           {
               var nameField = default(string?);
               var topicIdField = default(Guid);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   topicIdField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, DeleteTopicState message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, DeleteTopicState Value) ReadV06(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   topicIdField
               ));
           }
           public static int WriteV06(byte[] buffer, int index, DeleteTopicState message)
           {
               index = Encoder.WriteCompactNullableString(buffer, index, message.NameField);
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}