using System;
using System.Collections.Generic;
using System.Data;
using log4net;
using Models;

namespace Persistence
{
    public class EntriesRepository : IEntriesRepository {
        
        private static readonly ILog log = LogManager.GetLogger("EntriesRepository");

        private IChildRepository childRepo;
        private IChallengeRepository challengeRepo;
        
        public EntriesRepository(IChildRepository childRepo , IChallengeRepository challengeRepo)
        {
            log.Info("Creating Entries Repository");
            this.childRepo = childRepo;
            this.challengeRepo = challengeRepo;
        }
        
        public int FindChildNumber(long cid)
        {
            log.Info("Entering Count");
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select count() from Entries where cid = @cid";
                
                IDbDataParameter paramCId = comm.CreateParameter();
                paramCId.ParameterName = "@cid";
                paramCId.Value = cid;
                comm.Parameters.Add(paramCId);
                long long_counter = (Int64) comm.ExecuteScalar();
                int counter = (int) long_counter;
                log.InfoFormat("Exiting Count with value {0}",counter);
                return counter;
            }
        }

        public int FindChallengeNumber(long kid)
        {
            log.Info("Entering Count");
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select count() from Entries where kid = @kid";
                
                IDbDataParameter paramKId = comm.CreateParameter();
                paramKId.ParameterName = "@kid";
                paramKId.Value = kid;
                comm.Parameters.Add(paramKId);
                long long_counter = (Int64) comm.ExecuteScalar();
                int counter = (int)long_counter;
                log.InfoFormat("Exiting Count with value {0}",counter);
                return counter;
            }
        }

        public Entry FindOne(Models.Tuple<long, long> id)
        {
            log.InfoFormat("Entering FindOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select kid , cid , date from Entries where kid = @kid and cid = @cid";
                
                IDbDataParameter paramKId = comm.CreateParameter();
                paramKId.ParameterName = "@kid";
                paramKId.Value = id.Left;
                comm.Parameters.Add(paramKId);
                
                IDbDataParameter paramCId = comm.CreateParameter();
                paramCId.ParameterName = "@cid";
                paramCId.Value = id.Right;
                comm.Parameters.Add(paramCId);


                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        long kidE = dataR.GetInt64(0);
                        long cidE = dataR.GetInt64(1);
                        DateTime date = dataR.GetDateTime(2);
                        Models.Tuple<long, long> idE = new Models.Tuple<long,long>(kidE, cidE);
                        Child child = childRepo.FindOne(kidE);
                        Challenge challenge = challengeRepo.FindOne(cidE);
                        Entry entry = new Entry(date, child, challenge);
                        entry.Id = idE;
                        log.InfoFormat("Exiting FindOne with value {0}", entry);
                        return entry;
                    }
                }
            }
            log.InfoFormat("Exiting FindOne with value {0}", null);
            return null;
        }

        public IEnumerable<Entry> FindAll()
        {
            log.Info("Entering FindAll");
            IDbConnection con = DBUtils.getConnection();
            IList<Entry> entries = new List<Entry>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select kid , cid , date from Entries";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        long kid = dataR.GetInt64(0);
                        long cid = dataR.GetInt64(1);
                        DateTime date = dataR.GetDateTime(2);
                        Models.Tuple<long, long> id = new Models.Tuple<long, long>(kid, cid);
                        Child child = childRepo.FindOne(kid);
                        Challenge challenge = challengeRepo.FindOne(cid);
                        Entry entry = new Entry(date, child, challenge);
                        entry.Id = id;
                        entries.Add(entry);
                    }
                }
            }
            log.InfoFormat("Exiting FindAll with Children {0}",entries);
            return entries;
        }

        public Entry Save(Entry entry)
        {
            log.InfoFormat("Entering Save with Entry {0}",entry);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Entries values (@kid, @cid, @date)";
                var paramKId = comm.CreateParameter();
                paramKId.ParameterName = "@kid";
                paramKId.Value = entry.Id.Left;
                comm.Parameters.Add(paramKId);

                var paramCId = comm.CreateParameter();
                paramCId.ParameterName = "@cid";
                paramCId.Value = entry.Id.Right;
                comm.Parameters.Add(paramCId);

                var paramDate = comm.CreateParameter();
                paramDate.ParameterName = "@date";
                paramDate.Value = entry.Date;
                comm.Parameters.Add(paramDate);
                
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Save with value {0}", entry);
                    return entry;
                }
                else
                {
                    log.InfoFormat("Exiting Save with value {0}", null);
                    return null;
                }
            }
        }

        public Entry Delete(Models.Tuple<long, long> id)
        {
            log.InfoFormat("Entering Delete with value {0}",id);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Entries where kid=@kid and cid=@cid";
                IDbDataParameter paramKId = comm.CreateParameter();
                paramKId.ParameterName = "@kid";
                paramKId.Value = id.Left;
                comm.Parameters.Add(paramKId);
                
                IDbDataParameter paramCId = comm.CreateParameter();
                paramCId.ParameterName = "@cid";
                paramCId.Value = id.Right;
                comm.Parameters.Add(paramCId);
                
                Entry entry = FindOne(id);
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Delete with value {0}",null);
                    return null;
                }
                else
                {
                    log.InfoFormat("Exiting Delete with value {0}",entry);
                    return entry;
                }
            }
        }

        public Entry Update(Entry entry)
        {
            log.InfoFormat("Entering Update with Entry {0}",entry);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Entries set date = @date where kid = @kid and cid = @cid)";
                
                var paramDate = comm.CreateParameter();
                paramDate.ParameterName = "@date";
                paramDate.Value = entry.Date;
                comm.Parameters.Add(paramDate);

                IDbDataParameter paramKId = comm.CreateParameter();
                paramKId.ParameterName = "@kid";
                paramKId.Value = entry.Id.Left;
                comm.Parameters.Add(paramKId);
                
                IDbDataParameter paramCId = comm.CreateParameter();
                paramCId.ParameterName = "@cid";
                paramCId.Value = entry.Id.Right;
                comm.Parameters.Add(paramCId);
                
                var result = comm.ExecuteNonQuery();

                if (result == 0)
                {
                    log.InfoFormat("Exiting Update with value {0}",entry);
                    return entry;
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
                comm.CommandText = "select count() from Entries";
                int counter = (Int32) comm.ExecuteScalar();
                log.InfoFormat("Exiting Count with value {0}",counter);
                return counter;
            }
        }

        public bool Exists(Models.Tuple<long, long> id)
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