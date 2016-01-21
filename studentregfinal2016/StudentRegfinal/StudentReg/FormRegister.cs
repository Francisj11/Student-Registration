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
using System.Data.SqlClient;

namespace StudentReg
{
    public partial class FormRegister : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public FormRegister()
        {
            InitializeComponent();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }

        private void btn_regsave_Click(object sender, EventArgs e)
        {
            try
            {
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\myFolder\myAccessFile.accdb;
Jet OLEDB:Database Password=MyDbPassword; Data Source=C:\Users\franc_000\Documents\College\StudentRegfinal\StudentReg\studentregdb.accdb; Persist Security Info = false; ";
                connection.Open();
                String idstring = txtbox_Id.Text;
                String fnstring = txtbox_firstName.Text;
                String lnstring = txtbox_lastName.Text;
                String emailstring = txtbox_Email.Text;
                String addressstring = txtbox_Address.Text;
                String subjectstring = txtbox_Subject.Text;
                String caostring = txtbox_Cao.Text;
                String degreestring = txtbox_degreeGrade.Text;

                var cmd = new OleDbCommand("INSERT INTO Student ([Id],[Firstname], [Lastname] ,[Email] , [Address], [Subject], [intCAOdata], [doubleDegreegrade]) VALUES (@a, @b, @c, @d, @e, @f, @g, @h)");
                cmd.Connection = connection;
                cmd.Parameters.AddRange(new[] {
                    new OleDbParameter("@a", idstring),
                    new OleDbParameter("@b", fnstring),
                    new OleDbParameter("@c", lnstring),
                    new OleDbParameter("@d", emailstring),
                    new OleDbParameter("@e", addressstring),
                    new OleDbParameter("@f", subjectstring),
                    new OleDbParameter("@g", caostring),
                    new OleDbParameter("@h", degreestring)
                });
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student registered successfully.");
                this.Hide();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex);
            }
            connection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
