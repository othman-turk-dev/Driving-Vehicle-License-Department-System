using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;

namespace DVLD_Project.Licenses
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        int _PersonID = -1;
        ClsPerson _Person;

        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
        }
        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            _Person = ClsPerson.Find(_PersonID);

            if(_Person == null)
            {
                MessageBox.Show("There is person with ID = " + _Person.PersonID, "Not Fount",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            ctrPersonCardWithFilter1.LoadPersonInfo(_Person.PersonID);
            ctrDriverLicenses1.LoadData(_Person.PersonID);
            ctrPersonCardWithFilter1.FilterEnabled = false;

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }
   
    }
}
