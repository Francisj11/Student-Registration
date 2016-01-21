using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentReg
{
    public class Program
    {
        public static void Main()
        {
            Application.Run(new Form1());

            DateTime dat = DateTime.Now;
            Console.WriteLine("\n{0:d} at {0:T}.", dat);
            
            String line;
            int number = 0;
            line = Console.ReadLine();
            var menu = new menu();
            menu.DisplayMenu();
            Boolean register = true;
            List<Student> listStudent = new List<Student>();
            var Databasemethods = new Databasemethods();

            while (register)
            {

                line = Console.ReadLine();
                int.TryParse(line, out number);
                if (number == 1)
                {
                    Databasemethods.Register();                 
                }
                
                if (number == 2)
                {
                    Databasemethods.ListStudents();
                }
                if (number == 3)
                {
                    Databasemethods.EditStudents();
                }
                if (number == 4)
                {
                    Databasemethods.RemoveStudent();
                }
                if (number == 5)
                {
                    Databasemethods.Terminate();
                }
            }
        }
    }
}


