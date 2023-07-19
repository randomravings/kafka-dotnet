namespace Kafka.Common.Model.Comparison
{
    public sealed class TopicCompare :
        IComparer<Topic>,
        IEqualityComparer<Topic>
    {
        private TopicCompare() { }
        private static readonly TopicCompare INSTANCE = new();
        public static IComparer<Topic> Instance { get; } = INSTANCE;
        public static IEqualityComparer<Topic> Equality { get; } = INSTANCE;
        int IComparer<Topic>.Compare(Topic x, Topic y) =>
            TopicIdCompare.Instance.Compare(x.TopicId, y.TopicId) switch
            {
                0 => TopicNameCompare.Instance.Compare(x.TopicName, y.TopicName),
                int v => v
            }
        ;

        bool IEqualityComparer<Topic>.Equals(Topic x, Topic y) =>
            x == y
        ;

        int IEqualityComparer<Topic>.GetHashCode(Topic obj) =>
            obj.GetHashCode()
        ;
    }
}
