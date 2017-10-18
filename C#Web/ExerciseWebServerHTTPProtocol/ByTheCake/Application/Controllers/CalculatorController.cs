namespace ByTheCake.Application.Controllers
{
    using ByTheCake.Application.Views;
    using ByTheCake.Server.Enums;
    using ByTheCake.Server.HTTP.Contracts;
    using ByTheCake.Server.HTTP.Response;
    using System;

    public class CalculatorController
    {
        private string[] validOperators = new string[] { "*", "/", "+", "-" };
		public IHttpResponse Index()
        {
            return new ViewResponse(HttpStatusCode.OK, new CalculatorView());
        }

        public IHttpResponse Calculate(string firstOperand, string secondOperand, string operatorSign)
        {
            string result = "Invalid Sign!";
            var indexOfOperand = Array.IndexOf(validOperators, operatorSign);
            if (indexOfOperand >= 0)
            {
                var first = double.Parse(firstOperand);
                var second = double.Parse(secondOperand);
                var exp = default(double);
                if (indexOfOperand == 0)
                {
                    exp = first * second;
                }
                else if(indexOfOperand == 1)
                {
                    exp = first / second;
                }
                else if(indexOfOperand == 2)
                {
                    exp = first + second;
                }
                else if(indexOfOperand == 3)
                {
                    exp = first - second;
                }

                result = "Result: " + exp;
            }

            return new ViewResponse(HttpStatusCode.OK, new CalculatorView(result));
        }
    }
}
