namespace EventHolder
{
    using System;

    public class EventEngine
    {
        private readonly EventHolder events;

        public EventEngine()
        {
            this.events = new EventHolder();
        }

        public void Run()
        {
            bool isRuning = true;

            while (isRuning)
            {
                string command = Console.ReadLine();
                isRuning = this.ExecuteNextCommand(command);
            }

            Console.WriteLine(Messages.GetOutputMesseges());
        }

        private static void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);
            int firstPipeIndex = commandForExecution.IndexOf('|');
            int lastPipeIndex = commandForExecution.LastIndexOf('|');
            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution.Substring(
                    firstPipeIndex + 1,
                    lastPipeIndex - firstPipeIndex - 1).Trim();

                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private static DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
            return date;
        }

        private bool ExecuteNextCommand(string command)
        {
            switch (command[0])
            {
                case 'A':
                    this.AddEvent(command);
                    return true;
                case 'D':
                    this.DeleteEvents(command);
                    return true;
                case 'L':
                    this.ListEvents(command);
                    return true;
                case 'E':
                    return false;
            }

            return false;
        }

        private void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            DateTime date = GetDate(command, "ListEvents");
            string countString = command.Substring(pipeIndex + 1);

            int count = int.Parse(countString);
            this.events.ListEvents(date, count);
        }

        private void DeleteEvents(string command)
        {
            string title = command.Substring("DeleteEvents".Length + 1);
            this.events.DeleteEvents(title);
        }

        private void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;
            GetParameters(command, "CreateEvent", out date, out title, out location);

            this.events.CreateEvent(date, title, location);
        }
    }
}
