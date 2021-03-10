namespace Contest.model
{
    public class Challenge : Entity<long>
    {
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public string Name { get; set; }
        
    }
}