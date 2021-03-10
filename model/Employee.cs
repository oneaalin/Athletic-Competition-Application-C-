namespace Contest.model
{
    public class Employee : Entity<long>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}