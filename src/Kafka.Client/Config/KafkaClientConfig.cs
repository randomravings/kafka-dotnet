using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kafka.Client.Config
{
    public sealed class KafkaClientConfig
    {
        internal static JsonSerializerOptions JsonSerializerOptions { get; } = new()
        {
            WriteIndented = true
        };
        public ClientConfig Client { get; set; } = new();

        public OutputStreamConfig Producer { get; set; } = new();

        public InputStreamConfig Consumer { get; set; } = new();

        public override string ToString() =>
            JsonSerializer.Serialize(
                this,
                JsonSerializerOptions
            )
        ;

        public void Print(in TextWriter textWriter)
        {
            textWriter.WriteLine("Kakfa.Client:");
            WriteConfig(textWriter, Client);
            textWriter.WriteLine();
            textWriter.WriteLine("Kakfa.Producer:");
            WriteConfig(textWriter, Producer);
            textWriter.WriteLine();
            textWriter.WriteLine("Kakfa.Consumer:");
            WriteConfig(textWriter, Consumer);
            textWriter.WriteLine();
        }

        private static void WriteConfig<TConfig>(in TextWriter textWriter, in TConfig instance)
            where TConfig : notnull, new()
        {
            var properties = EnumerateJsonConfig(instance);
            foreach ((var name, var value) in properties)
            {
                textWriter.Write("  ");
                textWriter.Write(name);
                textWriter.Write(": ");
                WriteValue(textWriter, value);
                textWriter.WriteLine();
            }
        }

        private static void WriteValue(in TextWriter textWriter, in object? value)
        {
            switch(value)
            {
                case null:
                    textWriter.Write("<null>");
                    break;
                case true:
                    textWriter.Write("true");
                    break;
                case false:
                    textWriter.Write("false");
                    break;
                case Enum e:
                    var enumType = e.GetType();
                    var stringValue = e.ToString();
                    var memberInfos = enumType.GetMember(stringValue);
                    var enumValueMemberInfo = memberInfos
                        .FirstOrDefault(m =>
                            m.DeclaringType == enumType
                        )
                    ;
                    if (enumValueMemberInfo == null)
                    {
                        textWriter.Write(stringValue);
                        break;
                    }

                    var valueAttributes = enumValueMemberInfo
                        .GetCustomAttributes(
                            typeof(EnumMemberAttribute),
                            false
                        )
                    ;

                    if(valueAttributes == null || valueAttributes.Length != 1)
                        textWriter.Write(stringValue);
                    else
                        textWriter.Write(((EnumMemberAttribute)valueAttributes[0]).Value);
                    break;
                default:
                    textWriter.Write(value.ToString());
                    break;

            }
        }

        private static SortedList<string, object?> EnumerateJsonConfig<TConfig>(in TConfig instance)
            where TConfig : notnull, new()
        {
            var items = new SortedList<string, object?>();
            foreach (var property in instance.GetType().GetProperties())
            {
                var jsonPropertyName = property.GetCustomAttribute<JsonPropertyNameAttribute>();
                if (jsonPropertyName == null)
                    continue;
                var name = jsonPropertyName.Name;
                var value = property.GetValue(instance, null);
                items.Add(name, value);
            }
            return items;
        }
    }
}
