using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentReg
{
    public class UnderGrad : Student
    {
        public string CAO;

        public UnderGrad(string Id, string FirstName, string LastName, string Email, string Address, string Subject ,string CAO)
            : base(Id, FirstName, LastName, Email, Address, Subject)
        {
            this.CAO = CAO;
        }

        public override string ToString()

        {

            return "\nStudent Id: " + Id.ToString() + "\nCourse level: Undergraduate " + "\nFirst Name: " + FirstName.ToString() + "\nLast Name: " + LastName.ToString() + "\nEmail: "
                + Email.ToString() + "\nAddress: " + Address.ToString() + "\nSubject: " + Subject.ToString() + "\nCAO POINTS: " + CAO.ToString();
        }
    }
}

