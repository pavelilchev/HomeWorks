namespace ByTheCake.Application.Views
{
    using ByTheCake.Models;
    using ByTheCake.Server;
    using ByTheCake.Server.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CakeSearchView : IView
    {
        private List<string> cakes;

        public CakeSearchView(List<string> cakes)
        {
            this.cakes = cakes;
        }

        public string View()
        {
            const string fileName = "search.html";

            var html =  HtmlView.GetHtml(fileName);

            html = html.Replace("{{CAKES}}", string.Join(Environment.NewLine, cakes.Select(c => $"<li>{c.ToString()}</li>")));

            return html;
        }
    }
}
