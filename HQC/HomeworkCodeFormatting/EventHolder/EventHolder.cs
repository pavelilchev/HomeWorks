namespace EventHolder
{
    using System;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private readonly MultiDictionary<string, Event> eventsByTitle;
        private readonly OrderedBag<Event> sortedEventsByDate;

        public EventHolder()
        {
            this.eventsByTitle = new MultiDictionary<string, Event>(true);
            this.sortedEventsByDate = new OrderedBag<Event>();
        }

        public void CreateEvent(DateTime date, string title, string location)
        {
            var newEvent = new Event(date, title, location);
            this.AddEvent(title, newEvent);
        }
       
        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;
            foreach (var eventToRemove in this.eventsByTitle[title])
            {
                removed++;
                this.sortedEventsByDate.Remove(eventToRemove);
            }

            this.eventsByTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.sortedEventsByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }

        private void AddEvent(string title, Event newEvent)
        {
            this.eventsByTitle.Add(title.ToLower(), newEvent);
            this.sortedEventsByDate.Add(newEvent);
            Messages.EventAdded();
        }
    }
}
