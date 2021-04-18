using Models;

namespace Persistence
{
    public interface IEntriesRepository : IRepository<Tuple<long,long> , Entry> {
        /**
     * return the number of children that participates to a given challenge
     * @param cid the id of the challenge
     * @return the number of children that participates
     */
        int FindChildNumber(long cid);

        /**
     * returns the number of challenges of a child
     * @param kid the id of the child
     * @return the number of challenges of a child
     */
        int FindChallengeNumber(long kid);

    }
}