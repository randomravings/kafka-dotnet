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
    internal class SaslAuthenticateResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, SaslAuthenticateResponseData>
    {
        internal SaslAuthenticateResponseDecoder() :
            base(
                ApiKey.SaslAuthenticate,
                new(0, 2),
                new(2, 32767),
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
        protected override DecodeValue<SaslAuthenticateResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<SaslAuthenticateResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var authBytesField = Array.Empty<byte>();
            var sessionLifetimeMsField = default(long);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
            (i, authBytesField) = BinaryDecoder.ReadBytes(buffer, i);
            return new(i, new(
                errorCodeField,
                errorMessageField,
                authBytesField,
                sessionLifetimeMsField,
                taggedFields
            ));
        }
        private static DecodeResult<SaslAuthenticateResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var authBytesField = Array.Empty<byte>();
            var sessionLifetimeMsField = default(long);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
            (i, authBytesField) = BinaryDecoder.ReadBytes(buffer, i);
            (i, sessionLifetimeMsField) = BinaryDecoder.ReadInt64(buffer, i);
            return new(i, new(
                errorCodeField,
                errorMessageField,
                authBytesField,
                sessionLifetimeMsField,
                taggedFields
            ));
        }
        private static DecodeResult<SaslAuthenticateResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var authBytesField = Array.Empty<byte>();
            var sessionLifetimeMsField = default(long);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, authBytesField) = BinaryDecoder.ReadCompactBytes(buffer, i);
            (i, sessionLifetimeMsField) = BinaryDecoder.ReadInt64(buffer, i);
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
                errorCodeField,
                errorMessageField,
                authBytesField,
                sessionLifetimeMsField,
                taggedFields
            ));
        }
    }
}
