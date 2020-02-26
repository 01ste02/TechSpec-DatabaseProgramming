using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    class PolhemCourse
    {
        private string name;
        private string courseCode;
        private int coursePoints;
        private DateTime startDate;
        private DateTime endDate;

        public PolhemCourse (string name, string courseCode, int coursePoints, DateTime startDate, DateTime endDate)
        {
            CourseName = name;
            CourseCode = courseCode;
            CoursePoints = coursePoints;
            CourseStartDate = startDate;
            CourseEndDate = endDate;
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

        public bool IsCourseActive (DateTime checkDate)
        {
            if (startDate.CompareTo(checkDate) >= 0 && endDate.CompareTo(checkDate) <= 0)
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
