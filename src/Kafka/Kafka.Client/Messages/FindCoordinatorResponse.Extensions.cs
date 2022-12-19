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
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
        };
        private static readonly EncodeDelegate<FindCoordinatorResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
        };
        public static FindCoordinatorResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, FindCoordinatorResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static FindCoordinatorResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = default(string?);
            var nodeIdField = Decoder.ReadInt32(buffer, ref index);
            var hostField = Decoder.ReadString(buffer, ref index);
            var portField = Decoder.ReadInt32(buffer, ref index);
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
        private static int WriteV00(byte[] buffer, int index, FindCoordinatorResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
            index = Encoder.WriteString(buffer, index, message.HostField);
            index = Encoder.WriteInt32(buffer, index, message.PortField);
            return index;
        }
        private static FindCoordinatorResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
            var nodeIdField = Decoder.ReadInt32(buffer, ref index);
            var hostField = Decoder.ReadString(buffer, ref index);
            var portField = Decoder.ReadInt32(buffer, ref index);
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
        private static int WriteV01(byte[] buffer, int index, FindCoordinatorResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
            index = Encoder.WriteString(buffer, index, message.HostField);
            index = Encoder.WriteInt32(buffer, index, message.PortField);
            return index;
        }
        private static FindCoordinatorResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
            var nodeIdField = Decoder.ReadInt32(buffer, ref index);
            var hostField = Decoder.ReadString(buffer, ref index);
            var portField = Decoder.ReadInt32(buffer, ref index);
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
        private static int WriteV02(byte[] buffer, int index, FindCoordinatorResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
            index = Encoder.WriteString(buffer, index, message.HostField);
            index = Encoder.WriteInt32(buffer, index, message.PortField);
            return index;
        }
        private static FindCoordinatorResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
            var nodeIdField = Decoder.ReadInt32(buffer, ref index);
            var hostField = Decoder.ReadCompactString(buffer, ref index);
            var portField = Decoder.ReadInt32(buffer, ref index);
            var coordinatorsField = ImmutableArray<Coordinator>.Empty;
            _ = Decoder.ReadVarUInt32(buffer, ref index);
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
        private static int WriteV03(byte[] buffer, int index, FindCoordinatorResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
            index = Encoder.WriteCompactString(buffer, index, message.HostField);
            index = Encoder.WriteInt32(buffer, index, message.PortField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static FindCoordinatorResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var nodeIdField = default(int);
            var hostField = "";
            var portField = default(int);
            var coordinatorsField = Decoder.ReadCompactArray<Coordinator>(buffer, ref index, CoordinatorSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Coordinators'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
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
        private static int WriteV04(byte[] buffer, int index, FindCoordinatorResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<Coordinator>(buffer, index, message.CoordinatorsField, CoordinatorSerde.WriteV04);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class CoordinatorSerde
        {
            public static Coordinator ReadV04(byte[] buffer, ref int index)
            {
                var keyField = Decoder.ReadCompactString(buffer, ref index);
                var nodeIdField = Decoder.ReadInt32(buffer, ref index);
                var hostField = Decoder.ReadCompactString(buffer, ref index);
                var portField = Decoder.ReadInt32(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    keyField,
                    nodeIdField,
                    hostField,
                    portField,
                    errorCodeField,
                    errorMessageField
                );
            }
            public static int WriteV04(byte[] buffer, int index, Coordinator message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.KeyField);
                index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
                index = Encoder.WriteCompactString(buffer, index, message.HostField);
                index = Encoder.WriteInt32(buffer, index, message.PortField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}