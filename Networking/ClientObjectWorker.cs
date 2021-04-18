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
    public class ClientObjectWorker : IObserver
    {
        private IService server;
        private TcpClient connection;

        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;

        public ClientObjectWorker(IService server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                connected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        
        public virtual void run()
        {
            while(connected)
            {
                try
                {
                    object request = formatter.Deserialize(stream);
                    object response =handleRequest((Request)request);
                    if (response!=null)
                    {
                        sendResponse((ObjectResponseProtocol.Response) response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
				
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            try
            {
                stream.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error "+e);
            }
            
        }

        private ObjectResponseProtocol.Response handleRequest(Request request)
        {
            ObjectResponseProtocol.Response response = null;
            if (request is LoginRequest)
            {
                LoginRequest loginRequest = (LoginRequest) request;
                Employee employee = loginRequest.Employee;
                try
                {
                    Employee loggedEmployee;
                    lock (server)
                    {
                        loggedEmployee = server.LoginEmployee(employee.Username, employee.Password, this);
                    }

                    return new ObjectResponseProtocol.LoggedReponse(loggedEmployee);
                }
                catch (ValidationException e)
                {
                    connected = false;
                    return new ObjectResponseProtocol.ErrorResponse(e.Message);
                }
            }

            if (request is LogoutRequest)
            {
                LogoutRequest logoutRequest = (LogoutRequest) request;
                Employee employee = logoutRequest.Employee;
                try
                {
                    lock (server)
                    {
                        server.Logout(employee, this);
                    }

                    connected = false;
                    return new ObjectResponseProtocol.OkResponse();
                }
                catch (ValidationException e)
                {
                    return new ObjectResponseProtocol.ErrorResponse(e.Message);
                }
            }

            if (request is RegisterRequest)
            {
                RegisterRequest registerRequest = (RegisterRequest) request;
                Employee employee = registerRequest.Employee;

                try
                {
                    Employee registeredEmployee;
                    lock (server)
                    {
                        registeredEmployee = server.RegisterEmployee(employee.Username, employee.Password);
                    }

                    return new ObjectResponseProtocol.RegisteredResponse(registeredEmployee);
                }
                catch (ValidationException e)
                {
                    return new ObjectResponseProtocol.ErrorResponse(e.Message);
                }
            }

            if (request is GetAllChallengesRequest)
            {
                GetAllChallengesRequest getAllChallengesRequest = (GetAllChallengesRequest) request;

                try
                {
                    List<ChallengeDTO> challenges;
                    lock (server)
                    {
                        challenges = server.GetAllChallenges();
                    }

                    return new ObjectResponseProtocol.GetAllChallengesResponse(challenges);
                }
                catch (ValidationException e)
                {
                    return new ObjectResponseProtocol.ErrorResponse(e.Message);
                }
            }

            if (request is GetAllChildrenRequest)
            {
                GetAllChildrenRequest getAllChildrenRequest = (GetAllChildrenRequest) request;

                try
                {
                    List<ChildDTO> children;
                    lock (server)
                    {
                        children = server.GetAllChildren();
                    }

                    return new ObjectResponseProtocol.GetAllChildrenResponse(children);
                }
                catch (ValidationException e)
                {
                    return new ObjectResponseProtocol.ErrorResponse(e.Message);
                }
            }

            if (request is RegisterChildRequest)
            {
                RegisterChildRequest registerChildRequest = (RegisterChildRequest) request;
                RegistrationDTO registration = registerChildRequest.Registration;
                try
                {
                    Child child;
                    lock (server)
                    {
                        child = server.RegisterChild(registration.Name, registration.Age, registration.Challenge1,
                            registration.Challenge2);
                    }

                    return new ObjectResponseProtocol.RegisteredChildResponse(child);
                }
                catch(ValidationException e)
                {
                    return new ObjectResponseProtocol.ErrorResponse(e.Message);
                }
            }

            if (request is GetChallengeByPropertiesRequest)
            {
                GetChallengeByPropertiesRequest getChallengeByPropertiesRequest =
                    (GetChallengeByPropertiesRequest) request;
                Challenge challenge = getChallengeByPropertiesRequest.Challenge;

                try
                {
                    Challenge foundChallenge;
                    lock (server)
                    {
                        foundChallenge = server.GetChallengeByProperties(challenge.MinimumAge, challenge.MaximumAge,
                            challenge.Name);
                    }

                    return new ObjectResponseProtocol.GetChallengeByPropertiesResponse(foundChallenge);
                }
                catch (ValidationException e)
                {
                    return new ObjectResponseProtocol.ErrorResponse(e.Message);
                }
            }

            if (request is GetChildrenByIdRequest)
            {
                GetChildrenByIdRequest getChildrenByIdRequest = (GetChildrenByIdRequest) request;
                long cid = getChildrenByIdRequest.Cid;
                try
                {
                    List<Child> children;
                    lock (server)
                    {
                        children = server.GetChildrenById(cid);
                    }

                    return new ObjectResponseProtocol.GetChildrenByIdResponse(children);
                }
                catch (ValidationException e)
                {
                    return new ObjectResponseProtocol.ErrorResponse(e.Message);
                }
            }
            
            return response;
        }
        
        private void sendResponse(ObjectResponseProtocol.Response response)
        {
            Console.WriteLine("sending response "+response);
            lock (stream)
            {
              formatter.Serialize(stream, response);
              stream.Flush();  
            }
            
			
        }
        public void updateChildren(ChildDTO childDTO, List<ChallengeDTO> challenges)
        {
            UpdateDTO update = new UpdateDTO(childDTO, challenges);
            try
            {
                sendResponse(new ObjectResponseProtocol.NewChildResponse(update));
            }
            catch (Exception e)
            {
                throw new ValidationException("Sending error: " + e);
            }
        }
    }
}