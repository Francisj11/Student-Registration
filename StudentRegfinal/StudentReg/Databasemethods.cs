using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace StudentReg
{
    public class Databasemethods
    {
        String line, FirstName, LastName, StudentType, Address, Id, Email, Subject, CAO, DegreeGrade;
        int numberedit, intCAOdata = 0;
        double doubleDegreeGrade = 0.0;
        List<Student> listStudent = new List<Student>();
        string idremove;
        public int Register()
        {
            Console.WriteLine("\nEnter student's Id: ");
            Id = Console.ReadLine();
            Console.WriteLine("\nEnter student's First Name: ");
            FirstName = Console.ReadLine();
            Console.WriteLine("\nEnter student's Last Name: ");
            LastName = Console.ReadLine();
            Console.WriteLine("\nEnter student's Email: ");
            Email = Console.ReadLine();
            Console.WriteLine("\nEnter student's Address: ");
            Address = Console.ReadLine();
            Console.WriteLine("\nEnter student's Subject: ");
            Subject = Console.ReadLine();
            Console.WriteLine("\nEnter student's type (u/p): ");
            StudentType = Console.ReadLine();
            if (StudentType.Equals("u", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Enter CAO points: ");
                CAO = Console.ReadLine();
                
                UnderGrad ungrad = new UnderGrad(Id, FirstName, LastName, Email, Address, Subject, CAO);  //intCAOdata=CAO
                listStudent.Add(ungrad);
                var DbConnector = new DbConnect();
                DbConnector.connectRegUG(ungrad);
                menu.DisplayMenu();


            }
            else
            {
                Console.WriteLine("Enter Degree Grade: ");
                DegreeGrade = Console.ReadLine();
                
                PostGrad postgrad = new PostGrad(Id, FirstName, LastName, Email, Address, Subject, DegreeGrade);
                listStudent.Add(postgrad);
                var DbConnector = new DbConnect();
                DbConnector.connectRegPG(postgrad);
                menu.DisplayMenu();
            }

            return 0;

        }

        public int ListStudents()
        {
            Console.WriteLine("\n_________________________________________________\n_________________________________________________");
            Console.WriteLine("List of all the registered Students\n");
            foreach (Student i in listStudent)
            {
                Console.Write(i.ToString());
                Console.WriteLine("\n_____________");
            }
            Console.WriteLine("\n_________________________________________________");
            menu.DisplayMenu();
            return 0;
        }
        public int EditStudents()
        {
            Console.WriteLine("\nEnter ID of Student to be edited: ");
            Id = Console.ReadLine();
            for (int i = 0; i < listStudent.Count(); i++)
            {
                if (Id == listStudent[i].Id)
                {
                    Student studentobj = listStudent[i];
                    Console.WriteLine("Requested ID has been found.");
                    bool editor = true;
                    menu.DisplayEditMenu();
                    Console.WriteLine(studentobj.FirstName);


                    while (editor)
                    {
                        line = Console.ReadLine();
                        int.TryParse(line, out numberedit);
                        
                        if (numberedit == 1)
                        {
                            Console.WriteLine("\nEnter student's First Name: ");
                            listStudent[i].FirstName = Console.ReadLine();
                            Console.WriteLine(studentobj.FirstName);

                            var DbConnector = new DbConnect();
                            DbConnector.connectEdit(studentobj, "FirstName", studentobj.FirstName);
                            Console.WriteLine(studentobj.FirstName);
                            menu.DisplayEditMenu();
                        }
                        if (numberedit == 2)
                        {
                            Console.WriteLine("\nEnter student's Last Name: ");
                            listStudent[i].LastName = Console.ReadLine();
                            var DbConnector = new DbConnect();

                            DbConnector.connectEdit(studentobj, "LastName", studentobj.LastName);
                            menu.DisplayEditMenu();
                        }
                        if (numberedit == 3)
                        {
                            Console.WriteLine("\nEnter student's Email: ");
                            listStudent[i].Email = Console.ReadLine();
                            var DbConnector = new DbConnect();
                            DbConnector.connectEdit(studentobj, "[Email]", studentobj.Email);
                            menu.DisplayEditMenu();
                        }
                        if (numberedit == 4)
                        {

                            Console.WriteLine("\nEnter student's Address: ");
                            listStudent[i].Address = Console.ReadLine();
                            var DbConnector = new DbConnect();
                            DbConnector.connectEdit(studentobj, "[Address]", studentobj.Address);
                            menu.DisplayEditMenu();
                        }
                        if (numberedit == 5)
                        {
                            Console.WriteLine("\nEnter student's Subject: ");
                            listStudent[i].Subject = Console.ReadLine();
                            var DbConnector = new DbConnect();
                            DbConnector.connectEdit(studentobj, "[Subject]", studentobj.Subject);
                            menu.DisplayEditMenu();
                        }
                        if (numberedit == 6)
                        {
                            
                            menu.DisplayMenu();
                            break;
                        }

                    }
                }
                else
                {
                    Console.WriteLine("\nId not found.");
                    EditStudents();
                }
            }
            return 0;
        }
        public int RemoveStudent()

        {
            Console.WriteLine("\nEnter Id of Student to be Removed: ");
            //string idremove = "a";
            Id = Console.ReadLine();
            for (int i = 0; i < listStudent.Count(); i++)
            {
                if (Id == listStudent[i].Id)
                {
                    Student studentobj = listStudent[i];
                    Console.WriteLine("Student with ID: " + Id + " has been removed from registered students!");
                    listStudent.Remove(listStudent[i]);
                    string idremove = Id;
                    var DbConnector = new DbConnect();
                    DbConnector.connectRemove(studentobj, studentobj.Id);
                    menu.DisplayMenu();
                }
            }
            return 0;
        }
        public int Terminate()
        {
            Environment.Exit(0);
            return 0;
        }
    }
}
namespace StudentReg
{
    public class DbConnect
    {
        public int connectRegUG(UnderGrad x)
        {
            
      OleDbConnection connection = new OleDbConnection();
            try
            {

                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\myFolder\myAccessFile.accdb;
Jet OLEDB:Database Password=MyDbPassword; Data Source=C:\Users\franc_000\Documents\College\StudentRegfinal\StudentReg\studentregdb.accdb; Persist Security Info = false; ";
                connection.Open();
                var cmd = new OleDbCommand("INSERT INTO Student ([Id],[Firstname], [Lastname] ,[Email] , [Address], [Subject], [intCAOdata], [doubleDegreegrade]) VALUES (@a, @b, @c, @d, @e, @f, @g, @h)");
                cmd.Connection = connection;
                
                
                cmd.Parameters.AddRange(new[] {

                    new OleDbParameter("@a", x.Id),
                    new OleDbParameter("@b", x.FirstName),
                    new OleDbParameter("@c", x.LastName),
                    new OleDbParameter("@d", x.Email),                                ////cant find reference to correct variables
                    new OleDbParameter("@e", x.Address),
                    new OleDbParameter("@f", x.Subject),
                    new OleDbParameter("@g", x.CAO),
                    new OleDbParameter("@h", "")
                    });
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student registered successfully.");
            }


            catch (Exception ex)
            {

                Console.WriteLine("Error " + ex);
            }
            connection.Close();
            return 0;
        }


        
        
            public int connectRegPG(PostGrad x)
            {
                
                OleDbConnection connection = new OleDbConnection();
                try
                {

                    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\myFolder\myAccessFile.accdb;
Jet OLEDB:Database Password=MyDbPassword; Data Source=C:\Users\franc_000\Documents\College\StudentRegfinal\StudentReg\studentregdb.accdb; Persist Security Info = false; ";
                    connection.Open();
                    var cmd = new OleDbCommand("INSERT INTO Student ([Id],[Firstname], [Lastname] ,[Email] , [Address], [Subject], [intCAOdata], [doubleDegreegrade]) VALUES (@a, @b, @c, @d, @e, @f, @g, @h)");
                    cmd.Connection = connection;
                    
                    cmd.Parameters.AddRange(new[] {

                    new OleDbParameter("@a", x.Id),
                    new OleDbParameter("@b", x.FirstName),
                    new OleDbParameter("@c", x.LastName),
                    new OleDbParameter("@d", x.Email),                                ////cant find reference to correct variables
                    new OleDbParameter("@e", x.Address),
                    new OleDbParameter("@f", x.Subject),
                    new OleDbParameter("@g", ""),
                    new OleDbParameter("@h", x.DegreeGrade)
                    });
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Student registered successfully.");
                }


                catch (Exception ex)
                {

                    Console.WriteLine("Error " + ex);
                }
                connection.Close();
                return 0;
            }




            public int connectRemove(Student x, string idremove)
        {
            
            OleDbConnection connection = new OleDbConnection();
            try
            {
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\myFolder\myAccessFile.accdb;
Jet OLEDB:Database Password=MyDbPassword; Data Source=C:\Users\franc_000\Documents\College\StudentRegfinal\StudentReg\studentregdb.accdb; Persist Security Info = false; ";
                
                var cmd = new OleDbCommand("DELETE FROM Student WHERE Id = @a;");           //need correct reference
                connection.Open();
                cmd.Parameters.AddRange(new[] {
                    new OleDbParameter("@a", x.Id)
                });
                cmd.Connection = connection;                
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student removed successfully.");
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error " + ex);

            }
            connection.Close();
            return 0;
        }
        public int connectEdit(Student x, string editchoice, string editdata) { 

            OleDbConnection connection = new OleDbConnection();
            try
            {
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\myFolder\myAccessFile.accdb;
Jet OLEDB:Database Password=MyDbPassword; Data Source=C:\Users\franc_000\Documents\College\StudentRegfinal\StudentReg\studentregdb.accdb; Persist Security Info = false; ";
                
                //var cmd = new OleDbCommand("UPDATE Student SET "+"@editchoice"+" = '"+"@entrydata"+"' WHERE "+"@a"+" = @searchdata;");           //need correct reference
                var cmd = new OleDbCommand("UPDATE Student SET FirstName = 'bananak' WHERE Id = '123456';");           //need correct reference

                connection.Open();
                cmd.Parameters.AddRange(new[] {
                new OleDbParameter("@entrytype", editchoice),
                    new OleDbParameter("@entrydata", x.Id),
                    new OleDbParameter("@a", "Id"),
                    new OleDbParameter("@searchdata", x.Id)
                });
                cmd.Connection = connection;
                Console.WriteLine(editchoice);
                Console.WriteLine(editdata);
                Console.WriteLine(x.Id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student edited successfully.");
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error " + ex);

            }
            connection.Close();
            return 0;
        }
    }
}
