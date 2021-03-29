using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Contest.model;
using Contest.repository;
using Contest_CS.validator;

namespace Contest_CS.service
{
    public class Service
    {
        private IChildRepository childRepo;
        private IChallengeRepository challengeRepo;
        private IEmployeesRepository employeesRepo;
        private IEntriesRepository entriesRepo;

        public Service(IChildRepository childRepo, IChallengeRepository challengeRepo, IEmployeesRepository employeesRepo, IEntriesRepository entriesRepo)
        {
            this.childRepo = childRepo;
            this.challengeRepo = challengeRepo;
            this.employeesRepo = employeesRepo;
            this.entriesRepo = entriesRepo;
        }
        
        public static string MD5Hash(string text)  
        {  
            MD5 md5 = new MD5CryptoServiceProvider();  

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));  
  
            //get hash result after compute it  
            byte[] result = md5.Hash;  

            StringBuilder strBuilder = new StringBuilder();  
            for (int i = 0; i < result.Length; i++)  
            {  
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));  
            }  

            return strBuilder.ToString();  
        }  
        
        public Employee LoginEmployee(String username , String password){
        Employee employee = employeesRepo.FindByUsername(username);
        if(employee != null){
            String passwordSalt = MD5Hash(password);
            if(passwordSalt.Equals(employee.Password)){
                return employee;
            }
        }
        return null;
    }

    public Employee RegisterEmployee(String username,String password){
        String passwordSalt = MD5Hash(password);
        Employee employee = employeesRepo.Save(new Employee(username,passwordSalt));
        if(employee == null){
            return null;
        }
        return employee;
    }

    public List<ChallengeDTO> GetAllChallenges()
    {
        List<Challenge> challenges = challengeRepo.FindAll().OrderBy((a) => a.Name).ToList();
        List<ChallengeDTO> challengesDTO = new List<ChallengeDTO>();
        foreach(Challenge challenge in challenges){
            challengesDTO.Add(new ChallengeDTO(challenge.MinimumAge,challenge.MaximumAge,challenge.Name,entriesRepo.FindChildNumber(challenge.Id)));
        }
        return challengesDTO;
    }

    public List<ChildDTO> GetAllChildren(){
        IEnumerable<Child> children = childRepo.FindAll();
        List<ChildDTO> childrenDTO = new List<ChildDTO>();
        foreach(Child child in children){
            childrenDTO.Add(new ChildDTO(child.Name,child.Age,entriesRepo.FindChallengeNumber(child.Id)));
        }
        return childrenDTO;
    }

    private Contest.model.Tuple<int,int> CreateAgeInterval(int age){
         IEnumerable<Challenge> challenges = challengeRepo.FindAll();
         foreach(Challenge challenge in challenges){
             if(challenge.MinimumAge <= age && challenge.MaximumAge >= age){
                 return new Contest.model.Tuple<int,int>(challenge.MinimumAge,challenge.MaximumAge);
             }
         }
         return null;
    }

    public Child RegisterChild(String name,int age,String challenge1,String challenge2){

        if(challenge1.CompareTo(challenge2) == 0){
            throw new ValidationException("Participantul nu poate fi inscris de 2 ori la aceeasi proba ! ");
        }

        Child child = new Child(name,age);

        Child foundChild;
        if(childRepo.FindByProperties(name,age) != null) {

            foundChild = childRepo.FindByProperties(name, age);
            if (entriesRepo.FindChallengeNumber(foundChild.Id) == 1 && challenge2 != "") {
                throw new ValidationException("Participantul mai poate fi inscris la o singura proba ! ");
            }else if (entriesRepo.FindChallengeNumber(foundChild.Id) == 2){
                throw new ValidationException("Participantul nu mai poate fi inscris la nici o proba ! ");
            }

            Contest.model.Tuple<int,int> ageInterval = CreateAgeInterval(age);
            Challenge challengeFound1 = challengeRepo.FindByProperties(ageInterval.Left,ageInterval.Right,challenge1);

            if(challengeFound1 != null && entriesRepo.Exists(new Contest.model.Tuple<long,long>(foundChild.Id, challengeFound1.Id))){
                throw new ValidationException("Participantul nu mai poate fi inscris la aceeasi proba ! ");
            }

            Entry entry = new Entry(DateTime.Now,foundChild,challengeFound1);
            if(challengeFound1 != null){
                entry.Id =new Contest.model.Tuple<long,long>(foundChild.Id,challengeFound1.Id);
                if(entriesRepo.Save(entry) != null)
                    return foundChild;
            }

            return null;
        }

        Child added = childRepo.Save(child);
        foundChild = childRepo.FindByProperties(name,age);

        if(challenge1 != ""){
            Contest.model.Tuple<int,int> ageInterval = CreateAgeInterval(age);
            Challenge foundChallenge1 = challengeRepo.FindByProperties(ageInterval.Left,ageInterval.Right,challenge1);
            Entry entry = new Entry(DateTime.Now,foundChild,foundChallenge1);
            if(foundChallenge1 != null){
                entry.Id = new Contest.model.Tuple<long,long>(foundChild.Id,foundChallenge1.Id);
                if(entriesRepo.Save(entry) != null)
                    return foundChild;
            }
        }

        if(challenge2 != ""){
            Contest.model.Tuple<int,int> ageInterval = CreateAgeInterval(age);
            Challenge foundChallenge2 = challengeRepo.FindByProperties(ageInterval.Left,ageInterval.Right,challenge2);
            Entry entry = new Entry(DateTime.Now,foundChild,foundChallenge2);
            if(foundChallenge2 != null){
                entry.Id = new Contest.model.Tuple<long,long>(foundChild.Id,foundChallenge2.Id);
                if(entriesRepo.Save(entry) != null)
                    return foundChild;
            }
        }

        return added;

    }

    public Challenge getChallengeByProperties(int minimumAge, int maximumAge, string name)
    {
        return challengeRepo.FindByProperties(minimumAge, maximumAge, name);
    }

    public List<Child> getChildrenById(long cid)
    {
        List<Child> children = new List<Child>();
        foreach (Entry entry in entriesRepo.FindAll())
        {
            if(entry.Id.Right == cid)
                children.Add(childRepo.FindOne(entry.Id.Left));
        }

        return children;
    }

    }
}