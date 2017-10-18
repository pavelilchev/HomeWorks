namespace ByTheCake.Application.Views
{
    using ByTheCake.Models;
    using ByTheCake.Server;
    using ByTheCake.Server.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CakeAddView : IView
    {
        private List<Cake> cakes;

        public CakeAddView(List<Cake> cakes = null)
        {
            this.cakes = cakes;
        }

        public string View()
        {
            const string fileName = "cake-add.html";

            var html =  HtmlView.GetHtml(fileName);

            html = html.Replace("{{CAKES}}", string.Join(Environment.NewLine, cakes.Select(c => $"<li>{c.ToString()}</li>")));

            return html;
        }
    }
}
