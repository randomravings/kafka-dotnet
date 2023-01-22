using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using UpdatableFeatureResult = Kafka.Client.Messages.UpdateFeaturesResponse.UpdatableFeatureResult;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class UpdateFeaturesResponseSerde
   {
       private static readonly DecodeDelegate<UpdateFeaturesResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
       };
       private static readonly EncodeDelegate<UpdateFeaturesResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
};
       public static (int Offset, UpdateFeaturesResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, UpdateFeaturesResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, UpdateFeaturesResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var resultsField) = Decoder.ReadCompactArray<UpdatableFeatureResult>(buffer, index, UpdatableFeatureResultSerde.ReadV00);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               resultsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, UpdateFeaturesResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
           index = Encoder.WriteCompactArray<UpdatableFeatureResult>(buffer, index, message.ResultsField, UpdatableFeatureResultSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, UpdateFeaturesResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var resultsField) = Decoder.ReadCompactArray<UpdatableFeatureResult>(buffer, index, UpdatableFeatureResultSerde.ReadV01);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               resultsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, UpdateFeaturesResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
           index = Encoder.WriteCompactArray<UpdatableFeatureResult>(buffer, index, message.ResultsField, UpdatableFeatureResultSerde.WriteV01);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class UpdatableFeatureResultSerde
       {
           public static (int Offset, UpdatableFeatureResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var featureField) = Decoder.ReadCompactString(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   featureField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, UpdatableFeatureResult message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.FeatureField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, UpdatableFeatureResult Value) ReadV01(byte[] buffer, int index)
           {
               (index, var featureField) = Decoder.ReadCompactString(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   featureField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, UpdatableFeatureResult message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.FeatureField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}