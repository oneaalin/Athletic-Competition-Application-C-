using System;
using System.Windows.Forms;
using Client;
using Models;
using Server;
using Services;

namespace Client
{
    public partial class Login : Form
    {
        private ClientController ctrl;
        public Login(ClientController ctrl)
        {
            this.ctrl = ctrl;
            InitializeComponent();
        }
        

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register(this,ctrl);
            this.Hide();
            registerForm.Show();
            //this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            String usename = UsernameBox.Text;
            String password = PasswordBox.Text;
            try
            {
                Employee employee = ctrl.Login(usename, password);
                if (employee != null)
                {
                    Main mainForm = new Main(this, ctrl);
                    this.Hide();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("The username and/or password are not matching ! ");
                }
            }
            catch (ValidationException)
            {
                MessageBox.Show("The user is already logged in");
            }
            
        }
    }
}