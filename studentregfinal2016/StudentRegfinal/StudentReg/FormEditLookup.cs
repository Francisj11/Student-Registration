using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace StudentReg
{
    public partial class FormEditLookup : Form
    {
        //private OleDbConnection connection = new OleDbConnection();
        public FormEditLookup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\myFolder\myAccessFile.accdb;
Jet OLEDB:Database Password=MyDbPassword; Data Source=C:\Users\franc_000\Documents\College\StudentRegfinal\StudentReg\studentregdb.accdb; Persist Security Info = false; ";
            string lookupId = txtbox_editId.Text;
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Student where Id='" + txtbox_editId.Text + "'";
            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                MessageBox.Show("Student Id found.");
                this.Hide();
                
                FormEdit f5 = new FormEdit();
                f5.lookupId = lookupId;
                f5.ShowDialog();

            }
            else if (count > 1)
            {
                MessageBox.Show("Duplicate Student Id.");
            }
            else
            {
                MessageBox.Show("Incorrect Student Id.");
            }


            connection.Close();
        }
    }
}
