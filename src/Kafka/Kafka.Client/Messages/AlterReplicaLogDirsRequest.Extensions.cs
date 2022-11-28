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
        private static readonly DecodeDelegate<AlterReplicaLogDirsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
        };
        private static readonly EncodeDelegate<AlterReplicaLogDirsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static AlterReplicaLogDirsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, AlterReplicaLogDirsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static AlterReplicaLogDirsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var dirsField = Decoder.ReadArray<AlterReplicaLogDir>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterReplicaLogDirSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Dirs'");
            return new(
                dirsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, AlterReplicaLogDirsRequest message)
        {
            buffer = Encoder.WriteArray<AlterReplicaLogDir>(buffer, message.DirsField, (b, i) => AlterReplicaLogDirSerde.WriteV00(b, i));
            return buffer;
        }
        private static AlterReplicaLogDirsRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var dirsField = Decoder.ReadArray<AlterReplicaLogDir>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterReplicaLogDirSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Dirs'");
            return new(
                dirsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, AlterReplicaLogDirsRequest message)
        {
            buffer = Encoder.WriteArray<AlterReplicaLogDir>(buffer, message.DirsField, (b, i) => AlterReplicaLogDirSerde.WriteV01(b, i));
            return buffer;
        }
        private static AlterReplicaLogDirsRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var dirsField = Decoder.ReadCompactArray<AlterReplicaLogDir>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterReplicaLogDirSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Dirs'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                dirsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, AlterReplicaLogDirsRequest message)
        {
            buffer = Encoder.WriteCompactArray<AlterReplicaLogDir>(buffer, message.DirsField, (b, i) => AlterReplicaLogDirSerde.WriteV02(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class AlterReplicaLogDirSerde
        {
            public static AlterReplicaLogDir ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var pathField = Decoder.ReadString(ref buffer);
                var topicsField = Decoder.ReadArray<AlterReplicaLogDirTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterReplicaLogDirTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                return new(
                    pathField,
                    topicsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, AlterReplicaLogDir message)
            {
                buffer = Encoder.WriteString(buffer, message.PathField);
                buffer = Encoder.WriteArray<AlterReplicaLogDirTopic>(buffer, message.TopicsField, (b, i) => AlterReplicaLogDirTopicSerde.WriteV00(b, i));
                return buffer;
            }
            public static AlterReplicaLogDir ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var pathField = Decoder.ReadString(ref buffer);
                var topicsField = Decoder.ReadArray<AlterReplicaLogDirTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterReplicaLogDirTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                return new(
                    pathField,
                    topicsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, AlterReplicaLogDir message)
            {
                buffer = Encoder.WriteString(buffer, message.PathField);
                buffer = Encoder.WriteArray<AlterReplicaLogDirTopic>(buffer, message.TopicsField, (b, i) => AlterReplicaLogDirTopicSerde.WriteV01(b, i));
                return buffer;
            }
            public static AlterReplicaLogDir ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var pathField = Decoder.ReadCompactString(ref buffer);
                var topicsField = Decoder.ReadCompactArray<AlterReplicaLogDirTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterReplicaLogDirTopicSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    pathField,
                    topicsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, AlterReplicaLogDir message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.PathField);
                buffer = Encoder.WriteCompactArray<AlterReplicaLogDirTopic>(buffer, message.TopicsField, (b, i) => AlterReplicaLogDirTopicSerde.WriteV02(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class AlterReplicaLogDirTopicSerde
            {
                public static AlterReplicaLogDirTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, AlterReplicaLogDirTopic message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static AlterReplicaLogDirTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, AlterReplicaLogDirTopic message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static AlterReplicaLogDirTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var partitionsField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, AlterReplicaLogDirTopic message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}