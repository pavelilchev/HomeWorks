namespace ByTheCake.Application.Views
{
    using ByTheCake.Models;
    using ByTheCake.Server;
    using ByTheCake.Server.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CalculatorView : IView
    {
        private string result;

        public CalculatorView(string result = "")
        {
            this.result = result;
        }

        public string View()
        {
            const string fileName = "calculator.html";

            var html =  HtmlView.GetHtml(fileName);

            html = html.Replace("{{RESULT}}", this.result);

            return html;
        }
    }
}
