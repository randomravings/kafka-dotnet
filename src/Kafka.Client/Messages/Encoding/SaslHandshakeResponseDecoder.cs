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
    internal class SaslHandshakeResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, SaslHandshakeResponseData>
    {
        internal SaslHandshakeResponseDecoder() :
            base(
                ApiKey.SaslHandshake,
                new(0, 1),
                new(32767, -32768),
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
        protected override DecodeValue<SaslHandshakeResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<SaslHandshakeResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var errorCodeField = default(short);
            var mechanismsField = ImmutableArray<string>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, mechanismsField) = BinaryDecoder.ReadArray<string>(buffer, i, BinaryDecoder.ReadString);
            if (mechanismsField.IsDefault)
                throw new InvalidDataException("mechanismsField was null");
;
            return new(i, new(
                errorCodeField,
                mechanismsField,
                taggedFields
            ));
        }
        private static DecodeResult<SaslHandshakeResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var errorCodeField = default(short);
            var mechanismsField = ImmutableArray<string>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, mechanismsField) = BinaryDecoder.ReadArray<string>(buffer, i, BinaryDecoder.ReadString);
            if (mechanismsField.IsDefault)
                throw new InvalidDataException("mechanismsField was null");
;
            return new(i, new(
                errorCodeField,
                mechanismsField,
                taggedFields
            ));
        }
    }
}
