using Models;

namespace Persistence
{
    public interface IChallengeRepository : IRepository<long, Challenge> {
        /**
         * finds a challenge by some properties
         * @param minimumAge the minimum age of the challenge
         * @param maximumAge the maximum age of the challenge
         * @return Challenge
         */
        Challenge FindByProperties(int minimumAge,int maximumAge,string name);
    }
}