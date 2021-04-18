using System.Collections.Generic;
using Models;

namespace Persistence
{
    public interface IRepository <TId,TE> where TE:Entity<TId>
    {

        /**
     * returns an entity with the specified id
     * @param id - the id of the entity to be returned , id must not be null
     * @return the entity with the specified id or null (if there is no entity with the given id)
     */
        TE FindOne(TId id);

        /**
     *
     * @return all entities
     */
        IEnumerable<TE> FindAll();

        /**
     *
     * @param entity , entity must not be null
     * @return null if the given entity is saved , otherwise returns the entity(id already exists)
     */
        TE Save(TE entity);

        /**
     *
     * @param id , id must not ebe null
     * @return the removed entity or null if there is no entity with the given id
     */
        TE Delete(TId id);

        /**
     *
     * @param entity , entity must not be null
     * @return null - if the entity is updated , otherwise returns the entity(id does not exist)
     */
        TE Update(TE entity);

        /**
     * return how many entities are in the repository
     * @return int
     */
        int Count();

        /**
     * check if there is any entity with the specified id
     * @param id the id
     * @return true if it exists , false otherwise
     */
        bool Exists(TId id);
    }
}