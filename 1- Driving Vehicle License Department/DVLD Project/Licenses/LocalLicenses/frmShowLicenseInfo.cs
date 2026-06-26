using System;
using System.Windows.Forms;

namespace DVLD_Project.Licenses.LocalLicenses
{
    public partial class frmShowLicenseInfo : Form
    {
        int _LicenseID = -1;
        public frmShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();

            _LicenseID = LicenseID;
        }
        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {

            ctrDriverLicenseInfo1.LoadData(_LicenseID);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    
    }
}
