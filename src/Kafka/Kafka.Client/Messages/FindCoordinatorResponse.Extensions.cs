using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using Coordinator = Kafka.Client.Messages.FindCoordinatorResponse.Coordinator;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FindCoordinatorResponseSerde
    {
        private static readonly DecodeDelegate<FindCoordinatorResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
        };
        private static readonly EncodeDelegate<FindCoordinatorResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static FindCoordinatorResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, FindCoordinatorResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static FindCoordinatorResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = default(string?);
            var nodeIdField = Decoder.ReadInt32(ref buffer);
            var hostField = Decoder.ReadString(ref buffer);
            var portField = Decoder.ReadInt32(ref buffer);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, FindCoordinatorResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
            buffer = Encoder.WriteString(buffer, message.HostField);
            buffer = Encoder.WriteInt32(buffer, message.PortField);
            return buffer;
        }
        private static FindCoordinatorResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadNullableString(ref buffer);
            var nodeIdField = Decoder.ReadInt32(ref buffer);
            var hostField = Decoder.ReadString(ref buffer);
            var portField = Decoder.ReadInt32(ref buffer);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, FindCoordinatorResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
            buffer = Encoder.WriteString(buffer, message.HostField);
            buffer = Encoder.WriteInt32(buffer, message.PortField);
            return buffer;
        }
        private static FindCoordinatorResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadNullableString(ref buffer);
            var nodeIdField = Decoder.ReadInt32(ref buffer);
            var hostField = Decoder.ReadString(ref buffer);
            var portField = Decoder.ReadInt32(ref buffer);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, FindCoordinatorResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
            buffer = Encoder.WriteString(buffer, message.HostField);
            buffer = Encoder.WriteInt32(buffer, message.PortField);
            return buffer;
        }
        private static FindCoordinatorResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
            var nodeIdField = Decoder.ReadInt32(ref buffer);
            var hostField = Decoder.ReadCompactString(ref buffer);
            var portField = Decoder.ReadInt32(ref buffer);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, FindCoordinatorResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
            buffer = Encoder.WriteCompactString(buffer, message.HostField);
            buffer = Encoder.WriteInt32(buffer, message.PortField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static FindCoordinatorResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = Decoder.ReadCompactArray<Coordinator>(ref buffer, (ref ReadOnlyMemory<byte> b) => CoordinatorSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Coordinators'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                nodeIdField,
                hostField,
                portField,
                coordinatorsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, FindCoordinatorResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<Coordinator>(buffer, message.CoordinatorsField, (b, i) => CoordinatorSerde.WriteV04(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class CoordinatorSerde
        {
            public static Coordinator ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var keyField = Decoder.ReadCompactString(ref buffer);
                var nodeIdField = Decoder.ReadInt32(ref buffer);
                var hostField = Decoder.ReadCompactString(ref buffer);
                var portField = Decoder.ReadInt32(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, Coordinator message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.KeyField);
                buffer = Encoder.WriteInt32(buffer, message.NodeIdField);
                buffer = Encoder.WriteCompactString(buffer, message.HostField);
                buffer = Encoder.WriteInt32(buffer, message.PortField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}