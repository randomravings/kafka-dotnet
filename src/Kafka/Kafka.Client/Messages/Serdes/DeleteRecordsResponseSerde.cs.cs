using DeleteRecordsPartitionResult = Kafka.Client.Messages.DeleteRecordsResponse.DeleteRecordsTopicResult.DeleteRecordsPartitionResult;
using DeleteRecordsTopicResult = Kafka.Client.Messages.DeleteRecordsResponse.DeleteRecordsTopicResult;
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
    public static class DeleteRecordsResponseSerde
    {
        private static readonly ApiKey API_KEY = new(21);
        private static readonly VersionRange API_VERSIONS = new(0, 2);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (2, 32767);
        public static IEncoder<ResponseHeader, DeleteRecordsResponse> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 2 ? apiVersion : new Version(2);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = ResponseHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<ResponseHeader, DeleteRecordsResponse>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<ResponseHeader, DeleteRecordsResponse>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<ResponseHeader, DeleteRecordsResponse>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<ResponseHeader, DeleteRecordsResponse> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 2 ? apiVersion : new Version(2);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = ResponseHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<ResponseHeader, DeleteRecordsResponse>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<ResponseHeader, DeleteRecordsResponse>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<ResponseHeader, DeleteRecordsResponse>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, DeleteRecordsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<DeleteRecordsTopicResult>(buffer, index, message.TopicsField, DeleteRecordsTopicResultSerde.WriteV0);
            return index;
        }
        private static (int Offset, DeleteRecordsResponse Value) ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<DeleteRecordsTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<DeleteRecordsTopicResult>(buffer, index, DeleteRecordsTopicResultSerde.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, DeleteRecordsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<DeleteRecordsTopicResult>(buffer, index, message.TopicsField, DeleteRecordsTopicResultSerde.WriteV1);
            return index;
        }
        private static (int Offset, DeleteRecordsResponse Value) ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<DeleteRecordsTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<DeleteRecordsTopicResult>(buffer, index, DeleteRecordsTopicResultSerde.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, DeleteRecordsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<DeleteRecordsTopicResult>(buffer, index, message.TopicsField, DeleteRecordsTopicResultSerde.WriteV2);
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
        private static (int Offset, DeleteRecordsResponse Value) ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<DeleteRecordsTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<DeleteRecordsTopicResult>(buffer, index, DeleteRecordsTopicResultSerde.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
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
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class DeleteRecordsTopicResultSerde
        {
            public static int WriteV0(byte[] buffer, int index, DeleteRecordsTopicResult message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<DeleteRecordsPartitionResult>(buffer, index, message.PartitionsField, DeleteRecordsPartitionResultSerde.WriteV0);
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
            public static (int Offset, DeleteRecordsTopicResult Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<DeleteRecordsPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<DeleteRecordsPartitionResult>(buffer, index, DeleteRecordsPartitionResultSerde.ReadV0);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, DeleteRecordsTopicResult message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<DeleteRecordsPartitionResult>(buffer, index, message.PartitionsField, DeleteRecordsPartitionResultSerde.WriteV1);
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
            public static (int Offset, DeleteRecordsTopicResult Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<DeleteRecordsPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<DeleteRecordsPartitionResult>(buffer, index, DeleteRecordsPartitionResultSerde.ReadV1);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, DeleteRecordsTopicResult message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<DeleteRecordsPartitionResult>(buffer, index, message.PartitionsField, DeleteRecordsPartitionResultSerde.WriteV2);
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
            public static (int Offset, DeleteRecordsTopicResult Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<DeleteRecordsPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<DeleteRecordsPartitionResult>(buffer, index, DeleteRecordsPartitionResultSerde.ReadV2);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
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
                    partitionsField,
                    taggedFields
                ));
            }
            [GeneratedCode("kgen", "1.0.0.0")]
            private static class DeleteRecordsPartitionResultSerde
            {
                public static int WriteV0(byte[] buffer, int index, DeleteRecordsPartitionResult message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LowWatermarkField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
                public static (int Offset, DeleteRecordsPartitionResult Value) ReadV0(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var lowWatermarkField = default(long);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, lowWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        lowWatermarkField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static int WriteV1(byte[] buffer, int index, DeleteRecordsPartitionResult message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LowWatermarkField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
                public static (int Offset, DeleteRecordsPartitionResult Value) ReadV1(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var lowWatermarkField = default(long);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, lowWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        lowWatermarkField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static int WriteV2(byte[] buffer, int index, DeleteRecordsPartitionResult message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LowWatermarkField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
                public static (int Offset, DeleteRecordsPartitionResult Value) ReadV2(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var lowWatermarkField = default(long);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, lowWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                        lowWatermarkField,
                        errorCodeField,
                        taggedFields
                    ));
                }
            }
        }
    }
}