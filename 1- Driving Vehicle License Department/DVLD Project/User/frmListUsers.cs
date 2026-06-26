using System;
using System.Data;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.General_Tools;

namespace DVLD_Project.User
{
    public partial class frmListUsers : Form
    {

        private static DataTable _DataTableAllUsers;
        public frmListUsers()
        {
            InitializeComponent();

        }
        private void frmListUsers_Load(object sender, EventArgs e)
        {

            _DataTableAllUsers = ClsUser.GetAllUsers();
            DataGVUsers.DataSource = _DataTableAllUsers;

            CbFilterBy.SelectedIndex = 0;
            LbRecord.Text = DataGVUsers.Rows.Count.ToString();

            if (DataGVUsers.Rows.Count > 0)
            {

                DataGVUsers.Columns[0].HeaderText = "User ID";
                DataGVUsers.Columns[0].Width = 110;

                DataGVUsers.Columns[1].HeaderText = "Person ID";
                DataGVUsers.Columns[1].Width = 120;

                DataGVUsers.Columns[2].HeaderText = "Full Name";
                DataGVUsers.Columns[2].Width = 350;

                DataGVUsers.Columns[3].HeaderText = "UserName";
                DataGVUsers.Columns[3].Width = 120;

                DataGVUsers.Columns[4].HeaderText = "Is Active";
                DataGVUsers.Columns[4].Width = 120;
            }

        }
        private void _ResetFilter()
        {
            _DataTableAllUsers.DefaultView.RowFilter = string.Empty;
            LbRecord.Text = _DataTableAllUsers.Rows.Count.ToString();
        
        }
        private void CbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            _ResetFilter();

            if (CbFilterBy.Text == "Is Active")
            {
                TxtFilterValue.Visible = false;
                CbIsActive.Visible = true;
                CbIsActive.SelectedIndex = 0;

                CbIsActive.Focus();
            }
            else
            {

                TxtFilterValue.Visible = (CbFilterBy.Text != "None");
                CbIsActive.Visible = false;

                TxtFilterValue.Text = "";
                TxtFilterValue.Focus();
            }

        }
        private void TxtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (CbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (TxtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _DataTableAllUsers.DefaultView.RowFilter = "";
                LbRecord.Text = DataGVUsers.Rows.Count.ToString();
                
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                //in this case we deal with numbers not string.
                _DataTableAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, TxtFilterValue.Text.Trim());
            else
                _DataTableAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, TxtFilterValue.Text.Trim());

            LbRecord.Text = DataGVUsers.Rows.Count.ToString();

        }
        private void CbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "IsActive";
            string FilterValue = CbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _DataTableAllUsers.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _DataTableAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            LbRecord.Text = DataGVUsers.Rows.Count.ToString();

        }
        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdateUser();
            form.ShowDialog();

            frmListUsers_Load(null, null);
        }
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdateUser();
            form.ShowDialog();

            frmListUsers_Load(null, null);
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdateUser((int)DataGVUsers.CurrentRow.Cells[0].Value);
            form.ShowDialog();

            frmListUsers_Load(null, null);
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmUserInfo((int)DataGVUsers.CurrentRow.Cells[0].Value);
            form.ShowDialog();

            frmListUsers_Load(null, null);
        }
        private void DataGVUsers_DoubleClick(object sender, EventArgs e)
        {
            Form form = new frmUserInfo((int)DataGVUsers.CurrentRow.Cells[0].Value);
            form.ShowDialog();

            frmListUsers_Load(null, null);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int UserID = (int)DataGVUsers.CurrentRow.Cells[0].Value;
            if (ClsUser.DeleteUser(UserID))
            {
                MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmListUsers_Load(null, null);
            }

            else
                MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)DataGVUsers.CurrentRow.Cells[0].Value;
            frmChangePassword Frm1 = new frmChangePassword(UserID);
            
            Frm1.ShowDialog();
        }
        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private void phoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private void TxtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (CbFilterBy.Text == "Person ID" || CbFilterBy.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if(CbFilterBy.Text == "Full Name")
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        private void frmListUsers_Shown(object sender, EventArgs e)
        {
            ClsSettingColore.ColoreForDataGritView(DataGVUsers, CMStripForUser); //Fore Design

        }

    }
}
