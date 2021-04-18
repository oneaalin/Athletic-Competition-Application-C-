using System;
using Models;

namespace Networking
{
    public interface Request
    {
    }

    [Serializable]
    public class LoginRequest : Request
    {
        private Employee employee;

        public LoginRequest(Employee employee)
        {
            this.employee = employee;
        }

        public virtual Employee Employee
        {
            get
            {
                return employee;
            }
        }
        
    }
    
    [Serializable]
    public class LogoutRequest : Request
    {
        public Employee Employee { get; set; }

        public LogoutRequest(Employee employee)
        {
            Employee = employee;
        }
    }
    
    [Serializable]
    public class RegisterRequest : Request
    {
        public Employee Employee { get; set; }

        public RegisterRequest(Employee employee)
        {
            Employee = employee;
        }
    }

    [Serializable]
    public class GetAllChallengesRequest : Request
    {
    }

    [Serializable]
    public class GetAllChildrenRequest : Request
    {
    }

    [Serializable]
    public class RegisterChildRequest : Request
    {
        public RegistrationDTO Registration { get; set; }

        public RegisterChildRequest(RegistrationDTO registration)
        {
            Registration = registration;
        }
    }

    [Serializable]
    public class GetChallengeByPropertiesRequest : Request
    {
        public Challenge Challenge { get; set; }

        public GetChallengeByPropertiesRequest(Challenge challenge)
        {
            Challenge = challenge;
        }
    }

    [Serializable]
    public class GetChildrenByIdRequest : Request
    {
        public long Cid { get; set; }

        public GetChildrenByIdRequest(long cid)
        {
            Cid = cid;
        }
    }
    
}