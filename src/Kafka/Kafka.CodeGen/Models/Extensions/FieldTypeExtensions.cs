namespace Kafka.CodeGen.Models.Extensions
{
    public static class FieldTypeExtensions
    {
        public static string ToSystemType(
            this FieldType fieldType
        ) =>
            fieldType switch
            {
                ArrayFieldType a => $"{ToSystemType(a.ItemType)}[]",
                var f => Translate(f.Name)
            }
        ;

        private static string Translate(string type) =>
            type switch
            {
                "int8" => "sbyte",
                "int16" => "short",
                "int32" => "int",
                "int64" => "long",
                "uint16" => "ushort",
                "uint32" => "uint",
                "varint" => "int",
                "varlong" => "long",
                "uuid" => "Guid",
                "float64" => "double",
                "string" => "string",
                "bytes" => "ReadOnlyMemory<byte>",
                var s => s
            }
        ;
    }
}
