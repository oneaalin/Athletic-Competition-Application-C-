using System;
using System.Windows.Forms;
using Client;
using Microsoft.Data.Sqlite;
using Models;
using Server;
using Services;

namespace Client
{
    public partial class Register : Form
    {
        private Login loginForm;
        private ClientController ctrl;
        public Register(Login loginForm,ClientController ctrl)
        {
            this.loginForm = loginForm;
            this.ctrl = ctrl;
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            String username = UsernameBox.Text;
            String password = PasswordBox.Text;
            try
            {
                Employee employee = ctrl.RegisterEmployee(username, password);
                if (employee == null)
                {
                    this.Hide();
                    loginForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Date Invalide ! ");
                }
            }
            catch (SqliteException er)
            {
                MessageBox.Show("Exista deja un utilizator cu acest username ! ");
                UsernameBox.Text = "";
                PasswordBox.Text = "";
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm.Show();
            this.Close();
        }
    }
}