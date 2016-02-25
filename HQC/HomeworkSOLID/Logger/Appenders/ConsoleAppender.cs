namespace Logger.Appenders
{
    using System;
    using Enums;
    using Interfaces;

    public class ConsoleAppender : IAppender
    {
        private readonly ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
            this.ReportLevel = ReportLevel.Info;
        }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string msg, ReportLevel reportLevel)
        {
            if (this.ReportLevel > reportLevel)
            {
                return;
            }

            string output = this.layout.Format(msg, reportLevel);
            Console.WriteLine(output);
        }
    }
}
