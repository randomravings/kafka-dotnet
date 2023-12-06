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
    internal static class ResponseHeaderDecoder
    {
        internal static DecodeResult<ResponseHeaderData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var correlationIdField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, correlationIdField) = BinaryDecoder.ReadInt32(buffer, i);
            return new(i, new(
                correlationIdField,
                taggedFields
            ));
        }
        internal static DecodeResult<ResponseHeaderData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var correlationIdField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, correlationIdField) = BinaryDecoder.ReadInt32(buffer, i);
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
                correlationIdField,
                taggedFields
            ));
        }
    }
}
