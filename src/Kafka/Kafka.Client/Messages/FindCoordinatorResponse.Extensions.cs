using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using Coordinator = Kafka.Client.Messages.FindCoordinatorResponse.Coordinator;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FindCoordinatorResponseSerde
    {
        private static readonly Func<Stream, FindCoordinatorResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
        };
        private static readonly Action<Stream, FindCoordinatorResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static FindCoordinatorResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, FindCoordinatorResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static FindCoordinatorResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = default(string?);
            var nodeIdField = Decoder.ReadInt32(buffer);
            var hostField = Decoder.ReadString(buffer);
            var portField = Decoder.ReadInt32(buffer);
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
        private static void WriteV00(Stream buffer, FindCoordinatorResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.NodeIdField);
            Encoder.WriteString(buffer, message.HostField);
            Encoder.WriteInt32(buffer, message.PortField);
        }
        private static FindCoordinatorResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadNullableString(buffer);
            var nodeIdField = Decoder.ReadInt32(buffer);
            var hostField = Decoder.ReadString(buffer);
            var portField = Decoder.ReadInt32(buffer);
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
        private static void WriteV01(Stream buffer, FindCoordinatorResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteInt32(buffer, message.NodeIdField);
            Encoder.WriteString(buffer, message.HostField);
            Encoder.WriteInt32(buffer, message.PortField);
        }
        private static FindCoordinatorResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadNullableString(buffer);
            var nodeIdField = Decoder.ReadInt32(buffer);
            var hostField = Decoder.ReadString(buffer);
            var portField = Decoder.ReadInt32(buffer);
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
        private static void WriteV02(Stream buffer, FindCoordinatorResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteInt32(buffer, message.NodeIdField);
            Encoder.WriteString(buffer, message.HostField);
            Encoder.WriteInt32(buffer, message.PortField);
        }
        private static FindCoordinatorResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer);
            var nodeIdField = Decoder.ReadInt32(buffer);
            var hostField = Decoder.ReadCompactString(buffer);
            var portField = Decoder.ReadInt32(buffer);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV03(Stream buffer, FindCoordinatorResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteInt32(buffer, message.NodeIdField);
            Encoder.WriteCompactString(buffer, message.HostField);
            Encoder.WriteInt32(buffer, message.PortField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static FindCoordinatorResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = Decoder.ReadCompactArray<Coordinator>(buffer, b => CoordinatorSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Coordinators'");
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV04(Stream buffer, FindCoordinatorResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<Coordinator>(buffer, message.CoordinatorsField, (b, i) => CoordinatorSerde.WriteV04(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class CoordinatorSerde
        {
            public static Coordinator ReadV04(Stream buffer)
            {
                var keyField = Decoder.ReadCompactString(buffer);
                var nodeIdField = Decoder.ReadInt32(buffer);
                var hostField = Decoder.ReadCompactString(buffer);
                var portField = Decoder.ReadInt32(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV04(Stream buffer, Coordinator message)
            {
                Encoder.WriteCompactString(buffer, message.KeyField);
                Encoder.WriteInt32(buffer, message.NodeIdField);
                Encoder.WriteCompactString(buffer, message.HostField);
                Encoder.WriteInt32(buffer, message.PortField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}