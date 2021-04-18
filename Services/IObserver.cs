using System.Collections.Generic;
using Models;

namespace Services
{
    public interface IObserver
    {
        void updateChildren(ChildDTO childDTO,List<ChallengeDTO> challenges);
    }
}