using CreatableReplicaAssignment = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic.CreatableReplicaAssignment;
using CreatableTopic = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic;
using CreateableTopicConfig = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic.CreateableTopicConfig;
using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateTopicsRequestSerde
    {
        private static readonly ApiKey API_KEY = new(19);
        private static readonly VersionRange API_VERSIONS = new(0, 7);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (5, 32767);
        public static IEncoder<RequestHeader, CreateTopicsRequest> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 7 ? apiVersion : new Version(7);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = RequestHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<RequestHeader, CreateTopicsRequest>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<RequestHeader, CreateTopicsRequest>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<RequestHeader, CreateTopicsRequest>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<RequestHeader, CreateTopicsRequest>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<RequestHeader, CreateTopicsRequest>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<RequestHeader, CreateTopicsRequest>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<RequestHeader, CreateTopicsRequest>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                case 7:
                    return new Encoder<RequestHeader, CreateTopicsRequest>(API_KEY, 7, flexible, headerEncoder, WriteV7);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<RequestHeader, CreateTopicsRequest> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 7 ? apiVersion : new Version(7);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = RequestHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<RequestHeader, CreateTopicsRequest>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<RequestHeader, CreateTopicsRequest>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<RequestHeader, CreateTopicsRequest>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<RequestHeader, CreateTopicsRequest>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<RequestHeader, CreateTopicsRequest>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<RequestHeader, CreateTopicsRequest>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<RequestHeader, CreateTopicsRequest>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                case 7:
                    return new Decoder<RequestHeader, CreateTopicsRequest>(API_KEY, 7, flexible, headerDecoder, ReadV7);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = BinaryEncoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV0);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static (int Offset, CreateTopicsRequest Value) ReadV0(byte[] buffer, int index)
        {
            var topicsField = ImmutableArray<CreatableTopic>.Empty;
            var timeoutMsField = default(int);
            var validateOnlyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                topicsField,
                timeoutMsField,
                validateOnlyField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = BinaryEncoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV1);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            return index;
        }
        private static (int Offset, CreateTopicsRequest Value) ReadV1(byte[] buffer, int index)
        {
            var topicsField = ImmutableArray<CreatableTopic>.Empty;
            var timeoutMsField = default(int);
            var validateOnlyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, validateOnlyField) = BinaryDecoder.ReadBoolean(buffer, index);
            return (index, new(
                topicsField,
                timeoutMsField,
                validateOnlyField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = BinaryEncoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV2);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            return index;
        }
        private static (int Offset, CreateTopicsRequest Value) ReadV2(byte[] buffer, int index)
        {
            var topicsField = ImmutableArray<CreatableTopic>.Empty;
            var timeoutMsField = default(int);
            var validateOnlyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, validateOnlyField) = BinaryDecoder.ReadBoolean(buffer, index);
            return (index, new(
                topicsField,
                timeoutMsField,
                validateOnlyField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = BinaryEncoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV3);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            return index;
        }
        private static (int Offset, CreateTopicsRequest Value) ReadV3(byte[] buffer, int index)
        {
            var topicsField = ImmutableArray<CreatableTopic>.Empty;
            var timeoutMsField = default(int);
            var validateOnlyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV3);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, validateOnlyField) = BinaryDecoder.ReadBoolean(buffer, index);
            return (index, new(
                topicsField,
                timeoutMsField,
                validateOnlyField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = BinaryEncoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV4);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            return index;
        }
        private static (int Offset, CreateTopicsRequest Value) ReadV4(byte[] buffer, int index)
        {
            var topicsField = ImmutableArray<CreatableTopic>.Empty;
            var timeoutMsField = default(int);
            var validateOnlyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV4);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, validateOnlyField) = BinaryDecoder.ReadBoolean(buffer, index);
            return (index, new(
                topicsField,
                timeoutMsField,
                validateOnlyField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = BinaryEncoder.WriteCompactArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV5);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
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
        private static (int Offset, CreateTopicsRequest Value) ReadV5(byte[] buffer, int index)
        {
            var topicsField = ImmutableArray<CreatableTopic>.Empty;
            var timeoutMsField = default(int);
            var validateOnlyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV5);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, validateOnlyField) = BinaryDecoder.ReadBoolean(buffer, index);
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
                topicsField,
                timeoutMsField,
                validateOnlyField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = BinaryEncoder.WriteCompactArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV6);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
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
        private static (int Offset, CreateTopicsRequest Value) ReadV6(byte[] buffer, int index)
        {
            var topicsField = ImmutableArray<CreatableTopic>.Empty;
            var timeoutMsField = default(int);
            var validateOnlyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV6);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, validateOnlyField) = BinaryDecoder.ReadBoolean(buffer, index);
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
                topicsField,
                timeoutMsField,
                validateOnlyField,
                taggedFields
            ));
        }
        private static int WriteV7(byte[] buffer, int index, CreateTopicsRequest message)
        {
            index = BinaryEncoder.WriteCompactArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicSerde.WriteV7);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
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
        private static (int Offset, CreateTopicsRequest Value) ReadV7(byte[] buffer, int index)
        {
            var topicsField = ImmutableArray<CreatableTopic>.Empty;
            var timeoutMsField = default(int);
            var validateOnlyField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<CreatableTopic>(buffer, index, CreatableTopicSerde.ReadV7);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, validateOnlyField) = BinaryDecoder.ReadBoolean(buffer, index);
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
                topicsField,
                timeoutMsField,
                validateOnlyField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class CreatableTopicSerde
        {
            public static int WriteV0(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV0);
                index = BinaryEncoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV0);
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
            public static (int Offset, CreatableTopic Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var assignmentsField = ImmutableArray<CreatableReplicaAssignment>.Empty;
                var configsField = ImmutableArray<CreateableTopicConfig>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, numPartitionsField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, replicationFactorField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, var _assignmentsField_) = BinaryDecoder.ReadArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV0);
                if (_assignmentsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Assignments'");
                else
                    assignmentsField = _assignmentsField_.Value;
                (index, var _configsField_) = BinaryDecoder.ReadArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV0);
                if (_configsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Configs'");
                else
                    configsField = _configsField_.Value;
                return (index, new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV1);
                index = BinaryEncoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV1);
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
            public static (int Offset, CreatableTopic Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var assignmentsField = ImmutableArray<CreatableReplicaAssignment>.Empty;
                var configsField = ImmutableArray<CreateableTopicConfig>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, numPartitionsField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, replicationFactorField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, var _assignmentsField_) = BinaryDecoder.ReadArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV1);
                if (_assignmentsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Assignments'");
                else
                    assignmentsField = _assignmentsField_.Value;
                (index, var _configsField_) = BinaryDecoder.ReadArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV1);
                if (_configsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Configs'");
                else
                    configsField = _configsField_.Value;
                return (index, new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV2);
                index = BinaryEncoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV2);
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
            public static (int Offset, CreatableTopic Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var assignmentsField = ImmutableArray<CreatableReplicaAssignment>.Empty;
                var configsField = ImmutableArray<CreateableTopicConfig>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, numPartitionsField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, replicationFactorField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, var _assignmentsField_) = BinaryDecoder.ReadArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV2);
                if (_assignmentsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Assignments'");
                else
                    assignmentsField = _assignmentsField_.Value;
                (index, var _configsField_) = BinaryDecoder.ReadArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV2);
                if (_configsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Configs'");
                else
                    configsField = _configsField_.Value;
                return (index, new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV3);
                index = BinaryEncoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV3);
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
            public static (int Offset, CreatableTopic Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var assignmentsField = ImmutableArray<CreatableReplicaAssignment>.Empty;
                var configsField = ImmutableArray<CreateableTopicConfig>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, numPartitionsField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, replicationFactorField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, var _assignmentsField_) = BinaryDecoder.ReadArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV3);
                if (_assignmentsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Assignments'");
                else
                    assignmentsField = _assignmentsField_.Value;
                (index, var _configsField_) = BinaryDecoder.ReadArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV3);
                if (_configsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Configs'");
                else
                    configsField = _configsField_.Value;
                return (index, new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV4);
                index = BinaryEncoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV4);
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
            public static (int Offset, CreatableTopic Value) ReadV4(byte[] buffer, int index)
            {
                var nameField = "";
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var assignmentsField = ImmutableArray<CreatableReplicaAssignment>.Empty;
                var configsField = ImmutableArray<CreateableTopicConfig>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, numPartitionsField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, replicationFactorField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, var _assignmentsField_) = BinaryDecoder.ReadArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV4);
                if (_assignmentsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Assignments'");
                else
                    assignmentsField = _assignmentsField_.Value;
                (index, var _configsField_) = BinaryDecoder.ReadArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV4);
                if (_configsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Configs'");
                else
                    configsField = _configsField_.Value;
                return (index, new(
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV5);
                index = BinaryEncoder.WriteCompactArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV5);
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
            public static (int Offset, CreatableTopic Value) ReadV5(byte[] buffer, int index)
            {
                var nameField = "";
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var assignmentsField = ImmutableArray<CreatableReplicaAssignment>.Empty;
                var configsField = ImmutableArray<CreateableTopicConfig>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, numPartitionsField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, replicationFactorField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, var _assignmentsField_) = BinaryDecoder.ReadCompactArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV5);
                if (_assignmentsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Assignments'");
                else
                    assignmentsField = _assignmentsField_.Value;
                (index, var _configsField_) = BinaryDecoder.ReadCompactArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV5);
                if (_configsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Configs'");
                else
                    configsField = _configsField_.Value;
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
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV6);
                index = BinaryEncoder.WriteCompactArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV6);
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
            public static (int Offset, CreatableTopic Value) ReadV6(byte[] buffer, int index)
            {
                var nameField = "";
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var assignmentsField = ImmutableArray<CreatableReplicaAssignment>.Empty;
                var configsField = ImmutableArray<CreateableTopicConfig>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, numPartitionsField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, replicationFactorField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, var _assignmentsField_) = BinaryDecoder.ReadCompactArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV6);
                if (_assignmentsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Assignments'");
                else
                    assignmentsField = _assignmentsField_.Value;
                (index, var _configsField_) = BinaryDecoder.ReadCompactArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV6);
                if (_configsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Configs'");
                else
                    configsField = _configsField_.Value;
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
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField,
                    taggedFields
                ));
            }
            public static int WriteV7(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentSerde.WriteV7);
                index = BinaryEncoder.WriteCompactArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigSerde.WriteV7);
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
            public static (int Offset, CreatableTopic Value) ReadV7(byte[] buffer, int index)
            {
                var nameField = "";
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var assignmentsField = ImmutableArray<CreatableReplicaAssignment>.Empty;
                var configsField = ImmutableArray<CreateableTopicConfig>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, numPartitionsField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, replicationFactorField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, var _assignmentsField_) = BinaryDecoder.ReadCompactArray<CreatableReplicaAssignment>(buffer, index, CreatableReplicaAssignmentSerde.ReadV7);
                if (_assignmentsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Assignments'");
                else
                    assignmentsField = _assignmentsField_.Value;
                (index, var _configsField_) = BinaryDecoder.ReadCompactArray<CreateableTopicConfig>(buffer, index, CreateableTopicConfigSerde.ReadV7);
                if (_configsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Configs'");
                else
                    configsField = _configsField_.Value;
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
                    nameField,
                    numPartitionsField,
                    replicationFactorField,
                    assignmentsField,
                    configsField,
                    taggedFields
                ));
            }
            [GeneratedCode("kgen", "1.0.0.0")]
            private static class CreatableReplicaAssignmentSerde
            {
                public static int WriteV0(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.BrokerIdsField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, CreatableReplicaAssignment Value) ReadV0(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var brokerIdsField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _brokerIdsField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_brokerIdsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    else
                        brokerIdsField = _brokerIdsField_.Value;
                    return (index, new(
                        partitionIndexField,
                        brokerIdsField,
                        taggedFields
                    ));
                }
                public static int WriteV1(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.BrokerIdsField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, CreatableReplicaAssignment Value) ReadV1(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var brokerIdsField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _brokerIdsField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_brokerIdsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    else
                        brokerIdsField = _brokerIdsField_.Value;
                    return (index, new(
                        partitionIndexField,
                        brokerIdsField,
                        taggedFields
                    ));
                }
                public static int WriteV2(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.BrokerIdsField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, CreatableReplicaAssignment Value) ReadV2(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var brokerIdsField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _brokerIdsField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_brokerIdsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    else
                        brokerIdsField = _brokerIdsField_.Value;
                    return (index, new(
                        partitionIndexField,
                        brokerIdsField,
                        taggedFields
                    ));
                }
                public static int WriteV3(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.BrokerIdsField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, CreatableReplicaAssignment Value) ReadV3(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var brokerIdsField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _brokerIdsField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_brokerIdsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    else
                        brokerIdsField = _brokerIdsField_.Value;
                    return (index, new(
                        partitionIndexField,
                        brokerIdsField,
                        taggedFields
                    ));
                }
                public static int WriteV4(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.BrokerIdsField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, CreatableReplicaAssignment Value) ReadV4(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var brokerIdsField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _brokerIdsField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_brokerIdsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    else
                        brokerIdsField = _brokerIdsField_.Value;
                    return (index, new(
                        partitionIndexField,
                        brokerIdsField,
                        taggedFields
                    ));
                }
                public static int WriteV5(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.BrokerIdsField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, CreatableReplicaAssignment Value) ReadV5(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var brokerIdsField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _brokerIdsField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_brokerIdsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    else
                        brokerIdsField = _brokerIdsField_.Value;
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
                        partitionIndexField,
                        brokerIdsField,
                        taggedFields
                    ));
                }
                public static int WriteV6(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.BrokerIdsField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, CreatableReplicaAssignment Value) ReadV6(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var brokerIdsField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _brokerIdsField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_brokerIdsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    else
                        brokerIdsField = _brokerIdsField_.Value;
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
                        partitionIndexField,
                        brokerIdsField,
                        taggedFields
                    ));
                }
                public static int WriteV7(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.BrokerIdsField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, CreatableReplicaAssignment Value) ReadV7(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var brokerIdsField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _brokerIdsField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_brokerIdsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'BrokerIds'");
                    else
                        brokerIdsField = _brokerIdsField_.Value;
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
                        partitionIndexField,
                        brokerIdsField,
                        taggedFields
                    ));
                }
            }
            [GeneratedCode("kgen", "1.0.0.0")]
            private static class CreateableTopicConfigSerde
            {
                public static int WriteV0(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.ValueField);
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
                public static (int Offset, CreateableTopicConfig Value) ReadV0(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                    (index, valueField) = BinaryDecoder.ReadNullableString(buffer, index);
                    return (index, new(
                        nameField,
                        valueField,
                        taggedFields
                    ));
                }
                public static int WriteV1(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.ValueField);
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
                public static (int Offset, CreateableTopicConfig Value) ReadV1(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                    (index, valueField) = BinaryDecoder.ReadNullableString(buffer, index);
                    return (index, new(
                        nameField,
                        valueField,
                        taggedFields
                    ));
                }
                public static int WriteV2(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.ValueField);
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
                public static (int Offset, CreateableTopicConfig Value) ReadV2(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                    (index, valueField) = BinaryDecoder.ReadNullableString(buffer, index);
                    return (index, new(
                        nameField,
                        valueField,
                        taggedFields
                    ));
                }
                public static int WriteV3(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.ValueField);
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
                public static (int Offset, CreateableTopicConfig Value) ReadV3(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                    (index, valueField) = BinaryDecoder.ReadNullableString(buffer, index);
                    return (index, new(
                        nameField,
                        valueField,
                        taggedFields
                    ));
                }
                public static int WriteV4(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.ValueField);
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
                public static (int Offset, CreateableTopicConfig Value) ReadV4(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                    (index, valueField) = BinaryDecoder.ReadNullableString(buffer, index);
                    return (index, new(
                        nameField,
                        valueField,
                        taggedFields
                    ));
                }
                public static int WriteV5(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ValueField);
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
                public static (int Offset, CreateableTopicConfig Value) ReadV5(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                    (index, valueField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                        nameField,
                        valueField,
                        taggedFields
                    ));
                }
                public static int WriteV6(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ValueField);
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
                public static (int Offset, CreateableTopicConfig Value) ReadV6(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                    (index, valueField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                        nameField,
                        valueField,
                        taggedFields
                    ));
                }
                public static int WriteV7(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ValueField);
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
                public static (int Offset, CreateableTopicConfig Value) ReadV7(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                    (index, valueField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                        nameField,
                        valueField,
                        taggedFields
                    ));
                }
            }
        }
    }
}