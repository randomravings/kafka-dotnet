using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public static class ResponseHeaderDecoder
    {
        public static DecodeResult<ResponseHeaderData> ReadV0(byte[] buffer, int index)
        {
            var correlationIdField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, correlationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            return new(index, new(
                correlationIdField,
                taggedFields
            ));
        }
        public static DecodeResult<ResponseHeaderData> ReadV1(byte[] buffer, int index)
        {
            var correlationIdField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, correlationIdField) = BinaryDecoder.ReadInt32(buffer, index);
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
                correlationIdField,
                taggedFields
            ));
        }
    }
}
