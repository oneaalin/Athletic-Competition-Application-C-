namespace Contest.model
{
    public class Child : Entity<long>
    {
        public Child(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Age;
        }
    }
}