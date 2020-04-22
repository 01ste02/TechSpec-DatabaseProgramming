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
using MySql.Data.MySqlClient;

namespace DatabaseProgramming___Advanced_list___mock_database
{
    public partial class FrmCourseManager : Form
    {
        private List<PolhemCourse> courseList = new List<PolhemCourse>();
        private List<PolhemTeacher> teacherList = new List<PolhemTeacher>();
        private List<PolhemStudent> studentList = new List<PolhemStudent>();

        private bool isInitDone = false;

        public FrmCourseManager ()
        {
            InitializeComponent();

            getData();

            updateGUI();
        }

        /*private void mockDatabasePopulation ()
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
        }*/

        private void getData ()
        {
            courseList.Clear();

            string connectionString = "server=192.168.2.209; port=3306; " + "database=School; uid=DataDennisCunt7; pwd=MicrophoneRedKlyft67#;";
            MySqlConnection dbCourse = new MySqlConnection(connectionString);
            dbCourse.Open();

            MySqlCommand cmdCourse = new MySqlCommand("SELECT * FROM courses;", dbCourse);
            MySqlDataReader rdrCourse = cmdCourse.ExecuteReader();

            if (rdrCourse.HasRows)
            {
                while (rdrCourse.Read())
                {
                    string tmpCourseName = rdrCourse["name"].ToString();
                    string tmpCourseCode = rdrCourse["code"].ToString();
                    int tmpCourseSize = int.Parse(rdrCourse["size"].ToString());
                    DateTime tmpCourseStart = DateTime.Parse(rdrCourse["start"].ToString());
                    DateTime tmpCourseEnd = DateTime.Parse(rdrCourse["end"].ToString());
                    PolhemCourse tmpCourse = new PolhemCourse(tmpCourseName, tmpCourseCode, tmpCourseSize, tmpCourseStart, tmpCourseEnd);

                    MySqlConnection dbTeacher = new MySqlConnection(connectionString);
                    dbTeacher.Open();

                    MySqlCommand cmdTeacher = new MySqlCommand("SELECT * FROM teachers WHERE teachers.id in (SELECT teachercourses.teacher_id FROM teachercourses WHERE teachercourses.course_id = (SELECT id FROM courses WHERE courses.name = '" + tmpCourse.CourseName + "'));", dbTeacher);
                    MySqlDataReader rdrTeacher = cmdTeacher.ExecuteReader();

                    if (rdrTeacher.HasRows)
                    {
                        while (rdrTeacher.Read())
                        {
                            string tmpTeacherName = rdrTeacher["name"].ToString();
                            string tmpTeacherCode = rdrTeacher["code"].ToString();
                            string tmpTeacherEmail = rdrTeacher["email"].ToString();
                            string tmpTeacherPhone = rdrTeacher["phone"].ToString();

                            PolhemTeacher tmpTeacher = new PolhemTeacher(tmpTeacherName, tmpTeacherCode, tmpTeacherEmail, tmpTeacherPhone);
                            tmpCourse.CourseTeachers.Add(tmpTeacher);
                        }
                    }

                    rdrTeacher.Close();
                    dbTeacher.Close();

                    MySqlConnection dbStudent = new MySqlConnection(connectionString);
                    dbStudent.Open();

                    MySqlCommand cmdStudent = new MySqlCommand("SELECT * FROM students WHERE students.id in (SELECT coursestudents.students_id FROM coursestudents WHERE coursestudents.courses_id = (SELECT id FROM courses WHERE courses.name = '" + tmpCourse.CourseName +"'));", dbStudent);
                    MySqlDataReader rdrStudent = cmdStudent.ExecuteReader();

                    if (rdrStudent.HasRows)
                    {
                        while (rdrStudent.Read())
                        {
                            string tmpStudentName = rdrStudent["name"].ToString();
                            string tmpStudentClass = rdrStudent["class"].ToString();
                            string tmpStudentEmail = rdrStudent["email"].ToString();
                            string tmpStundentPhone = rdrStudent["phone"].ToString();

                            PolhemStudent tmpStudent = new PolhemStudent(tmpStudentName, tmpStudentClass, tmpStudentEmail, tmpStundentPhone);

                            tmpCourse.CourseStudents.Add(tmpStudent);
                        }
                    }

                    rdrStudent.Close();
                    dbStudent.Close();

                    courseList.Add(tmpCourse);
                }
            }

            rdrCourse.Close();
            dbCourse.Close();
        }

        private void updateCourseData (List<PolhemCourse> courseList, int selectedIndex)
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

        private void updateTeacherData (List<PolhemTeacher> teacherList, int selectedIndex)
        {
            tbxTeacherName.Text = teacherList[selectedIndex].TeacherName;
            tbxTeacherCode.Text = teacherList[selectedIndex].TeacherCode;
            tbxTeacherEmail.Text = teacherList[selectedIndex].TeacherEmail;
            tbxTeacherPhoneNr.Text = teacherList[selectedIndex].TeacherPhone;
        }

        private void updateStudentData (List<PolhemStudent> studentList, int selectedIndex)
        {
            tbxStudentName.Text = studentList[selectedIndex].StudentName;
            tbxStudentClass.Text = studentList[selectedIndex].StudentClass;
            tbxStudentEmail.Text = studentList[selectedIndex].StudentEmail;
            tbxStudentPhoneNr.Text = studentList[selectedIndex].StudentPhone;
        }

        private void updateCourseList (List<PolhemCourse> courseList)
        {
            lbxCourses.Items.Clear();
            
            for (int i = 0; i < courseList.Count; i++)
            {
                lbxCourses.Items.Add(courseList[i].CourseName);
            }

            lbxCourses.SelectedIndex = 0;
        }

        private void updateTeacherList (List<PolhemTeacher> teacherList)
        {
            lbxTeachers.Items.Clear();

            for (int i = 0; i < teacherList.Count; i++)
            {
                lbxTeachers.Items.Add(teacherList[i].TeacherName);
            }

            lbxTeachers.SelectedIndex = 0;
        }

        private void updateStudentList (List<PolhemStudent> studentList)
        {
            lbxStudents.Items.Clear();

            for (int i = 0; i < studentList.Count; i++)
            {
                lbxStudents.Items.Add(studentList[i].StudentName);
            }

            lbxStudents.SelectedIndex = 0;
        }

        private void lbxTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitDone)
            {
                updateTeacherData(teacherList, lbxTeachers.SelectedIndex);
            }
        }

        private void lbxCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitDone)
            {
                updateCourseData(courseList, lbxCourses.SelectedIndex);
                updateTeacherList(courseList[lbxCourses.SelectedIndex].CourseTeachers);
                updateStudentList(courseList[lbxCourses.SelectedIndex].CourseStudents);

                teacherList = courseList[lbxCourses.SelectedIndex].CourseTeachers;
                studentList = courseList[lbxCourses.SelectedIndex].CourseStudents;

                updateTeacherData(teacherList, lbxTeachers.SelectedIndex);
                updateStudentData(studentList, lbxStudents.SelectedIndex);
            }
        }

        private void lbxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitDone)
            {
                updateStudentData(studentList, lbxStudents.SelectedIndex);
            }
        }

        private void updateGUI()
        {
            updateCourseList(courseList);
            updateTeacherList(courseList[lbxCourses.SelectedIndex].CourseTeachers);
            updateStudentList(courseList[lbxCourses.SelectedIndex].CourseStudents);

            teacherList = courseList[lbxCourses.SelectedIndex].CourseTeachers;
            studentList = courseList[lbxCourses.SelectedIndex].CourseStudents;

            updateCourseData(courseList, lbxCourses.SelectedIndex);
            updateTeacherData(teacherList, lbxTeachers.SelectedIndex);
            updateStudentData(studentList, lbxStudents.SelectedIndex);

            isInitDone = true;
        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            getData();
            updateGUI();
        }
    }
}
