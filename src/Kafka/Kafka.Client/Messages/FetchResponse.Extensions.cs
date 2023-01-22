using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using Kafka.Common.Records;
using LeaderIdAndEpoch = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.LeaderIdAndEpoch;
using PartitionData = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData;
using EpochEndOffset = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.EpochEndOffset;
using SnapshotId = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.SnapshotId;
using FetchableTopicResponse = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse;
using AbortedTransaction = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.AbortedTransaction;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class FetchResponseSerde
   {
       private static readonly DecodeDelegate<FetchResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
           ReadV06,
           ReadV07,
           ReadV08,
           ReadV09,
           ReadV10,
           ReadV11,
           ReadV12,
           ReadV13,
       };
       private static readonly EncodeDelegate<FetchResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
           WriteV06,
           WriteV07,
           WriteV08,
           WriteV09,
           WriteV10,
           WriteV11,
           WriteV12,
           WriteV13,
};
       public static (int Offset, FetchResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, FetchResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, FetchResponse Value) ReadV00(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           var errorCodeField = default(short);
           var sessionIdField = default(int);
           (index, var responsesField) = Decoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV00);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               sessionIdField,
               responsesField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, FetchResponse message)
       {
           index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV00);
           return index;
       }
       private static (int Offset, FetchResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           var errorCodeField = default(short);
           var sessionIdField = default(int);
           (index, var responsesField) = Decoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV01);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               sessionIdField,
               responsesField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, FetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV01);
           return index;
       }
       private static (int Offset, FetchResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           var errorCodeField = default(short);
           var sessionIdField = default(int);
           (index, var responsesField) = Decoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV02);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               sessionIdField,
               responsesField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, FetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV02);
           return index;
       }
       private static (int Offset, FetchResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           var errorCodeField = default(short);
           var sessionIdField = default(int);
           (index, var responsesField) = Decoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV03);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               sessionIdField,
               responsesField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, FetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV03);
           return index;
       }
       private static (int Offset, FetchResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           var errorCodeField = default(short);
           var sessionIdField = default(int);
           (index, var responsesField) = Decoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV04);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               sessionIdField,
               responsesField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, FetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV04);
           return index;
       }
       private static (int Offset, FetchResponse Value) ReadV05(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           var errorCodeField = default(short);
           var sessionIdField = default(int);
           (index, var responsesField) = Decoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV05);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               sessionIdField,
               responsesField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, FetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV05);
           return index;
       }
       private static (int Offset, FetchResponse Value) ReadV06(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           var errorCodeField = default(short);
           var sessionIdField = default(int);
           (index, var responsesField) = Decoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV06);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               sessionIdField,
               responsesField.Value
           ));
       }
       private static int WriteV06(byte[] buffer, int index, FetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV06);
           return index;
       }
       private static (int Offset, FetchResponse Value) ReadV07(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var sessionIdField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV07);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               sessionIdField,
               responsesField.Value
           ));
       }
       private static int WriteV07(byte[] buffer, int index, FetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
           index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV07);
           return index;
       }
       private static (int Offset, FetchResponse Value) ReadV08(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var sessionIdField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV08);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               sessionIdField,
               responsesField.Value
           ));
       }
       private static int WriteV08(byte[] buffer, int index, FetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
           index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV08);
           return index;
       }
       private static (int Offset, FetchResponse Value) ReadV09(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var sessionIdField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV09);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               sessionIdField,
               responsesField.Value
           ));
       }
       private static int WriteV09(byte[] buffer, int index, FetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
           index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV09);
           return index;
       }
       private static (int Offset, FetchResponse Value) ReadV10(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var sessionIdField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV10);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               sessionIdField,
               responsesField.Value
           ));
       }
       private static int WriteV10(byte[] buffer, int index, FetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
           index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV10);
           return index;
       }
       private static (int Offset, FetchResponse Value) ReadV11(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var sessionIdField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV11);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               sessionIdField,
               responsesField.Value
           ));
       }
       private static int WriteV11(byte[] buffer, int index, FetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
           index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV11);
           return index;
       }
       private static (int Offset, FetchResponse Value) ReadV12(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var sessionIdField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadCompactArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV12);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               sessionIdField,
               responsesField.Value
           ));
       }
       private static int WriteV12(byte[] buffer, int index, FetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
           index = Encoder.WriteCompactArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV12);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, FetchResponse Value) ReadV13(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var sessionIdField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadCompactArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV13);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               sessionIdField,
               responsesField.Value
           ));
       }
       private static int WriteV13(byte[] buffer, int index, FetchResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
           index = Encoder.WriteCompactArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV13);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class FetchableTopicResponseSerde
       {
           public static (int Offset, FetchableTopicResponse Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, FetchableTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV00);
               return index;
           }
           public static (int Offset, FetchableTopicResponse Value) ReadV01(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, FetchableTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV01);
               return index;
           }
           public static (int Offset, FetchableTopicResponse Value) ReadV02(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, FetchableTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV02);
               return index;
           }
           public static (int Offset, FetchableTopicResponse Value) ReadV03(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV03);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, FetchableTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV03);
               return index;
           }
           public static (int Offset, FetchableTopicResponse Value) ReadV04(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV04);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, FetchableTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV04);
               return index;
           }
           public static (int Offset, FetchableTopicResponse Value) ReadV05(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV05);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV05(byte[] buffer, int index, FetchableTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV05);
               return index;
           }
           public static (int Offset, FetchableTopicResponse Value) ReadV06(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV06);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV06(byte[] buffer, int index, FetchableTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV06);
               return index;
           }
           public static (int Offset, FetchableTopicResponse Value) ReadV07(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV07);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV07(byte[] buffer, int index, FetchableTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV07);
               return index;
           }
           public static (int Offset, FetchableTopicResponse Value) ReadV08(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV08);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV08(byte[] buffer, int index, FetchableTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV08);
               return index;
           }
           public static (int Offset, FetchableTopicResponse Value) ReadV09(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV09);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV09(byte[] buffer, int index, FetchableTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV09);
               return index;
           }
           public static (int Offset, FetchableTopicResponse Value) ReadV10(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV10);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV10(byte[] buffer, int index, FetchableTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV10);
               return index;
           }
           public static (int Offset, FetchableTopicResponse Value) ReadV11(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV11);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV11(byte[] buffer, int index, FetchableTopicResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV11);
               return index;
           }
           public static (int Offset, FetchableTopicResponse Value) ReadV12(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadCompactString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadCompactArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV12);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV12(byte[] buffer, int index, FetchableTopicResponse message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicField);
               index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV12);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, FetchableTopicResponse Value) ReadV13(byte[] buffer, int index)
           {
               var topicField = "";
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV13);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV13(byte[] buffer, int index, FetchableTopicResponse message)
           {
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV13);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class PartitionDataSerde
           {
               public static (int Offset, PartitionData Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   var lastStableOffsetField = default(long);
                   var logStartOffsetField = default(long);
                   var divergingEpochField = EpochEndOffset.Empty;
                   var currentLeaderField = LeaderIdAndEpoch.Empty;
                   var snapshotIdField = SnapshotId.Empty;
                   var abortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                   var preferredReadReplicaField = default(int);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       highWatermarkField,
                       lastStableOffsetField,
                       logStartOffsetField,
                       divergingEpochField,
                       currentLeaderField,
                       snapshotIdField,
                       abortedTransactionsField,
                       preferredReadReplicaField,
                       recordsField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   var lastStableOffsetField = default(long);
                   var logStartOffsetField = default(long);
                   var divergingEpochField = EpochEndOffset.Empty;
                   var currentLeaderField = LeaderIdAndEpoch.Empty;
                   var snapshotIdField = SnapshotId.Empty;
                   var abortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                   var preferredReadReplicaField = default(int);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       highWatermarkField,
                       lastStableOffsetField,
                       logStartOffsetField,
                       divergingEpochField,
                       currentLeaderField,
                       snapshotIdField,
                       abortedTransactionsField,
                       preferredReadReplicaField,
                       recordsField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   var lastStableOffsetField = default(long);
                   var logStartOffsetField = default(long);
                   var divergingEpochField = EpochEndOffset.Empty;
                   var currentLeaderField = LeaderIdAndEpoch.Empty;
                   var snapshotIdField = SnapshotId.Empty;
                   var abortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                   var preferredReadReplicaField = default(int);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       highWatermarkField,
                       lastStableOffsetField,
                       logStartOffsetField,
                       divergingEpochField,
                       currentLeaderField,
                       snapshotIdField,
                       abortedTransactionsField,
                       preferredReadReplicaField,
                       recordsField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   var lastStableOffsetField = default(long);
                   var logStartOffsetField = default(long);
                   var divergingEpochField = EpochEndOffset.Empty;
                   var currentLeaderField = LeaderIdAndEpoch.Empty;
                   var snapshotIdField = SnapshotId.Empty;
                   var abortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                   var preferredReadReplicaField = default(int);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       highWatermarkField,
                       lastStableOffsetField,
                       logStartOffsetField,
                       divergingEpochField,
                       currentLeaderField,
                       snapshotIdField,
                       abortedTransactionsField,
                       preferredReadReplicaField,
                       recordsField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   (index, var lastStableOffsetField) = Decoder.ReadInt64(buffer, index);
                   var logStartOffsetField = default(long);
                   var divergingEpochField = EpochEndOffset.Empty;
                   var currentLeaderField = LeaderIdAndEpoch.Empty;
                   var snapshotIdField = SnapshotId.Empty;
                   (index, var abortedTransactionsField) = Decoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV04);
                   var preferredReadReplicaField = default(int);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       highWatermarkField,
                       lastStableOffsetField,
                       logStartOffsetField,
                       divergingEpochField,
                       currentLeaderField,
                       snapshotIdField,
                       abortedTransactionsField,
                       preferredReadReplicaField,
                       recordsField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                   index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV04);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV05(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   (index, var lastStableOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   var divergingEpochField = EpochEndOffset.Empty;
                   var currentLeaderField = LeaderIdAndEpoch.Empty;
                   var snapshotIdField = SnapshotId.Empty;
                   (index, var abortedTransactionsField) = Decoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV05);
                   var preferredReadReplicaField = default(int);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       highWatermarkField,
                       lastStableOffsetField,
                       logStartOffsetField,
                       divergingEpochField,
                       currentLeaderField,
                       snapshotIdField,
                       abortedTransactionsField,
                       preferredReadReplicaField,
                       recordsField
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV05);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV06(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   (index, var lastStableOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   var divergingEpochField = EpochEndOffset.Empty;
                   var currentLeaderField = LeaderIdAndEpoch.Empty;
                   var snapshotIdField = SnapshotId.Empty;
                   (index, var abortedTransactionsField) = Decoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV06);
                   var preferredReadReplicaField = default(int);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       highWatermarkField,
                       lastStableOffsetField,
                       logStartOffsetField,
                       divergingEpochField,
                       currentLeaderField,
                       snapshotIdField,
                       abortedTransactionsField,
                       preferredReadReplicaField,
                       recordsField
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV06);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV07(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   (index, var lastStableOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   var divergingEpochField = EpochEndOffset.Empty;
                   var currentLeaderField = LeaderIdAndEpoch.Empty;
                   var snapshotIdField = SnapshotId.Empty;
                   (index, var abortedTransactionsField) = Decoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV07);
                   var preferredReadReplicaField = default(int);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       highWatermarkField,
                       lastStableOffsetField,
                       logStartOffsetField,
                       divergingEpochField,
                       currentLeaderField,
                       snapshotIdField,
                       abortedTransactionsField,
                       preferredReadReplicaField,
                       recordsField
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV07);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV08(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   (index, var lastStableOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   var divergingEpochField = EpochEndOffset.Empty;
                   var currentLeaderField = LeaderIdAndEpoch.Empty;
                   var snapshotIdField = SnapshotId.Empty;
                   (index, var abortedTransactionsField) = Decoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV08);
                   var preferredReadReplicaField = default(int);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       highWatermarkField,
                       lastStableOffsetField,
                       logStartOffsetField,
                       divergingEpochField,
                       currentLeaderField,
                       snapshotIdField,
                       abortedTransactionsField,
                       preferredReadReplicaField,
                       recordsField
                   ));
               }
               public static int WriteV08(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV08);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV09(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   (index, var lastStableOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   var divergingEpochField = EpochEndOffset.Empty;
                   var currentLeaderField = LeaderIdAndEpoch.Empty;
                   var snapshotIdField = SnapshotId.Empty;
                   (index, var abortedTransactionsField) = Decoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV09);
                   var preferredReadReplicaField = default(int);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       highWatermarkField,
                       lastStableOffsetField,
                       logStartOffsetField,
                       divergingEpochField,
                       currentLeaderField,
                       snapshotIdField,
                       abortedTransactionsField,
                       preferredReadReplicaField,
                       recordsField
                   ));
               }
               public static int WriteV09(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV09);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV10(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   (index, var lastStableOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   var divergingEpochField = EpochEndOffset.Empty;
                   var currentLeaderField = LeaderIdAndEpoch.Empty;
                   var snapshotIdField = SnapshotId.Empty;
                   (index, var abortedTransactionsField) = Decoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV10);
                   var preferredReadReplicaField = default(int);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       highWatermarkField,
                       lastStableOffsetField,
                       logStartOffsetField,
                       divergingEpochField,
                       currentLeaderField,
                       snapshotIdField,
                       abortedTransactionsField,
                       preferredReadReplicaField,
                       recordsField
                   ));
               }
               public static int WriteV10(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV10);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV11(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   (index, var lastStableOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   var divergingEpochField = EpochEndOffset.Empty;
                   var currentLeaderField = LeaderIdAndEpoch.Empty;
                   var snapshotIdField = SnapshotId.Empty;
                   (index, var abortedTransactionsField) = Decoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV11);
                   (index, var preferredReadReplicaField) = Decoder.ReadInt32(buffer, index);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       highWatermarkField,
                       lastStableOffsetField,
                       logStartOffsetField,
                       divergingEpochField,
                       currentLeaderField,
                       snapshotIdField,
                       abortedTransactionsField,
                       preferredReadReplicaField,
                       recordsField
                   ));
               }
               public static int WriteV11(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV11);
                   index = Encoder.WriteInt32(buffer, index, message.PreferredReadReplicaField);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV12(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   (index, var lastStableOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   var divergingEpochField = EpochEndOffset.Empty;
                   var currentLeaderField = LeaderIdAndEpoch.Empty;
                   var snapshotIdField = SnapshotId.Empty;
                   (index, var abortedTransactionsField) = Decoder.ReadCompactArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV12);
                   (index, var preferredReadReplicaField) = Decoder.ReadInt32(buffer, index);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       highWatermarkField,
                       lastStableOffsetField,
                       logStartOffsetField,
                       divergingEpochField,
                       currentLeaderField,
                       snapshotIdField,
                       abortedTransactionsField,
                       preferredReadReplicaField,
                       recordsField
                   ));
               }
               public static int WriteV12(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = EpochEndOffsetSerde.WriteV12(buffer, index, message.DivergingEpochField);
                   index = LeaderIdAndEpochSerde.WriteV12(buffer, index, message.CurrentLeaderField);
                   index = SnapshotIdSerde.WriteV12(buffer, index, message.SnapshotIdField);
                   index = Encoder.WriteCompactArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV12);
                   index = Encoder.WriteInt32(buffer, index, message.PreferredReadReplicaField);
                   index = Encoder.WriteCompactRecords(buffer, index, message.RecordsField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV13(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   (index, var lastStableOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   var divergingEpochField = EpochEndOffset.Empty;
                   var currentLeaderField = LeaderIdAndEpoch.Empty;
                   var snapshotIdField = SnapshotId.Empty;
                   (index, var abortedTransactionsField) = Decoder.ReadCompactArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV13);
                   (index, var preferredReadReplicaField) = Decoder.ReadInt32(buffer, index);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       highWatermarkField,
                       lastStableOffsetField,
                       logStartOffsetField,
                       divergingEpochField,
                       currentLeaderField,
                       snapshotIdField,
                       abortedTransactionsField,
                       preferredReadReplicaField,
                       recordsField
                   ));
               }
               public static int WriteV13(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = EpochEndOffsetSerde.WriteV13(buffer, index, message.DivergingEpochField);
                   index = LeaderIdAndEpochSerde.WriteV13(buffer, index, message.CurrentLeaderField);
                   index = SnapshotIdSerde.WriteV13(buffer, index, message.SnapshotIdField);
                   index = Encoder.WriteCompactArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV13);
                   index = Encoder.WriteInt32(buffer, index, message.PreferredReadReplicaField);
                   index = Encoder.WriteCompactRecords(buffer, index, message.RecordsField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               [GeneratedCode("kgen", "1.0.0.0")]
               private static class LeaderIdAndEpochSerde
               {
                   public static (int Offset, LeaderIdAndEpoch Value) ReadV00(byte[] buffer, int index)
                   {
                       var leaderIdField = default(int);
                       var leaderEpochField = default(int);
                       return (index, new(
                           leaderIdField,
                           leaderEpochField
                       ));
                   }
                   public static int WriteV00(byte[] buffer, int index, LeaderIdAndEpoch message)
                   {
                       return index;
                   }
                   public static (int Offset, LeaderIdAndEpoch Value) ReadV01(byte[] buffer, int index)
                   {
                       var leaderIdField = default(int);
                       var leaderEpochField = default(int);
                       return (index, new(
                           leaderIdField,
                           leaderEpochField
                       ));
                   }
                   public static int WriteV01(byte[] buffer, int index, LeaderIdAndEpoch message)
                   {
                       return index;
                   }
                   public static (int Offset, LeaderIdAndEpoch Value) ReadV02(byte[] buffer, int index)
                   {
                       var leaderIdField = default(int);
                       var leaderEpochField = default(int);
                       return (index, new(
                           leaderIdField,
                           leaderEpochField
                       ));
                   }
                   public static int WriteV02(byte[] buffer, int index, LeaderIdAndEpoch message)
                   {
                       return index;
                   }
                   public static (int Offset, LeaderIdAndEpoch Value) ReadV03(byte[] buffer, int index)
                   {
                       var leaderIdField = default(int);
                       var leaderEpochField = default(int);
                       return (index, new(
                           leaderIdField,
                           leaderEpochField
                       ));
                   }
                   public static int WriteV03(byte[] buffer, int index, LeaderIdAndEpoch message)
                   {
                       return index;
                   }
                   public static (int Offset, LeaderIdAndEpoch Value) ReadV04(byte[] buffer, int index)
                   {
                       var leaderIdField = default(int);
                       var leaderEpochField = default(int);
                       return (index, new(
                           leaderIdField,
                           leaderEpochField
                       ));
                   }
                   public static int WriteV04(byte[] buffer, int index, LeaderIdAndEpoch message)
                   {
                       return index;
                   }
                   public static (int Offset, LeaderIdAndEpoch Value) ReadV05(byte[] buffer, int index)
                   {
                       var leaderIdField = default(int);
                       var leaderEpochField = default(int);
                       return (index, new(
                           leaderIdField,
                           leaderEpochField
                       ));
                   }
                   public static int WriteV05(byte[] buffer, int index, LeaderIdAndEpoch message)
                   {
                       return index;
                   }
                   public static (int Offset, LeaderIdAndEpoch Value) ReadV06(byte[] buffer, int index)
                   {
                       var leaderIdField = default(int);
                       var leaderEpochField = default(int);
                       return (index, new(
                           leaderIdField,
                           leaderEpochField
                       ));
                   }
                   public static int WriteV06(byte[] buffer, int index, LeaderIdAndEpoch message)
                   {
                       return index;
                   }
                   public static (int Offset, LeaderIdAndEpoch Value) ReadV07(byte[] buffer, int index)
                   {
                       var leaderIdField = default(int);
                       var leaderEpochField = default(int);
                       return (index, new(
                           leaderIdField,
                           leaderEpochField
                       ));
                   }
                   public static int WriteV07(byte[] buffer, int index, LeaderIdAndEpoch message)
                   {
                       return index;
                   }
                   public static (int Offset, LeaderIdAndEpoch Value) ReadV08(byte[] buffer, int index)
                   {
                       var leaderIdField = default(int);
                       var leaderEpochField = default(int);
                       return (index, new(
                           leaderIdField,
                           leaderEpochField
                       ));
                   }
                   public static int WriteV08(byte[] buffer, int index, LeaderIdAndEpoch message)
                   {
                       return index;
                   }
                   public static (int Offset, LeaderIdAndEpoch Value) ReadV09(byte[] buffer, int index)
                   {
                       var leaderIdField = default(int);
                       var leaderEpochField = default(int);
                       return (index, new(
                           leaderIdField,
                           leaderEpochField
                       ));
                   }
                   public static int WriteV09(byte[] buffer, int index, LeaderIdAndEpoch message)
                   {
                       return index;
                   }
                   public static (int Offset, LeaderIdAndEpoch Value) ReadV10(byte[] buffer, int index)
                   {
                       var leaderIdField = default(int);
                       var leaderEpochField = default(int);
                       return (index, new(
                           leaderIdField,
                           leaderEpochField
                       ));
                   }
                   public static int WriteV10(byte[] buffer, int index, LeaderIdAndEpoch message)
                   {
                       return index;
                   }
                   public static (int Offset, LeaderIdAndEpoch Value) ReadV11(byte[] buffer, int index)
                   {
                       var leaderIdField = default(int);
                       var leaderEpochField = default(int);
                       return (index, new(
                           leaderIdField,
                           leaderEpochField
                       ));
                   }
                   public static int WriteV11(byte[] buffer, int index, LeaderIdAndEpoch message)
                   {
                       return index;
                   }
                   public static (int Offset, LeaderIdAndEpoch Value) ReadV12(byte[] buffer, int index)
                   {
                       (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                       (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           leaderIdField,
                           leaderEpochField
                       ));
                   }
                   public static int WriteV12(byte[] buffer, int index, LeaderIdAndEpoch message)
                   {
                       index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                       index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
                   public static (int Offset, LeaderIdAndEpoch Value) ReadV13(byte[] buffer, int index)
                   {
                       (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                       (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           leaderIdField,
                           leaderEpochField
                       ));
                   }
                   public static int WriteV13(byte[] buffer, int index, LeaderIdAndEpoch message)
                   {
                       index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                       index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
               }
               [GeneratedCode("kgen", "1.0.0.0")]
               private static class EpochEndOffsetSerde
               {
                   public static (int Offset, EpochEndOffset Value) ReadV00(byte[] buffer, int index)
                   {
                       var epochField = default(int);
                       var endOffsetField = default(long);
                       return (index, new(
                           epochField,
                           endOffsetField
                       ));
                   }
                   public static int WriteV00(byte[] buffer, int index, EpochEndOffset message)
                   {
                       return index;
                   }
                   public static (int Offset, EpochEndOffset Value) ReadV01(byte[] buffer, int index)
                   {
                       var epochField = default(int);
                       var endOffsetField = default(long);
                       return (index, new(
                           epochField,
                           endOffsetField
                       ));
                   }
                   public static int WriteV01(byte[] buffer, int index, EpochEndOffset message)
                   {
                       return index;
                   }
                   public static (int Offset, EpochEndOffset Value) ReadV02(byte[] buffer, int index)
                   {
                       var epochField = default(int);
                       var endOffsetField = default(long);
                       return (index, new(
                           epochField,
                           endOffsetField
                       ));
                   }
                   public static int WriteV02(byte[] buffer, int index, EpochEndOffset message)
                   {
                       return index;
                   }
                   public static (int Offset, EpochEndOffset Value) ReadV03(byte[] buffer, int index)
                   {
                       var epochField = default(int);
                       var endOffsetField = default(long);
                       return (index, new(
                           epochField,
                           endOffsetField
                       ));
                   }
                   public static int WriteV03(byte[] buffer, int index, EpochEndOffset message)
                   {
                       return index;
                   }
                   public static (int Offset, EpochEndOffset Value) ReadV04(byte[] buffer, int index)
                   {
                       var epochField = default(int);
                       var endOffsetField = default(long);
                       return (index, new(
                           epochField,
                           endOffsetField
                       ));
                   }
                   public static int WriteV04(byte[] buffer, int index, EpochEndOffset message)
                   {
                       return index;
                   }
                   public static (int Offset, EpochEndOffset Value) ReadV05(byte[] buffer, int index)
                   {
                       var epochField = default(int);
                       var endOffsetField = default(long);
                       return (index, new(
                           epochField,
                           endOffsetField
                       ));
                   }
                   public static int WriteV05(byte[] buffer, int index, EpochEndOffset message)
                   {
                       return index;
                   }
                   public static (int Offset, EpochEndOffset Value) ReadV06(byte[] buffer, int index)
                   {
                       var epochField = default(int);
                       var endOffsetField = default(long);
                       return (index, new(
                           epochField,
                           endOffsetField
                       ));
                   }
                   public static int WriteV06(byte[] buffer, int index, EpochEndOffset message)
                   {
                       return index;
                   }
                   public static (int Offset, EpochEndOffset Value) ReadV07(byte[] buffer, int index)
                   {
                       var epochField = default(int);
                       var endOffsetField = default(long);
                       return (index, new(
                           epochField,
                           endOffsetField
                       ));
                   }
                   public static int WriteV07(byte[] buffer, int index, EpochEndOffset message)
                   {
                       return index;
                   }
                   public static (int Offset, EpochEndOffset Value) ReadV08(byte[] buffer, int index)
                   {
                       var epochField = default(int);
                       var endOffsetField = default(long);
                       return (index, new(
                           epochField,
                           endOffsetField
                       ));
                   }
                   public static int WriteV08(byte[] buffer, int index, EpochEndOffset message)
                   {
                       return index;
                   }
                   public static (int Offset, EpochEndOffset Value) ReadV09(byte[] buffer, int index)
                   {
                       var epochField = default(int);
                       var endOffsetField = default(long);
                       return (index, new(
                           epochField,
                           endOffsetField
                       ));
                   }
                   public static int WriteV09(byte[] buffer, int index, EpochEndOffset message)
                   {
                       return index;
                   }
                   public static (int Offset, EpochEndOffset Value) ReadV10(byte[] buffer, int index)
                   {
                       var epochField = default(int);
                       var endOffsetField = default(long);
                       return (index, new(
                           epochField,
                           endOffsetField
                       ));
                   }
                   public static int WriteV10(byte[] buffer, int index, EpochEndOffset message)
                   {
                       return index;
                   }
                   public static (int Offset, EpochEndOffset Value) ReadV11(byte[] buffer, int index)
                   {
                       var epochField = default(int);
                       var endOffsetField = default(long);
                       return (index, new(
                           epochField,
                           endOffsetField
                       ));
                   }
                   public static int WriteV11(byte[] buffer, int index, EpochEndOffset message)
                   {
                       return index;
                   }
                   public static (int Offset, EpochEndOffset Value) ReadV12(byte[] buffer, int index)
                   {
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           epochField,
                           endOffsetField
                       ));
                   }
                   public static int WriteV12(byte[] buffer, int index, EpochEndOffset message)
                   {
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
                   public static (int Offset, EpochEndOffset Value) ReadV13(byte[] buffer, int index)
                   {
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           epochField,
                           endOffsetField
                       ));
                   }
                   public static int WriteV13(byte[] buffer, int index, EpochEndOffset message)
                   {
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
               }
               [GeneratedCode("kgen", "1.0.0.0")]
               private static class SnapshotIdSerde
               {
                   public static (int Offset, SnapshotId Value) ReadV00(byte[] buffer, int index)
                   {
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       return (index, new(
                           endOffsetField,
                           epochField
                       ));
                   }
                   public static int WriteV00(byte[] buffer, int index, SnapshotId message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       return index;
                   }
                   public static (int Offset, SnapshotId Value) ReadV01(byte[] buffer, int index)
                   {
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       return (index, new(
                           endOffsetField,
                           epochField
                       ));
                   }
                   public static int WriteV01(byte[] buffer, int index, SnapshotId message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       return index;
                   }
                   public static (int Offset, SnapshotId Value) ReadV02(byte[] buffer, int index)
                   {
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       return (index, new(
                           endOffsetField,
                           epochField
                       ));
                   }
                   public static int WriteV02(byte[] buffer, int index, SnapshotId message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       return index;
                   }
                   public static (int Offset, SnapshotId Value) ReadV03(byte[] buffer, int index)
                   {
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       return (index, new(
                           endOffsetField,
                           epochField
                       ));
                   }
                   public static int WriteV03(byte[] buffer, int index, SnapshotId message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       return index;
                   }
                   public static (int Offset, SnapshotId Value) ReadV04(byte[] buffer, int index)
                   {
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       return (index, new(
                           endOffsetField,
                           epochField
                       ));
                   }
                   public static int WriteV04(byte[] buffer, int index, SnapshotId message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       return index;
                   }
                   public static (int Offset, SnapshotId Value) ReadV05(byte[] buffer, int index)
                   {
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       return (index, new(
                           endOffsetField,
                           epochField
                       ));
                   }
                   public static int WriteV05(byte[] buffer, int index, SnapshotId message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       return index;
                   }
                   public static (int Offset, SnapshotId Value) ReadV06(byte[] buffer, int index)
                   {
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       return (index, new(
                           endOffsetField,
                           epochField
                       ));
                   }
                   public static int WriteV06(byte[] buffer, int index, SnapshotId message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       return index;
                   }
                   public static (int Offset, SnapshotId Value) ReadV07(byte[] buffer, int index)
                   {
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       return (index, new(
                           endOffsetField,
                           epochField
                       ));
                   }
                   public static int WriteV07(byte[] buffer, int index, SnapshotId message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       return index;
                   }
                   public static (int Offset, SnapshotId Value) ReadV08(byte[] buffer, int index)
                   {
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       return (index, new(
                           endOffsetField,
                           epochField
                       ));
                   }
                   public static int WriteV08(byte[] buffer, int index, SnapshotId message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       return index;
                   }
                   public static (int Offset, SnapshotId Value) ReadV09(byte[] buffer, int index)
                   {
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       return (index, new(
                           endOffsetField,
                           epochField
                       ));
                   }
                   public static int WriteV09(byte[] buffer, int index, SnapshotId message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       return index;
                   }
                   public static (int Offset, SnapshotId Value) ReadV10(byte[] buffer, int index)
                   {
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       return (index, new(
                           endOffsetField,
                           epochField
                       ));
                   }
                   public static int WriteV10(byte[] buffer, int index, SnapshotId message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       return index;
                   }
                   public static (int Offset, SnapshotId Value) ReadV11(byte[] buffer, int index)
                   {
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       return (index, new(
                           endOffsetField,
                           epochField
                       ));
                   }
                   public static int WriteV11(byte[] buffer, int index, SnapshotId message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       return index;
                   }
                   public static (int Offset, SnapshotId Value) ReadV12(byte[] buffer, int index)
                   {
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           endOffsetField,
                           epochField
                       ));
                   }
                   public static int WriteV12(byte[] buffer, int index, SnapshotId message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
                   public static (int Offset, SnapshotId Value) ReadV13(byte[] buffer, int index)
                   {
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           endOffsetField,
                           epochField
                       ));
                   }
                   public static int WriteV13(byte[] buffer, int index, SnapshotId message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
               }
               [GeneratedCode("kgen", "1.0.0.0")]
               private static class AbortedTransactionSerde
               {
                   public static (int Offset, AbortedTransaction Value) ReadV00(byte[] buffer, int index)
                   {
                       var producerIdField = default(long);
                       var firstOffsetField = default(long);
                       return (index, new(
                           producerIdField,
                           firstOffsetField
                       ));
                   }
                   public static int WriteV00(byte[] buffer, int index, AbortedTransaction message)
                   {
                       return index;
                   }
                   public static (int Offset, AbortedTransaction Value) ReadV01(byte[] buffer, int index)
                   {
                       var producerIdField = default(long);
                       var firstOffsetField = default(long);
                       return (index, new(
                           producerIdField,
                           firstOffsetField
                       ));
                   }
                   public static int WriteV01(byte[] buffer, int index, AbortedTransaction message)
                   {
                       return index;
                   }
                   public static (int Offset, AbortedTransaction Value) ReadV02(byte[] buffer, int index)
                   {
                       var producerIdField = default(long);
                       var firstOffsetField = default(long);
                       return (index, new(
                           producerIdField,
                           firstOffsetField
                       ));
                   }
                   public static int WriteV02(byte[] buffer, int index, AbortedTransaction message)
                   {
                       return index;
                   }
                   public static (int Offset, AbortedTransaction Value) ReadV03(byte[] buffer, int index)
                   {
                       var producerIdField = default(long);
                       var firstOffsetField = default(long);
                       return (index, new(
                           producerIdField,
                           firstOffsetField
                       ));
                   }
                   public static int WriteV03(byte[] buffer, int index, AbortedTransaction message)
                   {
                       return index;
                   }
                   public static (int Offset, AbortedTransaction Value) ReadV04(byte[] buffer, int index)
                   {
                       (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
                       (index, var firstOffsetField) = Decoder.ReadInt64(buffer, index);
                       return (index, new(
                           producerIdField,
                           firstOffsetField
                       ));
                   }
                   public static int WriteV04(byte[] buffer, int index, AbortedTransaction message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                       index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                       return index;
                   }
                   public static (int Offset, AbortedTransaction Value) ReadV05(byte[] buffer, int index)
                   {
                       (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
                       (index, var firstOffsetField) = Decoder.ReadInt64(buffer, index);
                       return (index, new(
                           producerIdField,
                           firstOffsetField
                       ));
                   }
                   public static int WriteV05(byte[] buffer, int index, AbortedTransaction message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                       index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                       return index;
                   }
                   public static (int Offset, AbortedTransaction Value) ReadV06(byte[] buffer, int index)
                   {
                       (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
                       (index, var firstOffsetField) = Decoder.ReadInt64(buffer, index);
                       return (index, new(
                           producerIdField,
                           firstOffsetField
                       ));
                   }
                   public static int WriteV06(byte[] buffer, int index, AbortedTransaction message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                       index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                       return index;
                   }
                   public static (int Offset, AbortedTransaction Value) ReadV07(byte[] buffer, int index)
                   {
                       (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
                       (index, var firstOffsetField) = Decoder.ReadInt64(buffer, index);
                       return (index, new(
                           producerIdField,
                           firstOffsetField
                       ));
                   }
                   public static int WriteV07(byte[] buffer, int index, AbortedTransaction message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                       index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                       return index;
                   }
                   public static (int Offset, AbortedTransaction Value) ReadV08(byte[] buffer, int index)
                   {
                       (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
                       (index, var firstOffsetField) = Decoder.ReadInt64(buffer, index);
                       return (index, new(
                           producerIdField,
                           firstOffsetField
                       ));
                   }
                   public static int WriteV08(byte[] buffer, int index, AbortedTransaction message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                       index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                       return index;
                   }
                   public static (int Offset, AbortedTransaction Value) ReadV09(byte[] buffer, int index)
                   {
                       (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
                       (index, var firstOffsetField) = Decoder.ReadInt64(buffer, index);
                       return (index, new(
                           producerIdField,
                           firstOffsetField
                       ));
                   }
                   public static int WriteV09(byte[] buffer, int index, AbortedTransaction message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                       index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                       return index;
                   }
                   public static (int Offset, AbortedTransaction Value) ReadV10(byte[] buffer, int index)
                   {
                       (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
                       (index, var firstOffsetField) = Decoder.ReadInt64(buffer, index);
                       return (index, new(
                           producerIdField,
                           firstOffsetField
                       ));
                   }
                   public static int WriteV10(byte[] buffer, int index, AbortedTransaction message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                       index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                       return index;
                   }
                   public static (int Offset, AbortedTransaction Value) ReadV11(byte[] buffer, int index)
                   {
                       (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
                       (index, var firstOffsetField) = Decoder.ReadInt64(buffer, index);
                       return (index, new(
                           producerIdField,
                           firstOffsetField
                       ));
                   }
                   public static int WriteV11(byte[] buffer, int index, AbortedTransaction message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                       index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                       return index;
                   }
                   public static (int Offset, AbortedTransaction Value) ReadV12(byte[] buffer, int index)
                   {
                       (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
                       (index, var firstOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           producerIdField,
                           firstOffsetField
                       ));
                   }
                   public static int WriteV12(byte[] buffer, int index, AbortedTransaction message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                       index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
                   public static (int Offset, AbortedTransaction Value) ReadV13(byte[] buffer, int index)
                   {
                       (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
                       (index, var firstOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           producerIdField,
                           firstOffsetField
                       ));
                   }
                   public static int WriteV13(byte[] buffer, int index, AbortedTransaction message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                       index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
               }
           }
       }
   }
}