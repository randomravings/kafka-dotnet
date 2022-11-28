using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DeleteTopicState = Kafka.Client.Messages.DeleteTopicsRequest.DeleteTopicState;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteTopicsRequestSerde
    {
        private static readonly DecodeDelegate<DeleteTopicsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
        };
        private static readonly EncodeDelegate<DeleteTopicsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
        };
        public static DeleteTopicsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DeleteTopicsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DeleteTopicsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DeleteTopicsRequest message)
        {
            buffer = Encoder.WriteArray<string>(buffer, message.TopicNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            return buffer;
        }
        private static DeleteTopicsRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DeleteTopicsRequest message)
        {
            buffer = Encoder.WriteArray<string>(buffer, message.TopicNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            return buffer;
        }
        private static DeleteTopicsRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, DeleteTopicsRequest message)
        {
            buffer = Encoder.WriteArray<string>(buffer, message.TopicNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            return buffer;
        }
        private static DeleteTopicsRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, DeleteTopicsRequest message)
        {
            buffer = Encoder.WriteArray<string>(buffer, message.TopicNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            return buffer;
        }
        private static DeleteTopicsRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadCompactArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, DeleteTopicsRequest message)
        {
            buffer = Encoder.WriteCompactArray<string>(buffer, message.TopicNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static DeleteTopicsRequest ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadCompactArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, DeleteTopicsRequest message)
        {
            buffer = Encoder.WriteCompactArray<string>(buffer, message.TopicNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static DeleteTopicsRequest ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadCompactArray<DeleteTopicState>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeleteTopicStateSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var topicNamesField = ImmutableArray<string>.Empty;
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, DeleteTopicsRequest message)
        {
            buffer = Encoder.WriteCompactArray<DeleteTopicState>(buffer, message.TopicsField, (b, i) => DeleteTopicStateSerde.WriteV06(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class DeleteTopicStateSerde
        {
            public static DeleteTopicState ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactNullableString(ref buffer);
                var topicIdField = Decoder.ReadUuid(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    topicIdField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, DeleteTopicState message)
            {
                buffer = Encoder.WriteCompactNullableString(buffer, message.NameField);
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}