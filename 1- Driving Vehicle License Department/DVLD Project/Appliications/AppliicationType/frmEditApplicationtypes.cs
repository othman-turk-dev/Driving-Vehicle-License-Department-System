using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using System.ComponentModel;
using DVLD_Project.General_Tools;

namespace DVLD_Project.Appliications.AppliicationType
{
    public partial class frmEditApplicationtypes : Form
    {

        private int _ApplicationTypeID = -1;
        private ClsApplicationTypes _ApplicationType;
        public frmEditApplicationtypes(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;
        }
        private void frmEditApplicationtypes_Load(object sender, EventArgs e)
        {

            LbID.Text = _ApplicationTypeID.ToString();

            _ApplicationType = ClsApplicationTypes.Find(_ApplicationTypeID);

            if (_ApplicationType != null)
            {
                TxtTitle.Text = _ApplicationType.ApplicationTypeTitle;
                TxtFees.Text = _ApplicationType.ApplicationTypeFees.ToString();

            }

        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

            if(!this.ValidateChildren())
            {
                MessageBox.Show("There are other required fields", "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationType.ApplicationTypeTitle = TxtTitle.Text.Trim();
            _ApplicationType.ApplicationTypeFees = Convert.ToDecimal(TxtFees.Text.Trim());


            if (_ApplicationType.UpdateApplicationType())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void TxtTitle_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TxtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(TxtTitle, null);
            }

        }
        private void TxtFees_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TxtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtFees, "Fees cannot be empty!");

            }
            else if (!ClsValidation.IsNumber(TxtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtFees, "Invalid Number.");
            
            }
            else
            {
                errorProvider1.SetError(TxtFees, null);
            }

        }

    }
}
