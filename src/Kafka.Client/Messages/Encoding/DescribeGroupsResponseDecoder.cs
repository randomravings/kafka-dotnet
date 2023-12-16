using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using DescribedGroup = Kafka.Client.Messages.DescribeGroupsResponseData.DescribedGroup;
using DescribedGroupMember = Kafka.Client.Messages.DescribeGroupsResponseData.DescribedGroup.DescribedGroupMember;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class DescribeGroupsResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, DescribeGroupsResponseData>
    {
        internal DescribeGroupsResponseDecoder() :
            base(
                ApiKey.DescribeGroups,
                new(0, 5),
                new(5, 32767),
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
        protected override DecodeValue<DescribeGroupsResponseData> GetMessageDecoder(short apiVersion) =>
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
        private static DecodeResult<DescribeGroupsResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var groupsField = ImmutableArray<DescribedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, groupsField) = BinaryDecoder.ReadArray<DescribedGroup>(buffer, i, DescribedGroupDecoder.ReadV0);
            if (groupsField.IsDefault)
                throw new InvalidDataException("groupsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<DescribeGroupsResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var groupsField = ImmutableArray<DescribedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, groupsField) = BinaryDecoder.ReadArray<DescribedGroup>(buffer, i, DescribedGroupDecoder.ReadV1);
            if (groupsField.IsDefault)
                throw new InvalidDataException("groupsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<DescribeGroupsResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var groupsField = ImmutableArray<DescribedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, groupsField) = BinaryDecoder.ReadArray<DescribedGroup>(buffer, i, DescribedGroupDecoder.ReadV2);
            if (groupsField.IsDefault)
                throw new InvalidDataException("groupsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<DescribeGroupsResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var groupsField = ImmutableArray<DescribedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, groupsField) = BinaryDecoder.ReadArray<DescribedGroup>(buffer, i, DescribedGroupDecoder.ReadV3);
            if (groupsField.IsDefault)
                throw new InvalidDataException("groupsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<DescribeGroupsResponseData> ReadV4([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var groupsField = ImmutableArray<DescribedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, groupsField) = BinaryDecoder.ReadArray<DescribedGroup>(buffer, i, DescribedGroupDecoder.ReadV4);
            if (groupsField.IsDefault)
                throw new InvalidDataException("groupsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<DescribeGroupsResponseData> ReadV5([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var groupsField = ImmutableArray<DescribedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, groupsField) = BinaryDecoder.ReadCompactArray<DescribedGroup>(buffer, i, DescribedGroupDecoder.ReadV5);
            if (groupsField.IsDefault)
                throw new InvalidDataException("groupsField was null");
;
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
                groupsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class DescribedGroupDecoder
        {
            public static DecodeResult<DescribedGroup> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var groupIdField = "";
                var groupStateField = "";
                var protocolTypeField = "";
                var protocolDataField = "";
                var membersField = ImmutableArray<DescribedGroupMember>.Empty;
                var authorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, groupIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, groupStateField) = BinaryDecoder.ReadString(buffer, i);
                (i, protocolTypeField) = BinaryDecoder.ReadString(buffer, i);
                (i, protocolDataField) = BinaryDecoder.ReadString(buffer, i);
                (i, membersField) = BinaryDecoder.ReadArray<DescribedGroupMember>(buffer, i, DescribedGroupMemberDecoder.ReadV0);
                if (membersField.IsDefault)
                    throw new InvalidDataException("membersField was null");
;
                return new(i, new(
                    errorCodeField,
                    groupIdField,
                    groupStateField,
                    protocolTypeField,
                    protocolDataField,
                    membersField,
                    authorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<DescribedGroup> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var groupIdField = "";
                var groupStateField = "";
                var protocolTypeField = "";
                var protocolDataField = "";
                var membersField = ImmutableArray<DescribedGroupMember>.Empty;
                var authorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, groupIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, groupStateField) = BinaryDecoder.ReadString(buffer, i);
                (i, protocolTypeField) = BinaryDecoder.ReadString(buffer, i);
                (i, protocolDataField) = BinaryDecoder.ReadString(buffer, i);
                (i, membersField) = BinaryDecoder.ReadArray<DescribedGroupMember>(buffer, i, DescribedGroupMemberDecoder.ReadV1);
                if (membersField.IsDefault)
                    throw new InvalidDataException("membersField was null");
;
                return new(i, new(
                    errorCodeField,
                    groupIdField,
                    groupStateField,
                    protocolTypeField,
                    protocolDataField,
                    membersField,
                    authorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<DescribedGroup> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var groupIdField = "";
                var groupStateField = "";
                var protocolTypeField = "";
                var protocolDataField = "";
                var membersField = ImmutableArray<DescribedGroupMember>.Empty;
                var authorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, groupIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, groupStateField) = BinaryDecoder.ReadString(buffer, i);
                (i, protocolTypeField) = BinaryDecoder.ReadString(buffer, i);
                (i, protocolDataField) = BinaryDecoder.ReadString(buffer, i);
                (i, membersField) = BinaryDecoder.ReadArray<DescribedGroupMember>(buffer, i, DescribedGroupMemberDecoder.ReadV2);
                if (membersField.IsDefault)
                    throw new InvalidDataException("membersField was null");
;
                return new(i, new(
                    errorCodeField,
                    groupIdField,
                    groupStateField,
                    protocolTypeField,
                    protocolDataField,
                    membersField,
                    authorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<DescribedGroup> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var groupIdField = "";
                var groupStateField = "";
                var protocolTypeField = "";
                var protocolDataField = "";
                var membersField = ImmutableArray<DescribedGroupMember>.Empty;
                var authorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, groupIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, groupStateField) = BinaryDecoder.ReadString(buffer, i);
                (i, protocolTypeField) = BinaryDecoder.ReadString(buffer, i);
                (i, protocolDataField) = BinaryDecoder.ReadString(buffer, i);
                (i, membersField) = BinaryDecoder.ReadArray<DescribedGroupMember>(buffer, i, DescribedGroupMemberDecoder.ReadV3);
                if (membersField.IsDefault)
                    throw new InvalidDataException("membersField was null");
;
                (i, authorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, i);
                return new(i, new(
                    errorCodeField,
                    groupIdField,
                    groupStateField,
                    protocolTypeField,
                    protocolDataField,
                    membersField,
                    authorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<DescribedGroup> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var groupIdField = "";
                var groupStateField = "";
                var protocolTypeField = "";
                var protocolDataField = "";
                var membersField = ImmutableArray<DescribedGroupMember>.Empty;
                var authorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, groupIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, groupStateField) = BinaryDecoder.ReadString(buffer, i);
                (i, protocolTypeField) = BinaryDecoder.ReadString(buffer, i);
                (i, protocolDataField) = BinaryDecoder.ReadString(buffer, i);
                (i, membersField) = BinaryDecoder.ReadArray<DescribedGroupMember>(buffer, i, DescribedGroupMemberDecoder.ReadV4);
                if (membersField.IsDefault)
                    throw new InvalidDataException("membersField was null");
;
                (i, authorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, i);
                return new(i, new(
                    errorCodeField,
                    groupIdField,
                    groupStateField,
                    protocolTypeField,
                    protocolDataField,
                    membersField,
                    authorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<DescribedGroup> ReadV5([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var groupIdField = "";
                var groupStateField = "";
                var protocolTypeField = "";
                var protocolDataField = "";
                var membersField = ImmutableArray<DescribedGroupMember>.Empty;
                var authorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, groupIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, groupStateField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, protocolTypeField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, protocolDataField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, membersField) = BinaryDecoder.ReadCompactArray<DescribedGroupMember>(buffer, i, DescribedGroupMemberDecoder.ReadV5);
                if (membersField.IsDefault)
                    throw new InvalidDataException("membersField was null");
;
                (i, authorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, i);
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
                    groupIdField,
                    groupStateField,
                    protocolTypeField,
                    protocolDataField,
                    membersField,
                    authorizedOperationsField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class DescribedGroupMemberDecoder
            {
                public static DecodeResult<DescribedGroupMember> ReadV0([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var memberIdField = "";
                    var groupInstanceIdField = default(string?);
                    var clientIdField = "";
                    var clientHostField = "";
                    var memberMetadataField = Array.Empty<byte>();
                    var memberAssignmentField = Array.Empty<byte>();
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
                    (i, clientIdField) = BinaryDecoder.ReadString(buffer, i);
                    (i, clientHostField) = BinaryDecoder.ReadString(buffer, i);
                    (i, memberMetadataField) = BinaryDecoder.ReadBytes(buffer, i);
                    (i, memberAssignmentField) = BinaryDecoder.ReadBytes(buffer, i);
                    return new(i, new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField,
                        taggedFields
                    ));
                }
                public static DecodeResult<DescribedGroupMember> ReadV1([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var memberIdField = "";
                    var groupInstanceIdField = default(string?);
                    var clientIdField = "";
                    var clientHostField = "";
                    var memberMetadataField = Array.Empty<byte>();
                    var memberAssignmentField = Array.Empty<byte>();
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
                    (i, clientIdField) = BinaryDecoder.ReadString(buffer, i);
                    (i, clientHostField) = BinaryDecoder.ReadString(buffer, i);
                    (i, memberMetadataField) = BinaryDecoder.ReadBytes(buffer, i);
                    (i, memberAssignmentField) = BinaryDecoder.ReadBytes(buffer, i);
                    return new(i, new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField,
                        taggedFields
                    ));
                }
                public static DecodeResult<DescribedGroupMember> ReadV2([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var memberIdField = "";
                    var groupInstanceIdField = default(string?);
                    var clientIdField = "";
                    var clientHostField = "";
                    var memberMetadataField = Array.Empty<byte>();
                    var memberAssignmentField = Array.Empty<byte>();
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
                    (i, clientIdField) = BinaryDecoder.ReadString(buffer, i);
                    (i, clientHostField) = BinaryDecoder.ReadString(buffer, i);
                    (i, memberMetadataField) = BinaryDecoder.ReadBytes(buffer, i);
                    (i, memberAssignmentField) = BinaryDecoder.ReadBytes(buffer, i);
                    return new(i, new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField,
                        taggedFields
                    ));
                }
                public static DecodeResult<DescribedGroupMember> ReadV3([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var memberIdField = "";
                    var groupInstanceIdField = default(string?);
                    var clientIdField = "";
                    var clientHostField = "";
                    var memberMetadataField = Array.Empty<byte>();
                    var memberAssignmentField = Array.Empty<byte>();
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
                    (i, clientIdField) = BinaryDecoder.ReadString(buffer, i);
                    (i, clientHostField) = BinaryDecoder.ReadString(buffer, i);
                    (i, memberMetadataField) = BinaryDecoder.ReadBytes(buffer, i);
                    (i, memberAssignmentField) = BinaryDecoder.ReadBytes(buffer, i);
                    return new(i, new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField,
                        taggedFields
                    ));
                }
                public static DecodeResult<DescribedGroupMember> ReadV4([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var memberIdField = "";
                    var groupInstanceIdField = default(string?);
                    var clientIdField = "";
                    var clientHostField = "";
                    var memberMetadataField = Array.Empty<byte>();
                    var memberAssignmentField = Array.Empty<byte>();
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
                    (i, groupInstanceIdField) = BinaryDecoder.ReadNullableString(buffer, i);
                    (i, clientIdField) = BinaryDecoder.ReadString(buffer, i);
                    (i, clientHostField) = BinaryDecoder.ReadString(buffer, i);
                    (i, memberMetadataField) = BinaryDecoder.ReadBytes(buffer, i);
                    (i, memberAssignmentField) = BinaryDecoder.ReadBytes(buffer, i);
                    return new(i, new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField,
                        taggedFields
                    ));
                }
                public static DecodeResult<DescribedGroupMember> ReadV5([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var memberIdField = "";
                    var groupInstanceIdField = default(string?);
                    var clientIdField = "";
                    var clientHostField = "";
                    var memberMetadataField = Array.Empty<byte>();
                    var memberAssignmentField = Array.Empty<byte>();
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, memberIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                    (i, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                    (i, clientIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                    (i, clientHostField) = BinaryDecoder.ReadCompactString(buffer, i);
                    (i, memberMetadataField) = BinaryDecoder.ReadCompactBytes(buffer, i);
                    (i, memberAssignmentField) = BinaryDecoder.ReadCompactBytes(buffer, i);
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
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField,
                        taggedFields
                    ));
                }
            }
        }
    }
}
