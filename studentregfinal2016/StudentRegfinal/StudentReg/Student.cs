using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentReg
{
    public class Student
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string Address;
        public string Id;
        public string Subject;

        public Student(string Id, string FirstName, string LastName, string Email, string Address, string Subject)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Address = Address;
            this.Subject = Subject;
        }        
    }
}
