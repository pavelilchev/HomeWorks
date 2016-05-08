namespace Problem2ProcessorScheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProcessorScheduling
    {
        public static void Main()
        {
            int tasks = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();

            var sortedTasks = new SortedSet<Task>();
            for (int i = 0; i < tasks; i++)
            {
                var task =
                    Console.ReadLine()
                        .Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                sortedTasks.Add(new Task(task[0], task[1]));
            }

            var resultTasks = new List<Task>();
            int totaValue = 0;
            while (sortedTasks.Count > 0)
            {
                var currentTask = sortedTasks.Max;
                totaValue += currentTask.Value;
                sortedTasks.Remove(currentTask);
                resultTasks.Add(currentTask);
                resultTasks.Sort((x,y)=>x.DeadLine.CompareTo(y.DeadLine));
                bool cannotComplete = resultTasks.Where((t, i) => t.DeadLine < i + 1).Any();

                if (cannotComplete)
                {
                    resultTasks.Remove(currentTask);
                    totaValue -= currentTask.Value;
                }
            }

            Console.WriteLine("Optimal schedule: " + string.Join(" -> ", resultTasks.Select(x=>x.Id)));
            Console.WriteLine("Total value: " + totaValue);
        }

        private class Task : IComparable<Task>
        {
            private static int uniqueId = 1;

            public Task(int value, int deadLine)
            {
                this.Value = value;
                this.DeadLine = deadLine;
                this.Id = uniqueId++;
            }

            public int Id { get; private set; }

            public int Value { get; private set; }

            public int DeadLine { get; private set; }

            public int CompareTo(Task other)
            {
                return this.Value.CompareTo(other.Value);
            }
        }
    }
}
