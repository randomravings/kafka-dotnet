namespace Kafka.Common.Model.Comparison
{
    public sealed class ApiKeyCompare :
        IComparer<ApiKey>
    {
        private ApiKeyCompare() { }
        public static IComparer<ApiKey> Instance { get; } = new ApiKeyCompare();
        int IComparer<ApiKey>.Compare(ApiKey x, ApiKey y) =>
            x.Value.CompareTo(y.Value)
        ;
    }
}
