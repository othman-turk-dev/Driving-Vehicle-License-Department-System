using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD_Project.Licenses.LocalLicenses.Controls
{
    public partial class ctrDriverLicenseInfoWithFilter : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {

            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                GbFilter.Enabled = _FilterEnabled;
            }

        }

        private int _LicenseID = -1;
        public int LicenseID
        {
            get { return ctrDriverLicenseInfo1.LicenseID; }
        }
        public ClsLicenses SelectedLicenseInfo
        {

            get { return ctrDriverLicenseInfo1.SelectedLicenseInfo; }
        }
        public ctrDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        public void LoadLicenseInfo(int LicenseID)
        {

            txtFilterValue.Text = LicenseID.ToString();
            _LicenseID = ctrDriverLicenseInfo1.LicenseID;

            ctrDriverLicenseInfo1.LoadData(LicenseID);

            if (OnLicenseSelected != null && FilterEnabled)
                OnLicenseSelected(ctrDriverLicenseInfo1.LicenseID);
        
        }
        private void btnFind_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFilterValue.Focus();

                return;
            }

            _LicenseID = Convert.ToInt32(txtFilterValue.Text);
            LoadLicenseInfo(_LicenseID);

        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

        }
        public void txtLicenseIDFocus()
        {

            txtFilterValue.Focus();
        }
        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }

        }
    
    }
}
