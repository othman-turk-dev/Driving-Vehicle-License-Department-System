using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_Project.General_Tools
{
    public class MyRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {

            using (SolidBrush b = new SolidBrush(Color.FromArgb(65, 65, 65)))
            {
                e.Graphics.FillRectangle(b, e.AffectedBounds);
            }
        }

    } //For Design

    static class ClsSetColore
    {
        public static void ColoreForDataGritView(DataGridView dataGridView, ContextMenuStrip contextMenu)
        {
            dataGridView.DefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(75, 75, 75);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            dataGridView.DefaultCellStyle.Font = new Font("Cambria", 10);
            dataGridView.RowHeadersWidth = 24;
            contextMenu.Renderer = new MyRenderer();

        } //For Design

    }
}
