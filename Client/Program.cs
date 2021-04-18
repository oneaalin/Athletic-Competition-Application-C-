using System;
using System.Windows.Forms;
using Networking;
using Services;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IService server = new ServerObjectProxy("127.0.0.1", 55555);
            ClientController ctrl = new ClientController(server);

            Application.Run(new Login(ctrl));
        }
    }
}