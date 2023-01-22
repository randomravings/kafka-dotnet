using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using FeatureUpdateKey = Kafka.Client.Messages.UpdateFeaturesRequest.FeatureUpdateKey;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class UpdateFeaturesRequestSerde
   {
       private static readonly DecodeDelegate<UpdateFeaturesRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
       };
       private static readonly EncodeDelegate<UpdateFeaturesRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
};
       public static (int Offset, UpdateFeaturesRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, UpdateFeaturesRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, UpdateFeaturesRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var featureUpdatesField) = Decoder.ReadCompactArray<FeatureUpdateKey>(buffer, index, FeatureUpdateKeySerde.ReadV00);
           if (featureUpdatesField == null)
               throw new NullReferenceException("Null not allowed for 'FeatureUpdates'");
           var validateOnlyField = default(bool);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               timeoutMsField,
               featureUpdatesField.Value,
               validateOnlyField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, UpdateFeaturesRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteCompactArray<FeatureUpdateKey>(buffer, index, message.FeatureUpdatesField, FeatureUpdateKeySerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, UpdateFeaturesRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var featureUpdatesField) = Decoder.ReadCompactArray<FeatureUpdateKey>(buffer, index, FeatureUpdateKeySerde.ReadV01);
           if (featureUpdatesField == null)
               throw new NullReferenceException("Null not allowed for 'FeatureUpdates'");
           (index, var validateOnlyField) = Decoder.ReadBoolean(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               timeoutMsField,
               featureUpdatesField.Value,
               validateOnlyField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, UpdateFeaturesRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteCompactArray<FeatureUpdateKey>(buffer, index, message.FeatureUpdatesField, FeatureUpdateKeySerde.WriteV01);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class FeatureUpdateKeySerde
       {
           public static (int Offset, FeatureUpdateKey Value) ReadV00(byte[] buffer, int index)
           {
               (index, var featureField) = Decoder.ReadCompactString(buffer, index);
               (index, var maxVersionLevelField) = Decoder.ReadInt16(buffer, index);
               (index, var allowDowngradeField) = Decoder.ReadBoolean(buffer, index);
               var upgradeTypeField = default(sbyte);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   featureField,
                   maxVersionLevelField,
                   allowDowngradeField,
                   upgradeTypeField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, FeatureUpdateKey message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.FeatureField);
               index = Encoder.WriteInt16(buffer, index, message.MaxVersionLevelField);
               index = Encoder.WriteBoolean(buffer, index, message.AllowDowngradeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, FeatureUpdateKey Value) ReadV01(byte[] buffer, int index)
           {
               (index, var featureField) = Decoder.ReadCompactString(buffer, index);
               (index, var maxVersionLevelField) = Decoder.ReadInt16(buffer, index);
               var allowDowngradeField = default(bool);
               (index, var upgradeTypeField) = Decoder.ReadInt8(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   featureField,
                   maxVersionLevelField,
                   allowDowngradeField,
                   upgradeTypeField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, FeatureUpdateKey message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.FeatureField);
               index = Encoder.WriteInt16(buffer, index, message.MaxVersionLevelField);
               index = Encoder.WriteInt8(buffer, index, message.UpgradeTypeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}