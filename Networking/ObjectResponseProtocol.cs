using System;
using System.Collections.Generic;
using Models;

namespace Networking
{
    public class ObjectResponseProtocol
    {
        public interface Response
        {
        }

        [Serializable]
        public class OkResponse : Response
        {
        }

        [Serializable]
        public class ErrorResponse : Response
        {
            public string Message { get; set; }

            public ErrorResponse(string message)
            {
                Message = message;
            }
        }

        [Serializable]
        public class LoggedReponse : Response
        {
            public Employee Employee { get; set; }

            public LoggedReponse(Employee employee)
            {
                Employee = employee;
            }
        }

        [Serializable]
        public class RegisteredResponse : Response
        {
            public Employee Employee { get; set; }

            public RegisteredResponse(Employee employee)
            {
                Employee = employee;
            }
        }

        [Serializable]
        public class GetAllChallengesResponse : Response
        {
            public List<ChallengeDTO> Challenges { get; set; }

            public GetAllChallengesResponse(List<ChallengeDTO> challenges)
            {
                Challenges = challenges;
            }
        }

        [Serializable]
        public class GetAllChildrenResponse : Response
        {
            public List<ChildDTO> Children { get; set; }

            public GetAllChildrenResponse(List<ChildDTO> children)
            {
                Children = children;
            }
        }

        [Serializable]
        public class RegisteredChildResponse : Response
        {
            public Child Child { get; set; }

            public RegisteredChildResponse(Child child)
            {
                Child = child;
            }
        }

        [Serializable]
        public class GetChallengeByPropertiesResponse : Response
        {
            public Challenge Challenge { get; set; }

            public GetChallengeByPropertiesResponse(Challenge challenge)
            {
                Challenge = challenge;
            }
        }
        
        [Serializable]
        public class GetChildrenByIdResponse : Response
        {
            public List<Child> Children { get; set; }

            public GetChildrenByIdResponse(List<Child> children)
            {
                Children = children;
            }
        }

        public interface UpdateResponse : Response
        {
        }

        [Serializable]
        public class NewChildResponse : UpdateResponse
        {
            public UpdateDTO Update { get; set; }

            public NewChildResponse(UpdateDTO update)
            {
                Update = update;
            }
        }

    }
}