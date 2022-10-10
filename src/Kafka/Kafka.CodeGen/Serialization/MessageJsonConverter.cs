using Kafka.CodeGen.Models;
using Kafka.Common.Protocol;
using Newtonsoft.Json;
using System.Collections.Immutable;
using Version = Kafka.CodeGen.Models.Version;

namespace Kafka.CodeGen.Serialization
{
    internal sealed class MessageJsonConverter :
        JsonConverter<Message>
    {
        public override bool CanRead => true;
        public override bool CanWrite => false;
        public override void WriteJson(
            JsonWriter writer,
            Message? value,
            JsonSerializer serializer
        ) =>
            throw new NotImplementedException()
        ;

        public override Message ReadJson(
            JsonReader reader,
            Type objectType,
            Message? existingValue,
            bool hasExistingValue,
            JsonSerializer serializer
        )
        {
            var apiKey = ApiKey.None;
            var type = "";
            var listeners = Array.Empty<string>();
            var name = "";
            var validVersions = Version.Empty;
            var flexibleVersions = Version.Empty;
            var fields = new List<Field>();
            var structs = new Dictionary<string, Struct>();
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.PropertyName:
                        switch (reader.Value)
                        {
                            case "apiKey":
                                apiKey = (ApiKey)(reader.ReadAsInt32() ?? -1);
                                break;
                            case "type":
                                type = reader.ReadAsString() ?? "";
                                break;
                            case "listeners":
                                var listenerList = new List<string>();
                                reader.Read(); // Start array
                                reader.Read(); // String or end array.
                                while (reader.TokenType != JsonToken.EndArray)
                                {
                                    listenerList.Add((string)reader.Value);
                                    reader.Read();
                                }
                                listeners = listenerList.ToArray();
                                break;
                            case "name":
                                name = reader.ReadAsString() ?? "";
                                break;
                            case "validVersions":
                                var validVersionsValue = reader.ReadAsString() ?? "";
                                validVersions = ParseVersion(validVersionsValue);
                                break;
                            case "flexibleVersions":
                                var flexibleVersionsValue = reader.ReadAsString() ?? "";
                                flexibleVersions = ParseVersion(flexibleVersionsValue);
                                break;
                            case "fields":
                                reader.Read(); // Start array
                                reader.Read(); // Start object
                                ParseFields(reader, fields, structs);
                                break;
                            case "commonStructs":
                                reader.Read(); // Start array
                                reader.Read(); // Start object
                                ParseStructs(reader, structs);
                                break;
                            default:
                                throw new InvalidOperationException($"Unknown message key '{reader.Value}'");
                        }
                        break;
                }
            }

            return type switch
            {
                "request" => new RequestMessage(
                    apiKey,
                    listeners,
                    name,
                    validVersions,
                    flexibleVersions,
                    fields.ToImmutableArray(),
                    structs.ToImmutableDictionary()
                ),
                "response" => new ResponseMessage(
                    apiKey,
                    name,
                    validVersions,
                    flexibleVersions,
                    fields.ToImmutableArray(),
                    structs.ToImmutableDictionary()
                ),
                "data" => new DataMessage(
                    name,
                    validVersions,
                    flexibleVersions,
                    fields.ToImmutableArray(),
                    structs.ToImmutableDictionary()
                ),
                "header" => new HeaderMessage(
                    name,
                    validVersions,
                    flexibleVersions,
                    fields.ToImmutableArray(),
                    structs.ToImmutableDictionary()
                ),
                var s => throw new Exception($"Unkown message type: {s}")
            };
        }

        private static void ParseFields(
            JsonReader reader,
            IList<Field> fields,
            IDictionary<string, Struct> structs
        )
        {
            while (reader.TokenType != JsonToken.EndArray)
            {
                ParseField(
                    reader,
                    fields,
                    structs
                );
                reader.Read();
            }
        }

        private static void ParseStructs(
            JsonReader reader,
            IDictionary<string, Struct> structs
        )
        {
            while (reader.TokenType != JsonToken.EndArray)
            {
                ParseStruct(
                    reader,
                    structs
                );
                reader.Read();
            }
        }

        private static void ParseField(
            JsonReader reader,
            IList<Field> fields,
            IDictionary<string, Struct> structs
        )
        {
            var name = "";
            var type = (FieldType)EmptyFieldType.Instance;
            var versions = Version.Empty;
            var entityType = "";
            var about = "";
            var tag = -1;
            var ignorable = false;
            var mapKey = false;
            var nullableVersions = Version.Empty;
            var defaultValue = "";
            var flexibleVersions = Version.Empty;
            var taggedVersions = Version.Empty;
            var zeroCopy = false;
            var localFields = new List<Field>();
            var localStructs = new Dictionary<string, Struct>();
            while (reader.TokenType != JsonToken.EndObject && reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.PropertyName:
                        switch (reader.Value)
                        {
                            case "name":
                                name = reader.ReadAsString() ?? "";
                                break;
                            case "type":
                                var typeValue = reader.ReadAsString() ?? "";
                                type = GetFieldType(typeValue);
                                break;
                            case "versions":
                                var versionsValue = reader.ReadAsString() ?? "";
                                versions = ParseVersion(versionsValue);
                                break;
                            case "nullableVersions":
                                var nullableVersionsValue = reader.ReadAsString() ?? "";
                                nullableVersions = ParseVersion(nullableVersionsValue);
                                break;
                            case "taggedVersions":
                                var taggedVersionsValue = reader.ReadAsString() ?? "";
                                taggedVersions = ParseVersion(taggedVersionsValue);
                                break;
                            case "flexibleVersions":
                                var flexibleVersionsValue = reader.ReadAsString() ?? "";
                                flexibleVersions = ParseVersion(flexibleVersionsValue);
                                break;
                            case "entityType":
                                entityType = reader.ReadAsString() ?? "";
                                break;
                            case "about":
                                about = reader.ReadAsString() ?? "";
                                break;
                            case "tag":
                                tag = reader.ReadAsInt32() ?? -1;
                                break;
                            case "ignorable":
                                ignorable = reader.ReadAsBoolean() ?? false;
                                break;
                            case "mapKey":
                                mapKey = reader.ReadAsBoolean() ?? false;
                                break;
                            case "default":
                                defaultValue = reader.ReadAsString() ?? "";
                                break;
                            case "zeroCopy":
                                zeroCopy = reader.ReadAsBoolean() ?? false;
                                break;
                            case "fields":
                                reader.Read(); // Start array
                                reader.Read(); // Start object
                                ParseFields(
                                    reader,
                                    localFields,
                                    localStructs
                                );
                                break;
                            default:
                                throw new InvalidOperationException($"Unknown field key '{reader.Value}'");
                        }
                        break;
                }
            }

            if (type is EmptyFieldType)
                throw new InvalidOperationException("Unable to determine field type");

            var structType = GetStructType(type);
            if(structType != null && localFields.Count > 0)
                structs.Add(
                    structType.Name,
                    new(
                        structType.Name,
                        versions,
                        localFields.ToImmutableArray(),
                        localStructs.ToImmutableDictionary()
                    )
                );

            fields.Add(
                new(
                    Name: name,
                    Type: type,
                    Versions: versions,
                    NullableVersions: nullableVersions,
                    TaggedVersions: taggedVersions,
                    FlexibleVersions: flexibleVersions,
                    EntityType: entityType,
                    About: about,
                    Ignorable: ignorable,
                    MapKey: mapKey,
                    ZeroCopy: zeroCopy,
                    Tag: tag,
                    DefaultValue: defaultValue
                )
            );
        }

        private static StructFieldType? GetStructType(
            FieldType type
        ) =>
            type switch
            {
                StructFieldType s => s,
                ArrayFieldType a => GetStructType(a.ItemType),
                _ => default
            }
        ;


        private static void ParseStruct(
            JsonReader reader,
            IDictionary<string, Struct> structs
        )
        {
            var name = "";
            var versions = Version.Empty;
            var fields = new List<Field>();
            var localStructs = new Dictionary<string, Struct>();
            while (reader.TokenType != JsonToken.EndObject && reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.PropertyName:
                        switch (reader.Value)
                        {
                            case "name":
                                name = reader.ReadAsString() ?? "";
                                break;
                            case "versions":
                                var versionsValue = reader.ReadAsString() ?? "";
                                versions = ParseVersion(versionsValue);
                                break;
                            case "fields":
                                reader.Read(); // Start array
                                reader.Read(); // Start object
                                ParseFields(
                                    reader,
                                    fields,
                                    localStructs
                                );
                                break;
                            default:
                                throw new InvalidOperationException($"Unknown field key '{reader.Value}'");
                        }
                        break;
                }
            }

            structs.Add(
                name,
                new(
                    name,
                    versions,
                    fields.ToImmutableArray(),
                    localStructs.ToImmutableDictionary()
                )
            );
        }

        private static FieldType GetFieldType(string type) =>
            (type.StartsWith("[]"), type) switch
            {
                (true, var t) => new ArrayFieldType(GetFieldType(t[2..])),
                (_, "bool") => new ScalarFieldType("bool"),
                (_, "int8") => new ScalarFieldType("int8"),
                (_, "int16") => new ScalarFieldType("int16"),
                (_, "uint16") => new ScalarFieldType("uint16"),
                (_, "int32") => new ScalarFieldType("int32"),
                (_, "uint32") => new ScalarFieldType("uint32"),
                (_, "int64") => new ScalarFieldType("int64"),
                (_, "uint64") => new ScalarFieldType("uint64"),
                (_, "varint") => new ScalarFieldType("uint32"),
                (_, "varlong") => new ScalarFieldType("uint64"),
                (_, "uuid") => new ScalarFieldType("uuid"),
                (_, "float64") => new ScalarFieldType("float64"),
                (_, "string") => new ScalarFieldType("string"),
                (_, "bytes") => new ScalarFieldType("bytes"),
                (_, "records") => RecordsFieldType.Instance,
                (_, var t) => new StructFieldType(t)
            }
        ;

        private static Version ParseVersion(
            string versionString
        )
        {
            return versionString switch
            {
                "none" => Version.Empty,
                var v => (v.IndexOf('+'), v.IndexOf('-')) switch
                {
                    (var p, -1) when p >= 0 => Version.From(short.Parse(v[..p])),
                    (-1, var d) when d >= 0 => Version.Between(short.Parse(v[..d]), short.Parse(v[(d + 1)..])),
                    _ => Version.Exactly(short.Parse(v))
                }
            };
        }
    }
}
