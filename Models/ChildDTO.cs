using System;

namespace Models
{
    [Serializable]
    public class ChildDTO
    {
        public ChildDTO(string name, int age, int challengesNumber)
        {
            Name = name;
            Age = age;
            ChallengesNumber = challengesNumber;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int ChallengesNumber { get; set; }
    }
}