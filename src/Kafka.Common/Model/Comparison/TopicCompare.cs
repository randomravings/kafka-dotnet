namespace Kafka.Common.Model.Comparison
{
    public sealed class TopicCompare :
        IComparer<Topic>
    {
        private TopicCompare() { }
        public static IComparer<Topic> Instance { get; } = new TopicCompare();
        int IComparer<Topic>.Compare(Topic x, Topic y)
        {
            if (x.TopicId.Value == Guid.Empty ^ y.TopicId.Value == Guid.Empty)
                return TopicNameCompare.Instance.Compare(x.TopicName, y.TopicName);
            else
                return TopicIdCompare.Instance.Compare(x.TopicId, y.TopicId);
        }
    }
}
