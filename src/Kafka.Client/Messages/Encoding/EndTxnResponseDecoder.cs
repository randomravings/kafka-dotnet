using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class EndTxnResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, EndTxnResponseData>
    {
        internal EndTxnResponseDecoder() :
            base(
                ApiKey.EndTxn,
                new(0, 3),
                new(3, 32767),
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
        protected override DecodeDelegate<EndTxnResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                3 => ReadV3,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<EndTxnResponseData> ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                taggedFields
            ));
        }
        private static DecodeResult<EndTxnResponseData> ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                taggedFields
            ));
        }
        private static DecodeResult<EndTxnResponseData> ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                taggedFields
            ));
        }
        private static DecodeResult<EndTxnResponseData> ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                taggedFields
            ));
        }
    }
}
