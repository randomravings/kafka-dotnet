using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DeleteTopicState = Kafka.Client.Messages.DeleteTopicsRequest.DeleteTopicState;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteTopicsRequestSerde
    {
        private static readonly Func<Stream, DeleteTopicsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
        };
        private static readonly Action<Stream, DeleteTopicsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
        };
        public static DeleteTopicsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DeleteTopicsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DeleteTopicsRequest ReadV00(Stream buffer)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static void WriteV00(Stream buffer, DeleteTopicsRequest message)
        {
            Encoder.WriteArray<string>(buffer, message.TopicNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
        }
        private static DeleteTopicsRequest ReadV01(Stream buffer)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static void WriteV01(Stream buffer, DeleteTopicsRequest message)
        {
            Encoder.WriteArray<string>(buffer, message.TopicNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
        }
        private static DeleteTopicsRequest ReadV02(Stream buffer)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static void WriteV02(Stream buffer, DeleteTopicsRequest message)
        {
            Encoder.WriteArray<string>(buffer, message.TopicNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
        }
        private static DeleteTopicsRequest ReadV03(Stream buffer)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static void WriteV03(Stream buffer, DeleteTopicsRequest message)
        {
            Encoder.WriteArray<string>(buffer, message.TopicNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
        }
        private static DeleteTopicsRequest ReadV04(Stream buffer)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadCompactArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static void WriteV04(Stream buffer, DeleteTopicsRequest message)
        {
            Encoder.WriteCompactArray<string>(buffer, message.TopicNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DeleteTopicsRequest ReadV05(Stream buffer)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadCompactArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static void WriteV05(Stream buffer, DeleteTopicsRequest message)
        {
            Encoder.WriteCompactArray<string>(buffer, message.TopicNamesField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DeleteTopicsRequest ReadV06(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<DeleteTopicState>(buffer, b => DeleteTopicStateSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var topicNamesField = ImmutableArray<string>.Empty;
            var timeoutMsField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static void WriteV06(Stream buffer, DeleteTopicsRequest message)
        {
            Encoder.WriteCompactArray<DeleteTopicState>(buffer, message.TopicsField, (b, i) => DeleteTopicStateSerde.WriteV06(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DeleteTopicStateSerde
        {
            public static DeleteTopicState ReadV06(Stream buffer)
            {
                var nameField = Decoder.ReadCompactNullableString(buffer);
                var topicIdField = Decoder.ReadUuid(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    topicIdField
                );
            }
            public static void WriteV06(Stream buffer, DeleteTopicState message)
            {
                Encoder.WriteCompactNullableString(buffer, message.NameField);
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}