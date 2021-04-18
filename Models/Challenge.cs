using System;

namespace Models
{
    [Serializable]
    public class Challenge : Entity<long>
    {
        public Challenge(int minimumAge, int maximumAge, string name)
        {
            MinimumAge = minimumAge;
            MaximumAge = maximumAge;
            Name = name;
        }

        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public string Name { get; set; }
        
    }
}