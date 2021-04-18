using Models;

namespace Persistence
{
    public interface IEmployeesRepository : IRepository<long, Employee> {
        /**
     * finds an employee by a given username
     * @param username the username of an employee
     * @return Employee
     */
        Employee FindByUsername(string username);
    }
}