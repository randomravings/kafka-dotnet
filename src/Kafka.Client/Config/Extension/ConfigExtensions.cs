using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Config.Extension
{
    public static class ConfigExtensions
    {
        public static KafkaClientConfig Copy([NotNull] this KafkaClientConfig kafkaClientConfig) =>
            CopyInstance(kafkaClientConfig)
        ;
        public static ClientConfig Copy([NotNull] this ClientConfig clientConfig) =>
            CopyInstance(clientConfig)
        ;
        public static ReadStreamConfig Copy([NotNull] this ReadStreamConfig inputStreamConfig) =>
            CopyInstance(inputStreamConfig)
        ;
        public static WriteStreamConfig Copy([NotNull] this WriteStreamConfig outputStreamConfig) =>
            CopyInstance(outputStreamConfig)
        ;
        private static T CopyInstance<T>(T instance)
            where T : notnull, new()
        {
            var copy = new T();
            foreach (var property in instance.GetType().GetProperties())
            {
                var value = property.GetValue(instance, null);
                property.SetValue(copy, value, null);
            }
            return copy;
        }
    }
}
