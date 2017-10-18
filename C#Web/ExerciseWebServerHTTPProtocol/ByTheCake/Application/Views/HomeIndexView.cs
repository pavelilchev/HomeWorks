namespace ByTheCake.Application.Views
{
    using ByTheCake.Server.Contracts;

    public class HomeIndexView : IView
    {
        public string View()
        {
            const string fileName = "index.html";

            return HtmlView.GetHtml(fileName);
        }
    }
}
