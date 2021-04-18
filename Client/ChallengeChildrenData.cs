using System.Collections.Generic;
using System.Windows.Forms;
using Contest.model;

namespace Contest_CS
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