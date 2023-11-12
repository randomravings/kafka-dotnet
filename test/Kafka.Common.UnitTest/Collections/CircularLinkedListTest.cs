using Kafka.Common.Collections;

namespace Kafka.Common.UnitTest.Collections
{
    [TestFixture]
    public class CircularLinkedListTest
    {
        [Test]
        public void TestConstructor()
        {
            var node = new CircularLinkedList<int>(1);
            Assert.Multiple(() =>
            {
                Assert.That(node.Previous, Is.SameAs(node));
                Assert.That(node.Next, Is.SameAs(node));
                Assert.That(node.Value, Is.EqualTo(1));
            });
        }

        [Test]
        public void TestAdd()
        {
            var node0 = new CircularLinkedList<int>(0);

            var node1 = node0.Add(1);
            Assert.Multiple(() =>
            {
                Assert.That(node0.Previous, Is.SameAs(node1));
                Assert.That(node0.Next, Is.SameAs(node1));
                Assert.That(node1.Previous, Is.SameAs(node0));
                Assert.That(node1.Next, Is.SameAs(node0));
                Assert.That(node1.Value, Is.EqualTo(1));
                Assert.That(node1.Previous.Value, Is.EqualTo(0));
                Assert.That(node1.Next.Value, Is.EqualTo(0));
            });

            var node2 = node0.Add(2);
            Assert.Multiple(() =>
            {
                Assert.That(node0.Previous, Is.SameAs(node2));
                Assert.That(node0.Next, Is.SameAs(node1));
                Assert.That(node1.Previous, Is.SameAs(node0));
                Assert.That(node1.Next, Is.SameAs(node2));
                Assert.That(node2.Previous, Is.SameAs(node1));
                Assert.That(node2.Next, Is.SameAs(node0));
                Assert.That(node2.Value, Is.EqualTo(2));
                Assert.That(node2.Previous.Value, Is.EqualTo(1));
                Assert.That(node2.Next.Value, Is.EqualTo(0));
            });

            var node3 = node0.Add(3);
            Assert.Multiple(() =>
            {
                Assert.That(node0.Previous, Is.SameAs(node3));
                Assert.That(node0.Next, Is.SameAs(node1));
                Assert.That(node1.Previous, Is.SameAs(node0));
                Assert.That(node1.Next, Is.SameAs(node2));
                Assert.That(node2.Previous, Is.SameAs(node1));
                Assert.That(node2.Next, Is.SameAs(node3));
                Assert.That(node3.Previous, Is.SameAs(node2));
                Assert.That(node3.Next, Is.SameAs(node0));
                Assert.That(node3.Value, Is.EqualTo(3));
                Assert.That(node3.Previous.Value, Is.EqualTo(2));
                Assert.That(node3.Next.Value, Is.EqualTo(0));
            });

            var node4 = node0.Add(4);
            Assert.Multiple(() =>
            {
                Assert.That(node0.Previous, Is.SameAs(node4));
                Assert.That(node0.Next, Is.SameAs(node1));
                Assert.That(node1.Previous, Is.SameAs(node0));
                Assert.That(node1.Next, Is.SameAs(node2));
                Assert.That(node2.Previous, Is.SameAs(node1));
                Assert.That(node2.Next, Is.SameAs(node3));
                Assert.That(node3.Previous, Is.SameAs(node2));
                Assert.That(node3.Next, Is.SameAs(node4));
                Assert.That(node4.Previous, Is.SameAs(node3));
                Assert.That(node4.Next, Is.SameAs(node0));
                Assert.That(node4.Value, Is.EqualTo(4));
                Assert.That(node4.Previous.Value, Is.EqualTo(3));
                Assert.That(node4.Next.Value, Is.EqualTo(0));
            });

            var node22 = node3.Add(22);
            Assert.Multiple(() =>
            {
                Assert.That(node0.Previous, Is.SameAs(node4));
                Assert.That(node0.Next, Is.SameAs(node1));
                Assert.That(node1.Previous, Is.SameAs(node0));
                Assert.That(node1.Next, Is.SameAs(node2));
                Assert.That(node2.Previous, Is.SameAs(node1));
                Assert.That(node2.Next, Is.SameAs(node22));
                Assert.That(node3.Previous, Is.SameAs(node22));
                Assert.That(node3.Next, Is.SameAs(node4));
                Assert.That(node4.Previous, Is.SameAs(node3));
                Assert.That(node4.Next, Is.SameAs(node0));
                Assert.That(node22.Previous, Is.SameAs(node2));
                Assert.That(node22.Next, Is.SameAs(node3));
                Assert.That(node22.Value, Is.EqualTo(22));
                Assert.That(node22.Previous.Value, Is.EqualTo(2));
                Assert.That(node22.Next.Value, Is.EqualTo(3));
            });
        }

        [Test]
        public void TestRemoveSingleNode()
        {
            var node = new CircularLinkedList<int>(0);
            node = node.Remove();
            Assert.That(node, Is.Null);
        }

        [Test]
        public void TestRemoveMiddle()
        {
            var node0 = new CircularLinkedList<int>(0);
            var node1 = node0.Add(1);
            var node2 = node0.Add(2);
            var node3 = node0.Add(3);
            var node4 = node0.Add(4);
            var node5 = node0.Add(5);

            var node = node3.Remove();

            Assert.Multiple(() =>
            {
                // The preceeding node is returned.
                Assert.That(node, Is.EqualTo(node4));

                // Node 3 is now detached/isolated.
                Assert.That(node3.Value, Is.EqualTo(3));
                Assert.That(node3.Previous, Is.SameAs(node3));
                Assert.That(node3.Next, Is.SameAs(node3));

                // The remaining nodes.
                Assert.That(node0.Value, Is.EqualTo(0));
                Assert.That(node0.Previous, Is.SameAs(node5));
                Assert.That(node0.Next, Is.SameAs(node1));
                Assert.That(node1.Value, Is.EqualTo(1));
                Assert.That(node1.Previous, Is.SameAs(node0));
                Assert.That(node1.Next, Is.SameAs(node2));
                Assert.That(node2.Value, Is.EqualTo(2));
                Assert.That(node2.Previous, Is.SameAs(node1));
                Assert.That(node2.Next, Is.SameAs(node4));
                Assert.That(node4.Value, Is.EqualTo(4));
                Assert.That(node4.Previous, Is.SameAs(node2));
                Assert.That(node4.Next, Is.SameAs(node5));
                Assert.That(node5.Value, Is.EqualTo(5));
                Assert.That(node5.Previous, Is.SameAs(node4));
                Assert.That(node5.Next, Is.SameAs(node0));
            });
        }
    }
}
