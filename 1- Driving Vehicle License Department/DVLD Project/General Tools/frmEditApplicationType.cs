using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Application.ApplicationType
{
    public partial class frmEditApplicationType : Form
    {
        private int _ApplicationTypeID = -1;
        private ClsApplicationtypes _ApplicationType;
        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;

        }
        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            LbID.Text = _ApplicationTypeID.ToString();

            _ApplicationType = ClsApplicationtypes.Find(_ApplicationTypeID);
            
            if(_ApplicationType != null)
            {
                TxtTitle.Text = _ApplicationType.ApplicationTypeTitle;
                TxtFees.Text = _ApplicationType.ApplicationTypeFees.ToString();

            }

        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void TxtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

    }
}
