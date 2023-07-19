using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using SyncGroupRequestAssignment = Kafka.Client.Messages.SyncGroupRequest.SyncGroupRequestAssignment;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SyncGroupRequestSerde
    {
        private static readonly ApiKey API_KEY = new(14);
        private static readonly VersionRange API_VERSIONS = new(0, 5);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (4, 32767);
        public static IEncoder<RequestHeader, SyncGroupRequest> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 5 ? apiVersion : new Version(5);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = RequestHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<RequestHeader, SyncGroupRequest>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<RequestHeader, SyncGroupRequest>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<RequestHeader, SyncGroupRequest>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<RequestHeader, SyncGroupRequest>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<RequestHeader, SyncGroupRequest>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<RequestHeader, SyncGroupRequest>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<RequestHeader, SyncGroupRequest> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 5 ? apiVersion : new Version(5);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = RequestHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<RequestHeader, SyncGroupRequest>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<RequestHeader, SyncGroupRequest>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<RequestHeader, SyncGroupRequest>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<RequestHeader, SyncGroupRequest>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<RequestHeader, SyncGroupRequest>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<RequestHeader, SyncGroupRequest>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, SyncGroupRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV0);
            return index;
        }
        private static (int Offset, SyncGroupRequest Value) ReadV0(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = ImmutableArray<SyncGroupRequestAssignment>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _assignmentsField_) = BinaryDecoder.ReadArray<SyncGroupRequestAssignment>(buffer, index, SyncGroupRequestAssignmentSerde.ReadV0);
            if (_assignmentsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Assignments'");
            else
                assignmentsField = _assignmentsField_.Value;
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolNameField,
                assignmentsField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, SyncGroupRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV1);
            return index;
        }
        private static (int Offset, SyncGroupRequest Value) ReadV1(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = ImmutableArray<SyncGroupRequestAssignment>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _assignmentsField_) = BinaryDecoder.ReadArray<SyncGroupRequestAssignment>(buffer, index, SyncGroupRequestAssignmentSerde.ReadV1);
            if (_assignmentsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Assignments'");
            else
                assignmentsField = _assignmentsField_.Value;
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolNameField,
                assignmentsField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, SyncGroupRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV2);
            return index;
        }
        private static (int Offset, SyncGroupRequest Value) ReadV2(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = ImmutableArray<SyncGroupRequestAssignment>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _assignmentsField_) = BinaryDecoder.ReadArray<SyncGroupRequestAssignment>(buffer, index, SyncGroupRequestAssignmentSerde.ReadV2);
            if (_assignmentsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Assignments'");
            else
                assignmentsField = _assignmentsField_.Value;
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolNameField,
                assignmentsField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, SyncGroupRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV3);
            return index;
        }
        private static (int Offset, SyncGroupRequest Value) ReadV3(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = ImmutableArray<SyncGroupRequestAssignment>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, groupInstanceIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, var _assignmentsField_) = BinaryDecoder.ReadArray<SyncGroupRequestAssignment>(buffer, index, SyncGroupRequestAssignmentSerde.ReadV3);
            if (_assignmentsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Assignments'");
            else
                assignmentsField = _assignmentsField_.Value;
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolNameField,
                assignmentsField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, SyncGroupRequest message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteCompactArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV4);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, SyncGroupRequest Value) ReadV4(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = ImmutableArray<SyncGroupRequestAssignment>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, var _assignmentsField_) = BinaryDecoder.ReadCompactArray<SyncGroupRequestAssignment>(buffer, index, SyncGroupRequestAssignmentSerde.ReadV4);
            if (_assignmentsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Assignments'");
            else
                assignmentsField = _assignmentsField_.Value;
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if(taggedFieldsCount > 0)
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
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolNameField,
                assignmentsField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, SyncGroupRequest message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ProtocolNameField);
            index = BinaryEncoder.WriteCompactArray<SyncGroupRequestAssignment>(buffer, index, message.AssignmentsField, SyncGroupRequestAssignmentSerde.WriteV5);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, SyncGroupRequest Value) ReadV5(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentsField = ImmutableArray<SyncGroupRequestAssignment>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, protocolNameField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, var _assignmentsField_) = BinaryDecoder.ReadCompactArray<SyncGroupRequestAssignment>(buffer, index, SyncGroupRequestAssignmentSerde.ReadV5);
            if (_assignmentsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Assignments'");
            else
                assignmentsField = _assignmentsField_.Value;
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if(taggedFieldsCount > 0)
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
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolNameField,
                assignmentsField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class SyncGroupRequestAssignmentSerde
        {
            public static int WriteV0(byte[] buffer, int index, SyncGroupRequestAssignment message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.AssignmentField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, SyncGroupRequestAssignment Value) ReadV0(byte[] buffer, int index)
            {
                var memberIdField = "";
                var assignmentField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, assignmentField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    memberIdField,
                    assignmentField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, SyncGroupRequestAssignment message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.AssignmentField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, SyncGroupRequestAssignment Value) ReadV1(byte[] buffer, int index)
            {
                var memberIdField = "";
                var assignmentField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, assignmentField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    memberIdField,
                    assignmentField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, SyncGroupRequestAssignment message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.AssignmentField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, SyncGroupRequestAssignment Value) ReadV2(byte[] buffer, int index)
            {
                var memberIdField = "";
                var assignmentField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, assignmentField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    memberIdField,
                    assignmentField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, SyncGroupRequestAssignment message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.AssignmentField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, SyncGroupRequestAssignment Value) ReadV3(byte[] buffer, int index)
            {
                var memberIdField = "";
                var assignmentField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, assignmentField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    memberIdField,
                    assignmentField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, SyncGroupRequestAssignment message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, message.AssignmentField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, SyncGroupRequestAssignment Value) ReadV4(byte[] buffer, int index)
            {
                var memberIdField = "";
                var assignmentField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, assignmentField) = BinaryDecoder.ReadCompactBytes(buffer, index);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
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
                return (index, new(
                    memberIdField,
                    assignmentField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, SyncGroupRequestAssignment message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, message.AssignmentField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, SyncGroupRequestAssignment Value) ReadV5(byte[] buffer, int index)
            {
                var memberIdField = "";
                var assignmentField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, assignmentField) = BinaryDecoder.ReadCompactBytes(buffer, index);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
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
                return (index, new(
                    memberIdField,
                    assignmentField,
                    taggedFields
                ));
            }
        }
    }
}