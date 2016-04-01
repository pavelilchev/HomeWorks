namespace Problem3CalculateArithmeticExpression
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public static class CalculateArithmeticExpression
    {
        public static void Main()
        {
            try
            {
                string expression = Console.ReadLine();
                var expressionTokens = SplitInput(expression);

                var rpn = ConvertExpressionToRpn(expressionTokens);

                double result = CalculateExpressionInRpn(rpn);

                Console.WriteLine(result);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
        }

        private static double CalculateExpressionInRpn(Queue<string> expressionTokens)
        {
            var operands = new Stack<string>();
            var operatorTokens = new Dictionary<string, int>
            {
               { "+", 2 },
               { "-", 2 },
               { "*", 3 },
               { "/", 3 },
               { "^", 4 }
            };

            while (expressionTokens.Count > 0)
            {
                var token = expressionTokens.Dequeue();

                if (!operatorTokens.ContainsKey(token))
                {
                    operands.Push(token);
                }
                else
                {
                    if (operands.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression.");
                    }

                    double operandTwo = double.Parse(operands.Pop());
                    double operandOne = double.Parse(operands.Pop());
                    double result = 0;

                    switch (token)
                    {
                        case "+":
                            result += operandTwo + operandOne;
                            break;
                        case "-":
                            result += operandOne - operandTwo;
                            break;
                        case "*":
                            result += operandOne * operandTwo;
                            break;
                        case "/":
                            result += operandOne / operandTwo;
                            break;
                        case "^":
                            result += Math.Pow(operandOne, operandTwo);
                            break;
                    }

                    operands.Push(result.ToString(CultureInfo.InvariantCulture));
                }
            }

            if (operands.Count != 1)
            { 
                throw new ArgumentException("Expression is wrong");
            }

            double expressionResult = double.Parse(operands.Pop());
            return expressionResult;
        }

        private static Queue<string> ConvertExpressionToRpn(string[] expressionTokens)
        {
            var output = new Queue<string>();
            var operators = new Stack<string>();
            var operatorTokens = new Dictionary<string, int>
            {
               { "+", 2 },
               { "-", 2 },
               { "*", 3 },
               { "/", 3 },
               { "^", 4 },
            };

            foreach (string token in expressionTokens)
            {
                if (operatorTokens.ContainsKey(token))
                {
                    if (operators.Count == 0)
                    {
                        operators.Push(token);
                    }
                    else
                    {
                        var prevToken = operators.Peek();

                        while (prevToken != "(" && operatorTokens[prevToken] >= operatorTokens[token])
                        {
                            prevToken = operators.Pop();
                            output.Enqueue(prevToken);

                            if (operators.Count == 0)
                            {
                                break;
                            }

                            prevToken = operators.Peek();
                        }

                        operators.Push(token);
                    }
                }
                else if (token == "(")
                {
                    operators.Push(token);
                }
                else if (token == ")")
                {
                    var prevToken = operators.Pop();
                    while (prevToken != "(")
                    {
                        output.Enqueue(prevToken);
                        prevToken = operators.Pop();
                    }

                    if (prevToken != "(")
                    {
                        throw new ArgumentException("Expression is wrong");
                    }
                }
                else
                {
                    output.Enqueue(token);
                }
            }

            while (operators.Count > 0)
            {
                var currentToken = operators.Pop();
                if (currentToken == "(")
                {
                    throw new ArgumentException("Expression is wrong");
                }

                output.Enqueue(currentToken);
            }

            return output;
        }

        private static string[] SplitInput(string input)
        {
            var splitedInput = new List<string>();
            bool lastIsDigit = false;
            string digit = string.Empty;

            foreach (char c in input)
            {
                if (c == ' ')
                {
                    continue;
                }

                if (lastIsDigit)
                {
                    if (!char.IsDigit(c) && c != '.')
                    {
                        splitedInput.Add(digit);
                        digit = string.Empty;
                        splitedInput.Add(c.ToString());
                        lastIsDigit = false;
                    }
                    else
                    {
                        digit += c;
                    }
                }
                else
                {
                    if (char.IsDigit(c) || c == '-' || c == '.')
                    {
                        digit += c;
                        lastIsDigit = true;
                    }
                    else
                    {
                        splitedInput.Add(c.ToString());
                    }
                }
            }

            if (!string.IsNullOrEmpty(digit))
            {
                splitedInput.Add(digit);
            }

            return splitedInput.ToArray();
        }
    }
}
