namespace EventHolder
{
    using System.Text;

    public static class Messages
    {
        private static readonly StringBuilder Output = new StringBuilder();

        public static void EventAdded()
        {
            Output.Append("Event added").AppendLine();
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                Output.AppendFormat("{0} events deleted", x).AppendLine();
            }
        }

        public static void NoEventsFound()
        {
            Output.Append("No events found").AppendLine();
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Output.Append(eventToPrint).AppendLine();
            }
        }

        public static string GetOutputMesseges()
        {
            return Output.ToString();
        }
    }
}
