using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Coordinator = Kafka.Client.Messages.FindCoordinatorResponseData.Coordinator;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class FindCoordinatorResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, FindCoordinatorResponseData>
    {
        internal FindCoordinatorResponseDecoder() :
            base(
                ApiKey.FindCoordinator,
                new(0, 4),
                new(3, 32767),
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
        protected override DecodeValue<FindCoordinatorResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                3 => ReadV3,
                4 => ReadV4,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<FindCoordinatorResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, hostField) = BinaryDecoder.ReadString(buffer, i);
            (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField,
                taggedFields
            ));
        }
        private static DecodeResult<FindCoordinatorResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
            (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, hostField) = BinaryDecoder.ReadString(buffer, i);
            (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField,
                taggedFields
            ));
        }
        private static DecodeResult<FindCoordinatorResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
            (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, hostField) = BinaryDecoder.ReadString(buffer, i);
            (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField,
                taggedFields
            ));
        }
        private static DecodeResult<FindCoordinatorResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, hostField) = BinaryDecoder.ReadCompactString(buffer, i);
            (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
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
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField,
                taggedFields
            ));
        }
        private static DecodeResult<FindCoordinatorResponseData> ReadV4([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _coordinatorsField_) = BinaryDecoder.ReadCompactArray<Coordinator>(buffer, i, CoordinatorDecoder.ReadV4);
            if (_coordinatorsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Coordinators'");
            else
                coordinatorsField = _coordinatorsField_.Value;
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
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class CoordinatorDecoder
        {
            public static DecodeResult<Coordinator> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var keyField = "";
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<Coordinator> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var keyField = "";
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<Coordinator> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var keyField = "";
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<Coordinator> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var keyField = "";
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
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
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<Coordinator> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var keyField = "";
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, keyField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, hostField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
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
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
        }
    }
}
