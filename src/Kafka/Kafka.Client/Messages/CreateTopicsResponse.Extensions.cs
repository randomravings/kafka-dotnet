using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using CreatableTopicConfigs = Kafka.Client.Messages.CreateTopicsResponse.CreatableTopicResult.CreatableTopicConfigs;
using CreatableTopicResult = Kafka.Client.Messages.CreateTopicsResponse.CreatableTopicResult;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class CreateTopicsResponseSerde
   {
       private static readonly DecodeDelegate<CreateTopicsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
           ReadV06,
           ReadV07,
       };
       private static readonly EncodeDelegate<CreateTopicsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
           WriteV06,
           WriteV07,
};
       public static (int Offset, CreateTopicsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, CreateTopicsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, CreateTopicsResponse Value) ReadV00(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var topicsField) = Decoder.ReadArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, CreateTopicsResponse message)
       {
           index = Encoder.WriteArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV00);
           return index;
       }
       private static (int Offset, CreateTopicsResponse Value) ReadV01(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var topicsField) = Decoder.ReadArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, CreateTopicsResponse message)
       {
           index = Encoder.WriteArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV01);
           return index;
       }
       private static (int Offset, CreateTopicsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, CreateTopicsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV02);
           return index;
       }
       private static (int Offset, CreateTopicsResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV03);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, CreateTopicsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV03);
           return index;
       }
       private static (int Offset, CreateTopicsResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV04);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, CreateTopicsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV04);
           return index;
       }
       private static (int Offset, CreateTopicsResponse Value) ReadV05(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV05);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, CreateTopicsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV05);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, CreateTopicsResponse Value) ReadV06(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV06);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV06(byte[] buffer, int index, CreateTopicsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV06);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, CreateTopicsResponse Value) ReadV07(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV07);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               topicsField.Value
           ));
       }
       private static int WriteV07(byte[] buffer, int index, CreateTopicsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV07);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class CreatableTopicResultSerde
       {
           public static (int Offset, CreatableTopicResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               var errorMessageField = default(string?);
               var topicConfigErrorCodeField = default(short);
               var numPartitionsField = default(int);
               var replicationFactorField = default(short);
               var configsField = ImmutableArray<CreatableTopicConfigs>.Empty;
               return (index, new(
                   nameField,
                   topicIdField,
                   errorCodeField,
                   errorMessageField,
                   topicConfigErrorCodeField,
                   numPartitionsField,
                   replicationFactorField,
                   configsField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, CreatableTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               return index;
           }
           public static (int Offset, CreatableTopicResult Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               var topicConfigErrorCodeField = default(short);
               var numPartitionsField = default(int);
               var replicationFactorField = default(short);
               var configsField = ImmutableArray<CreatableTopicConfigs>.Empty;
               return (index, new(
                   nameField,
                   topicIdField,
                   errorCodeField,
                   errorMessageField,
                   topicConfigErrorCodeField,
                   numPartitionsField,
                   replicationFactorField,
                   configsField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, CreatableTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               return index;
           }
           public static (int Offset, CreatableTopicResult Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               var topicConfigErrorCodeField = default(short);
               var numPartitionsField = default(int);
               var replicationFactorField = default(short);
               var configsField = ImmutableArray<CreatableTopicConfigs>.Empty;
               return (index, new(
                   nameField,
                   topicIdField,
                   errorCodeField,
                   errorMessageField,
                   topicConfigErrorCodeField,
                   numPartitionsField,
                   replicationFactorField,
                   configsField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, CreatableTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               return index;
           }
           public static (int Offset, CreatableTopicResult Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               var topicConfigErrorCodeField = default(short);
               var numPartitionsField = default(int);
               var replicationFactorField = default(short);
               var configsField = ImmutableArray<CreatableTopicConfigs>.Empty;
               return (index, new(
                   nameField,
                   topicIdField,
                   errorCodeField,
                   errorMessageField,
                   topicConfigErrorCodeField,
                   numPartitionsField,
                   replicationFactorField,
                   configsField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, CreatableTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               return index;
           }
           public static (int Offset, CreatableTopicResult Value) ReadV04(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               var topicConfigErrorCodeField = default(short);
               var numPartitionsField = default(int);
               var replicationFactorField = default(short);
               var configsField = ImmutableArray<CreatableTopicConfigs>.Empty;
               return (index, new(
                   nameField,
                   topicIdField,
                   errorCodeField,
                   errorMessageField,
                   topicConfigErrorCodeField,
                   numPartitionsField,
                   replicationFactorField,
                   configsField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, CreatableTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               return index;
           }
           public static (int Offset, CreatableTopicResult Value) ReadV05(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               var topicIdField = default(Guid);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               var topicConfigErrorCodeField = default(short);
               (index, var numPartitionsField) = Decoder.ReadInt32(buffer, index);
               (index, var replicationFactorField) = Decoder.ReadInt16(buffer, index);
               (index, var configsField) = Decoder.ReadCompactArray<CreatableTopicConfigs>(buffer, index, CreatableTopicConfigsSerde.ReadV05);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   topicIdField,
                   errorCodeField,
                   errorMessageField,
                   topicConfigErrorCodeField,
                   numPartitionsField,
                   replicationFactorField,
                   configsField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, CreatableTopicResult message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteInt16(buffer, index, message.TopicConfigErrorCodeField);
               index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
               index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
               index = Encoder.WriteCompactArray<CreatableTopicConfigs>(buffer, index, message.ConfigsField, CreatableTopicConfigsSerde.WriteV05);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, CreatableTopicResult Value) ReadV06(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               var topicIdField = default(Guid);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               var topicConfigErrorCodeField = default(short);
               (index, var numPartitionsField) = Decoder.ReadInt32(buffer, index);
               (index, var replicationFactorField) = Decoder.ReadInt16(buffer, index);
               (index, var configsField) = Decoder.ReadCompactArray<CreatableTopicConfigs>(buffer, index, CreatableTopicConfigsSerde.ReadV06);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   topicIdField,
                   errorCodeField,
                   errorMessageField,
                   topicConfigErrorCodeField,
                   numPartitionsField,
                   replicationFactorField,
                   configsField
               ));
           }
           public static int WriteV06(byte[] buffer, int index, CreatableTopicResult message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteInt16(buffer, index, message.TopicConfigErrorCodeField);
               index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
               index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
               index = Encoder.WriteCompactArray<CreatableTopicConfigs>(buffer, index, message.ConfigsField, CreatableTopicConfigsSerde.WriteV06);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, CreatableTopicResult Value) ReadV07(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               var topicConfigErrorCodeField = default(short);
               (index, var numPartitionsField) = Decoder.ReadInt32(buffer, index);
               (index, var replicationFactorField) = Decoder.ReadInt16(buffer, index);
               (index, var configsField) = Decoder.ReadCompactArray<CreatableTopicConfigs>(buffer, index, CreatableTopicConfigsSerde.ReadV07);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   topicIdField,
                   errorCodeField,
                   errorMessageField,
                   topicConfigErrorCodeField,
                   numPartitionsField,
                   replicationFactorField,
                   configsField
               ));
           }
           public static int WriteV07(byte[] buffer, int index, CreatableTopicResult message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteInt16(buffer, index, message.TopicConfigErrorCodeField);
               index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
               index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
               index = Encoder.WriteCompactArray<CreatableTopicConfigs>(buffer, index, message.ConfigsField, CreatableTopicConfigsSerde.WriteV07);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class CreatableTopicConfigsSerde
           {
               public static (int Offset, CreatableTopicConfigs Value) ReadV00(byte[] buffer, int index)
               {
                   var nameField = "";
                   var valueField = default(string?);
                   var readOnlyField = default(bool);
                   var configSourceField = default(sbyte);
                   var isSensitiveField = default(bool);
                   return (index, new(
                       nameField,
                       valueField,
                       readOnlyField,
                       configSourceField,
                       isSensitiveField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, CreatableTopicConfigs message)
               {
                   return index;
               }
               public static (int Offset, CreatableTopicConfigs Value) ReadV01(byte[] buffer, int index)
               {
                   var nameField = "";
                   var valueField = default(string?);
                   var readOnlyField = default(bool);
                   var configSourceField = default(sbyte);
                   var isSensitiveField = default(bool);
                   return (index, new(
                       nameField,
                       valueField,
                       readOnlyField,
                       configSourceField,
                       isSensitiveField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, CreatableTopicConfigs message)
               {
                   return index;
               }
               public static (int Offset, CreatableTopicConfigs Value) ReadV02(byte[] buffer, int index)
               {
                   var nameField = "";
                   var valueField = default(string?);
                   var readOnlyField = default(bool);
                   var configSourceField = default(sbyte);
                   var isSensitiveField = default(bool);
                   return (index, new(
                       nameField,
                       valueField,
                       readOnlyField,
                       configSourceField,
                       isSensitiveField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, CreatableTopicConfigs message)
               {
                   return index;
               }
               public static (int Offset, CreatableTopicConfigs Value) ReadV03(byte[] buffer, int index)
               {
                   var nameField = "";
                   var valueField = default(string?);
                   var readOnlyField = default(bool);
                   var configSourceField = default(sbyte);
                   var isSensitiveField = default(bool);
                   return (index, new(
                       nameField,
                       valueField,
                       readOnlyField,
                       configSourceField,
                       isSensitiveField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, CreatableTopicConfigs message)
               {
                   return index;
               }
               public static (int Offset, CreatableTopicConfigs Value) ReadV04(byte[] buffer, int index)
               {
                   var nameField = "";
                   var valueField = default(string?);
                   var readOnlyField = default(bool);
                   var configSourceField = default(sbyte);
                   var isSensitiveField = default(bool);
                   return (index, new(
                       nameField,
                       valueField,
                       readOnlyField,
                       configSourceField,
                       isSensitiveField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, CreatableTopicConfigs message)
               {
                   return index;
               }
               public static (int Offset, CreatableTopicConfigs Value) ReadV05(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var valueField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, var readOnlyField) = Decoder.ReadBoolean(buffer, index);
                   (index, var configSourceField) = Decoder.ReadInt8(buffer, index);
                   (index, var isSensitiveField) = Decoder.ReadBoolean(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       valueField,
                       readOnlyField,
                       configSourceField,
                       isSensitiveField
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, CreatableTopicConfigs message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.NameField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                   index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                   index = Encoder.WriteInt8(buffer, index, message.ConfigSourceField);
                   index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, CreatableTopicConfigs Value) ReadV06(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var valueField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, var readOnlyField) = Decoder.ReadBoolean(buffer, index);
                   (index, var configSourceField) = Decoder.ReadInt8(buffer, index);
                   (index, var isSensitiveField) = Decoder.ReadBoolean(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       valueField,
                       readOnlyField,
                       configSourceField,
                       isSensitiveField
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, CreatableTopicConfigs message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.NameField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                   index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                   index = Encoder.WriteInt8(buffer, index, message.ConfigSourceField);
                   index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, CreatableTopicConfigs Value) ReadV07(byte[] buffer, int index)
               {
                   (index, var nameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var valueField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, var readOnlyField) = Decoder.ReadBoolean(buffer, index);
                   (index, var configSourceField) = Decoder.ReadInt8(buffer, index);
                   (index, var isSensitiveField) = Decoder.ReadBoolean(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       nameField,
                       valueField,
                       readOnlyField,
                       configSourceField,
                       isSensitiveField
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, CreatableTopicConfigs message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.NameField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                   index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                   index = Encoder.WriteInt8(buffer, index, message.ConfigSourceField);
                   index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}