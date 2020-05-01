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

            foreach (Control x in gbxCourse.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).ReadOnly = true;
                    ((TextBox)x).BackColor = SystemColors.Window;
                }
            }

            foreach (Control x in gbxStudent.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).ReadOnly = true;
                    ((TextBox)x).BackColor = SystemColors.Window;
                }
            }

            foreach (Control x in gbxTeacher.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).ReadOnly = true;
                    ((TextBox)x).BackColor = SystemColors.Window;
                }
            }
        }

        private void getData ()
        {
            courseList.Clear();
            studentList.Clear();
            teacherList.Clear();

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
        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            getData();
            updateGUI();
        }

        private void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            PolhemCourse tmpCourse = null;
            for (int i = 0; i < courseList.Count; i++)
            {
                if (courseList[i].CourseName == lbxCourses.SelectedItem.ToString())
                {
                    tmpCourse = courseList[i];
                    break;
                }
            }

            using (var updateItem = new UpdateItem("course", tmpCourse))
            {
                updateItem.ShowDialog();
            }

            getData();
            updateGUI();
        }

        private void btnUpdateTeacher_Click(object sender, EventArgs e)
        {
            PolhemTeacher tmpTeacher = null;
            for (int i = 0; i < teacherList.Count; i++)
            {
                if (teacherList[i].TeacherName == lbxTeachers.SelectedItem.ToString())
                {
                    tmpTeacher = teacherList[i];
                    break;
                }
            }

            using (var updateItem = new UpdateItem("teacher", null, null, tmpTeacher))
            {
                updateItem.ShowDialog();
            }

            getData();
            updateGUI();
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            PolhemStudent tmpStudent = null;
            for (int i = 0; i < studentList.Count; i++)
            {
                if (studentList[i].StudentName == lbxStudents.SelectedItem.ToString())
                {
                    tmpStudent = studentList[i];
                    break;
                }
            }
            using (var updateItem = new UpdateItem("student", null, tmpStudent))
            {
                updateItem.ShowDialog();
            }

            getData();
            updateGUI();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            using (var addItem = new AddItem("course"))
            {
                addItem.ShowDialog();
            }
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            using (var addItem = new AddItem("teacher"))
            {
                addItem.ShowDialog();
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            using (var addItem = new AddItem("student"))
            {
                addItem.ShowDialog();
            }
        }

        private void btnRemoveTeacher_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Är du säker på att du vill ta bort " + lbxTeachers.SelectedItem.ToString() + " från skolan?", "Ta bort lärare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                PolhemTeacher tmpTeacher = null;
                for (int i = 0; i < teacherList.Count; i++)
                {
                    if (teacherList[i].TeacherName == lbxTeachers.SelectedItem.ToString())
                    {
                        tmpTeacher = teacherList[i];
                        break;
                    }
                }

                string connectionString = "server=192.168.2.209; port=3306; " + "database=School; uid=DataDennisCunt7; pwd=MicrophoneRedKlyft67#;";
                MySqlConnection deleteConnection = new MySqlConnection(connectionString);
                deleteConnection.Open();

                MySqlCommand deleteCmd = new MySqlCommand("DELETE FROM teachercourses WHERE teacher_id = (SELECT id FROM teachers WHERE name='" + tmpTeacher.TeacherName +"' AND email='" + tmpTeacher.TeacherEmail + "');", deleteConnection);
                MySqlCommand deleteTeacher = new MySqlCommand("DELETE FROM teachers WHERE name = '" + tmpTeacher.TeacherName +"' AND email = '" + tmpTeacher.TeacherEmail + "'); ", deleteConnection);

                int affectedCourses = deleteCmd.ExecuteNonQuery();
                int affectedTeachers = deleteTeacher.ExecuteNonQuery();

                deleteConnection.Close();

                MessageBox.Show(this, "Tog bort " + affectedTeachers.ToString() + " lärare, och påverkade " + affectedCourses.ToString() + " kurser.", "Borttagning genomförd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show(this, "Läraren har inte blivit borttagen.", "Borttagning avbruten", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Är du säker på att du vill ta bort " + lbxStudents.SelectedItem.ToString() + " från skolan?", "Ta bort elev", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                PolhemStudent tmpStudent = null;
                for (int i = 0; i < studentList.Count; i++)
                {
                    if (studentList[i].StudentName == lbxStudents.SelectedItem.ToString())
                    {
                        tmpStudent = studentList[i];
                        break;
                    }
                }

                string connectionString = "server=192.168.2.209; port=3306; " + "database=School; uid=DataDennisCunt7; pwd=MicrophoneRedKlyft67#;";
                MySqlConnection deleteConnection = new MySqlConnection(connectionString);
                deleteConnection.Open();

                MySqlCommand deleteCmd = new MySqlCommand("DELETE FROM coursestudents WHERE students_id = (SELECT id FROM students WHERE name='" + tmpStudent.StudentName + "' AND email='" + tmpStudent.StudentEmail + "');", deleteConnection);
                MySqlCommand deleteStudent = new MySqlCommand("DELETE FROM students WHERE name = '" + tmpStudent.StudentName + "' AND email = '" + tmpStudent.StudentEmail + "'); ", deleteConnection);

                int affectedCourses = deleteCmd.ExecuteNonQuery();
                int affectedTeachers = deleteStudent.ExecuteNonQuery();

                deleteConnection.Close();

                MessageBox.Show(this, "Tog bort " + affectedTeachers.ToString() + " elever, och påverkade " + affectedCourses.ToString() + " kurser.", "Borttagning genomförd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show(this, "Eleven har inte blivit borttagen.", "Borttagning avbruten", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnUpdateTeacherBelonging_Click(object sender, EventArgs e)
        {
            using (var changeBelonging = new ChangeCourseBelonging("teacher"))
            {
                changeBelonging.ShowDialog();
            }
        }

        private void btnUpdateStudentBelonging_Click(object sender, EventArgs e)
        {
            using (var changeBelonging = new ChangeCourseBelonging("student"))
            {
                changeBelonging.ShowDialog();
            }
        }

        private void btnUpdateClassBelonging_Click(object sender, EventArgs e)
        {
            using (var changeBelonging = new ChangeCourseBelonging("class"))
            {
                changeBelonging.ShowDialog();
            }
        }

        private void btnRemoveCourse_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Är du säker på att du vill ta bort " + lbxCourses.SelectedItem.ToString() + " från skolan?", "Ta bort kurs", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                PolhemCourse tmpCourse = null;
                for (int i = 0; i < courseList.Count; i++)
                {
                    if (courseList[i].CourseName == lbxCourses.SelectedItem.ToString())
                    {
                        tmpCourse = courseList[i];
                        break;
                    }
                }

                string connectionString = "server=192.168.2.209; port=3306; " + "database=School; uid=DataDennisCunt7; pwd=MicrophoneRedKlyft67#;";
                MySqlConnection deleteConnection = new MySqlConnection(connectionString);
                deleteConnection.Open();

                MySqlCommand deleteCmd = new MySqlCommand("DELETE FROM coursestudents WHERE courses_id = (SELECT id FROM courses WHERE name='" + tmpCourse.CourseName + "' AND code='" + tmpCourse.CourseCode + "');", deleteConnection);
                MySqlCommand deleteCmd2 = new MySqlCommand("DELETE FROM teachercourses WHERE course_id = (SELECT id FROM courses WHERE name='" + tmpCourse.CourseName + "' AND code='" + tmpCourse.CourseCode + "');", deleteConnection);
                MySqlCommand deleteCourse = new MySqlCommand("DELETE FROM courses WHERE name = '" + tmpCourse.CourseName + "' AND code = '" + tmpCourse.CourseCode + "'); ", deleteConnection);

                int affectedStudents = deleteCmd.ExecuteNonQuery();
                int affectedTeachers = deleteCmd2.ExecuteNonQuery();
                int affectedCourses = deleteCourse.ExecuteNonQuery();

                deleteConnection.Close();

                MessageBox.Show(this, "Tog bort " + affectedCourses.ToString() + " kurser, och påverkade " + affectedTeachers.ToString() + " lärare och " + affectedStudents.ToString() + " elever.", "Borttagning genomförd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show(this, "Kursen har inte blivit borttagen.", "Borttagning avbruten", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnUpdateStudentClassBelongings_Click(object sender, EventArgs e)
        {
            using (var changeBelongingClass = new ChangeCourseBelongingStudent())
            {
                changeBelongingClass.ShowDialog();
            }
        }
    }
}
