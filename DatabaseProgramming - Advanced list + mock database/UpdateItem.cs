using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Courses;
using MySql.Data.MySqlClient;

namespace DatabaseProgramming___Advanced_list___mock_database
{
    public partial class UpdateItem : Form
    {
        private GroupBox gbxUpdateContainer = new GroupBox();

        private Label lblTeacherName;
        private Label lblTeacherCode;
        private Label lblTeacherEmail;
        private Label lblTeacherPhone;
        private TextBox tbxTeacherName;
        private TextBox tbxTeacherCode;
        private TextBox tbxTeacherEmail;
        private TextBox tbxTeacherPhone;

        private Label lblStudentName;
        private Label lblStudentClass;
        private Label lblStudentEmail;
        private Label lblStudentPhone;
        private TextBox tbxStudentName;
        private TextBox tbxStudentClass;
        private TextBox tbxStudentEmail;
        private TextBox tbxStudentPhone;

        private Label lblCourseName;
        private Label lblCourseCode;
        private Label lblCoursePoints;
        private Label lblCourseStart;
        private Label lblCourseEnd;
        private TextBox tbxCourseName;
        private TextBox tbxCourseCode;
        private TextBox tbxCoursePoints;
        private TextBox tbxCourseStart;
        private TextBox tbxCourseEnd;

        private Button btnUpdate;
        private Button btnAbort;

        private string updateCase = "";
        private PolhemStudent studentData;
        private PolhemTeacher teacherData;
        private PolhemCourse courseData;
        public UpdateItem(string item, PolhemCourse course = null, PolhemStudent student = null, PolhemTeacher teacher = null)
        {
            InitializeComponent();

            updateCase = item;
            studentData = student;
            teacherData = teacher;
            courseData = course;

            switch (updateCase)
            {
                case "student":
                    this.Controls.Add(gbxUpdateContainer);
                    gbxUpdateContainer.Size = new Size(365, 151);
                    gbxUpdateContainer.Location = new Point(13, 13);
                    gbxUpdateContainer.Text = "Elev";

                    this.Size = new Size(405, 220 + System.Windows.Forms.SystemInformation.CaptionHeight);
                    this.FormBorderStyle = FormBorderStyle.FixedSingle;

                    btnUpdate = new Button();
                    this.Controls.Add(btnUpdate);
                    btnUpdate.Location = new Point(13, 170);
                    btnUpdate.Size = new Size((gbxUpdateContainer.Size.Width - 20) / 2, 20);
                    btnUpdate.Text = "Uppdatera";

                    btnAbort = new Button();
                    this.Controls.Add(btnAbort);
                    btnAbort.Location = new Point(33 + ((gbxUpdateContainer.Size.Width - 20) / 2), 170);
                    btnAbort.Size = new Size((gbxUpdateContainer.Size.Width - 20) / 2, 20);
                    btnAbort.Text = "Avbryt";

                    lblStudentClass = new Label();
                    lblStudentEmail = new Label();
                    lblStudentName = new Label();
                    lblStudentPhone = new Label();
                    tbxStudentClass = new TextBox();
                    tbxStudentEmail = new TextBox();
                    tbxStudentName = new TextBox();
                    tbxStudentPhone = new TextBox();

                    this.Controls.Add(lblStudentClass);
                    this.Controls.Add(lblStudentEmail);
                    this.Controls.Add(lblStudentName);
                    this.Controls.Add(lblStudentPhone);
                    this.Controls.Add(tbxStudentClass);
                    this.Controls.Add(tbxStudentEmail);
                    this.Controls.Add(tbxStudentName);
                    this.Controls.Add(tbxStudentPhone);

                    gbxUpdateContainer.Controls.Add(tbxStudentPhone);
                    gbxUpdateContainer.Controls.Add(tbxStudentEmail);
                    gbxUpdateContainer.Controls.Add(tbxStudentName);
                    gbxUpdateContainer.Controls.Add(tbxStudentClass);
                    gbxUpdateContainer.Controls.Add(lblStudentPhone);
                    gbxUpdateContainer.Controls.Add(lblStudentEmail);
                    gbxUpdateContainer.Controls.Add(lblStudentName);
                    gbxUpdateContainer.Controls.Add(lblStudentClass);

                    lblStudentName.Text = "Namn";
                    lblStudentName.Location = new Point(15, 30);
                    lblStudentName.Size = new Size(35, 13);

                    lblStudentClass.Text = "Klass";
                    lblStudentClass.Location = new Point(271, 30);
                    lblStudentClass.Size = new Size(32, 13);

                    lblStudentEmail.Text = "Epost";
                    lblStudentEmail.Location = new Point(18, 69);
                    lblStudentEmail.Size = new Size(34, 13);

                    lblStudentPhone.Text = "Telefonnummer";
                    lblStudentPhone.Location = new Point(18, 108);
                    lblStudentPhone.Size = new Size(80, 13);

                    tbxStudentName.Location = new Point(18, 46);
                    tbxStudentName.Size = new Size(240, 20);

                    tbxStudentClass.Location = new Point(274, 46);
                    tbxStudentClass.Size = new Size(73, 20);

                    tbxStudentEmail.Location = new Point(18, 85);
                    tbxStudentEmail.Size = new Size(329, 20);

                    tbxStudentPhone.Location = new Point(18, 124);
                    tbxStudentPhone.Size = new Size(329, 20);

                    tbxStudentClass.Text = student.StudentClass;
                    tbxStudentEmail.Text = student.StudentEmail;
                    tbxStudentName.Text = student.StudentName;
                    tbxStudentPhone.Text = student.StudentPhone;
                    break;

                case "teacher":
                    this.Controls.Add(gbxUpdateContainer);
                    gbxUpdateContainer.Size = new Size(365, 151);
                    gbxUpdateContainer.Location = new Point(13, 13);
                    gbxUpdateContainer.Text = "Lärare";

                    this.Size = new Size(405, 220 + System.Windows.Forms.SystemInformation.CaptionHeight);
                    this.FormBorderStyle = FormBorderStyle.FixedSingle;

                    btnUpdate = new Button();
                    this.Controls.Add(btnUpdate);
                    btnUpdate.Location = new Point(13, 170);
                    btnUpdate.Size = new Size((gbxUpdateContainer.Size.Width - 20) / 2, 20);
                    btnUpdate.Text = "Uppdatera";

                    btnAbort = new Button();
                    this.Controls.Add(btnAbort);
                    btnAbort.Location = new Point(33 + ((gbxUpdateContainer.Size.Width - 20) / 2), 170);
                    btnAbort.Size = new Size((gbxUpdateContainer.Size.Width - 20) / 2, 20);
                    btnAbort.Text = "Avbryt";

                    lblTeacherCode = new Label();
                    lblTeacherEmail = new Label();
                    lblTeacherName = new Label();
                    lblTeacherPhone = new Label();
                    tbxTeacherCode = new TextBox();
                    tbxTeacherEmail = new TextBox();
                    tbxTeacherName = new TextBox();
                    tbxTeacherPhone = new TextBox();

                    this.Controls.Add(lblTeacherCode);
                    this.Controls.Add(lblTeacherEmail);
                    this.Controls.Add(lblTeacherName);
                    this.Controls.Add(lblTeacherPhone);
                    this.Controls.Add(tbxTeacherCode);
                    this.Controls.Add(tbxTeacherEmail);
                    this.Controls.Add(tbxTeacherName);
                    this.Controls.Add(tbxTeacherPhone);

                    gbxUpdateContainer.Controls.Add(tbxTeacherPhone);
                    gbxUpdateContainer.Controls.Add(tbxTeacherEmail);
                    gbxUpdateContainer.Controls.Add(tbxTeacherName);
                    gbxUpdateContainer.Controls.Add(tbxTeacherCode);
                    gbxUpdateContainer.Controls.Add(lblTeacherPhone);
                    gbxUpdateContainer.Controls.Add(lblTeacherEmail);
                    gbxUpdateContainer.Controls.Add(lblTeacherName);
                    gbxUpdateContainer.Controls.Add(lblTeacherCode);

                    lblTeacherName.Text = "Namn";
                    lblTeacherName.Location = new Point(15, 30);
                    lblTeacherName.Size = new Size(35, 13);

                    lblTeacherCode.Text = "Kod";
                    lblTeacherCode.Location = new Point(271, 30);
                    lblTeacherCode.Size = new Size(32, 13);

                    lblTeacherEmail.Text = "Epost";
                    lblTeacherEmail.Location = new Point(18, 69);
                    lblTeacherEmail.Size = new Size(34, 13);

                    lblTeacherPhone.Text = "Telefonnummer";
                    lblTeacherPhone.Location = new Point(18, 108);
                    lblTeacherPhone.Size = new Size(80, 13);

                    tbxTeacherName.Location = new Point(18, 46);
                    tbxTeacherName.Size = new Size(240, 20);

                    tbxTeacherCode.Location = new Point(274, 46);
                    tbxTeacherCode.Size = new Size(73, 20);

                    tbxTeacherEmail.Location = new Point(18, 85);
                    tbxTeacherEmail.Size = new Size(329, 20);

                    tbxTeacherPhone.Location = new Point(18, 124);
                    tbxTeacherPhone.Size = new Size(329, 20);

                    tbxTeacherCode.Text = teacher.TeacherCode;
                    tbxTeacherEmail.Text = teacher.TeacherEmail;
                    tbxTeacherName.Text = teacher.TeacherName;
                    tbxTeacherPhone.Text = teacher.TeacherPhone;
                    break;

                case "course":
                    this.Controls.Add(gbxUpdateContainer);
                    gbxUpdateContainer.Size = new Size(217, 217);
                    gbxUpdateContainer.Location = new Point(13, 13);
                    gbxUpdateContainer.Text = "Kurs";

                    this.Size = new Size(262, 288 + System.Windows.Forms.SystemInformation.CaptionHeight);
                    this.FormBorderStyle = FormBorderStyle.FixedSingle;

                    btnUpdate = new Button();
                    this.Controls.Add(btnUpdate);
                    btnUpdate.Location = new Point(13, 235);
                    btnUpdate.Size = new Size((this.Width - 40) / 2, 20);
                    btnUpdate.Text = "Uppdatera";

                    btnAbort = new Button();
                    this.Controls.Add(btnAbort);
                    btnAbort.Location = new Point(13 + ((this.Width - 40) / 2), 235);
                    btnAbort.Size = new Size((this.Width - 40) / 2, 20);
                    btnAbort.Text = "Avbryt";

                    lblCourseCode = new Label();
                    lblCourseEnd = new Label();
                    lblCourseName = new Label();
                    lblCoursePoints = new Label();
                    lblCourseStart = new Label();

                    tbxCourseCode = new TextBox();
                    tbxCourseEnd = new TextBox();
                    tbxCourseName = new TextBox();
                    tbxCoursePoints = new TextBox();
                    tbxCourseStart = new TextBox();

                    this.Controls.Add(lblCourseCode);
                    this.Controls.Add(lblCourseEnd);
                    this.Controls.Add(lblCourseName);
                    this.Controls.Add(lblCoursePoints);
                    this.Controls.Add(lblCourseStart);
                    this.Controls.Add(tbxCourseCode);
                    this.Controls.Add(tbxCourseEnd);
                    this.Controls.Add(tbxCoursePoints);
                    this.Controls.Add(tbxCourseName);
                    this.Controls.Add(tbxCourseStart);

                    gbxUpdateContainer.Controls.Add(lblCourseCode);
                    gbxUpdateContainer.Controls.Add(lblCourseEnd);
                    gbxUpdateContainer.Controls.Add(lblCourseName);
                    gbxUpdateContainer.Controls.Add(lblCoursePoints);
                    gbxUpdateContainer.Controls.Add(lblCourseStart);
                    gbxUpdateContainer.Controls.Add(tbxCourseCode);
                    gbxUpdateContainer.Controls.Add(tbxCourseEnd);
                    gbxUpdateContainer.Controls.Add(tbxCoursePoints);
                    gbxUpdateContainer.Controls.Add(tbxCourseName);
                    gbxUpdateContainer.Controls.Add(tbxCourseStart);

                    lblCourseCode.Text = "Kod";
                    lblCourseCode.Location = new Point(6, 90);
                    lblCourseCode.Size = new Size(26,13);

                    lblCourseEnd.Text = "Slut";
                    lblCourseEnd.Location = new Point(6,190);
                    lblCourseEnd.Size = new Size(25,13);

                    lblCourseName.Text = "Namn";
                    lblCourseName.Location = new Point(6, 30);
                    lblCourseName.Size = new Size(35,13);

                    lblCoursePoints.Text = "Omfattning";
                    lblCoursePoints.Location = new Point(6,125);
                    lblCoursePoints.Size = new Size(58,13);

                    lblCourseStart.Text = "Start";
                    lblCourseStart.Location = new Point(6,160);
                    lblCourseStart.Size = new Size(29,13);

                    tbxCourseCode.Location = new Point(131,87);
                    tbxCourseCode.Size = new Size(80,20);

                    tbxCourseEnd.Location = new Point(85,187);
                    tbxCourseEnd.Size = new Size(126,20);

                    tbxCourseName.Location = new Point(6,50);
                    tbxCourseName.Size = new Size(205,20);

                    tbxCoursePoints.Location = new Point(147,122);
                    tbxCoursePoints.Size = new Size(64,20);

                    tbxCourseStart.Location = new Point(85,157);
                    tbxCourseStart.Size = new Size(126,20);

                    tbxCourseCode.Text = course.CourseCode;
                    tbxCourseEnd.Text = course.CourseEndDate.ToShortDateString();
                    tbxCourseName.Text = course.CourseName;
                    tbxCoursePoints.Text = course.CoursePoints.ToString();
                    tbxCourseStart.Text = course.CourseStartDate.ToShortDateString();
                    break;

                default:
                    break;
            }

            btnUpdate.Click += btnUpdateClick;
            btnAbort.Click += btnAbortClick;
        }

        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (areInputsCorrect(updateCase))
            {
                string authenticationString = "server=192.168.2.209; port=3306; " + "database=School; uid=DataDennisCunt7; pwd=MicrophoneRedKlyft67#;";
                MySqlConnection updateConnection = new MySqlConnection(authenticationString);
                updateConnection.Open();

                MySqlCommand sqlCmd = new MySqlCommand("SELECT * FROM students", updateConnection);

                switch (updateCase)
                {
                    case "student":
                        sqlCmd = new MySqlCommand("UPDATE students SET name = '" + tbxStudentName.Text + "', class = '" + tbxStudentClass.Text + "', email = '" + tbxStudentEmail.Text + "', phone = '" + tbxStudentPhone.Text + "' WHERE name = '" + studentData.StudentName + "';", updateConnection);
                        break;
                    case "teacher":
                        sqlCmd = new MySqlCommand("UPDATE teachers SET name = '" + tbxTeacherName.Text + "', code = '" + tbxTeacherCode.Text + "', email = '" + tbxTeacherEmail.Text + "', phone = '" + tbxTeacherPhone.Text + "' WHERE name = '" + teacherData.TeacherName + "';", updateConnection);
                        break;
                    case "course":
                        sqlCmd = new MySqlCommand("UPDATE courses SET name = '" + tbxCourseName.Text + "', code = '" + tbxCourseCode.Text + "', size = '" + int.Parse(tbxCoursePoints.Text) + "', start = '" + DateTime.Parse(tbxCourseStart.Text).ToString(CultureInfo.InvariantCulture.DateTimeFormat.SortableDateTimePattern) + "', end = '" + DateTime.Parse(tbxCourseEnd.Text).ToString(CultureInfo.InvariantCulture.DateTimeFormat.SortableDateTimePattern) + "' WHERE name = '" + courseData.CourseName + "';", updateConnection);
                        break;
                }

                int affectedRows = sqlCmd.ExecuteNonQuery();
                updateConnection.Close();

                if (updateCase == "student")
                {
                    if (affectedRows == 1)
                    {
                        MessageBox.Show(this, "En elev uppdaterades", "Uppdatering genomförd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else if (affectedRows > 1)
                    {
                        MessageBox.Show(this, "Mer än en elev uppdaterades. Om detta inte var meningen så bör du kontakta databasadministratören.", "Uppdatering misslyckades", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                    else if (affectedRows == 0)
                    {
                        MessageBox.Show(this, "Ingen elev uppdaterades. Försök igen.", "Uppdatering misslyckades", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
                else if (updateCase == "teacher")
                {
                    if (affectedRows == 1)
                    {
                        MessageBox.Show(this, "En lärare uppdaterades", "Uppdatering genomförd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else if (affectedRows > 1)
                    {
                        MessageBox.Show(this, "Mer än en lärare uppdaterades. Om detta inte var meningen så bör du kontakta databasadministratören.", "Uppdatering misslyckades", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                    else if (affectedRows == 0)
                    {
                        MessageBox.Show(this, "Ingen lärare uppdaterades. Försök igen.", "Uppdatering misslyckades", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
                else if (updateCase == "course")
                {
                    if (affectedRows == 1)
                    {
                        MessageBox.Show(this, "En kurs uppdaterades", "Uppdatering genomförd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else if (affectedRows > 1)
                    {
                        MessageBox.Show(this, "Mer än en kurs uppdaterades. Om detta inte var meningen så bör du kontakta databasadministratören.", "Uppdatering misslyckades", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                    else if (affectedRows == 0)
                    {
                        MessageBox.Show(this, "Ingen kurs uppdaterades. Försök igen.", "Uppdatering misslyckades", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Var vänlig se till att eventuella datum och sifferfält enbart innehåller datum (enligt formatet åååå-mm-dd) eller siffror. Kontrollera även att inga fält lämnats tomma.", "Fel i inmatning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool areInputsCorrect (string updateCase)
        {
            bool result = false;

            if (updateCase == "course")
            {
                bool pointsCorrect = false;
                bool startDateCorrect = false;
                bool endDateCorrect = false;

                if (!string.IsNullOrEmpty(tbxCoursePoints.Text) && !string.IsNullOrWhiteSpace(tbxCoursePoints.Text))
                {
                    if (int.TryParse(tbxCoursePoints.Text, out int outPut))
                    {
                        pointsCorrect = true;
                    }
                }

                if (!string.IsNullOrEmpty(tbxCourseStart.Text) && !string.IsNullOrWhiteSpace(tbxCourseStart.Text))
                {
                    if (DateTime.TryParse(tbxCourseStart.Text, out DateTime result1))
                    {
                        startDateCorrect = true;
                    }
                }

                if (!string.IsNullOrEmpty(tbxCourseEnd.Text) && !string.IsNullOrWhiteSpace(tbxCourseEnd.Text))
                {
                    if (DateTime.TryParse(tbxCourseEnd.Text, out DateTime result2))
                    {
                        endDateCorrect = true;
                    }
                }

                result = (!string.IsNullOrEmpty(tbxCourseName.Text) && !string.IsNullOrWhiteSpace(tbxCourseName.Text) && !string.IsNullOrEmpty(tbxCourseCode.Text) && !string.IsNullOrWhiteSpace(tbxCourseCode.Text) && !string.IsNullOrEmpty(tbxCoursePoints.Text) && !string.IsNullOrWhiteSpace(tbxCoursePoints.Text) && !string.IsNullOrEmpty(tbxCourseStart.Text) && !string.IsNullOrWhiteSpace(tbxCourseStart.Text) && !string.IsNullOrEmpty(tbxCourseEnd.Text) && !string.IsNullOrWhiteSpace(tbxCourseEnd.Text) && pointsCorrect && startDateCorrect && endDateCorrect);
            }
            else if (updateCase == "student")
            {
                result = (!string.IsNullOrEmpty(tbxStudentName.Text) && !string.IsNullOrWhiteSpace(tbxStudentName.Text) && !string.IsNullOrEmpty(tbxStudentClass.Text) && !string.IsNullOrWhiteSpace(tbxStudentClass.Text) && !string.IsNullOrEmpty(tbxStudentEmail.Text) && !string.IsNullOrWhiteSpace(tbxStudentEmail.Text) && !string.IsNullOrEmpty(tbxStudentPhone.Text) && !string.IsNullOrWhiteSpace(tbxStudentPhone.Text));
            }
            else if (updateCase == "teacher")
            {
                result = (!string.IsNullOrEmpty(tbxTeacherName.Text) && !string.IsNullOrWhiteSpace(tbxTeacherName.Text) && !string.IsNullOrEmpty(tbxTeacherCode.Text) && !string.IsNullOrWhiteSpace(tbxTeacherCode.Text) && !string.IsNullOrEmpty(tbxTeacherEmail.Text) && !string.IsNullOrWhiteSpace(tbxTeacherEmail.Text) && !string.IsNullOrEmpty(tbxTeacherPhone.Text) && !string.IsNullOrWhiteSpace(tbxTeacherPhone.Text));
            }

            return result;
        }
        private void btnAbortClick (object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
