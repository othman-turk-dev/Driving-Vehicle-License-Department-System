using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.General_Tools;

namespace DVLD_Project.Tests
{
    public partial class frmTakeTest : Form
    {

        private int _AppointmentID;
        private ClsTestType.enTestType _TestType;

        private int _TestID = -1;
        private ClsTest _Test;
        public frmTakeTest(int AppointmentID, ClsTestType.enTestType TestType)
        {
            InitializeComponent();

            _AppointmentID = AppointmentID;
            _TestType = TestType;
        }
        private void frmTakeTest_Load(object sender, EventArgs e)
        {

            ctrScheduledTest1.TestTypeID = _TestType;

            ctrScheduledTest1.LoadInfo(_AppointmentID);

            if (ctrScheduledTest1.TestAppointmentID == -1)
                BtnSave.Enabled = false;
            else
                BtnSave.Enabled = true;


            int _TestID = ctrScheduledTest1.TestID;
            if (_TestID != -1)
            {
                _Test = ClsTest.FindByTestID(_TestID);

                if (_Test.TestResult)
                    RbPass.Checked = true;
                else
                    RbFail.Checked = true;

                TxtNotes.Text = _Test.Notes;

                LbErorreMessage.Visible = true;
                RbFail.Enabled = false;
                RbPass.Enabled = false;

            }

            else
                _Test = new ClsTest();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            _Test.TestAppointmentID = _AppointmentID;
            _Test.TestResult = RbPass.Checked;
            _Test.Notes = TxtNotes.Text.Trim();
            _Test.CreatedByUserID = ClsGlobal.GlobalUser.UserID;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ctrScheduledTest1.LoadInfo(_Test.TestAppointmentID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            BtnSave.Enabled = false;
            RbPass.Enabled = false;
            RbFail.Enabled = false;

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

    }
}
