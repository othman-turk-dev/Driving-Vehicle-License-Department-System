using System;
using DVLD_Project.Login;
using System.Windows.Forms;
using DVLD_Project.Appliications.International_License;

namespace DVLD_Project
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            Form form = new frmIssueInternationalLicenseApp();
            form.ShowDialog();

        }
    }
}
