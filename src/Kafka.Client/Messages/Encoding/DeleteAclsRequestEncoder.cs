using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using DeleteAclsFilter = Kafka.Client.Messages.DeleteAclsRequestData.DeleteAclsFilter;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class DeleteAclsRequestEncoder : 
        RequestEncoder<RequestHeaderData, DeleteAclsRequestData>
    {
        internal DeleteAclsRequestEncoder() :
            base(
                ApiKey.DeleteAcls,
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
        protected override EncodeValue<DeleteAclsRequestData> GetMessageEncoder(short apiVersion) =>
            apiVersion switch
            {
                0 => WriteV0,
                1 => WriteV1,
                2 => WriteV2,
                3 => WriteV3,
                _ => throw new NotSupportedException()
            }
        ;
        private static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteAclsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<DeleteAclsFilter>(buffer, i, message.FiltersField, DeleteAclsFilterEncoder.WriteV0);
            return i;
        }
        private static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteAclsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteArray<DeleteAclsFilter>(buffer, i, message.FiltersField, DeleteAclsFilterEncoder.WriteV1);
            return i;
        }
        private static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteAclsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<DeleteAclsFilter>(buffer, i, message.FiltersField, DeleteAclsFilterEncoder.WriteV2);
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
        private static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteAclsRequestData message)
        {
            var i = index;
            i = BinaryEncoder.WriteCompactArray<DeleteAclsFilter>(buffer, i, message.FiltersField, DeleteAclsFilterEncoder.WriteV3);
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
        private static class DeleteAclsFilterEncoder
        {
            public static int WriteV0([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteAclsFilter message)
            {
                var i = index;
                i = BinaryEncoder.WriteInt8(buffer, i, message.ResourceTypeFilterField);
                i = BinaryEncoder.WriteNullableString(buffer, i, message.ResourceNameFilterField);
                i = BinaryEncoder.WriteNullableString(buffer, i, message.PrincipalFilterField);
                i = BinaryEncoder.WriteNullableString(buffer, i, message.HostFilterField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.OperationField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.PermissionTypeField);
                return i;
            }
            public static int WriteV1([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteAclsFilter message)
            {
                var i = index;
                i = BinaryEncoder.WriteInt8(buffer, i, message.ResourceTypeFilterField);
                i = BinaryEncoder.WriteNullableString(buffer, i, message.ResourceNameFilterField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.PatternTypeFilterField);
                i = BinaryEncoder.WriteNullableString(buffer, i, message.PrincipalFilterField);
                i = BinaryEncoder.WriteNullableString(buffer, i, message.HostFilterField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.OperationField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.PermissionTypeField);
                return i;
            }
            public static int WriteV2([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteAclsFilter message)
            {
                var i = index;
                i = BinaryEncoder.WriteInt8(buffer, i, message.ResourceTypeFilterField);
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.ResourceNameFilterField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.PatternTypeFilterField);
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.PrincipalFilterField);
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.HostFilterField);
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
            public static int WriteV3([NotNull] in byte[] buffer, in int index, [NotNull] in DeleteAclsFilter message)
            {
                var i = index;
                i = BinaryEncoder.WriteInt8(buffer, i, message.ResourceTypeFilterField);
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.ResourceNameFilterField);
                i = BinaryEncoder.WriteInt8(buffer, i, message.PatternTypeFilterField);
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.PrincipalFilterField);
                i = BinaryEncoder.WriteCompactNullableString(buffer, i, message.HostFilterField);
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
