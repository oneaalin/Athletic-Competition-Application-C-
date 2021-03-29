using Contest.model;

namespace Contest.repository
{
    public interface IChildRepository : IRepository<long,Child>
    {
        Child FindByProperties(string name, int age);
    }
}