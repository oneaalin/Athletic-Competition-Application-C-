using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Models;
using Services;

namespace Networking
{
    public class ServerObjectProxy : IService
    {
        private string host;
        private int port;

        private IObserver client;

        private NetworkStream stream;

        private IFormatter formatter;
        private TcpClient connection;

        private Queue<ObjectResponseProtocol.Response> responses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;

        public ServerObjectProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            responses = new Queue<ObjectResponseProtocol.Response>();
        }


        public virtual Employee LoginEmployee(string username, string password, IObserver client)
        {
            initializeConnection();
            Employee employee = new Employee(username, password);
            sendRequest(new LoginRequest(employee));
            ObjectResponseProtocol.Response response = readResponse();
            if (response is ObjectResponseProtocol.LoggedReponse)
            {
                this.client = client;
            }

            if (response is ObjectResponseProtocol.ErrorResponse)
            {
                ObjectResponseProtocol.ErrorResponse error = (ObjectResponseProtocol.ErrorResponse) response;
                closeConnection();
                throw new ValidationException(error.Message);
            }

            ObjectResponseProtocol.LoggedReponse resp = (ObjectResponseProtocol.LoggedReponse) response;
            return resp.Employee;
        }

        public Employee RegisterEmployee(string username, string password)
        {
            initializeConnection();
            Employee employee = new Employee(username, password);
            sendRequest(new RegisterRequest(employee));
            ObjectResponseProtocol.Response response = readResponse();
            if (response is ObjectResponseProtocol.ErrorResponse)
            {
                ObjectResponseProtocol.ErrorResponse error = (ObjectResponseProtocol.ErrorResponse) response;
                closeConnection();
                throw new ValidationException(error.Message);
            }

            ObjectResponseProtocol.RegisteredResponse resp = (ObjectResponseProtocol.RegisteredResponse) response;
            closeConnection();
            return resp.Employee;
        }

        public List<ChallengeDTO> GetAllChallenges()
        {
            sendRequest(new GetAllChallengesRequest());
            ObjectResponseProtocol.Response response = readResponse();
            if (response is ObjectResponseProtocol.ErrorResponse)
            {
                ObjectResponseProtocol.ErrorResponse error = (ObjectResponseProtocol.ErrorResponse) response;
                throw new ValidationException(error.Message);
            }

            ObjectResponseProtocol.GetAllChallengesResponse resp =
                (ObjectResponseProtocol.GetAllChallengesResponse) response;
            return resp.Challenges;
        }

        public List<ChildDTO> GetAllChildren()
        {
            sendRequest(new GetAllChildrenRequest());
            ObjectResponseProtocol.Response response = readResponse();
            if (response is ObjectResponseProtocol.ErrorResponse)
            {
                ObjectResponseProtocol.ErrorResponse error = (ObjectResponseProtocol.ErrorResponse) response;
                throw new ValidationException(error.Message);
            }

            ObjectResponseProtocol.GetAllChildrenResponse resp =
                (ObjectResponseProtocol.GetAllChildrenResponse) response;
            return resp.Children;
        }

        public Child RegisterChild(string name, int age, string challenge1, string challenge2)
        {
            RegistrationDTO registration = new RegistrationDTO(name, age, challenge1, challenge2);
            sendRequest(new RegisterChildRequest(registration));
            ObjectResponseProtocol.Response response = readResponse();
            if (response is ObjectResponseProtocol.ErrorResponse)
            {
                ObjectResponseProtocol.ErrorResponse error = (ObjectResponseProtocol.ErrorResponse) response;
                throw new ValidationException(error.Message);
            }

            ObjectResponseProtocol.RegisteredChildResponse resp = (ObjectResponseProtocol.RegisteredChildResponse) response;
            return resp.Child;
        }

        public Challenge GetChallengeByProperties(int minimumAge, int maximumAge, string name)
        {
            Challenge challenge = new Challenge(minimumAge, maximumAge, name);
            sendRequest(new GetChallengeByPropertiesRequest(challenge));
            ObjectResponseProtocol.Response response = readResponse();
            if (response is ObjectResponseProtocol.ErrorResponse)
            {
                ObjectResponseProtocol.ErrorResponse error = (ObjectResponseProtocol.ErrorResponse) response;
                throw new ValidationException(error.Message);
            }

            ObjectResponseProtocol.GetChallengeByPropertiesResponse resp =
                (ObjectResponseProtocol.GetChallengeByPropertiesResponse) response;
            return resp.Challenge;
        }

        public List<Child> GetChildrenById(long cid)
        {
            sendRequest(new GetChildrenByIdRequest(cid));
            ObjectResponseProtocol.Response response = readResponse();
            if (response is ObjectResponseProtocol.ErrorResponse)
            {
                ObjectResponseProtocol.ErrorResponse error = (ObjectResponseProtocol.ErrorResponse) response;
                throw new ValidationException(error.Message);
            }

            ObjectResponseProtocol.GetChildrenByIdResponse resp =
                (ObjectResponseProtocol.GetChildrenByIdResponse) response;
            return resp.Children;
        }

        public void Logout(Employee employee, IObserver client)
        {
            sendRequest(new LogoutRequest(employee));
            ObjectResponseProtocol.Response response = readResponse();
            closeConnection();
            if (response is ObjectResponseProtocol.ErrorResponse)
            {
                ObjectResponseProtocol.ErrorResponse error = (ObjectResponseProtocol.ErrorResponse) response;
                throw new ValidationException(error.Message);
            }
        }
        
        private void closeConnection()
        {
            finished=true;
            try
            {
                stream.Close();
                //output.close();
                connection.Close();
                _waitHandle.Close();
                client=null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        private void sendRequest(Request request)
        {
            try
            {
                formatter.Serialize(stream, request);
                stream.Flush();
            }
            catch (Exception e)
            {
                throw new ValidationException("Error sending object "+e);
            }

        }

        private ObjectResponseProtocol.Response readResponse()
        {
            ObjectResponseProtocol.Response response =null;
            try
            {
                _waitHandle.WaitOne();
                lock (responses)
                {
                    //Monitor.Wait(responses); 
                    response = responses.Dequeue();
                
                }
				

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }
        private void initializeConnection()
        {
            try
            {
                connection=new TcpClient(host,port);
                stream=connection.GetStream();
                formatter = new BinaryFormatter();
                finished=false;
                _waitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        private void startReader()
        {
            Thread tw =new Thread(run);
            tw.Start();
        }
        
        private void handleUpdate(ObjectResponseProtocol.UpdateResponse update)
        {
            if (update is ObjectResponseProtocol.NewChildResponse)
            {

                ObjectResponseProtocol.NewChildResponse childUpdate =(ObjectResponseProtocol.NewChildResponse) update;
                try
                {
                    client.updateChildren(childUpdate.Update.Child,childUpdate.Update.Challenges);
                }
                catch (ValidationException e)
                {
                    Console.WriteLine(e.StackTrace); 
                }
            }
        }
        public virtual void run()
        {
            while(!finished)
            {
                try
                {
                    object response = formatter.Deserialize(stream);
                    Console.WriteLine("response received "+response);
                    if (response is ObjectResponseProtocol.UpdateResponse)
                    {
                        handleUpdate((ObjectResponseProtocol.UpdateResponse)response);
                    }
                    else
                    {
							
                        lock (responses)
                        {
                            
                            responses.Enqueue((ObjectResponseProtocol.Response)response);
                               
                        }
                        _waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Reading error "+e);
                }
					
            }
        }
    }
}