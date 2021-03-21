using System;

namespace Contest.model
{
    public class Entry : Entity<Tuple<long,long>>
    {
        public Entry(DateTime date, Child child, Challenge challenge)
        {
            Date = date;
            Child = child;
            Challenge = challenge;
        }

        public DateTime Date { get; set;}
        public Child Child { get; set;}
        public Challenge Challenge { get; set;}
    }
}