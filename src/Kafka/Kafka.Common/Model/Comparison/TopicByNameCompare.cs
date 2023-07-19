namespace Kafka.Common.Model.Comparison
{
    public sealed class TopicByNameCompare :
        IComparer<Topic>,
        IEqualityComparer<Topic>
    {
        private TopicByNameCompare() { }
        private static readonly TopicByNameCompare INSTANCE = new();
        public static IComparer<Topic> Instance { get; } = INSTANCE;
        public static IEqualityComparer<Topic> Equality { get; } = INSTANCE;
        int IComparer<Topic>.Compare(Topic x, Topic y) =>
            TopicNameCompare.Instance.Compare(x.TopicName, y.TopicName)
        ;

        bool IEqualityComparer<Topic>.Equals(Topic x, Topic y) =>
            x.TopicName == y.TopicName
        ;

        int IEqualityComparer<Topic>.GetHashCode(Topic obj) =>
            obj.TopicName.GetHashCode()
        ;
    }
}
