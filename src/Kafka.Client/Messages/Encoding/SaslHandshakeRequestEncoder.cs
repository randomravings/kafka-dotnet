using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class SaslHandshakeRequestEncoder : 
        RequestEncoder<RequestHeaderData, SaslHandshakeRequestData>
    {
        internal SaslHandshakeRequestEncoder() :
            base(
                ApiKey.SaslHandshake,
                new(0, 1),
                new(32767, -32768),
                RequestHeaderEncoder.WriteV0,
                WriteV0
            )
        { }
        protected override EncodeValue<RequestHeaderData> GetHeaderEncoder(short apiVersion)
        {
            if (FlexibleVersions.Includes(apiVersion))
                return RequestHeaderEncoder.WriteV2;
            else
                return RequestHeaderEncoder.WriteV1;
        }
        protected override EncodeValue<SaslHandshakeRequestData> GetMessageEncoder(short apiVersion) =>
            apiVersion switch
            {
                0 => WriteV0,
                1 => WriteV1,
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in SaslHandshakeRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.MechanismField);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in SaslHandshakeRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteString(buffer, i, message.MechanismField);
            return i;
        }
    }
}
