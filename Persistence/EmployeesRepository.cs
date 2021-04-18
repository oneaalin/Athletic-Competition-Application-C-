using System;
using System.Collections.Generic;
using System.Data;
using log4net;
using Models;

namespace Persistence
{
    public class EmployeesRepository : IEmployeesRepository{
        
        private static readonly ILog log = LogManager.GetLogger("EmployeesRepository");

        public EmployeesRepository()
        {
            log.Info("Creating Employees Repository");
        }
        
        public Employee FindByUsername(string username)
        {
            log.InfoFormat("Entering FindByUsername with value {0}",username);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id , username, password from Employees where username = @username";
                
                IDbDataParameter paramUsername = comm.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = username;
                comm.Parameters.Add(paramUsername);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        long id = dataR.GetInt64(0);
                        String the_username = dataR.GetString(1);
                        String password = dataR.GetString(2);
                        Employee employee = new Employee(the_username, password);
                        employee.Id = id;
                        log.InfoFormat("Exiting FindByUsername with value {0}", employee);
                        return employee;
                    }
                }
            }
            log.InfoFormat("Exiting FindByUsername with value {0}", null);
            return null;
        }

        public Employee FindOne(long id)
        {
            log.InfoFormat("Entering FindOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id , username, password from Employees where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        long idC = dataR.GetInt64(0);
                        String username = dataR.GetString(1);
                        String password = dataR.GetString(2);
                        Employee employee = new Employee(username, password);
                        employee.Id = idC;
                        log.InfoFormat("Exiting FindOne with value {0}", employee);
                        return employee;
                    }
                }
            }
            log.InfoFormat("Exiting FindOne with value {0}", null);
            return null;
        }

        public IEnumerable<Employee> FindAll()
        {
            log.Info("Entering FindAll");
            IDbConnection con = DBUtils.getConnection();
            IList<Employee> employees = new List<Employee>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id , username, password from Employees";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        long id = dataR.GetInt64(0);
                        String username = dataR.GetString(1);
                        String password = dataR.GetString(2);
                        Employee employee = new Employee(username, password);
                        employee.Id = id;
                        employees.Add(employee);
                    }
                }
            }
            log.InfoFormat("Exiting FindAll with Children {0}",employees);
            return employees;
        }

        public Employee Save(Employee employee)
        {
            log.InfoFormat("Entering Save with Employee {0}",employee);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Employees (username,password) values ( @username, @password)";

                var paramUsername = comm.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = employee.Username;
                comm.Parameters.Add(paramUsername);

                var paramPassword = comm.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = employee.Password;
                comm.Parameters.Add(paramPassword);
                
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Save with value {0}", employee);
                    return employee;
                }
                else
                {
                    log.InfoFormat("Exiting Save with value {0}", null);
                    return null;
                }
            }
        }

        public Employee Delete(long id)
        {
            log.InfoFormat("Entering Delete with value {0}",id);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Employees where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                Employee employee = FindOne(id);
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Delete with value {0}",null);
                    return null;
                }
                else
                {
                    log.InfoFormat("Exiting Delete with value {0}",employee);
                    return employee;
                }
            }
        }

        public Employee Update(Employee employee)
        {
            log.InfoFormat("Entering Update with Employee {0}",employee);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Employees set username = @username , password = @password where id = @id)";
                
                var paramUsername = comm.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = employee.Username;
                comm.Parameters.Add(paramUsername);

                var paramPassowrd = comm.CreateParameter();
                paramPassowrd.ParameterName = "@password";
                paramPassowrd.Value = employee.Password;
                comm.Parameters.Add(paramPassowrd);
                
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = employee.Id;
                comm.Parameters.Add(paramId);
                
                var result = comm.ExecuteNonQuery();

                if (result == 0)
                {
                    log.InfoFormat("Exiting Update with value {0}",employee);
                    return employee;
                }
                else
                {
                    log.InfoFormat("Exiting Update with value {0}",null);
                    return null;
                }
            }
        }

        public int Count()
        {
            log.Info("Entering Count");
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select count() from Employees";
                int counter = (Int32) comm.ExecuteScalar();
                log.InfoFormat("Exiting Count with value {0}",counter);
                return counter;
            }
        }

        public bool Exists(long id)
        {
            log.InfoFormat("Entering Exists with value {0}",id);
            if (FindOne(id) == null)
            {
                log.InfoFormat("Exiting Exists with value {0}",false);
                return false;
            }
            log.InfoFormat("Exiting Exists with value {0}",true);
            return true;
        }
    }
}