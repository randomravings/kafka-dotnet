using Kafka.Client.Collections;
using Kafka.Common.Model;

namespace Kafka.Client.UnitTest.Collections
{
    [TestFixture]
    public class ConcurrentClusterNodeTest
    {
        [Test]
        public void TestAdd()
        {
            var nodes = new ClusterNodeId[]
            {
                101,
                104,
                102,
                103,
            };

            var clusterNodes = new SpinningDictionary<ClusterNodeId, int>(Compare.ClusterNodeId);

            for (int i = 0; i < nodes.Length; i++)
            {
                var added = clusterNodes.Add(nodes[i], i);
                var count = clusterNodes.Count;
                Assert.Multiple(() =>
                {
                    Assert.That(added, Is.EqualTo(true));
                    Assert.That(count, Is.EqualTo(i + 1));
                });
            }

            var expected = nodes.OrderBy(r => r.Value);
            var items = clusterNodes.CopyItems().Select(r => r.Key);
            CollectionAssert.AreEqual(expected, items);
        }
    }
}
