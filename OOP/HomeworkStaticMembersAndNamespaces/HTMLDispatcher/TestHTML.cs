using System;

namespace HTMLDispatcher
{
    class TestHTML
    {
        static void Main(string[] args)
        {
            ElementBuilder element = new ElementBuilder("div");
            element.AddAttribute("id", "page");
            element.AddAttribute("class", "big");
            element.AddContent("<p>Hello</p>");
            Console.WriteLine(element);            
            Console.WriteLine(element * 2);
         
        }
    }
}
