using System;

namespace Networking
{
    [Serializable]
    public class RegistrationDTO
    {
        public String Name { get; set; }
        public int Age { get; set; }
        public String Challenge1 { get; set; }
        public String Challenge2 { get; set; }

        public RegistrationDTO(string name, int age, string challenge1, string challenge2)
        {
            Name = name;
            Age = age;
            Challenge1 = challenge1;
            Challenge2 = challenge2;
        }
    }
}