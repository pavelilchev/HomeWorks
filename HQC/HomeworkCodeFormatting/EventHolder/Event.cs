namespace EventHolder
{
    using System;
    using System.Text;

    public class Event : IComparable<Event>
    {
        private readonly string title;
        private readonly string location;
        private DateTime date;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(Event otherEvent)
        {
            int dateCompare = this.date.CompareTo(otherEvent.date);
            if (dateCompare != 0)
            {
                return dateCompare;
            }
          
            int locationCompare = string.Compare(this.location, otherEvent.location, StringComparison.InvariantCulture);
            if (locationCompare != 0)
            {
                return locationCompare;
            }

            int titleCompare = string.Compare(this.title, otherEvent.title, StringComparison.InvariantCulture);
            return titleCompare;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            output.AppendFormat("{0}{1}", " | ", this.title);

            if (!string.IsNullOrEmpty(this.location))
            {
                output.AppendFormat("{0}{1}", " | ", this.location);
            }

            return output.ToString();
        }
    }
}
