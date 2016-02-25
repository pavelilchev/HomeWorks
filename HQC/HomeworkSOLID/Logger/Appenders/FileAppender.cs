namespace Logger.Appenders
{
    using System.IO;
    using Enums;
    using Interfaces;

    public class FileAppender : IAppender
    {
        private const string DefaultLogPath = @"..\..\log.txt";
        private readonly ILayout layout;

        public FileAppender(ILayout layout)
        {
            this.layout = layout;
            this.File = DefaultLogPath;
            this.ReportLevel = ReportLevel.Info;
        }

        public string File { get; set; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string msg, ReportLevel reportLevel)
        {
            if (this.ReportLevel > reportLevel)
            {
                return;
            }

            string output = this.layout.Format(msg, reportLevel);

            using (var streamWriter = new StreamWriter(this.File, true))
            {
                streamWriter.WriteLine(output);
            }
        }
    }
}
