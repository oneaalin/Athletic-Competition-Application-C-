using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contest.model;
using Contest.repository;
using Contest_CS.repository;

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


      IChildRepository childRepo = new ChildRepository();
      IChallengeRepository challengeRepo = new ChallengeRepository();
      //childRepo.Save(new Child("Alin", 10));
      childRepo.Save(new Child("Andrei", 12));
      //childRepo.Delete(2);
      foreach(var element in childRepo.FindAll())
      {
        Trace.WriteLine(element);
      }

      //Application.EnableVisualStyles();
      //Application.SetCompatibleTextRenderingDefault(false);
      //Application.Run(new Form1());
    }
  }
}
