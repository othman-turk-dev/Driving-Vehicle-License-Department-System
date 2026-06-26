using System;
using System.Windows.Forms;

namespace DVLD_Project.People
{
    public partial class frmFindPerson : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public frmFindPerson()
        {
            InitializeComponent();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this,ctrPersonCardWithFilter1.PersonID);
            this.Close();
        }

    }
}
