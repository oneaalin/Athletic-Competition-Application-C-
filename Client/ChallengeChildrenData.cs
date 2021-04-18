using System.Collections.Generic;
using System.Windows.Forms;
using Models;

namespace Client
{
    public partial class ChallengeChildrenData : Form
    {
        public ChallengeChildrenData(List<Child> children)
        {
            InitializeComponent();
            ChildrenDataGridView.DataSource = children;
        }
    }
}