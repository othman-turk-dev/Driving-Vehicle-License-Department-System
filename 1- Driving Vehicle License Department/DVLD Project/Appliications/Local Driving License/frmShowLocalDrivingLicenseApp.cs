using System;
using System.Windows.Forms;

namespace DVLD_Project.Appliications.Local_Driving_License
{
    public partial class frmShowLocalDrivingLicenseApp : Form
    {
        private int _Application = -1;
        public frmShowLocalDrivingLicenseApp(int Application)
        {
            InitializeComponent();

            _Application = Application;
        }
        private void frmShowLocalDrivingLicenseApp_Load(object sender, EventArgs e)
        {

            ctrDrivingLicenseApplicationInfo1.LoadDrivingLicenseApplicationInfo(_Application);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

    }
}
