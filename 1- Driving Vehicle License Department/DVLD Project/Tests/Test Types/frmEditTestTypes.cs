using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using System.ComponentModel;
using DVLD_Project.General_Tools;

namespace DVLD_Project.Tests.Test_Types
{
    public partial class frmEditTestTypes : Form
    {
        private ClsTestType.enTestType _TestTypeID = ClsTestType.enTestType.VisionTest;
        private ClsTestType _TestType;
        public frmEditTestTypes(ClsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
        }
        private void frmEditTestTypes_Load(object sender, EventArgs e)
        {
            LbID.Text = _TestTypeID.ToString();

            _TestType = ClsTestType.Find(_TestTypeID);

            if (_TestType != null)
            {
                TxtTitle.Text = _TestType.TestTypeTitle;
                TxtDescription.Text = _TestType.TestTypeDescription;
                TxtFees.Text = _TestType.TestTypeFees.ToString();

            }

        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("There are other required fields", "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _TestType.TestTypeTitle = TxtTitle.Text.Trim();
            _TestType.TestTypeDescription = TxtDescription.Text.Trim();
            _TestType.TestTypeFees = Convert.ToDecimal(TxtFees.Text.Trim());


            if (_TestType.UpdateTestType())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void TxtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtDescription, "Description cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(TxtDescription, null);
            }

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
