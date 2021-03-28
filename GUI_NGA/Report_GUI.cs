using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_NGA
{
    public partial class Report_GUI : Form
    {
        public Report_GUI()
        {
            InitializeComponent();
        }

        private void Report_GUI_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLCHTCDataSet.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.QLCHTCDataSet.DataTable1);

            this.reportViewer1.RefreshReport();
        }
    }
}
