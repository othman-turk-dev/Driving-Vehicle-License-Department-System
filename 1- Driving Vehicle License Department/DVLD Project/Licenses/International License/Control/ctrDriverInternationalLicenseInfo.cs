using System;
using System.IO;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.Properties;

namespace DVLD_Project.Licenses.International_License.Control
{
    public partial class ctrDriverInternationalLicenseInfo : UserControl
    {
        private enum enGender { Male = 0, Female = 1 };

        int _InternationalLicenseID = -1;
        ClsInternationalLicense _InternationalLicense;
        public ctrDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        public int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }
        private void _LoadImage()
        {

            if (_InternationalLicense.DriverInfo.PersonInfo.Gendor == (int)enGender.Male)
                PicImage.Image = Resources.Man715;
            else
                PicImage.Image = Resources.Woman715;

            string ImagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    PicImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void LoadData(int InternationalLicenseID)
        {

            _InternationalLicenseID = InternationalLicenseID;
            _InternationalLicense = ClsInternationalLicense.Find(_InternationalLicenseID);

            if(_InternationalLicense == null)
            {
                MessageBox.Show("Could not find Internationa License ID = " + _InternationalLicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            LbApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            LbDateOfBirth.Text = _InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            LbDriverID.Text = _InternationalLicense.DriverID.ToString();
            LbExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();
            LbGender.Text = (_InternationalLicense.DriverInfo.PersonInfo.Gendor == (int)enGender.Male) ? "Male" : "Female";
            LbInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            LbIsActive.Text = (_InternationalLicense.IsActive) ? "Yes" : "No";
            LbIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            LbLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            LbName.Text = _InternationalLicense.ApplicantFullName;
            LbNational.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo;

            _LoadImage();
        }

    }
}
