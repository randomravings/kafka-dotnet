using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class SyncGroupResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, SyncGroupResponseData>
    {
        internal SyncGroupResponseDecoder() :
            base(
                ApiKey.SyncGroup,
                new(0, 5),
                new(4, 32767),
                ResponseHeaderDecoder.ReadV0,
                ReadV0
            )
        { }
        protected override DecodeValue<ResponseHeaderData> GetHeaderDecoder(short apiVersion)
        {
            if (FlexibleVersions.Includes(apiVersion))
                return ResponseHeaderDecoder.ReadV1;
            else
                return ResponseHeaderDecoder.ReadV0;
        }
        protected override DecodeValue<SyncGroupResponseData> GetMessageDecoder(short apiVersion) =>
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
        private static DecodeResult<SyncGroupResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Array.Empty<byte>();
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, assignmentField) = BinaryDecoder.ReadBytes(buffer, i);
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
        private static DecodeResult<SyncGroupResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Array.Empty<byte>();
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, assignmentField) = BinaryDecoder.ReadBytes(buffer, i);
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
        private static DecodeResult<SyncGroupResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Array.Empty<byte>();
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, assignmentField) = BinaryDecoder.ReadBytes(buffer, i);
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
        private static DecodeResult<SyncGroupResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Array.Empty<byte>();
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, assignmentField) = BinaryDecoder.ReadBytes(buffer, i);
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
        private static DecodeResult<SyncGroupResponseData> ReadV4([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Array.Empty<byte>();
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, assignmentField) = BinaryDecoder.ReadCompactBytes(buffer, i);
            (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                    (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                    taggedFieldsBuilder.Add(new(tag, bytes));
                    taggedFieldsCount--;
                }
            }
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField,
                taggedFields
            ));
        }
        private static DecodeResult<SyncGroupResponseData> ReadV5([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Array.Empty<byte>();
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, protocolTypeField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, protocolNameField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, assignmentField) = BinaryDecoder.ReadCompactBytes(buffer, i);
            (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                    (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                    taggedFieldsBuilder.Add(new(tag, bytes));
                    taggedFieldsCount--;
                }
            }
            return new(i, new(
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
