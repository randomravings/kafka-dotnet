namespace Kafka.Common.Types.Comparison
{
    public sealed class TopicCompare :
        IComparer<Topic>
    {
        private TopicCompare() { }
        public static IComparer<Topic> Instance { get; } = new TopicCompare();
        int IComparer<Topic>.Compare(Topic x, Topic y) =>
            string.CompareOrdinal(x.Name, y.Name) switch
            {
                0 => x.Id.CompareTo(y.Id),
                int v => v
            }
        ;
    }
}
