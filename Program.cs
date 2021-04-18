using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contest.model;
using Contest.repository;
using Contest_CS.repository;
using Contest_CS.service;

namespace Contest_CS
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {


      //IChildRepository childRepo = new ChildRepository();
      //IChallengeRepository challengeRepo = new ChallengeRepository();
      //childRepo.Save(new Child("Alin", 10));
      //childRepo.Save(new Child("Andrei", 12));
      //childRepo.Delete(2);
      /*foreach(var element in childRepo.FindAll())
      {
        Trace.WriteLine(element);
      }*/

      IChildRepository childRepo = new ChildRepository();
      IChallengeRepository challengeRepo = new ChallengeRepository();
      IEmployeesRepository employeesRepo = new EmployeesRepository();
      IEntriesRepository entriesRepo = new EntriesRepository(childRepo, challengeRepo);

      Service service = new Service(childRepo, challengeRepo, employeesRepo, entriesRepo);
      
      
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      //Application.Run(new Login(service));
      
      
    }
  }
}
