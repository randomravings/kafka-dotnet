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
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
        };
        private static readonly EncodeDelegate<DeleteTopicsRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
        };
        public static DeleteTopicsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DeleteTopicsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DeleteTopicsRequest ReadV00(byte[] buffer, ref int index)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DeleteTopicsRequest message)
        {
            index = Encoder.WriteArray<string>(buffer, index, message.TopicNamesField, Encoder.WriteCompactString);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static DeleteTopicsRequest ReadV01(byte[] buffer, ref int index)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DeleteTopicsRequest message)
        {
            index = Encoder.WriteArray<string>(buffer, index, message.TopicNamesField, Encoder.WriteCompactString);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static DeleteTopicsRequest ReadV02(byte[] buffer, ref int index)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, DeleteTopicsRequest message)
        {
            index = Encoder.WriteArray<string>(buffer, index, message.TopicNamesField, Encoder.WriteCompactString);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static DeleteTopicsRequest ReadV03(byte[] buffer, ref int index)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, DeleteTopicsRequest message)
        {
            index = Encoder.WriteArray<string>(buffer, index, message.TopicNamesField, Encoder.WriteCompactString);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static DeleteTopicsRequest ReadV04(byte[] buffer, ref int index)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadCompactArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, DeleteTopicsRequest message)
        {
            index = Encoder.WriteCompactArray<string>(buffer, index, message.TopicNamesField, Encoder.WriteCompactString);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static DeleteTopicsRequest ReadV05(byte[] buffer, ref int index)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = Decoder.ReadCompactArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'TopicNames'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static int WriteV05(byte[] buffer, int index, DeleteTopicsRequest message)
        {
            index = Encoder.WriteCompactArray<string>(buffer, index, message.TopicNamesField, Encoder.WriteCompactString);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static DeleteTopicsRequest ReadV06(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadCompactArray<DeleteTopicState>(buffer, ref index, DeleteTopicStateSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var topicNamesField = ImmutableArray<string>.Empty;
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField,
                topicNamesField,
                timeoutMsField
            );
        }
        private static int WriteV06(byte[] buffer, int index, DeleteTopicsRequest message)
        {
            index = Encoder.WriteCompactArray<DeleteTopicState>(buffer, index, message.TopicsField, DeleteTopicStateSerde.WriteV06);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class DeleteTopicStateSerde
        {
            public static DeleteTopicState ReadV06(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactNullableString(buffer, ref index);
                var topicIdField = Decoder.ReadUuid(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    topicIdField
                );
            }
            public static int WriteV06(byte[] buffer, int index, DeleteTopicState message)
            {
                index = Encoder.WriteCompactNullableString(buffer, index, message.NameField);
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}