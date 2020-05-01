using Courses;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProgramming___Advanced_list___mock_database
{
    public partial class ChangeCourseBelonging : Form
    {
        private List<PolhemCourse> courseList = new List<PolhemCourse>();
        private List<PolhemTeacher> teacherList = new List<PolhemTeacher>();
        private List<PolhemStudent> studentList = new List<PolhemStudent>();
        private List<string> classList = new List<string>();

        private string belongingUpdateFor;
        public ChangeCourseBelonging(string belonging)
        {
            InitializeComponent();

            this.Text = "Uppdatera Kurstillhörighet";
            belongingUpdateFor = belonging;
            lbxCourses.SelectionMode = SelectionMode.MultiExtended;

            getData();
            updateGUI();
        }

        private void getData()
        {
            courseList.Clear();
            studentList.Clear();
            teacherList.Clear();
            classList.Clear();

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

                    MySqlCommand cmdStudent = new MySqlCommand("SELECT * FROM students WHERE students.id in (SELECT coursestudents.students_id FROM coursestudents WHERE coursestudents.courses_id = (SELECT id FROM courses WHERE courses.name = '" + tmpCourse.CourseName + "'));", dbStudent);
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

            MySqlConnection dbTeachers = new MySqlConnection(connectionString);
            dbTeachers.Open();

            MySqlCommand cmdTeachers = new MySqlCommand("SELECT * FROM teachers;", dbTeachers);
            MySqlDataReader rdrTeachers = cmdTeachers.ExecuteReader();

            if (rdrTeachers.HasRows)
            {
                while (rdrTeachers.Read())
                {
                    string tmpTeacherName = rdrTeachers["name"].ToString();
                    string tmpTeacherCode = rdrTeachers["code"].ToString();
                    string tmpTeacherEmail = rdrTeachers["email"].ToString();
                    string tmpTeacherPhone = rdrTeachers["phone"].ToString();

                    PolhemTeacher tmpTeacher = new PolhemTeacher(tmpTeacherName, tmpTeacherCode, tmpTeacherEmail, tmpTeacherPhone);
                    teacherList.Add(tmpTeacher);
                }
            }

            rdrTeachers.Close();
            dbTeachers.Close();

            MySqlConnection dbStudents = new MySqlConnection(connectionString);
            dbStudents.Open();

            MySqlCommand cmdStudents = new MySqlCommand("SELECT * FROM students;", dbStudents);
            MySqlDataReader rdrStudents = cmdStudents.ExecuteReader();

            if (rdrStudents.HasRows)
            {
                while (rdrStudents.Read())
                {
                    string tmpStudentName = rdrStudents["name"].ToString();
                    string tmpStudentClass = rdrStudents["class"].ToString();
                    string tmpStudentEmail = rdrStudents["email"].ToString();
                    string tmpStundentPhone = rdrStudents["phone"].ToString();

                    PolhemStudent tmpStudent = new PolhemStudent(tmpStudentName, tmpStudentClass, tmpStudentEmail, tmpStundentPhone);
                    studentList.Add(tmpStudent);
                }
            }

            rdrStudents.Close();
            dbStudents.Close();

            MySqlConnection dbClasses = new MySqlConnection(connectionString);
            dbClasses.Open();

            MySqlCommand cmdClasses = new MySqlCommand("SELECT DISTINCT class FROM students;", dbClasses);
            MySqlDataReader rdrClasses = cmdClasses.ExecuteReader();

            if (rdrClasses.HasRows)
            {
                while (rdrClasses.Read())
                {
                    classList.Add(rdrClasses["class"].ToString());
                }
            }

            rdrClasses.Close();
            dbClasses.Close();
        }

        private void updateGUI ()
        {
            for (int i = 0; i < courseList.Count; i++)
            {
                lbxCourses.Items.Add(courseList[i].CourseName);
            }

            if (belongingUpdateFor == "student")
            {
                lblItemOne.Text = "Elever";
                
                for (int i = 0; i < studentList.Count; i++)
                {
                    lbxItemOne.Items.Add(studentList[i].StudentName);
                }
            }
            else if (belongingUpdateFor == "teacher")
            {
                lblItemOne.Text = "Lärare";

                for (int i = 0; i < teacherList.Count; i++)
                {
                    lbxItemOne.Items.Add(teacherList[i].TeacherName);
                }
            }
            else if (belongingUpdateFor == "class")
            {
                lblItemOne.Text = "Klasser";

                for (int i = 0; i < classList.Count; i++)
                {
                    lbxItemOne.Items.Add(classList[i]);
                }
            }
        }

        private void lbxItemOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lbxCourses.Items.Count; i++)
            {
                lbxCourses.SetSelected(i, false);
            }

            for (int i = 0; i < courseList.Count; i++)
            {
                if (belongingUpdateFor == "student")
                {
                    for (int j = 0; j < courseList[i].CourseStudents.Count; j++)
                    {
                        if (courseList[i].CourseStudents[j].StudentName == studentList[findStudentIndex(lbxItemOne.SelectedItem.ToString())].StudentName && courseList[i].CourseStudents[j].StudentEmail == studentList[findStudentIndex(lbxItemOne.SelectedItem.ToString())].StudentEmail && courseList[i].CourseStudents[j].StudentClass == studentList[findStudentIndex(lbxItemOne.SelectedItem.ToString())].StudentClass && courseList[i].CourseStudents[j].StudentPhone == studentList[findStudentIndex(lbxItemOne.SelectedItem.ToString())].StudentPhone)
                        {
                            lbxCourses.SetSelected(i, true);
                        }
                    }
                }
                else if (belongingUpdateFor == "teacher")
                {
                    for (int j = 0; j < courseList[i].CourseTeachers.Count; j++)
                    {
                        if (courseList[i].CourseTeachers[j].TeacherName == teacherList[findTeacherIndex(lbxItemOne.SelectedItem.ToString())].TeacherName && courseList[i].CourseTeachers[j].TeacherCode == teacherList[findTeacherIndex(lbxItemOne.SelectedItem.ToString())].TeacherCode && courseList[i].CourseTeachers[j].TeacherEmail == teacherList[findTeacherIndex(lbxItemOne.SelectedItem.ToString())].TeacherEmail && courseList[i].CourseTeachers[j].TeacherPhone == teacherList[findTeacherIndex(lbxItemOne.SelectedItem.ToString())].TeacherPhone)
                        {
                            lbxCourses.SetSelected(i, true);
                        }
                    }
                }
                else if (belongingUpdateFor == "class")
                {
                    for (int j = 0; j < courseList[i].CourseStudents.Count; j++)
                    {
                        if (courseList[i].CourseStudents[j].StudentClass.Equals(classList[findClassIndex(lbxItemOne.SelectedItem.ToString())]))
                        {
                            lbxCourses.SetSelected(i, true);
                        }
                    }
                }
            }

            lbxCourses.Focus();
        }

        private int findStudentIndex (string StudentName)
        {
            for (int i = 0; i < studentList.Count; i++)
            {
                if (studentList[i].StudentName == StudentName)
                {
                    return i;
                }
            }

            return 0;
        }

        private int findTeacherIndex(string TeacherName)
        {
            for (int i = 0; i < teacherList.Count; i++)
            {
                if (teacherList[i].TeacherName == TeacherName)
                {
                    return i;
                }
            }

            return 0;
        }

        private int findClassIndex(string ClassName)
        {
            for (int i = 0; i < classList.Count; i++)
            {
                if (classList[i] == ClassName)
                {
                    return i;
                }
            }

            return 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = "server=192.168.2.209; port=3306; " + "database=School; uid=DataDennisCunt7; pwd=MicrophoneRedKlyft67#;";
            MySqlConnection dbUpdateBelonging = new MySqlConnection(connectionString);
            dbUpdateBelonging.Open();

            MySqlCommand cmdRemoveAll = null;
            MySqlCommand cmdInsertUpdated = null;

            if (belongingUpdateFor == "student")
            {
                cmdRemoveAll = new MySqlCommand("DELETE FROM coursestudents WHERE students_id = (SELECT id FROM students WHERE name='" + studentList[findStudentIndex(lbxItemOne.SelectedItem.ToString())].StudentName + "' AND email='" + studentList[findStudentIndex(lbxItemOne.SelectedItem.ToString())].StudentEmail + "');", dbUpdateBelonging);

                string tmpCmdString = "INSERT INTO coursestudents (courses_id, students_id) VALUES";

                for (int i = 0; i < lbxCourses.SelectedIndices.Count; i++)
                {
                    tmpCmdString += " (" + (lbxCourses.SelectedIndices[i] + 1).ToString() + ", (SELECT id FROM students WHERE name='" + studentList[findStudentIndex(lbxItemOne.SelectedItem.ToString())].StudentName + "' AND email='" + studentList[findStudentIndex(lbxItemOne.SelectedItem.ToString())].StudentEmail + "'))";

                    if (i < (lbxCourses.SelectedIndices.Count - 1))
                    {
                        tmpCmdString += ",";
                    }
                }

                tmpCmdString += ";";

                Console.WriteLine(tmpCmdString);
                cmdInsertUpdated = new MySqlCommand(tmpCmdString, dbUpdateBelonging);

                int removedClassBelongings = cmdRemoveAll.ExecuteNonQuery();
                int addedClassBelongings = cmdInsertUpdated.ExecuteNonQuery();

                dbUpdateBelonging.Close();

                MessageBox.Show(this, "Tog bort " + removedClassBelongings.ToString() + " klasstillhörigheter och lade till " + addedClassBelongings.ToString() + " klasstillhörigheter för " + studentList[findStudentIndex(lbxItemOne.SelectedItem.ToString())].StudentName, "Uppdatering genomförd", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if (belongingUpdateFor == "teacher")
            {
                cmdRemoveAll = new MySqlCommand("DELETE FROM teachercourses WHERE teacher_id = (SELECT id FROM teachers WHERE name='" + teacherList[findTeacherIndex(lbxItemOne.SelectedItem.ToString())].TeacherName + "' AND email='" + teacherList[findTeacherIndex(lbxItemOne.SelectedItem.ToString())].TeacherEmail + "');", dbUpdateBelonging);

                string tmpCmdString = "INSERT INTO teachercourses (teacher_id, course_id) VALUES";

                for (int i = 0; i < lbxCourses.SelectedIndices.Count; i++)
                {
                    tmpCmdString += " ((SELECT id FROM teachers WHERE name='" + teacherList[findTeacherIndex(lbxItemOne.SelectedItem.ToString())].TeacherName + "' AND email='" + teacherList[findTeacherIndex(lbxItemOne.SelectedItem.ToString())].TeacherEmail + "'), " + (lbxCourses.SelectedIndices[i] + 1).ToString() + ")";

                    if (i < (lbxCourses.SelectedIndices.Count - 1))
                    {
                        tmpCmdString += ",";
                    }
                }

                tmpCmdString += ";";

                Console.WriteLine(tmpCmdString);
                cmdInsertUpdated = new MySqlCommand(tmpCmdString, dbUpdateBelonging);

                int removedClassBelongings = cmdRemoveAll.ExecuteNonQuery();
                int addedClassBelongings = cmdInsertUpdated.ExecuteNonQuery();

                dbUpdateBelonging.Close();

                MessageBox.Show(this, "Tog bort " + removedClassBelongings.ToString() + " klasstillhörigheter och lade till " + addedClassBelongings.ToString() + " klasstillhörigheter för " + teacherList[findTeacherIndex(lbxItemOne.SelectedItem.ToString())].TeacherName, "Uppdatering genomförd", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if (belongingUpdateFor == "class")
            {
                cmdRemoveAll = new MySqlCommand("DELETE FROM coursestudents WHERE students_id in (SELECT id FROM students WHERE class='" + classList[findClassIndex(lbxItemOne.SelectedItem.ToString())] + "');", dbUpdateBelonging);

                string tmpCmdString = "INSERT INTO coursestudents (courses_id, students_id) VALUES";
                for (int i = 0; i < lbxCourses.SelectedIndices.Count; i++)
                {
                    for (int j = 0; j < studentList.Count; j++)
                    {
                        if (studentList[j].StudentClass == classList[findClassIndex(lbxItemOne.SelectedItem.ToString())])
                        {
                            tmpCmdString += " (" + (lbxCourses.SelectedIndices[i] + 1).ToString() + ", (SELECT id FROM students WHERE name='" + studentList[j].StudentName + "' AND email='" + studentList[j].StudentEmail + "')),";
                        }
                    }
                }

                tmpCmdString = tmpCmdString.Remove(tmpCmdString.Length - 1);
                tmpCmdString += ";";

                Console.WriteLine(tmpCmdString);

                cmdInsertUpdated = new MySqlCommand(tmpCmdString, dbUpdateBelonging);

                int removedClassBelongings = cmdRemoveAll.ExecuteNonQuery();
                int addedClassBelongings = cmdInsertUpdated.ExecuteNonQuery();

                dbUpdateBelonging.Close();

                MessageBox.Show(this, "Tog bort " + removedClassBelongings.ToString() + " klasstillhörigheter och lade till " + addedClassBelongings.ToString() + " klasstillhörigheter för " + classList[findClassIndex(lbxItemOne.SelectedItem.ToString())], "Uppdatering genomförd", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            getData();
            updateGUI();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
