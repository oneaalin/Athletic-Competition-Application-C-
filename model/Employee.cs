namespace Contest.model
{
    public class Employee : Entity<long>
    {
        private string Username { get; set; }
        private string Password { get; set; }
    }
}