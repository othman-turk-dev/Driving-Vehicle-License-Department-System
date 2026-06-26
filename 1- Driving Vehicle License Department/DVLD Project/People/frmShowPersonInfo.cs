using System;
using System.Windows.Forms;

namespace DVLD_Project.People
{
    public partial class frmShowPersonInfo : Form
    {
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();

            ctrPersonCard1.LoadDataForPerson(PersonID);
        }
        public frmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();

            ctrPersonCard1.LoadDataForPerson(NationalNo);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

    }
}
