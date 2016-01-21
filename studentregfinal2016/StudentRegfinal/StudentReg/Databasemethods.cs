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
        int intCAOdata = 0;
        double doubleDegreeGrade = 0.0;
        List<Student> listStudent = new List<Student>();

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
                int.TryParse(line, out intCAOdata);
                UnderGrad ungrad = new UnderGrad(Id, FirstName, LastName, Email, Address, Subject, intCAOdata);
                listStudent.Add(ungrad);
                menu.DisplayMenu();
                var DbConnector = new DbConnect();
                DbConnector.connect();


            }
            else
            {
                Console.WriteLine("Enter Degree Grade: ");
                DegreeGrade = Console.ReadLine();
                Double.TryParse(line, out doubleDegreeGrade);
                PostGrad postgrad = new PostGrad(Id, FirstName, LastName, Email, Address, Subject, doubleDegreeGrade);
                listStudent.Add(postgrad);
                menu.DisplayMenu();
                var DbConnector = new DbConnect();
                DbConnector.connect();
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
                    Console.WriteLine("Requested ID has been found.");
                    Console.WriteLine("\nEnter student's Id: ");
                    Id = Console.ReadLine();
                    Console.WriteLine("\nEnter student's First Name: ");
                    listStudent[i].FirstName = Console.ReadLine();
                    Console.WriteLine("\nEnter student's Last Name: ");
                    listStudent[i].LastName = Console.ReadLine();
                    Console.WriteLine("\nEnter student's Email: ");
                    listStudent[i].Email = Console.ReadLine();
                    Console.WriteLine("\nEnter student's Address: ");
                    listStudent[i].Address = Console.ReadLine();
                    Console.WriteLine("\nEnter student's Subject: ");
                    listStudent[i].Subject = Console.ReadLine();
                    Console.WriteLine("\nEnter student's type (u/p): ");
                    StudentType = Console.ReadLine();
                    if (StudentType.Equals("u", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Enter CAO points: ");
                        CAO = Console.ReadLine();
                        int.TryParse(line, out intCAOdata);
                        UnderGrad ungrad = new UnderGrad(listStudent[i].Id, listStudent[i].FirstName, listStudent[i].LastName, listStudent[i].Email, listStudent[i].Address, listStudent[i].Subject, intCAOdata);
                        listStudent[i] = ungrad;
                        menu.DisplayMenu();
                    }
                    else
                    {
                        Console.WriteLine("Enter Degree Grade: ");
                        DegreeGrade = Console.ReadLine();
                        Double.TryParse(line, out doubleDegreeGrade);
                        PostGrad postgrad = new PostGrad(listStudent[i].Id, listStudent[i].FirstName, listStudent[i].LastName, listStudent[i].Email, listStudent[i].Address, listStudent[i].Subject, doubleDegreeGrade);
                        listStudent[i] = postgrad;
                        menu.DisplayMenu();
                    }
                }
            }
            return 0;
        }
        public int RemoveStudent()
        {
            Console.WriteLine("\nEnter Id of Student to be Removed: ");
            Id = Console.ReadLine();
            for (int i = 0; i < listStudent.Count(); i++)
            {
                if (Id == listStudent[i].Id)
                {
                    Console.WriteLine("Student with ID: " + listStudent[i].Id + " has been removed from registered students!");
                    listStudent.Remove(listStudent[i]);
                    break;
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



//Id, FirstName, LastName, Email, Address, Subject, intCAOdata, doubleDegreegrade


namespace StudentReg
{
    public class DbConnect
    {
        public int connect()
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
                    new OleDbParameter("@a", "Id"),
                    new OleDbParameter("@b", "FirstName"),
                    new OleDbParameter("@c", "LastName"),
                    new OleDbParameter("@d", "Email"),
                    new OleDbParameter("@e", "Address"),
                    new OleDbParameter("@f", "Subject"),
                    new OleDbParameter("@g", "intCAOdata"),
                    new OleDbParameter("@h", "doubleDegreegrade")
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

    }
}

    