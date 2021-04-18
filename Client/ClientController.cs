using System;
using System.Collections.Generic;
using Models;
using Networking;
using Services;

namespace Client
{
    public class ClientController : IObserver
    {

        public event EventHandler<UserEventArgs> updateEvent;
        private IService server;
        private Employee currentEmployee;

        public ClientController(IService server)
        {
            this.server = server;
            this.currentEmployee = null;
        }

        public void updateChildren(ChildDTO childDTO, List<ChallengeDTO> challenges)
        {
            UpdateDTO update = new UpdateDTO(childDTO, challenges);
            UserEventArgs userArgs = new UserEventArgs(UserEvent.NewChild, update);
            OnUserEvent(userArgs);   
        }

        protected virtual void OnUserEvent(UserEventArgs e)
        {
            if (updateEvent == null)
                return;
            updateEvent(this, e);
        }

        public Employee Login(String username, String password)
        {
            currentEmployee = server.LoginEmployee(username, password, this);
            return currentEmployee;
        }

        public void Logout()
        {
            server.Logout(currentEmployee,this);
            currentEmployee = null;
        }

        public Employee RegisterEmployee(String username, String password)
        {
            Employee employee = server.RegisterEmployee(username, password);
            return employee;
        }

        public List<ChallengeDTO> GetAllChallenges()
        {
            List<ChallengeDTO> challenges = server.GetAllChallenges();
            return challenges;
        }

        public List<ChildDTO> GetAllChildren()
        {
            List<ChildDTO> children = server.GetAllChildren();
            return children;
        }

        public Child RegisterChild(String name, int age, String challenge1, String challenge2)
        {
            Child child = server.RegisterChild(name, age, challenge1, challenge2);
            return child;
        }

        public Challenge GetChallengeByProperties(int minimumAge, int maximumAge, string name)
        {
            Challenge challenge = server.GetChallengeByProperties(minimumAge, maximumAge, name);
            return challenge;
        }

        public List<Child> GetChildrenById(long cid)
        {
            List<Child> children = server.GetChildrenById(cid);
            return children;
        }
        
        
    }
}