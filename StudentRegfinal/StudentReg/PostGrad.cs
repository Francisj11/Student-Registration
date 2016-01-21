using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentReg
{
    public class PostGrad : Student
    {

        public string DegreeGrade;

        public PostGrad(string Id, string FirstName, string LastName, string Email, string Address, string Subject, string DegreeGrade)
            : base(Id, FirstName, LastName, Email, Address, Subject)
        {
            this.DegreeGrade = DegreeGrade;
        }

        public override string ToString()
        {
            return "\nStudent Id: "+Id.ToString() + "\nCourse level: Postgraduate" + "\nFirst Name: " + FirstName.ToString() + "\nLast Name: " + LastName.ToString() + "\nEmail: "
                + Email.ToString() + "\nAddress: " + Address.ToString() + "\nSubject: " + Subject.ToString() + "\nDegree Grade: " + DegreeGrade.ToString() ;
        }
    }
}
