namespace PhotoShare.Client.Core
{
    using System;
    using Models;

    public class Engine
    {
        private readonly CommandDispatcher commandDispatcher;

        public static User User { get; set; }


        public Engine(CommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Trim();
                    string[] data = input.Split(' ');
                    string result = this.commandDispatcher.DispatchCommand(data);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
