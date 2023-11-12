using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using ListedGroup = Kafka.Client.Messages.ListGroupsResponseData.ListedGroup;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class ListGroupsResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, ListGroupsResponseData>
    {
        public ListGroupsResponseDecoder() :
            base(
                ApiKey.ListGroups,
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
        protected override DecodeDelegate<ListGroupsResponseData> GetMessageDecoder(short apiVersion) =>
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
        private static DecodeResult<ListGroupsResponseData> ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _groupsField_) = BinaryDecoder.ReadArray<ListedGroup>(buffer, index, ListedGroupDecoder.ReadV0);
            if (_groupsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Groups'");
            else
                groupsField = _groupsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListGroupsResponseData> ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _groupsField_) = BinaryDecoder.ReadArray<ListedGroup>(buffer, index, ListedGroupDecoder.ReadV1);
            if (_groupsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Groups'");
            else
                groupsField = _groupsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListGroupsResponseData> ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _groupsField_) = BinaryDecoder.ReadArray<ListedGroup>(buffer, index, ListedGroupDecoder.ReadV2);
            if (_groupsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Groups'");
            else
                groupsField = _groupsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListGroupsResponseData> ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _groupsField_) = BinaryDecoder.ReadCompactArray<ListedGroup>(buffer, index, ListedGroupDecoder.ReadV3);
            if (_groupsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Groups'");
            else
                groupsField = _groupsField_.Value;
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
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListGroupsResponseData> ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _groupsField_) = BinaryDecoder.ReadCompactArray<ListedGroup>(buffer, index, ListedGroupDecoder.ReadV4);
            if (_groupsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Groups'");
            else
                groupsField = _groupsField_.Value;
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
                groupsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class ListedGroupDecoder
        {
            public static DecodeResult<ListedGroup> ReadV0(byte[] buffer, int index)
            {
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, protocolTypeField) = BinaryDecoder.ReadString(buffer, index);
                return new(index, new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListedGroup> ReadV1(byte[] buffer, int index)
            {
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, protocolTypeField) = BinaryDecoder.ReadString(buffer, index);
                return new(index, new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListedGroup> ReadV2(byte[] buffer, int index)
            {
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, protocolTypeField) = BinaryDecoder.ReadString(buffer, index);
                return new(index, new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListedGroup> ReadV3(byte[] buffer, int index)
            {
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, protocolTypeField) = BinaryDecoder.ReadCompactString(buffer, index);
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
                    groupIdField,
                    protocolTypeField,
                    groupStateField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListedGroup> ReadV4(byte[] buffer, int index)
            {
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, protocolTypeField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupStateField) = BinaryDecoder.ReadCompactString(buffer, index);
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
                    groupIdField,
                    protocolTypeField,
                    groupStateField,
                    taggedFields
                ));
            }
        }
    }
}
