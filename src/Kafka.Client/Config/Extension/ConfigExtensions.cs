namespace Kafka.Client.Config.Extension
{
    public static class ConfigExtensions
    {
        public static KafkaClientConfig Copy(this KafkaClientConfig kafkaClientConfig) =>
            CopyInstance(kafkaClientConfig)
        ;
        public static ClientConfig Copy(this ClientConfig clientConfig) =>
            CopyInstance(clientConfig)
        ;
        public static InputStreamConfig Copy(this InputStreamConfig inputStreamConfig) =>
            CopyInstance(inputStreamConfig)
        ;
        public static OutputStreamConfig Copy(this OutputStreamConfig outputStreamConfig) =>
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
