using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Contest.model;
using Contest_CS.service;
using Contest_CS.validator;

namespace Contest_CS
{
    public partial class Main : Form
    {
        private Login loginForm;
        private Service service;
        private Employee employee;
        public Main(Login loginForm ,Service service,Employee employee)
        {
            this.loginForm = loginForm;
            this.service = service;
            this.employee = employee;
            InitializeComponent();
            ChallengesDataGridView.DataSource = service.GetAllChallenges();
            ChildrenDataGridView.DataSource = service.GetAllChildren();
            SecondChallengeBox.Visible = false;
            DeleteSecondChallengeLabel.Visible = false;
        }

        private void AddSecondChallengeLabel_Click(object sender, EventArgs e)
        {
            SecondChallengeBox.Visible = true;
            DeleteSecondChallengeLabel.Visible = true;
            AddSecondChallengeLabel.Visible = false;
        }

        private void DeleteSecondChallengeLabel_Click(object sender, EventArgs e)
        {
            SecondChallengeBox.Visible = false;
            DeleteSecondChallengeLabel.Visible = false;
            AddSecondChallengeLabel.Visible = true;
            SecondChallengeComboBox.Items.Clear();
            SecondChallengeComboBox.Text = "Alege a doua proba";
        }

        

        private void FirstChallengeComboBox_DropDown(object sender, EventArgs e)
        {
            string ageText = AgeTextBox.Text;
            FirstChallengeComboBox.Items.Clear();
            SecondChallengeComboBox.Items.Clear();
            try
            {
                int age = Int32.Parse(ageText);
                IDictionary<string, ChallengeDTO> challengesDictionary = new Dictionary<string, ChallengeDTO>();
                List<ChallengeDTO> challenges = service.GetAllChallenges().ToList();
                List<ChallengeDTO> filtered = new List<ChallengeDTO>();
                foreach (ChallengeDTO challenge in challenges)
                {
                    if(challenge.MinimumAge <= age && challenge.MaximumAge >= age)
                        filtered.Add(challenge);
                }
                foreach (ChallengeDTO challenge in filtered)
                {
                    challengesDictionary[challenge.Name] = challenge;
                }

                foreach (KeyValuePair<string, ChallengeDTO> entry in challengesDictionary)
                {
                    FirstChallengeComboBox.Items.Add(entry.Key);
                }

                RegisterButton.Enabled = true;
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.StackTrace);
                RegisterButton.Enabled = false;
            }
        }

        private void SecondChallengeComboBox_DropDown(object sender, EventArgs e)
        {
            string ageText = AgeTextBox.Text;
            FirstChallengeComboBox.Items.Clear();
            SecondChallengeComboBox.Items.Clear();
            try
            {
                int age = Int32.Parse(ageText);
                IDictionary<string, ChallengeDTO> challengesDictionary = new Dictionary<string, ChallengeDTO>();
                List<ChallengeDTO> challenges = service.GetAllChallenges().ToList();
                List<ChallengeDTO> filtered = new List<ChallengeDTO>();
                foreach (ChallengeDTO challenge in challenges)
                {
                    if(challenge.MinimumAge <= age && challenge.MaximumAge >= age)
                        filtered.Add(challenge);
                }
                foreach (ChallengeDTO challenge in filtered)
                {
                    challengesDictionary[challenge.Name] = challenge;
                }

                foreach (KeyValuePair<string, ChallengeDTO> entry in challengesDictionary)
                {
                    SecondChallengeComboBox.Items.Add(entry.Key);
                }

                RegisterButton.Enabled = true;
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.StackTrace);
                RegisterButton.Enabled = false;
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string ageText = AgeTextBox.Text;
            int age = Int32.Parse(ageText);
            string challenge1 = "";
            string challenge2 = "";
            if (FirstChallengeComboBox.SelectedItem != null && FirstChallengeComboBox.SelectedIndex != -1)
                challenge1 = FirstChallengeComboBox.SelectedItem.ToString();
            if (SecondChallengeComboBox.SelectedItem != null && SecondChallengeComboBox.SelectedIndex != -1)
                challenge2 = SecondChallengeComboBox.SelectedItem.ToString();
            try
            {
                Child child = service.RegisterChild(name, age, challenge1, challenge2);
                if (child != null)
                    ErrorLabel.Text = "A aparut o eroare ! ";
                else
                    ErrorLabel.Text = "";
            }
            catch (ValidationException exception)
            {
                ErrorLabel.Text = exception.getErrors();
            }

        }

        private void ChallengesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                int minimumAge = Int32.Parse(ChallengesDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                int maximumAge = Int32.Parse(ChallengesDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
                string name = ChallengesDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();

                Challenge challenge = service.getChallengeByProperties(minimumAge, maximumAge, name);
                ChallengeChildrenData childrenData = new ChallengeChildrenData(service.getChildrenById(challenge.Id));
                childrenData.Show();
            }
        }
    }
}