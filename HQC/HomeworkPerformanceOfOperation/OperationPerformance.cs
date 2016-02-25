namespace PerformanceOfOperation
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;

    public static class OperationPerformance
    {
        private const int Repetitions = 1000;

        public static void Main()
        {
            var output = TestFirstTable();

            SaveResult(output, @"..\..\ResultFirst.txt");

            var result = TestSecondTable();
            SaveResult(result, @"..\..\ResultSecond.txt");
        }

        private static string TestSecondTable()
        {
            Stopwatch stopwatch = new Stopwatch();
            double doubleTest = 555.55d;
            Decimal decimalTest = 555.55m;
            StringBuilder output = new StringBuilder();

            // Math.Sqrt
            stopwatch.Start();
            for (int i = 0; i < Repetitions; i++)
            {
                Math.Sqrt(doubleTest);
            }

            output.Append(stopwatch.Elapsed + " ");

            stopwatch.Restart();
            for (int i = 0; i < Repetitions; i++)
            {
                Math.Sqrt((double)decimalTest);
            }

            output.Append(stopwatch.Elapsed + " ");
            output.AppendLine();

            // Math.Log
            stopwatch.Start();
            for (int i = 0; i < Repetitions; i++)
            {
              Math.Log(doubleTest);
            }

            output.Append(stopwatch.Elapsed + " ");

            stopwatch.Restart();
            for (int i = 0; i < Repetitions; i++)
            {
                Math.Log((double)decimalTest);
            }

            output.Append(stopwatch.Elapsed + " ");
            output.AppendLine();

            // Math.Sin
            stopwatch.Start();
            for (int i = 0; i < Repetitions; i++)
            {
                double test = Math.Sin(doubleTest);
            }

            output.Append(stopwatch.Elapsed + " ");

            stopwatch.Restart();
            for (int i = 0; i < Repetitions; i++)
            {
                double test = Math.Sin((double)decimalTest);
            }

            output.Append(stopwatch.Elapsed + " ");

            return output.ToString();
        }

        private static string TestFirstTable()
        {
            Stopwatch stopwatch = new Stopwatch();
            int intTest = 1;
            long longTest = 1L;
            double doubleTest = 1.1d;
            float floatTets = 1.1f;
            StringBuilder output = new StringBuilder();

            #region Add test

            stopwatch.Start();
            for (int i = intTest; i < Repetitions; i++)
            {
                intTest += i;
            }

            output.Append("Int " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (long i = longTest; i < Repetitions; i++)
            {
                longTest += i;
            }

            output.Append("Long " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (double i = doubleTest; i < Repetitions; i++)
            {
                doubleTest += i;
            }

            output.Append("Double  " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (float i = floatTets; i < Repetitions; i++)
            {
                floatTets += i;
            }

            output.Append("Float " + stopwatch.Elapsed);
            output.AppendLine();

            #endregion add

            #region Substract test

            stopwatch.Restart();
            for (int i = intTest; i < Repetitions; i++)
            {
                intTest -= i;
            }

            output.Append("Int " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (long i = longTest; i < Repetitions; i++)
            {
                longTest -= i;
            }

            output.Append("Long " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (double i = doubleTest; i < Repetitions; i++)
            {
                doubleTest -= i;
            }

            output.Append("Double " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (float i = floatTets; i < Repetitions; i++)
            {
                floatTets -= i;
            }

            output.Append("Float " + stopwatch.Elapsed);
            output.AppendLine();

            #endregion substract

            #region Prefix test

            stopwatch.Restart();
            for (int i = intTest; i < Repetitions; i++)
            {
                intTest++;
            }

            output.Append("Int " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (long i = longTest; i < Repetitions; i++)
            {
                longTest++;
            }

            output.Append("Long " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (double i = doubleTest; i < Repetitions; i++)
            {
                doubleTest++;
            }

            output.Append("Double " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (float i = floatTets; i < Repetitions; i++)
            {
                floatTets++;
            }

            output.Append("Float " + stopwatch.Elapsed);
            output.AppendLine();

            #endregion prefix

            #region Postfix test

            stopwatch.Restart();
            for (int i = intTest; i < Repetitions; i++)
            {
                ++intTest;
            }

            output.Append("Int " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (long i = longTest; i < Repetitions; i++)
            {
                ++longTest;
            }

            output.Append("Long " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (double i = doubleTest; i < Repetitions; i++)
            {
                ++doubleTest;
            }

            output.Append("Double " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (float i = floatTets; i < Repetitions; i++)
            {
                ++floatTets;
            }

            output.Append("Float " + stopwatch.Elapsed);
            output.AppendLine();

            #endregion postfix

            #region +=1 test

            stopwatch.Restart();
            for (int i = intTest; i < Repetitions; i++)
            {
                intTest += 1;
            }

            output.Append("Int " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (long i = longTest; i < Repetitions; i++)
            {
                longTest += 1;
            }

            output.Append("Long " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (double i = doubleTest; i < Repetitions; i++)
            {
                doubleTest += 1;
            }

            output.Append("Double " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (float i = floatTets; i < Repetitions; i++)
            {
                floatTets += 1;
            }

            output.Append("Float " + stopwatch.Elapsed);
            output.AppendLine();

            #endregion +=1

            #region multiply test

            stopwatch.Restart();
            for (int i = intTest; i < Repetitions; i++)
            {
                intTest *= 1;
            }

            output.Append("Int " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (long i = longTest; i < Repetitions; i++)
            {
                longTest *= 1;
            }

            output.Append("Long " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (double i = doubleTest; i < Repetitions; i++)
            {
                doubleTest *= 1;
            }

            output.Append("Double " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (float i = floatTets; i < Repetitions; i++)
            {
                floatTets *= 1;
            }

            output.Append("Float " + stopwatch.Elapsed);
            output.AppendLine();

            #endregion multiply

            #region divide test

            stopwatch.Restart();
            for (int i = intTest; i < Repetitions; i++)
            {
                intTest /= 1;
            }

            output.Append("Int " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (long i = longTest; i < Repetitions; i++)
            {
                longTest /= 1;
            }

            output.Append("Long " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (double i = doubleTest; i < Repetitions; i++)
            {
                doubleTest /= 1;
            }

            output.Append("Double " + stopwatch.Elapsed);

            stopwatch.Restart();
            for (float i = floatTets; i < Repetitions; i++)
            {
                floatTets /= 1;
            }

            output.Append("Float " + stopwatch.Elapsed);
            output.AppendLine();

            #endregion divide 

            return output.ToString();
        }

        private static void SaveResult(string output, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(output);
            }
        }
    }
}
