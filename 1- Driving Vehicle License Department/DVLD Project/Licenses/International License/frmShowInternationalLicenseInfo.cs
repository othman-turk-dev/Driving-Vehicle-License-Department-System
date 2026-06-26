using System;
using System.Windows.Forms;

namespace DVLD_Project.Licenses.International_License
{
    public partial class frmShowInternationalLicenseInfo : Form
    {
        int _InternationalLicenseID = -1;
        public frmShowInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();

            _InternationalLicenseID = InternationalLicenseID;
        }
        private void frmShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

            ctrDriverInternationalLicenseInfo1.LoadData(_InternationalLicenseID);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

    }
}
