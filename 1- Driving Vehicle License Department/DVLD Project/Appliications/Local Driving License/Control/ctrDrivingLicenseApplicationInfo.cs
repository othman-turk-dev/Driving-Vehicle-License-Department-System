using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_Project.Licenses.LocalLicenses;

namespace DVLD_Project.Appliications.Local_Driving_License.Control
{
    public partial class ctrDrivingLicenseApplicationInfo : UserControl
    {
        ClsLocalDrivingLicenseApplications _clsLocalDriving;
        int _LocalDrivingLicenseApplicationID = -1;
        private int _LicenseID;
        public ctrDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }
        public void SetupDefaultData()
        {

            _LocalDrivingLicenseApplicationID = -1;

            LbID.Text = "[???]";
            LbAppliedLicnse.Text = "[???]";
            LbPassedTest.Text = "[???]";

            ctrApplicationBasicInfo1.ResetDafaultData();

        }
        private void _FillDrivingLicenseApplicationInfo()
        {

            _LicenseID = _clsLocalDriving.GetActiveLicenseID();

            //incase there is license enable the show link.
            LinkShowLicensInfo.Visible = (_LicenseID != -1);

            _LocalDrivingLicenseApplicationID = _clsLocalDriving.LocalDrivingLicenseApplicationID;

            LbID.Text = _clsLocalDriving.LocalDrivingLicenseApplicationID.ToString();
            LbAppliedLicnse.Text = _clsLocalDriving.LicenseClassesInfo.ClassName;
            
            LbPassedTest.Text = _clsLocalDriving.GetPassedTestCount() + "/3";

            ctrApplicationBasicInfo1.LoadDataForApplication(_clsLocalDriving.ApplicationID);
        }
        public void LoadDrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {

            _clsLocalDriving = ClsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationByLocalID(LocalDrivingLicenseApplicationID);

            if(_clsLocalDriving == null)
            {
                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                SetupDefaultData();
                return;
            }

            _FillDrivingLicenseApplicationInfo();

        }
        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {

            _clsLocalDriving = ClsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationByApplicationID(ApplicationID);
            if (_clsLocalDriving == null)
            {
                SetupDefaultData();


                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillDrivingLicenseApplicationInfo();

        }
        private void LinkShowLicensInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmShowLicenseInfo(_clsLocalDriving.GetActiveLicenseID());
            form.ShowDialog();

        }

    }
}
