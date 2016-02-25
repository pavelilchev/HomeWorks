namespace Logger.Layouts
{
    using System;
    using Enums;
    using Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Format(string msg, ReportLevel reportLevel)
        {
            DateTime time = DateTime.Now;
            string output = $"{time} - {reportLevel} - {msg}";

            return output;
        }
    }
}
