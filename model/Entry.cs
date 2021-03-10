using System;

namespace Contest.model
{
    public class Entry : Entity<Tuple<long,long>>
    {
        public DateTime Date { get; set;}
    }
}