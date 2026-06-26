using System;
using System.Windows.Forms;

namespace DVLD_Project.User
{
    public partial class frmUserInfo : Form
    {
        private int _UserID;
        public frmUserInfo(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }
        private void frmUserInfo_Load(object sender, EventArgs e)
        {

            ctrUserCard1.LoadUserData(_UserID);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

    }
}
