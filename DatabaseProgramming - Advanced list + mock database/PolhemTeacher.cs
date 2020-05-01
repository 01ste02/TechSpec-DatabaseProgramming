using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    public class PolhemTeacher
    {
        private string name;
        private string code;
        private string email;
        private string phone;

        public PolhemTeacher (string name, string code, string email, string phone)
        {
            TeacherName = name;
            TeacherCode = code;
            TeacherEmail = email;
            TeacherPhone = phone;
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

        public string TeacherPhone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }
    }
}
