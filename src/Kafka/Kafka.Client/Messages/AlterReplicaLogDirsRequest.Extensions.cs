using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AlterReplicaLogDir = Kafka.Client.Messages.AlterReplicaLogDirsRequest.AlterReplicaLogDir;
using AlterReplicaLogDirTopic = Kafka.Client.Messages.AlterReplicaLogDirsRequest.AlterReplicaLogDir.AlterReplicaLogDirTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterReplicaLogDirsRequestSerde
    {
        private static readonly Func<Stream, AlterReplicaLogDirsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, AlterReplicaLogDirsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static AlterReplicaLogDirsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AlterReplicaLogDirsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AlterReplicaLogDirsRequest ReadV00(Stream buffer)
        {
            var dirsField = Decoder.ReadArray<AlterReplicaLogDir>(buffer, b => AlterReplicaLogDirSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Dirs'");
            return new(
                dirsField
            );
        }
        private static void WriteV00(Stream buffer, AlterReplicaLogDirsRequest message)
        {
            Encoder.WriteArray<AlterReplicaLogDir>(buffer, message.DirsField, (b, i) => AlterReplicaLogDirSerde.WriteV00(b, i));
        }
        private static AlterReplicaLogDirsRequest ReadV01(Stream buffer)
        {
            var dirsField = Decoder.ReadArray<AlterReplicaLogDir>(buffer, b => AlterReplicaLogDirSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Dirs'");
            return new(
                dirsField
            );
        }
        private static void WriteV01(Stream buffer, AlterReplicaLogDirsRequest message)
        {
            Encoder.WriteArray<AlterReplicaLogDir>(buffer, message.DirsField, (b, i) => AlterReplicaLogDirSerde.WriteV01(b, i));
        }
        private static AlterReplicaLogDirsRequest ReadV02(Stream buffer)
        {
            var dirsField = Decoder.ReadCompactArray<AlterReplicaLogDir>(buffer, b => AlterReplicaLogDirSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Dirs'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                dirsField
            );
        }
        private static void WriteV02(Stream buffer, AlterReplicaLogDirsRequest message)
        {
            Encoder.WriteCompactArray<AlterReplicaLogDir>(buffer, message.DirsField, (b, i) => AlterReplicaLogDirSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class AlterReplicaLogDirSerde
        {
            public static AlterReplicaLogDir ReadV00(Stream buffer)
            {
                var pathField = Decoder.ReadString(buffer);
                var topicsField = Decoder.ReadArray<AlterReplicaLogDirTopic>(buffer, b => AlterReplicaLogDirTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                return new(
                    pathField,
                    topicsField
                );
            }
            public static void WriteV00(Stream buffer, AlterReplicaLogDir message)
            {
                Encoder.WriteString(buffer, message.PathField);
                Encoder.WriteArray<AlterReplicaLogDirTopic>(buffer, message.TopicsField, (b, i) => AlterReplicaLogDirTopicSerde.WriteV00(b, i));
            }
            public static AlterReplicaLogDir ReadV01(Stream buffer)
            {
                var pathField = Decoder.ReadString(buffer);
                var topicsField = Decoder.ReadArray<AlterReplicaLogDirTopic>(buffer, b => AlterReplicaLogDirTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                return new(
                    pathField,
                    topicsField
                );
            }
            public static void WriteV01(Stream buffer, AlterReplicaLogDir message)
            {
                Encoder.WriteString(buffer, message.PathField);
                Encoder.WriteArray<AlterReplicaLogDirTopic>(buffer, message.TopicsField, (b, i) => AlterReplicaLogDirTopicSerde.WriteV01(b, i));
            }
            public static AlterReplicaLogDir ReadV02(Stream buffer)
            {
                var pathField = Decoder.ReadCompactString(buffer);
                var topicsField = Decoder.ReadCompactArray<AlterReplicaLogDirTopic>(buffer, b => AlterReplicaLogDirTopicSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    pathField,
                    topicsField
                );
            }
            public static void WriteV02(Stream buffer, AlterReplicaLogDir message)
            {
                Encoder.WriteCompactString(buffer, message.PathField);
                Encoder.WriteCompactArray<AlterReplicaLogDirTopic>(buffer, message.TopicsField, (b, i) => AlterReplicaLogDirTopicSerde.WriteV02(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class AlterReplicaLogDirTopicSerde
            {
                public static AlterReplicaLogDirTopic ReadV00(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static void WriteV00(Stream buffer, AlterReplicaLogDirTopic message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static AlterReplicaLogDirTopic ReadV01(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static void WriteV01(Stream buffer, AlterReplicaLogDirTopic message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static AlterReplicaLogDirTopic ReadV02(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var partitionsField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static void WriteV02(Stream buffer, AlterReplicaLogDirTopic message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}