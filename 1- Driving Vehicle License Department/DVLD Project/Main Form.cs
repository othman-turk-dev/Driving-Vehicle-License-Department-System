using System;
using System.Drawing;
using DVLD_Project.User;
using DVLD_Project.Login;
using DVLD_Project.People;
using DVLD_Project.Drivers;
using System.Windows.Forms;
using DVLD_Project.General_Tools;
using DVLD_Project.Tests.Test_Types;
using DVLD_Project.Licenses.Detain_License;
using DVLD_Project.Appliications.AppliicationType;
using DVLD_Project.Appliications.Renew_Local_License;
using DVLD_Project.Appliications.International_License;
using DVLD_Project.Appliications.Local_Driving_License;
using DVLD_Project.Appliications.Release_Detained_License;
using DVLD_Project.Appliications.Replace_Lost_or_Damaged_License;
using DVLD_Project.All_Operations_in_System;

namespace DVLD_Project
{
    public partial class FrmMain : Form
    {
        //Fore Design
        public class DarkColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(80, 80, 80);
            public override Color MenuItemBorder => Color.FromArgb(100, 100, 100);
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(80, 80, 80);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(80, 80, 80);
            public override Color ToolStripDropDownBackground => Color.FromArgb(64, 64, 64);
            public override Color ImageMarginGradientBegin => Color.FromArgb(64, 64, 64);
            public override Color ImageMarginGradientMiddle => Color.FromArgb(64, 64, 64);
            public override Color ImageMarginGradientEnd => Color.FromArgb(64, 64, 64);
            public override Color SeparatorDark => Color.Gray;
            public override Color SeparatorLight => Color.DarkGray;
        
        }
        public class DarkMenuRenderer : ToolStripProfessionalRenderer
        {
            public DarkMenuRenderer() : base(new DarkColorTable()) { }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.Selected || e.Item.Pressed)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, 80, 80)), new Rectangle(Point.Empty, e.Item.Size));
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextColor = Color.White;
                base.OnRenderItemText(e);
            }

        }

        frmLogin _frmLogin;
        public FrmMain(frmLogin frm)
        {
            InitializeComponent();

            _frmLogin = frm;
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {

            MainMenu.Renderer = new DarkMenuRenderer(); //Desgin
        }
        private void signOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClsGlobal.GlobalUser = null;
            _frmLogin.Show();

            this.Close();
        }
        private void currentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmUserInfo(ClsGlobal.GlobalUser.UserID);
            form.ShowDialog();

        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmChangePassword(ClsGlobal.GlobalUser.UserID);
            form.ShowDialog();

        }
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmListUsers();
            form.ShowDialog();

        }
        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmListDrivers();
            form.ShowDialog();

        }
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form form = new frmListPeople();
            form.ShowDialog();
        }
        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdateLocalDrivingLicenseApp();
            form.ShowDialog();

        }
        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmIssueInternationalLicenseApp();
            form.ShowDialog();

        }
        private void renewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form form = new frmRenewLocalDrivingLicenseApp();
            form.ShowDialog();
        }
        private void replaceForDamagedOrLostLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form form = new frmReplaceLostorDamagedLicenseApp();
            form.ShowDialog();
        }
        private void relaeseDateinedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmReleaseDetainedLicenseApp();
            form.ShowDialog();
        }
        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form form = new frmListLocalDrivingLicenseApp();
            form.ShowDialog();
        }
        private void localDrivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmListLocalDrivingLicenseApp();
            form.ShowDialog();

        }
        private void internationalDrivingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form form = new frmListInternationalLicenseApp();
            form.ShowDialog();
        }
        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form form = new frmListDetainLicense();
            form.ShowDialog();
        }
        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form form = new frmDetainLicenseApplication();
            form.ShowDialog();
        }
        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form form = new frmReleaseDetainedLicenseApp();
            form.ShowDialog();
        }
        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmShowApplicationType();
            form.ShowDialog();

        }
        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmShowTestTypes();
            form.ShowDialog();

        }
        private void allRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAllRequests();
            form.ShowDialog();

        }
        private void allTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAllTests();
            form.ShowDialog();

        }

    }
}
