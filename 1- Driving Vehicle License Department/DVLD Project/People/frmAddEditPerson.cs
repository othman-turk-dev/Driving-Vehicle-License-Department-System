using System;
using System.IO;
using System.Data;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using System.ComponentModel;
using DVLD_Project.Properties;
using DVLD_Project.General_Tools; 

namespace DVLD_Project.People
{
    public partial class frmAddEditPerson : Form
    {

        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        enum enMode {eAdd = 0, eUpdate = 1};
        enum enGender {Male = 0, Female = 1};

        int _PersonID = -1;
        ClsPerson _clsPerson;
        enMode _Mode = enMode.eAdd;

        public frmAddEditPerson()
        {
            InitializeComponent();

            _Mode = enMode.eAdd;
        }
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            _Mode = enMode.eUpdate;
            _PersonID = PersonID;
        }
        private void _FillingAllCountriesOnComboBox()
        {

            DataTable table = ClsCountries.GetAllCountries();

            foreach(DataRow row in table.Rows)
            {
                CmbCountry.Items.Add(row["CountryName"]);
            }

        }
        private void _SetupTheDefaultForm()
        {
            _FillingAllCountriesOnComboBox();

            if(_Mode == enMode.eAdd)
            {
                LbMode.Text = "Add New Person";
                this.Text = "Add New Person";
                _clsPerson = new ClsPerson();

            }
            else
            {
                LbMode.Text = "Update Person";
                this.Text = "Update Person";

            }

            if (RbtnMale.Checked)
                PicImage.Image = Resources.Man715;
            else
                PicImage.Image = Resources.Woman715;

            LinkImageRemove.Visible = (PicImage.ImageLocation != null);

            //we set the max date to 18 years from today, and set the default value the same.
            TxtDateTime.MaxDate = DateTime.Now.AddYears(-18);
            TxtDateTime.Value = TxtDateTime.MaxDate;

            //should not allow adding age more than 100 years
            TxtDateTime.MinDate = DateTime.Now.AddYears(-100);

            //this will set default country to jordan.
            CmbCountry.SelectedIndex = CmbCountry.FindString("Syria");

            TxtFName.Text = "";
            TxtSName.Text = "";
            TxtThName.Text = "";
            TxtLName.Text = "";
            TxtNational.Text = "";
            TxtEmail.Text = "";
            TxtPhone.Text = "";
            TxtBoxAddress.Text = "";

            RbtnMale.Checked = true;

        }
        private void _LoadDataToForm()
        {

            _clsPerson = ClsPerson.Find(_PersonID);

            if(_clsPerson == null)
            {
                MessageBox.Show("No one has this ID = "+ _PersonID,"Not Found Person",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();

                return;
            }

            LbPersonID.Text = _PersonID.ToString();
            TxtNational.Text = _clsPerson.NationalNo;
            TxtFName.Text = _clsPerson.FirstName;
            TxtSName.Text = _clsPerson.SecondName;
            TxtThName.Text = _clsPerson.ThirdName;
            TxtLName.Text = _clsPerson.LastName;
            TxtDateTime.Value = _clsPerson.DateOfBirth;

            if (_clsPerson.Gendor == (int)enGender.Male)
                RbtnMale.Checked = true;
            else
                RbtnFemale.Checked = true;

            TxtEmail.Text = _clsPerson.Email;
            TxtPhone.Text = _clsPerson.Phone;
            TxtBoxAddress.Text = _clsPerson.Address;

            CmbCountry.SelectedIndex = CmbCountry.FindString(_clsPerson.CountryInfo.CountryName);


            //load person image incase it was set.
            if (_clsPerson.ImagePath != null && _clsPerson.ImagePath != "")
                PicImage.ImageLocation = _clsPerson.ImagePath;
            else
                PicImage.Image = (RbtnMale.Checked) ? Resources.Man715 : Resources.Woman715;


            //hide/show the remove linke incase there is no image for the person.
            LinkImageRemove.Visible = (_clsPerson.ImagePath != "");

        }
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _SetupTheDefaultForm();

            if (_Mode == enMode.eUpdate)
                _LoadDataToForm();

        }
        private bool _HandlePersonImage()
        {

            if (_clsPerson.ImagePath != PicImage.ImageLocation)  //Change Image
            {
                if (_clsPerson.ImagePath != "") // delete the old image from the folder
                {

                    try
                    {
                        File.Delete(_clsPerson.ImagePath); // file explorer
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }

                }

                if (PicImage.ImageLocation != null) // if there New Image Selected
                {
                    
                    string SourceImageFile = PicImage.ImageLocation.ToString(); // real SourceImage 

                    if (ClsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        PicImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }

            }

            return true;

        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

            if(!this.ValidateChildren())
            {
                MessageBox.Show("There are other required fields","Not Saved",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);

                return;
            }

            if (!_HandlePersonImage())
                return;

            _clsPerson.FirstName = TxtFName.Text.Trim();
            _clsPerson.SecondName = TxtSName.Text.Trim();
            _clsPerson.ThirdName = TxtThName.Text.Trim();
            _clsPerson.LastName = TxtLName.Text.Trim();
            _clsPerson.NationalNo = TxtNational.Text.Trim();

            if (RbtnMale.Checked)
                _clsPerson.Gendor = (short)enGender.Male;
            else
                _clsPerson.Gendor = (short)enGender.Female;

            _clsPerson.Email = TxtEmail.Text.Trim();
            _clsPerson.Address = TxtBoxAddress.Text.Trim();
            _clsPerson.DateOfBirth = TxtDateTime.Value;
            _clsPerson.Phone = TxtPhone.Text.Trim();
            _clsPerson.NationalityCountryID = ClsCountries.Find(CmbCountry.Text).ID;

            if (PicImage.ImageLocation != null)
                _clsPerson.ImagePath = PicImage.ImageLocation;
            else
                _clsPerson.ImagePath = "";

            if(_clsPerson.Save())
            {
                LbPersonID.Text = _clsPerson.PersonID.ToString();
               
                LbMode.Text = "Update Person";
                this.Text = "Update Person";
                _Mode = enMode.eUpdate;

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _clsPerson.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void LinkLableImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                PicImage.Load(selectedFilePath);
                LinkImageRemove.Visible = true;
            }

        }
        private void LinkImageRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            PicImage.ImageLocation = null;

            if (RbtnMale.Checked)
                PicImage.Image = Resources.Man715;
            else
                PicImage.Image = Resources.Woman715;

            LinkImageRemove.Visible = false;

        }
        private void RbtnMale_Click(object sender, EventArgs e)
        {

            if(PicImage.ImageLocation == null)
                PicImage.Image = Resources.Man715;
        }
        private void RbtnFemale_Click(object sender, EventArgs e)
        {

            if (PicImage.ImageLocation == null)
                PicImage.Image = Resources.Woman715;
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void CanWriteOnlyText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
            
        }
        private void CanWriteOnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }
        private void TxtEmail_Validating(object sender, CancelEventArgs e)
        {

            if (TxtEmail.Text.Trim() == "")
            {
                errorProvider1.SetError(TxtEmail, null);

                return;
            }

            //validate email format
            if (!ClsValidation.ValidateEmail(TxtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtEmail, "Enter a Correct Email!");
            }
            else
            {
                errorProvider1.SetError(TxtEmail, null);
            }

        }
        private void TxtNational_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtNational.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtNational, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(TxtNational, null);
            }

            //Make sure the national number is not used by another person
            if (TxtNational.Text.Trim() != _clsPerson.NationalNo && ClsPerson.isPersonExist(TxtNational.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtNational, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(TxtNational, null);
            }

        }
        private void TxtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPhone.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtPhone, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(TxtPhone, null);
            }

            if(TxtPhone.Text.Length != 10)
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtPhone, "You must enter the correct number!");
                return;
            }
            else
            {
                errorProvider1.SetError(TxtPhone, null);
            }

        }
        private void frmAddEditPerson_Activated(object sender, EventArgs e)
        {
            TxtFName.Focus();

        }
    
    }
}
