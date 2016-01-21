using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentReg
{
    public partial class FormList : Form
    {
        public FormList()
        {
            InitializeComponent();
        }

        private void FormList_Load(object sender, EventArgs e)
        {
            
            this.studentTableAdapter.Fill(this.studentregdbDataSet.Student);

        }

        private void btn_ExitList_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
