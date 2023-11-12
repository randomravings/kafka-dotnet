using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Coordinator = Kafka.Client.Messages.FindCoordinatorResponseData.Coordinator;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class FindCoordinatorResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, FindCoordinatorResponseData>
    {
        public FindCoordinatorResponseDecoder() :
            base(
                ApiKey.FindCoordinator,
                new(0, 4),
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
        protected override DecodeDelegate<FindCoordinatorResponseData> GetMessageDecoder(short apiVersion) =>
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
        private static DecodeResult<FindCoordinatorResponseData> ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, hostField) = BinaryDecoder.ReadString(buffer, index);
            (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
            return new(index, new(
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
        private static DecodeResult<FindCoordinatorResponseData> ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, hostField) = BinaryDecoder.ReadString(buffer, index);
            (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
            return new(index, new(
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
        private static DecodeResult<FindCoordinatorResponseData> ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, hostField) = BinaryDecoder.ReadString(buffer, index);
            (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
            return new(index, new(
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
        private static DecodeResult<FindCoordinatorResponseData> ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, hostField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
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
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField,
                taggedFields
            ));
        }
        private static DecodeResult<FindCoordinatorResponseData> ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _coordinatorsField_) = BinaryDecoder.ReadCompactArray<Coordinator>(buffer, index, CoordinatorDecoder.ReadV4);
            if (_coordinatorsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Coordinators'");
            else
                coordinatorsField = _coordinatorsField_.Value;
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
            public static DecodeResult<Coordinator> ReadV0(byte[] buffer, int index)
            {
                var keyField = "";
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<Coordinator> ReadV1(byte[] buffer, int index)
            {
                var keyField = "";
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<Coordinator> ReadV2(byte[] buffer, int index)
            {
                var keyField = "";
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<Coordinator> ReadV3(byte[] buffer, int index)
            {
                var keyField = "";
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
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
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<Coordinator> ReadV4(byte[] buffer, int index)
            {
                var keyField = "";
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, keyField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
