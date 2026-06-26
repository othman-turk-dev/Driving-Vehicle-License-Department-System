using System;
using DVLD_BusinessLayer;
using DVLD_Project.People;
using System.Windows.Forms;

namespace DVLD_Project.Appliications.Control
{
    public partial class ctrApplicationBasicInfo : UserControl
    {
        public ctrApplicationBasicInfo()
        {
            InitializeComponent();
        }

        private ClsApplication _Application;
        private int _ApplicationID=-1;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }
        public void ResetDafaultData()
        {

            _ApplicationID = -1;
            LinklForPerson.Enabled = false;

            LbID.Text = "[???]";
            LbStatus.Text = "[???]";
            LbFees.Text = "[???]";
            LbType.Text = "[???]";
            LbApplicant.Text = "[???]";
            LbDate.Text = "[???]";
            LbStatusDate.Text = "[???]";
            LbCreateBy.Text = "[???]";

        }
        public void LoadDataForApplication(int ApplicationID)
        {

            _Application = ClsApplication.FindBaseApplication(ApplicationID);

            if(_Application == null)
            {
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Not Found Application",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                ResetDafaultData();
                return;
            }
            else
                _FillApplication();

        }
        private void _FillApplication()
        {

            _ApplicationID = _Application.ApplicationID;
            LinklForPerson.Enabled = true;

            LbID.Text = _Application.ApplicationID.ToString();
            LbStatus.Text = _Application.StatusText;
            LbFees.Text = _Application.PaidFees.ToString();
            LbType.Text = _Application.ApplicationTypeInfo.ApplicationTypeTitle;
            LbApplicant.Text = _Application.ApplicantFullName;
            LbDate.Text = _Application.ApplicationDate.ToShortDateString();
            LbStatusDate.Text = _Application.LastStatusDate.ToShortDateString();
            LbCreateBy.Text = _Application.CreatedByUserInfo.UserName;

        }
        private void LinklForPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmShowPersonInfo(_Application.ApplicantPersonID);
            form.ShowDialog();

            LoadDataForApplication(_ApplicationID);
        }

    }
}
