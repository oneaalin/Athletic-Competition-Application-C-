namespace Contest.model
{
    public class ChallengeDTO
    {
        public ChallengeDTO(int minimumAge, int maximumAge, string name, int childrenNumber)
        {
            MinimumAge = minimumAge;
            MaximumAge = maximumAge;
            Name = name;
            ChildrenNumber = childrenNumber;
        }

        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public string Name { get; set; }
        public int ChildrenNumber { get; set; }
        
        
    }
}