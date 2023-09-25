using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class SyncGroupResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, SyncGroupResponseData>
    {
        public SyncGroupResponseDecoder() :
            base(
                ApiKey.SyncGroup,
                new(0, 5),
                new(4, 32767),
                ResponseHeaderDecoder.ReadV0,
                ReadV0
            )
        { }
        protected override DecodeDelegate<ResponseHeaderData> GetHeaderDecoder(short apiVersion)
        {
            if (_flexibleVersions.Includes(apiVersion))
                return ResponseHeaderDecoder.ReadV1;
            else
                return ResponseHeaderDecoder.ReadV0;
        }
        protected override DecodeDelegate<SyncGroupResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                3 => ReadV3,
                4 => ReadV4,
                5 => ReadV5,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<SyncGroupResponseData> ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Array.Empty<byte>();
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, assignmentField) = BinaryDecoder.ReadBytes(buffer, index);
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
        private static DecodeResult<SyncGroupResponseData> ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Array.Empty<byte>();
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, assignmentField) = BinaryDecoder.ReadBytes(buffer, index);
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
        private static DecodeResult<SyncGroupResponseData> ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Array.Empty<byte>();
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, assignmentField) = BinaryDecoder.ReadBytes(buffer, index);
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
        private static DecodeResult<SyncGroupResponseData> ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Array.Empty<byte>();
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, assignmentField) = BinaryDecoder.ReadBytes(buffer, index);
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
        private static DecodeResult<SyncGroupResponseData> ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Array.Empty<byte>();
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, assignmentField) = BinaryDecoder.ReadCompactBytes(buffer, index);
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                    (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                    taggedFieldsBuilder.Add(new(tag, bytes));
                    taggedFieldsCount--;
                }
            }
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
        private static DecodeResult<SyncGroupResponseData> ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Array.Empty<byte>();
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, protocolNameField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, assignmentField) = BinaryDecoder.ReadCompactBytes(buffer, index);
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                    (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                    taggedFieldsBuilder.Add(new(tag, bytes));
                    taggedFieldsCount--;
                }
            }
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
    }
}
