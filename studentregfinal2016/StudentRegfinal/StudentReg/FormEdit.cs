using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace StudentReg
{
    public partial class FormEdit : Form
    {
        public string lookupId { get; set; }
        public FormEdit()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            try
            {

                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\myFolder\myAccessFile.accdb;
Jet OLEDB:Database Password=MyDbPassword; Data Source=C:\Users\franc_000\Documents\College\StudentRegfinal\StudentReg\studentregdb.accdb; Persist Security Info = false; ";
                connection.Open();

                String fnstring = txtbox_firstName.Text;
                String lnstring = txtbox_lastName.Text;
                String emailstring = txtbox_Email.Text;
                String addressstring = txtbox_Address.Text;
                String subjectstring = txtbox_Subject.Text;
                String caostring = txtbox_Cao.Text;
                String degreestring = txtbox_degreeGrade.Text;

                var cmd = new OleDbCommand("UPDATE Student Set Firstname = @b, Lastname = @c, Email = @d, Address = @e, Subject = @f, intCAOdata = @g, doubleDegreegrade = @h WHERE Id = @i");
                cmd.Connection = connection;
                cmd.Parameters.AddRange(new[] {
                    new OleDbParameter("@b", fnstring),
                    new OleDbParameter("@c", lnstring),
                    new OleDbParameter("@d", emailstring),
                    new OleDbParameter("@e", addressstring),
                    new OleDbParameter("@f", subjectstring),
                    new OleDbParameter("@g", caostring),
                    new OleDbParameter("@h", degreestring),
                    new OleDbParameter("@i", lookupId)
                });
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student edited successfully.");
                this.Hide();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex);
            }
            connection.Close();
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
