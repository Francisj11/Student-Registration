using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentReg
{
    public class Programme
    {
        public string ProgName;
        public string SubjectName;
        public string School;
        public string ModuleName;
        public string ModuleCode;

        public Programme(string ProgName, string SubjectName, string School, string ModuleName, string ModuleCode)

        {
            this.ProgName = ProgName;
            this.SubjectName = SubjectName;
            this.School = School;
            this.ModuleName = ModuleName;
            this.ModuleCode = ModuleCode;

        }

        public override string ToString()
        {
            return base.ToString() + "\nProgramme Name: " + ProgName.ToString() + "\nSubject Name: " + SubjectName.ToString() + "\nSchool: " + School.ToString() + "\nModule Name "
                + ModuleName.ToString() + "\nModule Code: " + ModuleCode.ToString() ;

        }

    }
}

