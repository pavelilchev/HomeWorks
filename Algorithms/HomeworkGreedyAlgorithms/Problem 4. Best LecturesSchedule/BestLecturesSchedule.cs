namespace Problem_4.Best_LecturesSchedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BestLecturesSchedule
    {
        public static void Main()
        {
            int lecturesCount = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();

            var sortedLecures = new SortedSet<Lecture>();
            for (int i = 0; i < lecturesCount; i++)
            {
                var lectureArgs = Console.ReadLine().Split(new[] {' ', ':', '-'}, StringSplitOptions.RemoveEmptyEntries);
                var lecture = new Lecture(lectureArgs[0], int.Parse(lectureArgs[1]), int.Parse(lectureArgs[2]));
                sortedLecures.Add(lecture);
            }

            int currentEnd = int.MinValue;
            var result = new List<Lecture>();
            foreach (var lecture in sortedLecures)
            {
                if (lecture.Start >= currentEnd)
                {
                    result.Add(lecture);
                    currentEnd = lecture.End;
                }
            }

            Console.WriteLine("Lectures ({0})", result.Count);
            foreach (var lecture in result)
            {
                Console.WriteLine("{0}-{1} -> {2}", lecture.Start, lecture.End, lecture.Name);
            }
        }

        private class Lecture : IComparable<Lecture>
        {
            public Lecture(string name, int start, int end)
            {
                this.Name = name;
                this.Start = start;
                this.End = end;
            }

            public string Name { get; private set; }

            public int Start { get; private set; }

            public int End { get; private set; }

            public int CompareTo(Lecture other)
            {
                return this.End.CompareTo(other.End);
            }
        }
    }
}
