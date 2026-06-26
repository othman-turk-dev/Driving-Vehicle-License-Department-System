using System;
using System.Data;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.General_Tools;

namespace DVLD_Project.Application.ApplicationType
{
    public partial class frmShowApplicationType : Form
    {

        private DataTable _DataTableAllApplicationTypes;
        public frmShowApplicationType()
        {
            InitializeComponent();
        }
        private void frmShowApplicationType_Load(object sender, EventArgs e)
        {
            ClsSetColore.ColoreForDataGritView(DataGVApplicationTypes, CMStripForApplicationTypes);

            _DataTableAllApplicationTypes = ClsApplicationtypes.GetAllApplicationTypes();
            DataGVApplicationTypes.DataSource = _DataTableAllApplicationTypes;
            lblRecordsCount.Text = DataGVApplicationTypes.Rows.Count.ToString();

            if (DataGVApplicationTypes.Rows.Count > 0)
            {

                DataGVApplicationTypes.Columns[0].HeaderText = "ID";
                DataGVApplicationTypes.Columns[0].Width = 110;

                DataGVApplicationTypes.Columns[1].HeaderText = "Title";
                DataGVApplicationTypes.Columns[1].Width = 400;

                DataGVApplicationTypes.Columns[2].HeaderText = "Fees";
                DataGVApplicationTypes.Columns[2].Width = 100;
            }

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblRecordsCount_Click(object sender, EventArgs e)
        {

        }
    }
}
