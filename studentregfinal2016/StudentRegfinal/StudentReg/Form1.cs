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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            FormRegister f2 = new FormRegister();
            f2.ShowDialog();
        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            FormList f3 = new FormList();
            f3.ShowDialog();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            FormEditLookup f4 = new FormEditLookup();
            f4.ShowDialog();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            FormRemove f6 = new FormRemove();
            f6.ShowDialog();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
