using System;
using System.Collections.Generic;
using Models;

namespace Services
{
    public interface IService
    {
        Employee LoginEmployee(String username , String password,IObserver client);
        Employee RegisterEmployee(String username,String password);
        List<ChallengeDTO> GetAllChallenges();
        List<ChildDTO> GetAllChildren();
        Child RegisterChild(String name, int age, String challenge1, String challenge2);
        Challenge GetChallengeByProperties(int minimumAge, int maximumAge , String name);
        List<Child> GetChildrenById(long cid);
        void Logout(Employee employee,IObserver client);
    }
}