using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Courses;

namespace DatabaseProgramming___Advanced_list___mock_database
{
    public partial class FrmCourseManager : Form
    {
        private List<PolhemCourse> courseList = new List<PolhemCourse>();

        public FrmCourseManager ()
        {
            InitializeComponent();
        }

        private void mockDatabasePopulation ()
        {
            PolhemTeacher tmpTeacher1 = new PolhemTeacher("Hampus Åhlander", "AHH", "hampus.ahlander@skola.lund.se");
            PolhemTeacher tmpTeacher2 = new PolhemTeacher("Malte Dahlgren", "DAM", "malte.dahlgren@skola.lund.se");
            PolhemTeacher tmpTeacher3 = new PolhemTeacher("August Molander", "MOA", "august.molander@skola.lund.se");

            PolhemCourse tmpCourse1 = new PolhemCourse("Programmering 1", "PRG01", 100, DateTime.Parse("1990-12-13"), DateTime.Parse("2016-03-02"), tmpTeacher1);
            PolhemCourse tmpCourse2 = new PolhemCourse("Webbutveckling 1", "WEB01", 100, DateTime.Parse("1997-06-24"), DateTime.Parse("2001-03-18"), tmpTeacher2);
            PolhemCourse tmpCourse3 = new PolhemCourse("Teknik 1", "TEK01", 100, DateTime.Parse("2017-08-10"), DateTime.Parse("2018-06-09"), tmpTeacher3);

            courseList.Add(tmpCourse1);
            courseList.Add(tmpCourse2);
            courseList.Add(tmpCourse3);
        }

        private void fillCourseList (List<PolhemCourse> courseList)
        {
            lbxCourseList.Items.Clear();

            for (int i = 0; i < courseList.Count; i++)
            {
                lbxCourseList.Items.Add(courseList[i].CourseName);
            }

            lbxCourseList.SelectedIndex = 0;
        }

        private void updateGUIData (List<PolhemCourse> courseList, int selectedIndex)
        {
            tbxCourseName.Text = courseList[selectedIndex].CourseName;
            tbxCourseCode.Text = courseList[selectedIndex].CourseCode;
            tbxCoursePoints.Text = courseList[selectedIndex].CoursePoints.ToString();
            tbxCourseStart.Text = courseList[selectedIndex].CourseStartDate.ToShortDateString();
            tbxCourseEnd.Text = courseList[selectedIndex].CourseEndDate.ToShortDateString();

            if (courseList[selectedIndex].IsCourseActive(DateTime.Now))
            {
                tbxCourseActive.Text = "Ja";
            }
            else
            {
                tbxCourseActive.Text = "Nej";
            }
        }

        private void lbxCourseList_SelectedIndexChanged (object sender, EventArgs e)
        {
            updateGUIData(courseList, lbxCourseList.SelectedIndex);
        }
    }
}
