using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Contest.model;
using Contest_CS.service;
using Contest_CS.validator;
using Microsoft.Data.Sqlite;

namespace Contest_CS
{
    public partial class Register : Form
    {
        private Login loginForm;
        private Service service;
        public Register(Login loginForm,Service service)
        {
            this.loginForm = loginForm;
            this.service = service;
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            String username = UsernameBox.Text;
            String password = PasswordBox.Text;
            try
            {
                Employee employee = service.RegisterEmployee(username, password);
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