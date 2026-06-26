using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;

namespace DVLD_Project.User.Control
{
    public partial class ctrUserCard : UserControl
    {
        public ctrUserCard()
        {
            InitializeComponent();

        }

        ClsUser _User;
        private int _UserID = -1;
        public int UserID
        {
            get { return _UserID; }
        }
        private void _FillUserInfo()
        {
            ctrPersonCard1.LoadDataForPerson(_User.PersonID);
            LbLbUserID.Text = _User.UserID.ToString();
            LbUserName.Text = _User.UserName;

            LbIsActve.Text = (_User.IsActive) ? "Yes" : "No";

        }
        private void _ResetUserInfo()
        {
            ctrPersonCard1.ResetDafaultData();

            LbLbUserID.Text = "[???]";
            LbUserName.Text = "[???]";
            LbIsActve.Text = "[???]";

        }
        public void LoadUserData(int UserID)
        {

            _User = ClsUser.FindByUserID(UserID);

            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _UserID = UserID;
            _FillUserInfo();

        }

    }
}
