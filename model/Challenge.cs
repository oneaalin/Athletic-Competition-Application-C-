namespace Contest.model
{
    public class Challenge : Entity<long>
    {
        private int MinimumAge { get; set; }
        private int MaximumAge { get; set; }
        private string Name { get; set; }
        
    }
}