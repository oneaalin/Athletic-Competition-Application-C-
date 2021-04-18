using System;
using System.Net.Sockets;
using System.Threading;
using Networking;
using Persistence;
using Services;

namespace Server
{
    public class StartServer
    {
        public static void Main(string[] args)
        {
            IChildRepository childRepo = new ChildRepository();
            IChallengeRepository challengeRepo = new ChallengeRepository();
            IEmployeesRepository employeesRepo = new EmployeesRepository();
            IEntriesRepository entriesRepo = new EntriesRepository(childRepo, challengeRepo);

            IService service = new Service(childRepo, challengeRepo, employeesRepo, entriesRepo);
            
            SerialServer server = new SerialServer("127.0.0.1", 55555, service);
            server.Start();
            Console.WriteLine("Server started ...");
            
        }
    }
    
    public class SerialServer: ConcurrentServer 
    {
        private IService server;
        private ClientObjectWorker worker;
        public SerialServer(string host, int port, IService server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("SerialServer...");
        }
        protected override Thread createWorker(TcpClient client)
        {
            worker = new ClientObjectWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
}