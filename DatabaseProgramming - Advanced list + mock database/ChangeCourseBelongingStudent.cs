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
    public partial class ChangeCourseBelongingStudent : Form
    {
        private List<PolhemCourse> courseList = new List<PolhemCourse>();
        private List<PolhemTeacher> teacherList = new List<PolhemTeacher>();
        private List<PolhemStudent> studentList = new List<PolhemStudent>();
        private List<string> classList = new List<string>();

        private bool isInitFinished = false;

        public ChangeCourseBelongingStudent()
        {
            InitializeComponent();

            this.Text = "Uppdatera Kurstillhörighet";
            lbxStudents.SelectionMode = SelectionMode.MultiExtended;

            getData();
            updateGUI();

            isInitFinished = true;
        }

        private void getData()
        {
            courseList.Clear();
            studentList.Clear();
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
            lbxStudents.Items.Clear();
            lbxClasses.Items.Clear();

            for (int i = 0; i < studentList.Count; i++)
            {
                lbxStudents.Items.Add(studentList[i].StudentName);
            }

            for (int i = 0; i < classList.Count; i++)
            {
                lbxClasses.Items.Add(classList[i]);
            }
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

            MySqlCommand cmdInsertUpdated = null;

            string tmpUpdateCmdString = "UPDATE students SET CLASS = '" + lbxClasses.SelectedItem.ToString() + "' WHERE id in (";

            for (int i = 0; i < lbxStudents.SelectedIndices.Count; i++)
            {
                tmpUpdateCmdString += (lbxStudents.SelectedIndices[i] + 1).ToString() + ", ";
            }

            tmpUpdateCmdString = tmpUpdateCmdString.Remove(tmpUpdateCmdString.Length - 2);
            tmpUpdateCmdString += ");";

            Console.WriteLine(tmpUpdateCmdString);

            cmdInsertUpdated = new MySqlCommand(tmpUpdateCmdString, dbUpdateBelonging);

            int updatedClassBelongings = cmdInsertUpdated.ExecuteNonQuery();

            dbUpdateBelonging.Close();

            MessageBox.Show(this, "Uppdaterade klasstillhörigheter för " + updatedClassBelongings.ToString() + " elever.", "Uppdatering genomförd", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            getData();
            updateGUI();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitFinished)
            {
                for (int i = 0; i < lbxStudents.Items.Count; i++)
                {
                    lbxStudents.SetSelected(i, false);
                }

                for (int i = 0; i < studentList.Count; i++)
                {
                    if (classList[lbxClasses.SelectedIndex].ToString() == studentList[i].StudentClass)
                    {
                        lbxStudents.SetSelected(i, true);
                    }
                }

                lbxStudents.Focus();
            }

        }

        private void lbxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
