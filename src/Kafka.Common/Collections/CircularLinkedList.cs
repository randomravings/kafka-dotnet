namespace Kafka.Common.Collections
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class CircularLinkedList<T>
    {
        public CircularLinkedList(T value)
        {
            Value = value;
            Previous = this;
            Next = this;
        }

        /// <summary>
        /// Current value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Previous node, points to self if number of elements = 1,
        /// </summary>
        public CircularLinkedList<T> Previous { get; internal set; }

        /// <summary>
        /// Next node, points to self if number of elements = 1,
        /// </summary>
        public CircularLinkedList<T> Next { get; internal set; }

        /// <summary>
        /// Adds a node to the "end" of the list which is the current node's predecessor.
        /// Complexity: O(1)
        /// </summary>
        /// <param name="value"></param>
        public CircularLinkedList<T> Add(T value)
        {
            var node = new CircularLinkedList<T>(value)
            {
                Next = this,
                Previous = Previous
            };
            Previous.Next = node;
            Previous = node;
            return node;
        }

        /// <summary>
        /// Removes a node from the and returns the preceeding node in the list, null if empty.
        /// Complexity: O(1)
        /// </summary>
        /// <param name="node"></param>
        /// <returns>The next node, null if this is the only node.</returns>
        public CircularLinkedList<T>? Remove()
        {
            if (this == Previous)
                return null;
            var next = Next;
            Previous.Next = Next;
            Next.Previous = Previous;
            Previous = this;
            Next = this;
            return next;
        }
    }
}
