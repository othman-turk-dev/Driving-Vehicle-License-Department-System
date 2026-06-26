using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.Properties;
using System.IO;

namespace DVLD_Project.Licenses.LocalLicenses.Controls
{
    public partial class ctrDriverLicenseInfo : UserControl
    {
        enum enGender { Male = 0, Female = 1 };

        private int _LicenseID = -1;
        private ClsLicenses _License;
        public ctrDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public int LicenseID
        {

            get { return _LicenseID; }
        }
        public ClsLicenses SelectedLicenseInfo
        { 

            get { return _License; } 
        }
        public void ResetDafaultData()
        {
            LbClass.Text = "[???]";
            LbName.Text = "[???]";
            LbLicenseID.Text = "[???]";
            LbNational.Text = "[???]";
            LbGender.Text = "[???]";
            LbIssueDate.Text = "[???]";
            LbIssueReason.Text = "[???]";
            LbNotes.Text = "[???]"; 
            LbIsActive.Text = "[???]";
            LbDateOfBirth.Text = "[???]";
            LbDriverID.Text = "[???]";
            LbExpirationDate.Text= "[???]";
            LbIsDetained.Text = "[???]";

            PicImage.Image = Resources.Man715;
        }
        public void LoadData(int LicenseID)
        {

            _LicenseID = LicenseID;
            _License = ClsLicenses.FindByLicenseID(_LicenseID);

            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;

                return;
            }

            _FillingByInfo();

        }
        private void _LoadImage()
        {

            if (_License.DriverInfo.PersonInfo.Gendor == (int)enGender.Male)
                PicImage.Image = Resources.Man715;
            else
                PicImage.Image = Resources.Woman715;

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    PicImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        void _FillingByInfo()
        {

            LbLicenseID.Text = _License.LicenseID.ToString();
            LbIsActive.Text = _License.IsActive ? "Yes" : "No";
            LbIsDetained.Text = _License.IsDetained ? "Yes" : "No";
            LbClass.Text = _License.LicenseClassInfo.ClassName;
            LbName.Text = _License.DriverInfo.PersonInfo.FullName;
            LbNational.Text = _License.DriverInfo.PersonInfo.NationalNo;
            LbGender.Text = _License.DriverInfo.PersonInfo.Gendor == ((int)enGender.Male) ? "Male" : "Female";
            LbDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();

            LbDriverID.Text = _License.DriverID.ToString();
            LbIssueDate.Text = _License.IssueDate.ToShortDateString();
            LbExpirationDate.Text = _License.ExpirationDate.ToShortDateString();
            LbIssueReason.Text = _License.IssueReasonText;
            LbNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;

            _LoadImage();

        }

    }
}
