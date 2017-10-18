namespace ByTheCake.Application.Views
{
    using ByTheCake.Server.Contracts;

    public class HomeAboutView : IView
    {
        public string View()
        {
            const string fileName = "about.html";

            return HtmlView.GetHtml(fileName);
        }
    }
}