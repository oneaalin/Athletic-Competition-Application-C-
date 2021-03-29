using System;
using System.Windows.Forms;
using Contest.model;
using Contest_CS.service;

namespace Contest_CS
{
    public partial class Login : Form
    {
        private Service service;
        public Login(Service service)
        {
            this.service = service;
            InitializeComponent();
        }
        

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register(this,service);
            this.Hide();
            registerForm.Show();
            //this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            String usename = UsernameBox.Text;
            String password = PasswordBox.Text;
            Employee employee = service.LoginEmployee(usename, password);
            if (employee != null)
            {
                Main mainForm = new Main(this, service, employee);
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("The username and/or password are not matching ! ");
            }
        }
    }
}