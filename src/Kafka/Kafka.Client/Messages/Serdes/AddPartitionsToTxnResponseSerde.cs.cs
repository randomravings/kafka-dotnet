using AddPartitionsToTxnPartitionResult = Kafka.Client.Messages.AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult.AddPartitionsToTxnPartitionResult;
using AddPartitionsToTxnTopicResult = Kafka.Client.Messages.AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult;
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
    public static class AddPartitionsToTxnResponseSerde
    {
        private static readonly ApiKey API_KEY = new(24);
        private static readonly VersionRange API_VERSIONS = new(0, 3);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (3, 32767);
        public static IEncoder<ResponseHeader, AddPartitionsToTxnResponse> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 3 ? apiVersion : new Version(3);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = ResponseHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<ResponseHeader, AddPartitionsToTxnResponse>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<ResponseHeader, AddPartitionsToTxnResponse>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<ResponseHeader, AddPartitionsToTxnResponse>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<ResponseHeader, AddPartitionsToTxnResponse>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<ResponseHeader, AddPartitionsToTxnResponse> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 3 ? apiVersion : new Version(3);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = ResponseHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<ResponseHeader, AddPartitionsToTxnResponse>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<ResponseHeader, AddPartitionsToTxnResponse>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<ResponseHeader, AddPartitionsToTxnResponse>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<ResponseHeader, AddPartitionsToTxnResponse>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, AddPartitionsToTxnResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<AddPartitionsToTxnTopicResult>(buffer, index, message.ResultsField, AddPartitionsToTxnTopicResultSerde.WriteV0);
            return index;
        }
        private static (int Offset, AddPartitionsToTxnResponse Value) ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var resultsField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _resultsField_) = BinaryDecoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, index, AddPartitionsToTxnTopicResultSerde.ReadV0);
            if (_resultsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Results'");
            else
                resultsField = _resultsField_.Value;
            return (index, new(
                throttleTimeMsField,
                resultsField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, AddPartitionsToTxnResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<AddPartitionsToTxnTopicResult>(buffer, index, message.ResultsField, AddPartitionsToTxnTopicResultSerde.WriteV1);
            return index;
        }
        private static (int Offset, AddPartitionsToTxnResponse Value) ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var resultsField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _resultsField_) = BinaryDecoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, index, AddPartitionsToTxnTopicResultSerde.ReadV1);
            if (_resultsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Results'");
            else
                resultsField = _resultsField_.Value;
            return (index, new(
                throttleTimeMsField,
                resultsField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, AddPartitionsToTxnResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<AddPartitionsToTxnTopicResult>(buffer, index, message.ResultsField, AddPartitionsToTxnTopicResultSerde.WriteV2);
            return index;
        }
        private static (int Offset, AddPartitionsToTxnResponse Value) ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var resultsField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _resultsField_) = BinaryDecoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, index, AddPartitionsToTxnTopicResultSerde.ReadV2);
            if (_resultsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Results'");
            else
                resultsField = _resultsField_.Value;
            return (index, new(
                throttleTimeMsField,
                resultsField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, AddPartitionsToTxnResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<AddPartitionsToTxnTopicResult>(buffer, index, message.ResultsField, AddPartitionsToTxnTopicResultSerde.WriteV3);
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
        private static (int Offset, AddPartitionsToTxnResponse Value) ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var resultsField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _resultsField_) = BinaryDecoder.ReadCompactArray<AddPartitionsToTxnTopicResult>(buffer, index, AddPartitionsToTxnTopicResultSerde.ReadV3);
            if (_resultsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Results'");
            else
                resultsField = _resultsField_.Value;
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
                resultsField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class AddPartitionsToTxnTopicResultSerde
        {
            public static int WriteV0(byte[] buffer, int index, AddPartitionsToTxnTopicResult message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<AddPartitionsToTxnPartitionResult>(buffer, index, message.ResultsField, AddPartitionsToTxnPartitionResultSerde.WriteV0);
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
            public static (int Offset, AddPartitionsToTxnTopicResult Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var resultsField = ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _resultsField_) = BinaryDecoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, index, AddPartitionsToTxnPartitionResultSerde.ReadV0);
                if (_resultsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Results'");
                else
                    resultsField = _resultsField_.Value;
                return (index, new(
                    nameField,
                    resultsField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, AddPartitionsToTxnTopicResult message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<AddPartitionsToTxnPartitionResult>(buffer, index, message.ResultsField, AddPartitionsToTxnPartitionResultSerde.WriteV1);
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
            public static (int Offset, AddPartitionsToTxnTopicResult Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var resultsField = ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _resultsField_) = BinaryDecoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, index, AddPartitionsToTxnPartitionResultSerde.ReadV1);
                if (_resultsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Results'");
                else
                    resultsField = _resultsField_.Value;
                return (index, new(
                    nameField,
                    resultsField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, AddPartitionsToTxnTopicResult message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<AddPartitionsToTxnPartitionResult>(buffer, index, message.ResultsField, AddPartitionsToTxnPartitionResultSerde.WriteV2);
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
            public static (int Offset, AddPartitionsToTxnTopicResult Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var resultsField = ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _resultsField_) = BinaryDecoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, index, AddPartitionsToTxnPartitionResultSerde.ReadV2);
                if (_resultsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Results'");
                else
                    resultsField = _resultsField_.Value;
                return (index, new(
                    nameField,
                    resultsField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, AddPartitionsToTxnTopicResult message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<AddPartitionsToTxnPartitionResult>(buffer, index, message.ResultsField, AddPartitionsToTxnPartitionResultSerde.WriteV3);
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
            public static (int Offset, AddPartitionsToTxnTopicResult Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var resultsField = ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _resultsField_) = BinaryDecoder.ReadCompactArray<AddPartitionsToTxnPartitionResult>(buffer, index, AddPartitionsToTxnPartitionResultSerde.ReadV3);
                if (_resultsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Results'");
                else
                    resultsField = _resultsField_.Value;
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
                    resultsField,
                    taggedFields
                ));
            }
            [GeneratedCode("kgen", "1.0.0.0")]
            private static class AddPartitionsToTxnPartitionResultSerde
            {
                public static int WriteV0(byte[] buffer, int index, AddPartitionsToTxnPartitionResult message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
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
                public static (int Offset, AddPartitionsToTxnPartitionResult Value) ReadV0(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static int WriteV1(byte[] buffer, int index, AddPartitionsToTxnPartitionResult message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
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
                public static (int Offset, AddPartitionsToTxnPartitionResult Value) ReadV1(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static int WriteV2(byte[] buffer, int index, AddPartitionsToTxnPartitionResult message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
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
                public static (int Offset, AddPartitionsToTxnPartitionResult Value) ReadV2(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static int WriteV3(byte[] buffer, int index, AddPartitionsToTxnPartitionResult message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
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
                public static (int Offset, AddPartitionsToTxnPartitionResult Value) ReadV3(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
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
                        errorCodeField,
                        taggedFields
                    ));
                }
            }
        }
    }
}