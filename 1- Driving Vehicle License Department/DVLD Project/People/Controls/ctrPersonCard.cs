using System;
using System.IO;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_Project.Properties;

namespace DVLD_Project.People.Control
{
    public partial class ctrPersonCard : UserControl
    {

        private ClsPerson _person;
        private int _PersonID = -1;
        enum enGender {Male = 0, Female = 1};

        public int PersonID
        {
            get { return _PersonID; }

        }
        public ClsPerson SelectedPersonInfo
        {
            get { return _person; }

        }
        public ctrPersonCard()
        {
            InitializeComponent();

        }
        public void LoadDataForPerson(int ID)
        {

            _person = ClsPerson.Find(ID);

            if (_person == null)
            {
                MessageBox.Show("No one has this ID = " + _PersonID, "Not Found Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDafaultData();
                return;
            }
            _FillingPersonInfo();

        }
        public void LoadDataForPerson(string NationalNo)
        {
            _person = ClsPerson.Find(NationalNo);

            if (_person == null)
            {
                MessageBox.Show("No one has this National No = " + _PersonID, "Not Found Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDafaultData();
                return;
            }
            _FillingPersonInfo();

        }
        private void _LoadImage()
        {

            string ImagePath = _person.ImagePath;

            if (ImagePath != "" && ImagePath != null)
                if (File.Exists(ImagePath))
                    PicImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                PicImage.Image = (_person.Gendor == (short)enGender.Male) ? Resources.Man715 : Resources.Woman715;

        }
        private void _FillingPersonInfo()
        {

            LinkUpdateInfo.Enabled = true;
            _PersonID = _person.PersonID;

            LbPersonID.Text = _person.PersonID.ToString();
            LbName.Text = _person.FullName;
            LbNational.Text = _person.NationalNo;
            LbGendor.Text = (_person.Gendor == (short)enGender.Male) ? "Male" : "Female";
            LbEmail.Text = _person.Email;
            LbAddres.Text = _person.Address;
            LbDate.Text = _person.DateOfBirth.ToString("yyyy/MM/dd");
            LbPhone.Text = _person.Phone;
            LbCountry.Text = _person.CountryInfo.CountryName;

            _LoadImage();

        }
        public void ResetDafaultData()
        {

            _PersonID = -1;
            
            LbPersonID.Text = "[???]";
            LbName.Text = "[???]";
            LbNational.Text = "[???]";
            LbGendor.Text = "[???]";
            LbEmail.Text = "[???]";
            LbAddres.Text = "[???]";
            LbDate.Text = "[???]";
            LbPhone.Text = "[???]";
            LbCountry.Text = "[???]";

            PicImage.Image = Resources.Man715;

        }
        private void LinkUpdateInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form form = new frmAddEditPerson(_PersonID);
            form.ShowDialog();

            LoadDataForPerson(_PersonID);

        }

    }
}
