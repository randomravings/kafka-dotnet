using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AlterReplicaLogDir = Kafka.Client.Messages.AlterReplicaLogDirsRequest.AlterReplicaLogDir;
using AlterReplicaLogDirTopic = Kafka.Client.Messages.AlterReplicaLogDirsRequest.AlterReplicaLogDir.AlterReplicaLogDirTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterReplicaLogDirsRequestSerde
    {
        private static readonly DecodeDelegate<AlterReplicaLogDirsRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<AlterReplicaLogDirsRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static AlterReplicaLogDirsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AlterReplicaLogDirsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AlterReplicaLogDirsRequest ReadV00(byte[] buffer, ref int index)
        {
            var dirsField = Decoder.ReadArray<AlterReplicaLogDir>(buffer, ref index, AlterReplicaLogDirSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Dirs'");
            return new(
                dirsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AlterReplicaLogDirsRequest message)
        {
            index = Encoder.WriteArray<AlterReplicaLogDir>(buffer, index, message.DirsField, AlterReplicaLogDirSerde.WriteV00);
            return index;
        }
        private static AlterReplicaLogDirsRequest ReadV01(byte[] buffer, ref int index)
        {
            var dirsField = Decoder.ReadArray<AlterReplicaLogDir>(buffer, ref index, AlterReplicaLogDirSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Dirs'");
            return new(
                dirsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, AlterReplicaLogDirsRequest message)
        {
            index = Encoder.WriteArray<AlterReplicaLogDir>(buffer, index, message.DirsField, AlterReplicaLogDirSerde.WriteV01);
            return index;
        }
        private static AlterReplicaLogDirsRequest ReadV02(byte[] buffer, ref int index)
        {
            var dirsField = Decoder.ReadCompactArray<AlterReplicaLogDir>(buffer, ref index, AlterReplicaLogDirSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Dirs'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                dirsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, AlterReplicaLogDirsRequest message)
        {
            index = Encoder.WriteCompactArray<AlterReplicaLogDir>(buffer, index, message.DirsField, AlterReplicaLogDirSerde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class AlterReplicaLogDirSerde
        {
            public static AlterReplicaLogDir ReadV00(byte[] buffer, ref int index)
            {
                var pathField = Decoder.ReadString(buffer, ref index);
                var topicsField = Decoder.ReadArray<AlterReplicaLogDirTopic>(buffer, ref index, AlterReplicaLogDirTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                return new(
                    pathField,
                    topicsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, AlterReplicaLogDir message)
            {
                index = Encoder.WriteString(buffer, index, message.PathField);
                index = Encoder.WriteArray<AlterReplicaLogDirTopic>(buffer, index, message.TopicsField, AlterReplicaLogDirTopicSerde.WriteV00);
                return index;
            }
            public static AlterReplicaLogDir ReadV01(byte[] buffer, ref int index)
            {
                var pathField = Decoder.ReadString(buffer, ref index);
                var topicsField = Decoder.ReadArray<AlterReplicaLogDirTopic>(buffer, ref index, AlterReplicaLogDirTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                return new(
                    pathField,
                    topicsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, AlterReplicaLogDir message)
            {
                index = Encoder.WriteString(buffer, index, message.PathField);
                index = Encoder.WriteArray<AlterReplicaLogDirTopic>(buffer, index, message.TopicsField, AlterReplicaLogDirTopicSerde.WriteV01);
                return index;
            }
            public static AlterReplicaLogDir ReadV02(byte[] buffer, ref int index)
            {
                var pathField = Decoder.ReadCompactString(buffer, ref index);
                var topicsField = Decoder.ReadCompactArray<AlterReplicaLogDirTopic>(buffer, ref index, AlterReplicaLogDirTopicSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    pathField,
                    topicsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, AlterReplicaLogDir message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.PathField);
                index = Encoder.WriteCompactArray<AlterReplicaLogDirTopic>(buffer, index, message.TopicsField, AlterReplicaLogDirTopicSerde.WriteV02);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class AlterReplicaLogDirTopicSerde
            {
                public static AlterReplicaLogDirTopic ReadV00(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadString(buffer, ref index);
                    var partitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, AlterReplicaLogDirTopic message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                    return index;
                }
                public static AlterReplicaLogDirTopic ReadV01(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadString(buffer, ref index);
                    var partitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, AlterReplicaLogDirTopic message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                    return index;
                }
                public static AlterReplicaLogDirTopic ReadV02(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadCompactString(buffer, ref index);
                    var partitionsField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, AlterReplicaLogDirTopic message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}