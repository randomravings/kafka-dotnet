namespace Kafka.Common.Types
{
    public readonly record struct Topic(
        Guid Id,
        string? Name
    )
    {
        public static readonly Topic Empty = new(Guid.Empty, null);
        public static implicit operator Topic(string? name) => new(Guid.Empty, name);
        public static implicit operator Topic(Guid id) => new(id, null);
        public static bool operator <=(Topic a, Topic b) =>
            string.CompareOrdinal(a.Name, b.Name) switch
            {
                0 => a.Id.CompareTo(b.Id) <= 0,
                int c => c < 0
            }
        ;
        public static bool operator >=(Topic a, Topic b) =>
            string.CompareOrdinal(a.Name, b.Name) switch
            {
                0 => a.Id.CompareTo(b.Id) >= 0,
                int c => c > 0
            }
        ;
        public static bool operator <(Topic a, Topic b) =>
            string.CompareOrdinal(a.Name, b.Name) switch
            {
                0 => a.Id.CompareTo(b.Id) < 0,
                int c => c < 0
            }
        ;

        public static bool operator >(Topic a, Topic b) =>
            string.CompareOrdinal(a.Name, b.Name) switch
            {
                0 => a.Id.CompareTo(b.Id) > 0,
                int c => c > 0
            }
        ;
    }
}
