using System;
using System.Collections.Generic;
using System.Data;
using Contest.model;
using Contest.repository;
using log4net;


namespace Contest_CS.repository
{
    public class ChallengeRepository : IChallengeRepository{
        
        private static readonly ILog log = LogManager.GetLogger("ChallengeRepository");

        public ChallengeRepository()
        {
            log.Info("Creating Challenge Repository");
        }
        
        public Challenge FindByProperties(int minimumAge, int maximumAge, string name)
        {
            log.InfoFormat("Entering FindByProperties with minimum age {0} , maximum age {1} , name {2}", minimumAge,maximumAge,name);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id , minimum_age, maximum_age , name from Challenge where minimum_age = @minimum_age and maximum_age = @maximum_age and name = @name";
                
                IDbDataParameter paramMinimumAge = comm.CreateParameter();
                paramMinimumAge.ParameterName = "@minimum_age";
                paramMinimumAge.Value = minimumAge;
                comm.Parameters.Add(paramMinimumAge);

                IDbDataParameter paramMaximumAge = comm.CreateParameter();
                paramMaximumAge.ParameterName = "@maximum_age";
                paramMaximumAge.Value = maximumAge;
                comm.Parameters.Add(paramMaximumAge);
                
                IDbDataParameter paramName = comm.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = name;
                comm.Parameters.Add(paramName);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        long id = dataR.GetInt64(0);
                        int minimum_age = dataR.GetInt32(1);
                        int maximum_age = dataR.GetInt32(2);
                        String the_name = dataR.GetString(3);
                        Challenge challenge = new Challenge(minimum_age, maximum_age, the_name);
                        challenge.Id = id;
                        log.InfoFormat("Exiting FindByProperties with value {0}", challenge);
                        return challenge;
                    }
                }
            }
            log.InfoFormat("Exiting FindByProperties with value {0}", null);
            return null;
        }

        public Challenge FindOne(long id)
        {
            log.InfoFormat("Entering FindOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id , minimum_age, maximum_age , name from Challenge where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        long idC = dataR.GetInt64(0);
                        int minimum_age = dataR.GetInt32(1);
                        int maximum_age = dataR.GetInt32(2);
                        String name = dataR.GetString(3);
                        Challenge challenge = new Challenge(minimum_age, maximum_age, name);
                        challenge.Id = idC;
                        log.InfoFormat("Exiting FindOne with value {0}", challenge);
                        return challenge;
                    }
                }
            }
            log.InfoFormat("Exiting FindOne with value {0}", null);
            return null;
        }

        public IEnumerable<Challenge> FindAll()
        {
            log.Info("Entering FindAll");
            IDbConnection con = DBUtils.getConnection();
            IList<Challenge> challenges = new List<Challenge>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id ,minimum_age , maximum_age , name from Challenge";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        long id = dataR.GetInt64(0);
                        int minimum_age = dataR.GetInt32(1);
                        int maximum_age = dataR.GetInt32(2);
                        String name = dataR.GetString(3);
                        Challenge challenge = new Challenge(minimum_age, maximum_age, name);
                        challenge.Id = id;
                        challenges.Add(challenge);
                    }
                }
            }
            log.InfoFormat("Exiting FindAll with Children {0}",challenges);
            return challenges;
        }

        public Challenge Save(Challenge challenge)
        {
            log.InfoFormat("Entering Save with Challenge {0}",challenge);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Challenge(minimum_age,maximum_age,name)  values (@minimum_age , @maximum_age , @name)";

                var paramMinimumAge = comm.CreateParameter();
                paramMinimumAge.ParameterName = "@minimum_age";
                paramMinimumAge.Value = challenge.MinimumAge;
                comm.Parameters.Add(paramMinimumAge);

                var paramMaximumAge = comm.CreateParameter();
                paramMaximumAge.ParameterName = "@maximum_age";
                paramMaximumAge.Value = challenge.MaximumAge;
                comm.Parameters.Add(paramMaximumAge);
                
                var paramName = comm.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = challenge.Name;
                comm.Parameters.Add(paramName);
                
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Save with value {0}", challenge);
                    return challenge;
                }
                else
                {
                    log.InfoFormat("Exiting Save with value {0}", null);
                    return null;
                }
            }
        }

        public Challenge Delete(long id)
        {
            log.InfoFormat("Entering Delete with value {0}",id);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Challenge where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                
                Challenge challenge = FindOne(id);
                
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Delete with value {0}",null);
                    return null;
                }
                else
                {
                    log.InfoFormat("Exiting Delete with value {0}",challenge);
                    return challenge;
                }
            }
        }

        public Challenge Update(Challenge challenge)
        {
            log.InfoFormat("Entering Update with Challenge {0}",challenge);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Challenge set minimum_age = @minimum_age , maximum_age = @maximum_age , name = @name where id = @id)";
                
                var paramMinimumAge = comm.CreateParameter();
                paramMinimumAge.ParameterName = "@minimum_age";
                paramMinimumAge.Value = challenge.MinimumAge;
                comm.Parameters.Add(paramMinimumAge);

                var paramMaximumAge = comm.CreateParameter();
                paramMaximumAge.ParameterName = "@maximum_age";
                paramMaximumAge.Value = challenge.MaximumAge;
                comm.Parameters.Add(paramMaximumAge);
                
                var paramName = comm.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = challenge.Name;
                comm.Parameters.Add(paramName);
                
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = challenge.Id;
                comm.Parameters.Add(paramId);
                
                var result = comm.ExecuteNonQuery();

                if (result == 0)
                {
                    log.InfoFormat("Exiting Update with value {0}",challenge);
                    return challenge;
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
                comm.CommandText = "select count() from Challenge";
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