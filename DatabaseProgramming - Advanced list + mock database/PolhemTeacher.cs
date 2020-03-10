using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    class PolhemTeacher
    {
        private string name;
        private string code;
        private string email;

        public PolhemTeacher (string name, string code, string email)
        {
            TeacherName = name;
            TeacherCode = code;
            TeacherEmail = email;
        }

        public string TeacherName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string TeacherCode
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }

        public string TeacherEmail
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
    }
}
