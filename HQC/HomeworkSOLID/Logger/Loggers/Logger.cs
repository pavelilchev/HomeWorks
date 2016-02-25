namespace Logger.Loggers
{
    using Enums;
    using Interfaces;

    public class Logger : ILogger
    {
        private readonly IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = new IAppender[appenders.Length];
            this.InitAppenders(appenders);
        }

        public void Info(string msg)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(msg, ReportLevel.Info);
            }
        }

        public void Warn(string msg)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(msg, ReportLevel.Warn);
            }
        }

        public void Error(string msg)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(msg, ReportLevel.Error);
            }
        }

        public void Critical(string msg)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(msg, ReportLevel.Critical);
            }
        }

        public void Fatal(string msg)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(msg, ReportLevel.Fatal);
            }
        }

        private void InitAppenders(IAppender[] appenders)
        {
            for (int i = 0; i < appenders.Length; i++)
            {
                this.appenders[i] = appenders[i];
            }
        }
    }
}
