using System;
using System.Collections.Generic;
using System.Data;
using Contest.model;
using Contest.repository;
using log4net;

namespace Contest_CS.repository
{
    public class ChildRepository : IChildRepository{
        
        private static readonly ILog log = LogManager.GetLogger("ChildRepository");

        public ChildRepository()
        {
            log.Info("Creating Child Repository");
        }
        
        public Child FindOne(long id)
        {
            log.InfoFormat("Entering FindOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id , name, age from Child where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        long idC = dataR.GetInt64(0);
                        String name = dataR.GetString(1);
                        int age = dataR.GetInt32(2);
                        Child child = new Child(name, age);
                        child.Id = idC;
                        log.InfoFormat("Exiting FindOne with value {0}", child);
                        return child;
                    }
                }
            }
            log.InfoFormat("Exiting FindOne with value {0}", null);
            return null;
        }

        public IEnumerable<Child> FindAll()
        {
            log.Info("Entering FindAll");
            IDbConnection con = DBUtils.getConnection();
            IList<Child> children = new List<Child>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id , name, age from Child";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        long id = dataR.GetInt64(0);
                        String name = dataR.GetString(1);
                        int age = dataR.GetInt32(2);
                        Child child = new Child(name, age);
                        child.Id = id;
                        children.Add(child);
                    }
                }
            }
            log.InfoFormat("Exiting FindAll with Children {0}",children);
            return children;
        }

        public Child Save(Child child)
        {
            log.InfoFormat("Entering Save with Child {0}",child);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Child(name,age) values (@name, @age)";

                var paramName = comm.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = child.Name;
                comm.Parameters.Add(paramName);

                var paramAge = comm.CreateParameter();
                paramAge.ParameterName = "@age";
                paramAge.Value = child.Age;
                comm.Parameters.Add(paramAge);
                
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Save with value {0}", child);
                    return child;
                }
                else
                {
                    log.InfoFormat("Exiting Save with value {0}", null);
                    return null;
                }
            }
        }

        public Child Delete(long id)
        {
            log.InfoFormat("Entering Delete with value {0}",id);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Child where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                Child child = FindOne(id);
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Delete with value {0}",null);
                    return null;
                }
                else
                {
                    log.InfoFormat("Exiting Delete with value {0}",child);
                    return child;
                }
            }
        }

        public Child Update(Child child)
        {
            log.InfoFormat("Entering Update with Child {0}",child);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Child set name = @name , age = @age where id = @id)";
                
                var paramName = comm.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = child.Name;
                comm.Parameters.Add(paramName);

                var paramAge = comm.CreateParameter();
                paramAge.ParameterName = "@age";
                paramAge.Value = child.Age;
                comm.Parameters.Add(paramAge);
                
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = child.Id;
                comm.Parameters.Add(paramId);
                
                var result = comm.ExecuteNonQuery();

                if (result == 0)
                {
                    log.InfoFormat("Exiting Update with value {0}",child);
                    return child;
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
                comm.CommandText = "select count() from Child";
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