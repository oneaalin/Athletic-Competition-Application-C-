using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Client;
using Models;
using Networking;
using Server;
using Services;

namespace Client
{
    public partial class Main : Form
    {
        private Login loginForm;
        private ClientController ctrl;
        public Main(Login loginForm ,ClientController ctrl)
        {
            this.loginForm = loginForm;
            this.ctrl = ctrl;
            InitializeComponent();
            ChallengesDataGridView.DataSource = ctrl.GetAllChallenges();
            ChildrenDataGridView.DataSource = ctrl.GetAllChildren();
            SecondChallengeBox.Visible = false;
            DeleteSecondChallengeLabel.Visible = false;
            ctrl.updateEvent += userUpdate;
        }
        
        private void ChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("ChatWindow closing "+e.CloseReason);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ctrl.Logout();
                ctrl.updateEvent -= userUpdate;
                Application.Exit();
            }
          
        }

        public void userUpdate(object sender, UserEventArgs e)
        {
            if (e.UserEvent == UserEvent.NewChild)
            {
                UpdateDTO update = (UpdateDTO)e.Data;
                ChildDTO child = update.Child;
                List<ChallengeDTO> challenges = update.Challenges;
                ChildrenDataGridView.BeginInvoke(new UpdateDelegate(this.UpdateChildren), new Object[] {update});
                ChallengesDataGridView.BeginInvoke(new UpdateDelegate(this.UpdateChallenges), new Object[] {update});
            }
        }

        public delegate void UpdateDelegate(UpdateDTO update);

        private void UpdateChildren(UpdateDTO update)
        {
            ChildDTO child = update.Child;
            List<ChildDTO> children = new List<ChildDTO>();
            foreach(DataGridViewRow row in ChildrenDataGridView.Rows)
                children.Add((ChildDTO) row.DataBoundItem);
            children.Add(child);
            //ChildrenDataGridView.Rows.Clear();
            ChildrenDataGridView.DataSource = children;
        }

        private void UpdateChallenges(UpdateDTO update)
        {
            List<ChallengeDTO> challenges = update.Challenges;
            //ChallengesDataGridView.Rows.Clear();
            ChallengesDataGridView.DataSource = challenges;
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
                List<ChallengeDTO> challenges = ctrl.GetAllChallenges().ToList();
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
                List<ChallengeDTO> challenges = ctrl.GetAllChallenges().ToList();
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
                Child child = ctrl.RegisterChild(name, age, challenge1, challenge2);
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

                Challenge challenge = ctrl.GetChallengeByProperties(minimumAge, maximumAge, name);
                ChallengeChildrenData childrenData = new ChallengeChildrenData(ctrl.GetChildrenById(challenge.Id));
                childrenData.Show();
            }
        }
    }
}