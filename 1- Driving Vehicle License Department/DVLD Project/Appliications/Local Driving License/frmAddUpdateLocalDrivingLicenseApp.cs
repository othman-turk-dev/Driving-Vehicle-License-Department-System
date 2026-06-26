using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.General_Tools;

namespace DVLD_Project.Appliications.Local_Driving_License
{
    public partial class frmAddUpdateLocalDrivingLicenseApp : Form
    {
        enum enMode { Add = 0, Update = 1 }

        enMode _Mode = enMode.Add;
        
        ClsLocalDrivingLicenseApplications _ClsLocalDLApp;
        int _LocaDLAppID = -1;
        int _PersonID = -1;

        string _OldLicenseClassesInfo="";//for update License Class

        public frmAddUpdateLocalDrivingLicenseApp()
        {
            InitializeComponent();

            _Mode = enMode.Add;
        }
        public frmAddUpdateLocalDrivingLicenseApp(int LocalDrivingLicenseAppID)
        {
            InitializeComponent();

            _LocaDLAppID = LocalDrivingLicenseAppID;
            _Mode = enMode.Update;
        }
        private void _SetupDefaultValue()
        {

            if (_Mode == enMode.Add)
            {
                LbMode.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _ClsLocalDLApp = new ClsLocalDrivingLicenseApplications();

                TbApplicationInfo.Enabled = false;
                ctrPersonCardWithFilter1.FilterFocus();
                CbLicenseClasses.SelectedIndex = 2;
                LbAppFees.Text = ClsApplicationTypes.Find((int)ClsApplication.enApplicationType.NewDrivingLicense).ApplicationTypeFees.ToString();
                LbAppDate.Text = DateTime.Now.ToShortDateString();
                LbCreateBy.Text = ClsGlobal.GlobalUser.UserName;

            }
            else
            {
                LbMode.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                TbApplicationInfo.Enabled = true;
                BtnSave.Enabled = true;
            }
        }
        private void _LoadData()
        {

            ctrPersonCardWithFilter1.FilterEnabled = false;
            _ClsLocalDLApp = ClsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationByLocalID(_LocaDLAppID);

            if (_ClsLocalDLApp == null)
            {
                MessageBox.Show("No Application with ID = " + _LocaDLAppID.ToString(), "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
            _PersonID = _ClsLocalDLApp.ApplicantPersonID;

            LbAppDate.Text = _ClsLocalDLApp.ApplicationDate.ToShortDateString();
            LbLocalDLAppID.Text = _LocaDLAppID.ToString();
            LbCreateBy.Text = ClsUser.FindByUserID(_ClsLocalDLApp.CreatedByUserID).UserName;
            CbLicenseClasses.SelectedItem = _ClsLocalDLApp.LicenseClassesInfo.ClassName;
            LbAppFees.Text = _ClsLocalDLApp.PaidFees.ToString();

            _OldLicenseClassesInfo = _ClsLocalDLApp.LicenseClassesInfo.ClassName;

            ctrPersonCardWithFilter1.LoadPersonInfo(_ClsLocalDLApp.ApplicantPersonID);
        }
        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received
            _PersonID = PersonID;
            ctrPersonCardWithFilter1.LoadPersonInfo(PersonID);

        }
        private bool _IsAllowedAge(int PersonID,int LicenseClassID)
        {

            int GetMinimumAllowedAgeForLicense = ClsLicenseClasses.FindByLicenseClassID(LicenseClassID).MinimumAllowedAge;
            DateTime DateOfBirthforPerson = ClsPerson.Find(PersonID).DateOfBirth;
            DateTime MinimumDateOfLicense = DateTime.Now.AddYears(-GetMinimumAllowedAgeForLicense);

            if (DateOfBirthforPerson > MinimumDateOfLicense)
            {
                MessageBox.Show("This person is under "+ GetMinimumAllowedAgeForLicense.ToString()+
                    " years old.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return false;
            }

            return true;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

            int LicenseClassID = ClsLicenseClasses.FindByClassName(CbLicenseClasses.Text).LicenseClassID;

            int ActiveApplicationID = ClsApplication.GetActiveApplicationIDForLicenseClass(_PersonID, ClsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1 && _OldLicenseClassesInfo != CbLicenseClasses.Text)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CbLicenseClasses.Focus();
                return;
            }

            if (!_IsAllowedAge(_PersonID, LicenseClassID))
                return;

            if (ClsLicenses.IsLicenseExistByPersonID(ctrPersonCardWithFilter1.PersonID, LicenseClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ClsLocalDLApp.ApplicationDate = DateTime.Now;
            _ClsLocalDLApp.LastStatusDate = DateTime.Now;
            _ClsLocalDLApp.CreatedByUserID = ClsGlobal.GlobalUser.UserID;
            _ClsLocalDLApp.ApplicantPersonID = ctrPersonCardWithFilter1.PersonID;
            _ClsLocalDLApp.LicenseClassID = LicenseClassID;
            _ClsLocalDLApp.ApplicationStatus = ClsApplication.enApplicationStatus.New;
            _ClsLocalDLApp.PaidFees = Convert.ToDecimal(LbAppFees.Text);
            _ClsLocalDLApp.ApplicationTypeID = 1;


            if (_ClsLocalDLApp.Save())
            {
                LbLocalDLAppID.Text = _ClsLocalDLApp.LocalDrivingLicenseApplicationID.ToString();
                ctrPersonCardWithFilter1.FilterEnabled = false;

                //change form mode to update.
                _Mode = enMode.Update;
                LbMode.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmAddUpdateLocalDrivingLicenseApp_Load(object sender, EventArgs e)
        {
            _SetupDefaultValue();

            if (_Mode == enMode.Update)
                _LoadData();
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
            {
                BtnSave.Enabled = true;
                TbApplicationInfo.Enabled = true;
                TbCtrAddUpdate.SelectedTab = TbCtrAddUpdate.TabPages["TbApplicationInfo"];
                return;
            }


            //incase of add new mode.
            if (ctrPersonCardWithFilter1.PersonID != -1)
            {

                BtnSave.Enabled = true;
                TbApplicationInfo.Enabled = true;
                TbCtrAddUpdate.SelectedTab = TbCtrAddUpdate.TabPages["TbApplicationInfo"];

            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrPersonCardWithFilter1.FilterFocus();
            }

        }
        private void ctrPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;

        }
        private void frmAddUpdateLocalDrivingLicenseApp_Activated(object sender, EventArgs e)
        {

            ctrPersonCardWithFilter1.FilterFocus();
        }
    
    }
}
