namespace Contest.model
{
    public class Employee : Entity<long>
    {
        public Employee(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}