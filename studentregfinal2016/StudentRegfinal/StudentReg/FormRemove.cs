using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentReg
{
    public partial class FormRemove : Form
    {
        public FormRemove()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\myFolder\myAccessFile.accdb;
Jet OLEDB:Database Password=MyDbPassword; Data Source=C:\Users\franc_000\Documents\College\StudentRegfinal\StudentReg\studentregdb.accdb; Persist Security Info = false; ";
            string lookupId = txtbox_removeId.Text;
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Student where Id='" + txtbox_removeId.Text + "'";
            string removeId = txtbox_removeId.Text;
            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                try
                {
                    var cmd = new OleDbCommand("Delete * From Student WHERE Id = @i");
                    cmd.Connection = connection;
                    cmd.Parameters.AddRange(new[] {
                        new OleDbParameter("@i", removeId) });
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student deleted successfully.");
                    this.Hide();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error " + ex);
                }
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