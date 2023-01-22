using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using FetchPartition = Kafka.Client.Messages.FetchRequest.FetchTopic.FetchPartition;
using FetchTopic = Kafka.Client.Messages.FetchRequest.FetchTopic;
using ForgottenTopic = Kafka.Client.Messages.FetchRequest.ForgottenTopic;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class FetchRequestSerde
   {
       private static readonly DecodeDelegate<FetchRequest>[] READ_VERSIONS = {
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
       private static readonly EncodeDelegate<FetchRequest>[] WRITE_VERSIONS = {
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
       public static (int Offset, FetchRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, FetchRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, FetchRequest Value) ReadV00(byte[] buffer, int index)
       {
           var clusterIdField = default(string?);
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var maxWaitMsField) = Decoder.ReadInt32(buffer, index);
           (index, var minBytesField) = Decoder.ReadInt32(buffer, index);
           var maxBytesField = default(int);
           var isolationLevelField = default(sbyte);
           var sessionIdField = default(int);
           var sessionEpochField = default(int);
           (index, var topicsField) = Decoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
           var rackIdField = "";
           return (index, new(
               clusterIdField,
               replicaIdField,
               maxWaitMsField,
               minBytesField,
               maxBytesField,
               isolationLevelField,
               sessionIdField,
               sessionEpochField,
               topicsField.Value,
               forgottenTopicsDataField,
               rackIdField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, FetchRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
           index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
           index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV00);
           return index;
       }
       private static (int Offset, FetchRequest Value) ReadV01(byte[] buffer, int index)
       {
           var clusterIdField = default(string?);
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var maxWaitMsField) = Decoder.ReadInt32(buffer, index);
           (index, var minBytesField) = Decoder.ReadInt32(buffer, index);
           var maxBytesField = default(int);
           var isolationLevelField = default(sbyte);
           var sessionIdField = default(int);
           var sessionEpochField = default(int);
           (index, var topicsField) = Decoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
           var rackIdField = "";
           return (index, new(
               clusterIdField,
               replicaIdField,
               maxWaitMsField,
               minBytesField,
               maxBytesField,
               isolationLevelField,
               sessionIdField,
               sessionEpochField,
               topicsField.Value,
               forgottenTopicsDataField,
               rackIdField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, FetchRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
           index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
           index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV01);
           return index;
       }
       private static (int Offset, FetchRequest Value) ReadV02(byte[] buffer, int index)
       {
           var clusterIdField = default(string?);
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var maxWaitMsField) = Decoder.ReadInt32(buffer, index);
           (index, var minBytesField) = Decoder.ReadInt32(buffer, index);
           var maxBytesField = default(int);
           var isolationLevelField = default(sbyte);
           var sessionIdField = default(int);
           var sessionEpochField = default(int);
           (index, var topicsField) = Decoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
           var rackIdField = "";
           return (index, new(
               clusterIdField,
               replicaIdField,
               maxWaitMsField,
               minBytesField,
               maxBytesField,
               isolationLevelField,
               sessionIdField,
               sessionEpochField,
               topicsField.Value,
               forgottenTopicsDataField,
               rackIdField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, FetchRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
           index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
           index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV02);
           return index;
       }
       private static (int Offset, FetchRequest Value) ReadV03(byte[] buffer, int index)
       {
           var clusterIdField = default(string?);
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var maxWaitMsField) = Decoder.ReadInt32(buffer, index);
           (index, var minBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var maxBytesField) = Decoder.ReadInt32(buffer, index);
           var isolationLevelField = default(sbyte);
           var sessionIdField = default(int);
           var sessionEpochField = default(int);
           (index, var topicsField) = Decoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV03);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
           var rackIdField = "";
           return (index, new(
               clusterIdField,
               replicaIdField,
               maxWaitMsField,
               minBytesField,
               maxBytesField,
               isolationLevelField,
               sessionIdField,
               sessionEpochField,
               topicsField.Value,
               forgottenTopicsDataField,
               rackIdField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, FetchRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
           index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
           index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
           index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV03);
           return index;
       }
       private static (int Offset, FetchRequest Value) ReadV04(byte[] buffer, int index)
       {
           var clusterIdField = default(string?);
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var maxWaitMsField) = Decoder.ReadInt32(buffer, index);
           (index, var minBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var maxBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           var sessionIdField = default(int);
           var sessionEpochField = default(int);
           (index, var topicsField) = Decoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV04);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
           var rackIdField = "";
           return (index, new(
               clusterIdField,
               replicaIdField,
               maxWaitMsField,
               minBytesField,
               maxBytesField,
               isolationLevelField,
               sessionIdField,
               sessionEpochField,
               topicsField.Value,
               forgottenTopicsDataField,
               rackIdField
           ));
       }
       private static int WriteV04(byte[] buffer, int index, FetchRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
           index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
           index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV04);
           return index;
       }
       private static (int Offset, FetchRequest Value) ReadV05(byte[] buffer, int index)
       {
           var clusterIdField = default(string?);
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var maxWaitMsField) = Decoder.ReadInt32(buffer, index);
           (index, var minBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var maxBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           var sessionIdField = default(int);
           var sessionEpochField = default(int);
           (index, var topicsField) = Decoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV05);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
           var rackIdField = "";
           return (index, new(
               clusterIdField,
               replicaIdField,
               maxWaitMsField,
               minBytesField,
               maxBytesField,
               isolationLevelField,
               sessionIdField,
               sessionEpochField,
               topicsField.Value,
               forgottenTopicsDataField,
               rackIdField
           ));
       }
       private static int WriteV05(byte[] buffer, int index, FetchRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
           index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
           index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV05);
           return index;
       }
       private static (int Offset, FetchRequest Value) ReadV06(byte[] buffer, int index)
       {
           var clusterIdField = default(string?);
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var maxWaitMsField) = Decoder.ReadInt32(buffer, index);
           (index, var minBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var maxBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           var sessionIdField = default(int);
           var sessionEpochField = default(int);
           (index, var topicsField) = Decoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV06);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
           var rackIdField = "";
           return (index, new(
               clusterIdField,
               replicaIdField,
               maxWaitMsField,
               minBytesField,
               maxBytesField,
               isolationLevelField,
               sessionIdField,
               sessionEpochField,
               topicsField.Value,
               forgottenTopicsDataField,
               rackIdField
           ));
       }
       private static int WriteV06(byte[] buffer, int index, FetchRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
           index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
           index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV06);
           return index;
       }
       private static (int Offset, FetchRequest Value) ReadV07(byte[] buffer, int index)
       {
           var clusterIdField = default(string?);
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var maxWaitMsField) = Decoder.ReadInt32(buffer, index);
           (index, var minBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var maxBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           (index, var sessionIdField) = Decoder.ReadInt32(buffer, index);
           (index, var sessionEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV07);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var forgottenTopicsDataField) = Decoder.ReadArray<ForgottenTopic>(buffer, index, ForgottenTopicSerde.ReadV07);
           if (forgottenTopicsDataField == null)
               throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
           var rackIdField = "";
           return (index, new(
               clusterIdField,
               replicaIdField,
               maxWaitMsField,
               minBytesField,
               maxBytesField,
               isolationLevelField,
               sessionIdField,
               sessionEpochField,
               topicsField.Value,
               forgottenTopicsDataField.Value,
               rackIdField
           ));
       }
       private static int WriteV07(byte[] buffer, int index, FetchRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
           index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
           index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
           index = Encoder.WriteInt32(buffer, index, message.SessionEpochField);
           index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV07);
           index = Encoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV07);
           return index;
       }
       private static (int Offset, FetchRequest Value) ReadV08(byte[] buffer, int index)
       {
           var clusterIdField = default(string?);
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var maxWaitMsField) = Decoder.ReadInt32(buffer, index);
           (index, var minBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var maxBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           (index, var sessionIdField) = Decoder.ReadInt32(buffer, index);
           (index, var sessionEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV08);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var forgottenTopicsDataField) = Decoder.ReadArray<ForgottenTopic>(buffer, index, ForgottenTopicSerde.ReadV08);
           if (forgottenTopicsDataField == null)
               throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
           var rackIdField = "";
           return (index, new(
               clusterIdField,
               replicaIdField,
               maxWaitMsField,
               minBytesField,
               maxBytesField,
               isolationLevelField,
               sessionIdField,
               sessionEpochField,
               topicsField.Value,
               forgottenTopicsDataField.Value,
               rackIdField
           ));
       }
       private static int WriteV08(byte[] buffer, int index, FetchRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
           index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
           index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
           index = Encoder.WriteInt32(buffer, index, message.SessionEpochField);
           index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV08);
           index = Encoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV08);
           return index;
       }
       private static (int Offset, FetchRequest Value) ReadV09(byte[] buffer, int index)
       {
           var clusterIdField = default(string?);
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var maxWaitMsField) = Decoder.ReadInt32(buffer, index);
           (index, var minBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var maxBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           (index, var sessionIdField) = Decoder.ReadInt32(buffer, index);
           (index, var sessionEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV09);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var forgottenTopicsDataField) = Decoder.ReadArray<ForgottenTopic>(buffer, index, ForgottenTopicSerde.ReadV09);
           if (forgottenTopicsDataField == null)
               throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
           var rackIdField = "";
           return (index, new(
               clusterIdField,
               replicaIdField,
               maxWaitMsField,
               minBytesField,
               maxBytesField,
               isolationLevelField,
               sessionIdField,
               sessionEpochField,
               topicsField.Value,
               forgottenTopicsDataField.Value,
               rackIdField
           ));
       }
       private static int WriteV09(byte[] buffer, int index, FetchRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
           index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
           index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
           index = Encoder.WriteInt32(buffer, index, message.SessionEpochField);
           index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV09);
           index = Encoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV09);
           return index;
       }
       private static (int Offset, FetchRequest Value) ReadV10(byte[] buffer, int index)
       {
           var clusterIdField = default(string?);
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var maxWaitMsField) = Decoder.ReadInt32(buffer, index);
           (index, var minBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var maxBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           (index, var sessionIdField) = Decoder.ReadInt32(buffer, index);
           (index, var sessionEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV10);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var forgottenTopicsDataField) = Decoder.ReadArray<ForgottenTopic>(buffer, index, ForgottenTopicSerde.ReadV10);
           if (forgottenTopicsDataField == null)
               throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
           var rackIdField = "";
           return (index, new(
               clusterIdField,
               replicaIdField,
               maxWaitMsField,
               minBytesField,
               maxBytesField,
               isolationLevelField,
               sessionIdField,
               sessionEpochField,
               topicsField.Value,
               forgottenTopicsDataField.Value,
               rackIdField
           ));
       }
       private static int WriteV10(byte[] buffer, int index, FetchRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
           index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
           index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
           index = Encoder.WriteInt32(buffer, index, message.SessionEpochField);
           index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV10);
           index = Encoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV10);
           return index;
       }
       private static (int Offset, FetchRequest Value) ReadV11(byte[] buffer, int index)
       {
           var clusterIdField = default(string?);
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var maxWaitMsField) = Decoder.ReadInt32(buffer, index);
           (index, var minBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var maxBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           (index, var sessionIdField) = Decoder.ReadInt32(buffer, index);
           (index, var sessionEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV11);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var forgottenTopicsDataField) = Decoder.ReadArray<ForgottenTopic>(buffer, index, ForgottenTopicSerde.ReadV11);
           if (forgottenTopicsDataField == null)
               throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
           (index, var rackIdField) = Decoder.ReadString(buffer, index);
           return (index, new(
               clusterIdField,
               replicaIdField,
               maxWaitMsField,
               minBytesField,
               maxBytesField,
               isolationLevelField,
               sessionIdField,
               sessionEpochField,
               topicsField.Value,
               forgottenTopicsDataField.Value,
               rackIdField
           ));
       }
       private static int WriteV11(byte[] buffer, int index, FetchRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
           index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
           index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
           index = Encoder.WriteInt32(buffer, index, message.SessionEpochField);
           index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV11);
           index = Encoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV11);
           index = Encoder.WriteString(buffer, index, message.RackIdField);
           return index;
       }
       private static (int Offset, FetchRequest Value) ReadV12(byte[] buffer, int index)
       {
           var clusterIdField = default(string?);
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var maxWaitMsField) = Decoder.ReadInt32(buffer, index);
           (index, var minBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var maxBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           (index, var sessionIdField) = Decoder.ReadInt32(buffer, index);
           (index, var sessionEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV12);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var forgottenTopicsDataField) = Decoder.ReadCompactArray<ForgottenTopic>(buffer, index, ForgottenTopicSerde.ReadV12);
           if (forgottenTopicsDataField == null)
               throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
           (index, var rackIdField) = Decoder.ReadCompactString(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               clusterIdField,
               replicaIdField,
               maxWaitMsField,
               minBytesField,
               maxBytesField,
               isolationLevelField,
               sessionIdField,
               sessionEpochField,
               topicsField.Value,
               forgottenTopicsDataField.Value,
               rackIdField
           ));
       }
       private static int WriteV12(byte[] buffer, int index, FetchRequest message)
       {
           index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
           index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
           index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
           index = Encoder.WriteInt32(buffer, index, message.SessionEpochField);
           index = Encoder.WriteCompactArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV12);
           index = Encoder.WriteCompactArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV12);
           index = Encoder.WriteCompactString(buffer, index, message.RackIdField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, FetchRequest Value) ReadV13(byte[] buffer, int index)
       {
           var clusterIdField = default(string?);
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var maxWaitMsField) = Decoder.ReadInt32(buffer, index);
           (index, var minBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var maxBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var isolationLevelField) = Decoder.ReadInt8(buffer, index);
           (index, var sessionIdField) = Decoder.ReadInt32(buffer, index);
           (index, var sessionEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV13);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var forgottenTopicsDataField) = Decoder.ReadCompactArray<ForgottenTopic>(buffer, index, ForgottenTopicSerde.ReadV13);
           if (forgottenTopicsDataField == null)
               throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
           (index, var rackIdField) = Decoder.ReadCompactString(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               clusterIdField,
               replicaIdField,
               maxWaitMsField,
               minBytesField,
               maxBytesField,
               isolationLevelField,
               sessionIdField,
               sessionEpochField,
               topicsField.Value,
               forgottenTopicsDataField.Value,
               rackIdField
           ));
       }
       private static int WriteV13(byte[] buffer, int index, FetchRequest message)
       {
           index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
           index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
           index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
           index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
           index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
           index = Encoder.WriteInt32(buffer, index, message.SessionEpochField);
           index = Encoder.WriteCompactArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV13);
           index = Encoder.WriteCompactArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV13);
           index = Encoder.WriteCompactString(buffer, index, message.RackIdField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class FetchTopicSerde
       {
           public static (int Offset, FetchTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, FetchTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV00);
               return index;
           }
           public static (int Offset, FetchTopic Value) ReadV01(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, FetchTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV01);
               return index;
           }
           public static (int Offset, FetchTopic Value) ReadV02(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, FetchTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV02);
               return index;
           }
           public static (int Offset, FetchTopic Value) ReadV03(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV03);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, FetchTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV03);
               return index;
           }
           public static (int Offset, FetchTopic Value) ReadV04(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV04);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, FetchTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV04);
               return index;
           }
           public static (int Offset, FetchTopic Value) ReadV05(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV05);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV05(byte[] buffer, int index, FetchTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV05);
               return index;
           }
           public static (int Offset, FetchTopic Value) ReadV06(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV06);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV06(byte[] buffer, int index, FetchTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV06);
               return index;
           }
           public static (int Offset, FetchTopic Value) ReadV07(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV07);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV07(byte[] buffer, int index, FetchTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV07);
               return index;
           }
           public static (int Offset, FetchTopic Value) ReadV08(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV08);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV08(byte[] buffer, int index, FetchTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV08);
               return index;
           }
           public static (int Offset, FetchTopic Value) ReadV09(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV09);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV09(byte[] buffer, int index, FetchTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV09);
               return index;
           }
           public static (int Offset, FetchTopic Value) ReadV10(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV10);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV10(byte[] buffer, int index, FetchTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV10);
               return index;
           }
           public static (int Offset, FetchTopic Value) ReadV11(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV11);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV11(byte[] buffer, int index, FetchTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV11);
               return index;
           }
           public static (int Offset, FetchTopic Value) ReadV12(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadCompactString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadCompactArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV12);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV12(byte[] buffer, int index, FetchTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicField);
               index = Encoder.WriteCompactArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV12);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, FetchTopic Value) ReadV13(byte[] buffer, int index)
           {
               var topicField = "";
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV13);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV13(byte[] buffer, int index, FetchTopic message)
           {
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteCompactArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV13);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class FetchPartitionSerde
           {
               public static (int Offset, FetchPartition Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   var currentLeaderEpochField = default(int);
                   (index, var fetchOffsetField) = Decoder.ReadInt64(buffer, index);
                   var lastFetchedEpochField = default(int);
                   var logStartOffsetField = default(long);
                   (index, var partitionMaxBytesField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       fetchOffsetField,
                       lastFetchedEpochField,
                       logStartOffsetField,
                       partitionMaxBytesField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, FetchPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                   return index;
               }
               public static (int Offset, FetchPartition Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   var currentLeaderEpochField = default(int);
                   (index, var fetchOffsetField) = Decoder.ReadInt64(buffer, index);
                   var lastFetchedEpochField = default(int);
                   var logStartOffsetField = default(long);
                   (index, var partitionMaxBytesField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       fetchOffsetField,
                       lastFetchedEpochField,
                       logStartOffsetField,
                       partitionMaxBytesField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, FetchPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                   return index;
               }
               public static (int Offset, FetchPartition Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   var currentLeaderEpochField = default(int);
                   (index, var fetchOffsetField) = Decoder.ReadInt64(buffer, index);
                   var lastFetchedEpochField = default(int);
                   var logStartOffsetField = default(long);
                   (index, var partitionMaxBytesField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       fetchOffsetField,
                       lastFetchedEpochField,
                       logStartOffsetField,
                       partitionMaxBytesField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, FetchPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                   return index;
               }
               public static (int Offset, FetchPartition Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   var currentLeaderEpochField = default(int);
                   (index, var fetchOffsetField) = Decoder.ReadInt64(buffer, index);
                   var lastFetchedEpochField = default(int);
                   var logStartOffsetField = default(long);
                   (index, var partitionMaxBytesField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       fetchOffsetField,
                       lastFetchedEpochField,
                       logStartOffsetField,
                       partitionMaxBytesField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, FetchPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                   return index;
               }
               public static (int Offset, FetchPartition Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   var currentLeaderEpochField = default(int);
                   (index, var fetchOffsetField) = Decoder.ReadInt64(buffer, index);
                   var lastFetchedEpochField = default(int);
                   var logStartOffsetField = default(long);
                   (index, var partitionMaxBytesField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       fetchOffsetField,
                       lastFetchedEpochField,
                       logStartOffsetField,
                       partitionMaxBytesField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, FetchPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                   return index;
               }
               public static (int Offset, FetchPartition Value) ReadV05(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   var currentLeaderEpochField = default(int);
                   (index, var fetchOffsetField) = Decoder.ReadInt64(buffer, index);
                   var lastFetchedEpochField = default(int);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var partitionMaxBytesField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       fetchOffsetField,
                       lastFetchedEpochField,
                       logStartOffsetField,
                       partitionMaxBytesField
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, FetchPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                   return index;
               }
               public static (int Offset, FetchPartition Value) ReadV06(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   var currentLeaderEpochField = default(int);
                   (index, var fetchOffsetField) = Decoder.ReadInt64(buffer, index);
                   var lastFetchedEpochField = default(int);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var partitionMaxBytesField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       fetchOffsetField,
                       lastFetchedEpochField,
                       logStartOffsetField,
                       partitionMaxBytesField
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, FetchPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                   return index;
               }
               public static (int Offset, FetchPartition Value) ReadV07(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   var currentLeaderEpochField = default(int);
                   (index, var fetchOffsetField) = Decoder.ReadInt64(buffer, index);
                   var lastFetchedEpochField = default(int);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var partitionMaxBytesField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       fetchOffsetField,
                       lastFetchedEpochField,
                       logStartOffsetField,
                       partitionMaxBytesField
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, FetchPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                   return index;
               }
               public static (int Offset, FetchPartition Value) ReadV08(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   var currentLeaderEpochField = default(int);
                   (index, var fetchOffsetField) = Decoder.ReadInt64(buffer, index);
                   var lastFetchedEpochField = default(int);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var partitionMaxBytesField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       fetchOffsetField,
                       lastFetchedEpochField,
                       logStartOffsetField,
                       partitionMaxBytesField
                   ));
               }
               public static int WriteV08(byte[] buffer, int index, FetchPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                   return index;
               }
               public static (int Offset, FetchPartition Value) ReadV09(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   (index, var currentLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var fetchOffsetField) = Decoder.ReadInt64(buffer, index);
                   var lastFetchedEpochField = default(int);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var partitionMaxBytesField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       fetchOffsetField,
                       lastFetchedEpochField,
                       logStartOffsetField,
                       partitionMaxBytesField
                   ));
               }
               public static int WriteV09(byte[] buffer, int index, FetchPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                   return index;
               }
               public static (int Offset, FetchPartition Value) ReadV10(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   (index, var currentLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var fetchOffsetField) = Decoder.ReadInt64(buffer, index);
                   var lastFetchedEpochField = default(int);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var partitionMaxBytesField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       fetchOffsetField,
                       lastFetchedEpochField,
                       logStartOffsetField,
                       partitionMaxBytesField
                   ));
               }
               public static int WriteV10(byte[] buffer, int index, FetchPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                   return index;
               }
               public static (int Offset, FetchPartition Value) ReadV11(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   (index, var currentLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var fetchOffsetField) = Decoder.ReadInt64(buffer, index);
                   var lastFetchedEpochField = default(int);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var partitionMaxBytesField) = Decoder.ReadInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       fetchOffsetField,
                       lastFetchedEpochField,
                       logStartOffsetField,
                       partitionMaxBytesField
                   ));
               }
               public static int WriteV11(byte[] buffer, int index, FetchPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                   return index;
               }
               public static (int Offset, FetchPartition Value) ReadV12(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   (index, var currentLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var fetchOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var lastFetchedEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var partitionMaxBytesField) = Decoder.ReadInt32(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       fetchOffsetField,
                       lastFetchedEpochField,
                       logStartOffsetField,
                       partitionMaxBytesField
                   ));
               }
               public static int WriteV12(byte[] buffer, int index, FetchPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.LastFetchedEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, FetchPartition Value) ReadV13(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   (index, var currentLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var fetchOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var lastFetchedEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var partitionMaxBytesField) = Decoder.ReadInt32(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       fetchOffsetField,
                       lastFetchedEpochField,
                       logStartOffsetField,
                       partitionMaxBytesField
                   ));
               }
               public static int WriteV13(byte[] buffer, int index, FetchPartition message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.LastFetchedEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class ForgottenTopicSerde
       {
           public static (int Offset, ForgottenTopic Value) ReadV00(byte[] buffer, int index)
           {
               var topicField = "";
               var topicIdField = default(Guid);
               var partitionsField = ImmutableArray<int>.Empty;
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, ForgottenTopic message)
           {
               return index;
           }
           public static (int Offset, ForgottenTopic Value) ReadV01(byte[] buffer, int index)
           {
               var topicField = "";
               var topicIdField = default(Guid);
               var partitionsField = ImmutableArray<int>.Empty;
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, ForgottenTopic message)
           {
               return index;
           }
           public static (int Offset, ForgottenTopic Value) ReadV02(byte[] buffer, int index)
           {
               var topicField = "";
               var topicIdField = default(Guid);
               var partitionsField = ImmutableArray<int>.Empty;
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, ForgottenTopic message)
           {
               return index;
           }
           public static (int Offset, ForgottenTopic Value) ReadV03(byte[] buffer, int index)
           {
               var topicField = "";
               var topicIdField = default(Guid);
               var partitionsField = ImmutableArray<int>.Empty;
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, ForgottenTopic message)
           {
               return index;
           }
           public static (int Offset, ForgottenTopic Value) ReadV04(byte[] buffer, int index)
           {
               var topicField = "";
               var topicIdField = default(Guid);
               var partitionsField = ImmutableArray<int>.Empty;
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, ForgottenTopic message)
           {
               return index;
           }
           public static (int Offset, ForgottenTopic Value) ReadV05(byte[] buffer, int index)
           {
               var topicField = "";
               var topicIdField = default(Guid);
               var partitionsField = ImmutableArray<int>.Empty;
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, ForgottenTopic message)
           {
               return index;
           }
           public static (int Offset, ForgottenTopic Value) ReadV06(byte[] buffer, int index)
           {
               var topicField = "";
               var topicIdField = default(Guid);
               var partitionsField = ImmutableArray<int>.Empty;
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField
               ));
           }
           public static int WriteV06(byte[] buffer, int index, ForgottenTopic message)
           {
               return index;
           }
           public static (int Offset, ForgottenTopic Value) ReadV07(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV07(byte[] buffer, int index, ForgottenTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, ForgottenTopic Value) ReadV08(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV08(byte[] buffer, int index, ForgottenTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, ForgottenTopic Value) ReadV09(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV09(byte[] buffer, int index, ForgottenTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, ForgottenTopic Value) ReadV10(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV10(byte[] buffer, int index, ForgottenTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, ForgottenTopic Value) ReadV11(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV11(byte[] buffer, int index, ForgottenTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, ForgottenTopic Value) ReadV12(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadCompactString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionsField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV12(byte[] buffer, int index, ForgottenTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, ForgottenTopic Value) ReadV13(byte[] buffer, int index)
           {
               var topicField = "";
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicField,
                   topicIdField,
                   partitionsField.Value
               ));
           }
           public static int WriteV13(byte[] buffer, int index, ForgottenTopic message)
           {
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}