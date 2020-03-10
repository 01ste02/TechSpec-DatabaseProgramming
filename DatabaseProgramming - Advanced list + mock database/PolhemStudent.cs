using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    class PolhemStudent
    {
        private string name;
        private string class_;
        private string email;

        public PolhemStudent (string name, string class_, string email)
        {
            StudentName = name;
            StudentClass = class_;
            StudentEmail = email;
        }

        public string StudentName
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

        public string StudentClass
        {
            get
            {
                return class_;
            }
            set
            {
                class_ = value;
            }
        }

        public string StudentEmail
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
