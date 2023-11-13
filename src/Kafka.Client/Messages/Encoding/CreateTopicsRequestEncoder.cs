using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using CreateableTopicConfig = Kafka.Client.Messages.CreateTopicsRequestData.CreatableTopic.CreateableTopicConfig;
using CreatableTopic = Kafka.Client.Messages.CreateTopicsRequestData.CreatableTopic;
using CreatableReplicaAssignment = Kafka.Client.Messages.CreateTopicsRequestData.CreatableTopic.CreatableReplicaAssignment;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class CreateTopicsRequestEncoder : 
        RequestEncoder<RequestHeaderData, CreateTopicsRequestData>
    {
        public CreateTopicsRequestEncoder() :
            base(
                ApiKey.CreateTopics,
                new(0, 7),
                new(5, 32767),
                RequestHeaderEncoder.WriteV0,
                WriteV0
            )
        { }
        protected override EncodeDelegate<RequestHeaderData> GetHeaderEncoder(short apiVersion)
        {
            if (_flexibleVersions.Includes(apiVersion))
                return RequestHeaderEncoder.WriteV2;
            else
                return RequestHeaderEncoder.WriteV1;
        }
        protected override EncodeDelegate<CreateTopicsRequestData> GetMessageEncoder(short apiVersion) =>
            apiVersion switch
            {
                0 => WriteV0,
                1 => WriteV1,
                2 => WriteV2,
                3 => WriteV3,
                4 => WriteV4,
                5 => WriteV5,
                6 => WriteV6,
                7 => WriteV7,
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0(byte[] buffer, int index, CreateTopicsRequestData message)
        {
            index = BinaryEncoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicEncoder.WriteV0);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static int WriteV1(byte[] buffer, int index, CreateTopicsRequestData message)
        {
            index = BinaryEncoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicEncoder.WriteV1);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            return index;
        }
        private static int WriteV2(byte[] buffer, int index, CreateTopicsRequestData message)
        {
            index = BinaryEncoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicEncoder.WriteV2);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            return index;
        }
        private static int WriteV3(byte[] buffer, int index, CreateTopicsRequestData message)
        {
            index = BinaryEncoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicEncoder.WriteV3);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            return index;
        }
        private static int WriteV4(byte[] buffer, int index, CreateTopicsRequestData message)
        {
            index = BinaryEncoder.WriteArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicEncoder.WriteV4);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            return index;
        }
        private static int WriteV5(byte[] buffer, int index, CreateTopicsRequestData message)
        {
            index = BinaryEncoder.WriteCompactArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicEncoder.WriteV5);
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
        private static int WriteV6(byte[] buffer, int index, CreateTopicsRequestData message)
        {
            index = BinaryEncoder.WriteCompactArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicEncoder.WriteV6);
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
        private static int WriteV7(byte[] buffer, int index, CreateTopicsRequestData message)
        {
            index = BinaryEncoder.WriteCompactArray<CreatableTopic>(buffer, index, message.TopicsField, CreatableTopicEncoder.WriteV7);
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
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class CreatableTopicEncoder
        {
            public static int WriteV0(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV0);
                index = BinaryEncoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigEncoder.WriteV0);
                return index;
            }
            public static int WriteV1(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV1);
                index = BinaryEncoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigEncoder.WriteV1);
                return index;
            }
            public static int WriteV2(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV2);
                index = BinaryEncoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigEncoder.WriteV2);
                return index;
            }
            public static int WriteV3(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV3);
                index = BinaryEncoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigEncoder.WriteV3);
                return index;
            }
            public static int WriteV4(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV4);
                index = BinaryEncoder.WriteArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigEncoder.WriteV4);
                return index;
            }
            public static int WriteV5(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV5);
                index = BinaryEncoder.WriteCompactArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigEncoder.WriteV5);
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
            public static int WriteV6(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV6);
                index = BinaryEncoder.WriteCompactArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigEncoder.WriteV6);
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
            public static int WriteV7(byte[] buffer, int index, CreatableTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, index, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV7);
                index = BinaryEncoder.WriteCompactArray<CreateableTopicConfig>(buffer, index, message.ConfigsField, CreateableTopicConfigEncoder.WriteV7);
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
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class CreatableReplicaAssignmentEncoder
            {
                public static int WriteV0(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.BrokerIdsField, BinaryEncoder.WriteInt32);
                    return index;
                }
                public static int WriteV1(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.BrokerIdsField, BinaryEncoder.WriteInt32);
                    return index;
                }
                public static int WriteV2(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.BrokerIdsField, BinaryEncoder.WriteInt32);
                    return index;
                }
                public static int WriteV3(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.BrokerIdsField, BinaryEncoder.WriteInt32);
                    return index;
                }
                public static int WriteV4(byte[] buffer, int index, CreatableReplicaAssignment message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.BrokerIdsField, BinaryEncoder.WriteInt32);
                    return index;
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
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class CreateableTopicConfigEncoder
            {
                public static int WriteV0(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.ValueField);
                    return index;
                }
                public static int WriteV1(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.ValueField);
                    return index;
                }
                public static int WriteV2(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.ValueField);
                    return index;
                }
                public static int WriteV3(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.ValueField);
                    return index;
                }
                public static int WriteV4(byte[] buffer, int index, CreateableTopicConfig message)
                {
                    index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.ValueField);
                    return index;
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
            }
        }
    }
}
