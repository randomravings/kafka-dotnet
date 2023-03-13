namespace Kafka.Common.Model.Comparison
{
    public sealed class TopicIdCompare :
        IComparer<TopicId>
    {
        private TopicIdCompare() { }
        public static IComparer<TopicId> Instance { get; } = new TopicIdCompare();
        int IComparer<TopicId>.Compare(TopicId x, TopicId y) =>
            x.Value.CompareTo(y.Value)
        ;
    }
}
