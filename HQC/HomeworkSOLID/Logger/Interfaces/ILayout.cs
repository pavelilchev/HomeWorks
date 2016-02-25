namespace Logger.Interfaces
{
    using Enums;

    public interface ILayout
    {
        string Format(string msg, ReportLevel reportLevel);
    }
}
