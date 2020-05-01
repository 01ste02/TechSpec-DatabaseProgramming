using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    public class PolhemCourse
    {
        private string name;
        private string courseCode;
        private int coursePoints;
        private DateTime startDate;
        private DateTime endDate;
        public List<PolhemStudent> CourseStudents; //Kunde inte fundera ut hur man lade till setters och getters på en list
        public List<PolhemTeacher> CourseTeachers;

        public PolhemCourse (string name, string courseCode, int coursePoints, DateTime startDate, DateTime endDate, List<PolhemTeacher> teachers = null, List<PolhemStudent> students = null)
        {
            CourseName = name;
            CourseCode = courseCode;
            CoursePoints = coursePoints;
            CourseStartDate = startDate;
            CourseEndDate = endDate;

            if (teachers != null)
            {
                CourseTeachers = teachers;
            } 
            else
            {
                CourseTeachers = new List<PolhemTeacher>();
            }

            if (students != null)
            {
                CourseStudents = students;
            }
            else
            {
                CourseStudents = new List<PolhemStudent>();
            }
        }

        public string CourseName
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

        public string CourseCode
        {
            get
            {
                return courseCode;
            }
            set
            {
                courseCode = value;
            }
        }

        public int CoursePoints
        {
            get
            {
                return coursePoints;
            }
            set
            {
                coursePoints = value;
            }
        }

        public DateTime CourseStartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }

        public DateTime CourseEndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
            }
        }

        /*public List<PolhemStudent> CourseStudents
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
            }
        }

        public List<PolhemTeacher> CourseTeachers
        {
            get
            {
                return teacher;
            }
            set
            {
                teacher = value;
            }
        }*/

        public PolhemStudent CourseStudent (int number)
        {
            return CourseStudents[number];
        }

        public bool IsCourseActive (DateTime checkDate)
        {
            if (DateTime.Compare(startDate, checkDate) <= 0 && DateTime.Compare(endDate, checkDate) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
