using System;
using System.Collections.Generic;
using Models;

namespace Networking
{
    [Serializable]
    public class UpdateDTO
    {
        public ChildDTO Child { get; set; }
        public List<ChallengeDTO> Challenges { get; set; }

        public UpdateDTO(ChildDTO child, List<ChallengeDTO> challenges)
        {
            Child = child;
            Challenges = challenges;
        }
    }
}