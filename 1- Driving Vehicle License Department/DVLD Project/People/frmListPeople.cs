using System;
using System.IO;
using System.Data;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.General_Tools;

namespace DVLD_Project.People
{
    public partial class frmListPeople : Form
    {
        public frmListPeople()
        {
            InitializeComponent();
        }

        private static DataTable _DTAllPeople = ClsPerson.GetAllPeople();
        private DataTable _DTOnlySelect = _DTAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

        private void _RefreshPeopleList()
        {

            _DTAllPeople = ClsPerson.GetAllPeople();
            _DTOnlySelect = _DTAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            dgViewPeople.DataSource = _DTOnlySelect;
            lblRecordsCount.Text = dgViewPeople.Rows.Count.ToString();

        }
        private void frmListPeople_Load(object sender, EventArgs e)
        {

            dgViewPeople.DataSource = _DTOnlySelect;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgViewPeople.Rows.Count.ToString();

            if (dgViewPeople.Rows.Count > 0)
            {

                dgViewPeople.Columns[0].HeaderText = "Person ID";
                dgViewPeople.Columns[0].Width = 80;

                dgViewPeople.Columns[1].HeaderText = "National No.";
                dgViewPeople.Columns[1].Width = 110;


                dgViewPeople.Columns[2].HeaderText = "First Name";
                dgViewPeople.Columns[2].Width = 105;

                dgViewPeople.Columns[3].HeaderText = "Second Name";
                dgViewPeople.Columns[3].Width = 100;


                dgViewPeople.Columns[4].HeaderText = "Third Name";
                dgViewPeople.Columns[4].Width = 100;

                dgViewPeople.Columns[5].HeaderText = "Last Name";
                dgViewPeople.Columns[5].Width = 100;

                dgViewPeople.Columns[6].HeaderText = "Gendor";
                dgViewPeople.Columns[6].Width = 70;

                dgViewPeople.Columns[7].HeaderText = "Date Of Birth";
                dgViewPeople.Columns[7].Width = 100;

                dgViewPeople.Columns[8].HeaderText = "Nationality";
                dgViewPeople.Columns[8].Width = 90;


                dgViewPeople.Columns[9].HeaderText = "Phone";
                dgViewPeople.Columns[9].Width = 90;


                dgViewPeople.Columns[10].HeaderText = "Email";
                dgViewPeople.Columns[10].Width = 120;
            }

        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form form = new frmAddEditPerson();
            form.ShowDialog();

            _RefreshPeopleList();
        }
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAddEditPerson();
            form.ShowDialog();

            _RefreshPeopleList();
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmShowPersonInfo((int)dgViewPeople.CurrentRow.Cells[0].Value);
            form.ShowDialog();

            _RefreshPeopleList();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAddEditPerson((int)dgViewPeople.CurrentRow.Cells[0].Value);
            form.ShowDialog();

            _RefreshPeopleList();
        }
        private bool _IsImageDelete(int PersonID)
        {

            ClsPerson person = ClsPerson.Find(PersonID);

            if (person.ImagePath != "")
            {

                try
                {
                    File.Delete(person.ImagePath);
                }
                catch (IOException)
                {
                    // We could not delete the file.
                    //log it later   
                    return false;
                }

                return true;
            }
            else
                return true;

        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete Person [" + dgViewPeople.CurrentRow.Cells[0].Value + "]"
                , "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                int PersonID = (int)dgViewPeople.CurrentRow.Cells[0].Value;

                if (ClsPerson.isPersonExist(PersonID))
                {
                    if (_IsImageDelete(PersonID) && ClsPerson.DeletePerson(PersonID))
                    {
                        MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _RefreshPeopleList();
                    }
                    else
                        MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Person is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _DTOnlySelect.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgViewPeople.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
                _DTOnlySelect.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _DTOnlySelect.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgViewPeople.Rows.Count.ToString();

        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }
        private void dgViewPeople_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonInfo((int)dgViewPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "Phone")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            else if (cbFilterBy.Text == "First Name" || cbFilterBy.Text == "Second Name" ||
                cbFilterBy.Text == "Third Name" || cbFilterBy.Text == "Last Name" || cbFilterBy.Text == "Nationality")
                    e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ';

            else if (cbFilterBy.Text == "Gendor")
                e.Handled = e.KeyChar != 'm' && e.KeyChar != 'f' && e.KeyChar != (char)8;

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmListPeople_Shown(object sender, EventArgs e)
        {
            ClsSettingColore.ColoreForDataGritView(dgViewPeople, CMStripForPeole); //Fore Design

        }

    }
}
