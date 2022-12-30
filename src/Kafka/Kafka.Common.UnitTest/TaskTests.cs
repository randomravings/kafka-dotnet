using Kafka.Common.Hashing;

namespace Kafka.Common.UnitTest.Hashing
{
    [TestFixture]
    public class TaskTests
    {
        [Test]
        public async Task Test()
        {
            var taskCompletionSource1 = new TaskCompletionSource<string>();
            var taskCompletionSource2 = new TaskCompletionSource<string>();

            taskCompletionSource1.SetResult("a");
            taskCompletionSource2.SetException(new Exception());

            var taskCompletionSources = new[]
            {
                taskCompletionSource1.Task,
                taskCompletionSource2.Task
            };

            var allTasks = Task.WhenAll(taskCompletionSources);

            try
            {
                await allTasks;
            }
            catch(Exception)
            {
                for(int i = 0; i < taskCompletionSources.Length; i++)
                {
                    var x = taskCompletionSources[i];
                    if (x.IsFaulted)
                        Console.WriteLine($"Exception on {i}");
                    else
                        Console.WriteLine($"No Exception on {i}");
                }
            }
        }
    }
}
