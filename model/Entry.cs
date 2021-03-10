using System;

namespace Contest.model
{
    public class Entry : Entity<Tuple<long,long>>
    {
        private DateTime Date { get; set;}
    }
}