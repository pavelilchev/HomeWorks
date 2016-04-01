namespace ShoppingCenter
{
    using System;

    public class ShoppingCenterMain
    {
        public static void Main()
        {
            var shoppinCenter = new ShoppingCenter();
            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                string commandLine = Console.ReadLine();
                string output = shoppinCenter.ProcessCommand(commandLine);
                Console.WriteLine(output);
                Console.WriteLine();
            }
        } 
    }
}