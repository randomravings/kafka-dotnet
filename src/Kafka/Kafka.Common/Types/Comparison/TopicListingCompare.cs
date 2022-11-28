namespace Kafka.Common.Types.Comparison
{
    public sealed class TopicListingCompare :
        IComparer<TopicListing>
    {
        private TopicListingCompare() { }
        public static IComparer<TopicListing> Instance { get; } = new TopicListingCompare();
        int IComparer<TopicListing>.Compare(TopicListing? x, TopicListing? y) =>
            (x, y) switch
            {
                (null, null) => 0,
                (null, _) => -1,
                (_, null) => 1,
                (var a, var b) => TopicCompare.Instance.Compare(a.Topic, b.Topic)
            }            
        ;
    }
}
