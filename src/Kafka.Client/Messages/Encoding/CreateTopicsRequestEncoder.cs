using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using CreatableReplicaAssignment = Kafka.Client.Messages.CreateTopicsRequestData.CreatableTopic.CreatableReplicaAssignment;
using CreatableTopic = Kafka.Client.Messages.CreateTopicsRequestData.CreatableTopic;
using CreateableTopicConfig = Kafka.Client.Messages.CreateTopicsRequestData.CreatableTopic.CreateableTopicConfig;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class CreateTopicsRequestEncoder : 
        RequestEncoder<RequestHeaderData, CreateTopicsRequestData>
    {
        internal CreateTopicsRequestEncoder() :
            base(
                ApiKey.CreateTopics,
                new(0, 7),
                new(5, 32767),
                RequestHeaderEncoder.WriteV0,
                WriteV0
            )
        { }
        protected override EncodeValue<RequestHeaderData> GetHeaderEncoder(short apiVersion)
        {
            if (FlexibleVersions.Includes(apiVersion))
                return RequestHeaderEncoder.WriteV2;
            else
                return RequestHeaderEncoder.WriteV1;
        }
        protected override EncodeValue<CreateTopicsRequestData> GetMessageEncoder(short apiVersion) =>
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
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in CreateTopicsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<CreatableTopic>(buffer, i, message.TopicsField, CreatableTopicEncoder.WriteV0);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in CreateTopicsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<CreatableTopic>(buffer, i, message.TopicsField, CreatableTopicEncoder.WriteV1);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.ValidateOnlyField);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in CreateTopicsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<CreatableTopic>(buffer, i, message.TopicsField, CreatableTopicEncoder.WriteV2);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.ValidateOnlyField);
            return i;
        }
        private static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in CreateTopicsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<CreatableTopic>(buffer, i, message.TopicsField, CreatableTopicEncoder.WriteV3);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.ValidateOnlyField);
            return i;
        }
        private static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in CreateTopicsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<CreatableTopic>(buffer, i, message.TopicsField, CreatableTopicEncoder.WriteV4);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.ValidateOnlyField);
            return i;
        }
        private static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in CreateTopicsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<CreatableTopic>(buffer, i, message.TopicsField, CreatableTopicEncoder.WriteV5);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.ValidateOnlyField);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
            }
            return i;
        }
        private static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in CreateTopicsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<CreatableTopic>(buffer, i, message.TopicsField, CreatableTopicEncoder.WriteV6);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.ValidateOnlyField);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
            }
            return i;
        }
        private static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in CreateTopicsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<CreatableTopic>(buffer, i, message.TopicsField, CreatableTopicEncoder.WriteV7);
            i = BinaryEncoder.WriteInt32(buffer, i, message.TimeoutMsField);
            i = BinaryEncoder.WriteBoolean(buffer, i, message.ValidateOnlyField);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
            }
            return i;
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class CreatableTopicEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteInt32(buffer, i, message.NumPartitionsField);
                i = BinaryEncoder.WriteInt16(buffer, i, message.ReplicationFactorField);
                i = BinaryEncoder.WriteArray<CreatableReplicaAssignment>(buffer, i, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV0);
                i = BinaryEncoder.WriteArray<CreateableTopicConfig>(buffer, i, message.ConfigsField, CreateableTopicConfigEncoder.WriteV0);
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteInt32(buffer, i, message.NumPartitionsField);
                i = BinaryEncoder.WriteInt16(buffer, i, message.ReplicationFactorField);
                i = BinaryEncoder.WriteArray<CreatableReplicaAssignment>(buffer, i, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV1);
                i = BinaryEncoder.WriteArray<CreateableTopicConfig>(buffer, i, message.ConfigsField, CreateableTopicConfigEncoder.WriteV1);
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteInt32(buffer, i, message.NumPartitionsField);
                i = BinaryEncoder.WriteInt16(buffer, i, message.ReplicationFactorField);
                i = BinaryEncoder.WriteArray<CreatableReplicaAssignment>(buffer, i, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV2);
                i = BinaryEncoder.WriteArray<CreateableTopicConfig>(buffer, i, message.ConfigsField, CreateableTopicConfigEncoder.WriteV2);
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteInt32(buffer, i, message.NumPartitionsField);
                i = BinaryEncoder.WriteInt16(buffer, i, message.ReplicationFactorField);
                i = BinaryEncoder.WriteArray<CreatableReplicaAssignment>(buffer, i, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV3);
                i = BinaryEncoder.WriteArray<CreateableTopicConfig>(buffer, i, message.ConfigsField, CreateableTopicConfigEncoder.WriteV3);
                return i;
            }
            public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteInt32(buffer, i, message.NumPartitionsField);
                i = BinaryEncoder.WriteInt16(buffer, i, message.ReplicationFactorField);
                i = BinaryEncoder.WriteArray<CreatableReplicaAssignment>(buffer, i, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV4);
                i = BinaryEncoder.WriteArray<CreateableTopicConfig>(buffer, i, message.ConfigsField, CreateableTopicConfigEncoder.WriteV4);
                return i;
            }
            public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteInt32(buffer, i, message.NumPartitionsField);
                i = BinaryEncoder.WriteInt16(buffer, i, message.ReplicationFactorField);
                i = BinaryEncoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, i, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV5);
                i = BinaryEncoder.WriteCompactArray<CreateableTopicConfig>(buffer, i, message.ConfigsField, CreateableTopicConfigEncoder.WriteV5);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                    i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
                }
                return i;
            }
            public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteInt32(buffer, i, message.NumPartitionsField);
                i = BinaryEncoder.WriteInt16(buffer, i, message.ReplicationFactorField);
                i = BinaryEncoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, i, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV6);
                i = BinaryEncoder.WriteCompactArray<CreateableTopicConfig>(buffer, i, message.ConfigsField, CreateableTopicConfigEncoder.WriteV6);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                    i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
                }
                return i;
            }
            public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableTopic message)
            {
                var i = index;
                i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                i = BinaryEncoder.WriteInt32(buffer, i, message.NumPartitionsField);
                i = BinaryEncoder.WriteInt16(buffer, i, message.ReplicationFactorField);
                i = BinaryEncoder.WriteCompactArray<CreatableReplicaAssignment>(buffer, i, message.AssignmentsField, CreatableReplicaAssignmentEncoder.WriteV7);
                i = BinaryEncoder.WriteCompactArray<CreateableTopicConfig>(buffer, i, message.ConfigsField, CreateableTopicConfigEncoder.WriteV7);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                    i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
                }
                return i;
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class CreatableReplicaAssignmentEncoder
            {
                public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableReplicaAssignment message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteArray<int>(buffer, i, message.BrokerIdsField, BinaryEncoder.WriteInt32);
                    return i;
                }
                public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableReplicaAssignment message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteArray<int>(buffer, i, message.BrokerIdsField, BinaryEncoder.WriteInt32);
                    return i;
                }
                public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableReplicaAssignment message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteArray<int>(buffer, i, message.BrokerIdsField, BinaryEncoder.WriteInt32);
                    return i;
                }
                public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableReplicaAssignment message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteArray<int>(buffer, i, message.BrokerIdsField, BinaryEncoder.WriteInt32);
                    return i;
                }
                public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableReplicaAssignment message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteArray<int>(buffer, i, message.BrokerIdsField, BinaryEncoder.WriteInt32);
                    return i;
                }
                public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableReplicaAssignment message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteCompactArray<int>(buffer, i, message.BrokerIdsField, BinaryEncoder.WriteInt32);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                        i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
                    }
                    return i;
                }
                public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableReplicaAssignment message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteCompactArray<int>(buffer, i, message.BrokerIdsField, BinaryEncoder.WriteInt32);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                        i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
                    }
                    return i;
                }
                public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in CreatableReplicaAssignment message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteInt32(buffer, i, message.PartitionIndexField);
                    i = BinaryEncoder.WriteCompactArray<int>(buffer, i, message.BrokerIdsField, BinaryEncoder.WriteInt32);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                        i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
                    }
                    return i;
                }
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class CreateableTopicConfigEncoder
            {
                public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in CreateableTopicConfig message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                    i = BinaryEncoder.WriteNullableString(buffer, i, message.ValueField);
                    return i;
                }
                public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in CreateableTopicConfig message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                    i = BinaryEncoder.WriteNullableString(buffer, i, message.ValueField);
                    return i;
                }
                public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in CreateableTopicConfig message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                    i = BinaryEncoder.WriteNullableString(buffer, i, message.ValueField);
                    return i;
                }
                public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in CreateableTopicConfig message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                    i = BinaryEncoder.WriteNullableString(buffer, i, message.ValueField);
                    return i;
                }
                public static int WriteV4([NotNull] in byte[] buffer, in int index, [NotNull] in CreateableTopicConfig message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteString(buffer, i, message.NameField);
                    i = BinaryEncoder.WriteNullableString(buffer, i, message.ValueField);
                    return i;
                }
                public static int WriteV5([NotNull] in byte[] buffer, in int index, [NotNull] in CreateableTopicConfig message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                    i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.ValueField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                        i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
                    }
                    return i;
                }
                public static int WriteV6([NotNull] in byte[] buffer, in int index, [NotNull] in CreateableTopicConfig message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                    i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.ValueField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                        i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
                    }
                    return i;
                }
                public static int WriteV7([NotNull] in byte[] buffer, in int index, [NotNull] in CreateableTopicConfig message)
                {
                    var i = index;
                    i = BinaryEncoder.WriteCompactString(buffer, i, message.NameField);
                    i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.ValueField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                        i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
                    }
                    return i;
                }
            }
        }
    }
}
