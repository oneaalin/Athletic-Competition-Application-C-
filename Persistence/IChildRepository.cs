using Models;

namespace Persistence
{
    public interface IChildRepository : IRepository<long,Child>
    {
        Child FindByProperties(string name, int age);
    }
}