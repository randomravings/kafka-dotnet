using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using AclCreation = Kafka.Client.Messages.CreateAclsRequestData.AclCreation;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class CreateAclsRequestEncoder : 
        RequestEncoder<RequestHeaderData, CreateAclsRequestData>
    {
        internal CreateAclsRequestEncoder() :
            base(
                ApiKey.CreateAcls,
                new(0, 3),
                new(2, 32767),
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
        protected override EncodeValue<CreateAclsRequestData> GetMessageEncoder(short apiVersion) =>
            apiVersion switch
            {
                0 => WriteV0,
                1 => WriteV1,
                2 => WriteV2,
                3 => WriteV3,
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in CreateAclsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<AclCreation>(buffer, i, message.CreationsField, AclCreationEncoder.WriteV0);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in CreateAclsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<AclCreation>(buffer, i, message.CreationsField, AclCreationEncoder.WriteV1);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in CreateAclsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<AclCreation>(buffer, i, message.CreationsField, AclCreationEncoder.WriteV2);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
            }
            return i;
        }
        private static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in CreateAclsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<AclCreation>(buffer, i, message.CreationsField, AclCreationEncoder.WriteV3);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
            }
            return i;
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class AclCreationEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in AclCreation message)
            {
                var i = index;
                i = BinaryEncoder.WriteInt8(buffer, i, message.ResourceTypeField);
                i = BinaryEncoder.WriteString(buffer, i, message.ResourceNameField);
                i = BinaryEncoder.WriteString(buffer, i, message.PrincipalField);
                i = BinaryEncoder.WriteString(buffer, i, message.HostField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.OperationField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.PermissionTypeField);
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in AclCreation message)
            {
                var i = index;
                i = BinaryEncoder.WriteInt8(buffer, i, message.ResourceTypeField);
                i = BinaryEncoder.WriteString(buffer, i, message.ResourceNameField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.ResourcePatternTypeField);
                i = BinaryEncoder.WriteString(buffer, i, message.PrincipalField);
                i = BinaryEncoder.WriteString(buffer, i, message.HostField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.OperationField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.PermissionTypeField);
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in AclCreation message)
            {
                var i = index;
                i = BinaryEncoder.WriteInt8(buffer, i, message.ResourceTypeField);
                i = BinaryEncoder.WriteCompactString(buffer, i, message.ResourceNameField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.ResourcePatternTypeField);
                i = BinaryEncoder.WriteCompactString(buffer, i, message.PrincipalField);
                i = BinaryEncoder.WriteCompactString(buffer, i, message.HostField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.OperationField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.PermissionTypeField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                    i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
                }
                return i;
            }
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in AclCreation message)
            {
                var i = index;
                i = BinaryEncoder.WriteInt8(buffer, i, message.ResourceTypeField);
                i = BinaryEncoder.WriteCompactString(buffer, i, message.ResourceNameField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.ResourcePatternTypeField);
                i = BinaryEncoder.WriteCompactString(buffer, i, message.PrincipalField);
                i = BinaryEncoder.WriteCompactString(buffer, i, message.HostField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.OperationField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.PermissionTypeField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                i = BinaryEncoder.WriteVarUInt32(buffer, i, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    i = BinaryEncoder.WriteVarInt32(buffer, i, taggedField.Tag);
                    i = BinaryEncoder.WriteCompactBytes(buffer, i, taggedField.Value);
                }
                return i;
            }
        }
    }
}
