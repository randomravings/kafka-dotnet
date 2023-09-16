namespace Kafka.Common.Model.Comparison
{
    public sealed class TopicNameCompare :
        IComparer<TopicName>
    {
        private TopicNameCompare() { }
        public static IComparer<TopicName> Instance { get; } = new TopicNameCompare();
        int IComparer<TopicName>.Compare(TopicName x, TopicName y) =>
            string.CompareOrdinal(x.Value, y.Value)
        ;
    }
}
