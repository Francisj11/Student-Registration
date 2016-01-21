using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentReg
{
    class menu
    {
        static public int DisplayMenu()
        {
            Console.WriteLine("\nUniversity Student Registration System.");
            Console.WriteLine();
            Console.WriteLine("1. Register a student.");
            Console.WriteLine("2. List the current registered students.");
            Console.WriteLine("3. Edit a student");
            Console.WriteLine("4. Remove a student.");
            Console.WriteLine("5. Exit");
            Console.WriteLine("\n_________________________________________________");           
            return 0; 
        }
    }
}
