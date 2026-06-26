using System;
using System.Data;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.General_Tools;

namespace DVLD_Project.Tests.Test_Types
{
    public partial class frmShowTestTypes : Form
    {
        public frmShowTestTypes()
        {
            InitializeComponent();
        }

        private DataTable _DataTableAllTestTypes;
        private void frmShowTestTypes_Load(object sender, EventArgs e)
        {
            ClsSettingColore.ColoreForDataGritView(DataGVForTestTypes, CMStripForTestType);

            _DataTableAllTestTypes = ClsTestType.GetAllTestTypes();
            DataGVForTestTypes.DataSource = _DataTableAllTestTypes;

            LbRecordCount.Text = DataGVForTestTypes.Rows.Count.ToString();

            if (DataGVForTestTypes.Rows.Count > 0)
            {
                DataGVForTestTypes.Columns[0].HeaderText = "ID";
                DataGVForTestTypes.Columns[0].Width = 120;

                DataGVForTestTypes.Columns[1].HeaderText = "Title";
                DataGVForTestTypes.Columns[1].Width = 200;

                DataGVForTestTypes.Columns[2].HeaderText = "Description";
                DataGVForTestTypes.Columns[2].Width = 400;

                DataGVForTestTypes.Columns[3].HeaderText = "Fees";
                DataGVForTestTypes.Columns[3].Width = 100;
            }

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmEditTestTypes((ClsTestType.enTestType)DataGVForTestTypes.CurrentRow.Cells[0].Value);
            form.ShowDialog();

            frmShowTestTypes_Load(null, null);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
