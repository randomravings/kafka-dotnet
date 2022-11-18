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
            a.Id.CompareTo(b.Id) switch
            {
                -1 => true,
                1 => false,
                _ => string.CompareOrdinal(a.Name, b.Name) switch
                {
                    -1 => true,
                    1 => false,
                    _ => true,
                }
            }
            
        ;
        public static bool operator >=(Topic a, Topic b) =>
            a.Id.CompareTo(b.Id) switch
            {
                -1 => false,
                1 => true,
                _ => string.CompareOrdinal(a.Name, b.Name) switch
                {
                    -1 => false,
                    1 => true,
                    _ => true,
                }
            }
        ;
        public static bool operator <(Topic a, Topic b) =>
            a.Id.CompareTo(b.Id) switch
            {
                -1 => true,
                1 => false,
                _ => string.CompareOrdinal(a.Name, b.Name) switch
                {
                    -1 => true,
                    1 => false,
                    _ => false,
                }
            }
        ;

        public static bool operator >(Topic a, Topic b) =>
            a.Id.CompareTo(b.Id) switch
            {
                -1 => false,
                1 => true,
                _ => string.CompareOrdinal(a.Name, b.Name) switch
                {
                    -1 => false,
                    1 => true,
                    _ => false,
                }
            }
        ;
    }
}
