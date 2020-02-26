namespace DatabaseProgramming
{
    partial class CourseView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.lblCourseName = new System.Windows.Forms.Label();
            this.tbxCourseName = new System.Windows.Forms.TextBox();
            this.lblCourseCode = new System.Windows.Forms.Label();
            this.lblCoursePoints = new System.Windows.Forms.Label();
            this.lblCourseStart = new System.Windows.Forms.Label();
            this.lblCourseEnd = new System.Windows.Forms.Label();
            this.lblCourseActive = new System.Windows.Forms.Label();
            this.tbxCourseCode = new System.Windows.Forms.TextBox();
            this.tbxCoursePoints = new System.Windows.Forms.TextBox();
            this.tbxCourseStart = new System.Windows.Forms.TextBox();
            this.tbxCourseEnd = new System.Windows.Forms.TextBox();
            this.tbxCourseActive = new System.Windows.Forms.TextBox();
            this.lblCourseList = new System.Windows.Forms.Label();
            this.lbxCourseList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Location = new System.Drawing.Point(13, 13);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(35, 13);
            this.lblCourseName.TabIndex = 0;
            this.lblCourseName.Text = "Namn";
            // 
            // tbxCourseName
            // 
            this.tbxCourseName.Location = new System.Drawing.Point(13, 30);
            this.tbxCourseName.Name = "tbxCourseName";
            this.tbxCourseName.Size = new System.Drawing.Size(179, 20);
            this.tbxCourseName.TabIndex = 1;
            // 
            // lblCourseCode
            // 
            this.lblCourseCode.AutoSize = true;
            this.lblCourseCode.Location = new System.Drawing.Point(13, 60);
            this.lblCourseCode.Name = "lblCourseCode";
            this.lblCourseCode.Size = new System.Drawing.Size(46, 13);
            this.lblCourseCode.TabIndex = 2;
            this.lblCourseCode.Text = "Kurskod";
            // 
            // lblCoursePoints
            // 
            this.lblCoursePoints.AutoSize = true;
            this.lblCoursePoints.Location = new System.Drawing.Point(13, 87);
            this.lblCoursePoints.Name = "lblCoursePoints";
            this.lblCoursePoints.Size = new System.Drawing.Size(58, 13);
            this.lblCoursePoints.TabIndex = 3;
            this.lblCoursePoints.Text = "Omfattning";
            // 
            // lblCourseStart
            // 
            this.lblCourseStart.AutoSize = true;
            this.lblCourseStart.Location = new System.Drawing.Point(13, 113);
            this.lblCourseStart.Name = "lblCourseStart";
            this.lblCourseStart.Size = new System.Drawing.Size(29, 13);
            this.lblCourseStart.TabIndex = 4;
            this.lblCourseStart.Text = "Start";
            // 
            // lblCourseEnd
            // 
            this.lblCourseEnd.AutoSize = true;
            this.lblCourseEnd.Location = new System.Drawing.Point(13, 139);
            this.lblCourseEnd.Name = "lblCourseEnd";
            this.lblCourseEnd.Size = new System.Drawing.Size(25, 13);
            this.lblCourseEnd.TabIndex = 5;
            this.lblCourseEnd.Text = "Slut";
            // 
            // lblCourseActive
            // 
            this.lblCourseActive.AutoSize = true;
            this.lblCourseActive.Location = new System.Drawing.Point(13, 165);
            this.lblCourseActive.Name = "lblCourseActive";
            this.lblCourseActive.Size = new System.Drawing.Size(35, 13);
            this.lblCourseActive.TabIndex = 6;
            this.lblCourseActive.Text = "Pågår";
            // 
            // tbxCourseCode
            // 
            this.tbxCourseCode.Location = new System.Drawing.Point(131, 57);
            this.tbxCourseCode.Name = "tbxCourseCode";
            this.tbxCourseCode.Size = new System.Drawing.Size(61, 20);
            this.tbxCourseCode.TabIndex = 7;
            // 
            // tbxCoursePoints
            // 
            this.tbxCoursePoints.Location = new System.Drawing.Point(154, 84);
            this.tbxCoursePoints.Name = "tbxCoursePoints";
            this.tbxCoursePoints.Size = new System.Drawing.Size(37, 20);
            this.tbxCoursePoints.TabIndex = 8;
            // 
            // tbxCourseStart
            // 
            this.tbxCourseStart.Location = new System.Drawing.Point(92, 110);
            this.tbxCourseStart.Name = "tbxCourseStart";
            this.tbxCourseStart.Size = new System.Drawing.Size(100, 20);
            this.tbxCourseStart.TabIndex = 9;
            // 
            // tbxCourseEnd
            // 
            this.tbxCourseEnd.Location = new System.Drawing.Point(91, 136);
            this.tbxCourseEnd.Name = "tbxCourseEnd";
            this.tbxCourseEnd.Size = new System.Drawing.Size(100, 20);
            this.tbxCourseEnd.TabIndex = 10;
            // 
            // tbxCourseActive
            // 
            this.tbxCourseActive.Location = new System.Drawing.Point(164, 162);
            this.tbxCourseActive.Name = "tbxCourseActive";
            this.tbxCourseActive.Size = new System.Drawing.Size(26, 20);
            this.tbxCourseActive.TabIndex = 11;
            // 
            // lblCourseList
            // 
            this.lblCourseList.AutoSize = true;
            this.lblCourseList.Location = new System.Drawing.Point(225, 13);
            this.lblCourseList.Name = "lblCourseList";
            this.lblCourseList.Size = new System.Drawing.Size(63, 13);
            this.lblCourseList.TabIndex = 12;
            this.lblCourseList.Text = "Mina Kurser";
            // 
            // lbxCourseList
            // 
            this.lbxCourseList.FormattingEnabled = true;
            this.lbxCourseList.Location = new System.Drawing.Point(228, 35);
            this.lbxCourseList.Name = "lbxCourseList";
            this.lbxCourseList.Size = new System.Drawing.Size(127, 147);
            this.lbxCourseList.TabIndex = 13;
            this.lbxCourseList.SelectedIndexChanged += new System.EventHandler(this.lbxCourseList_SelectedIndexChanged);
            // 
            // CourseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 193);
            this.Controls.Add(this.lbxCourseList);
            this.Controls.Add(this.lblCourseList);
            this.Controls.Add(this.tbxCourseActive);
            this.Controls.Add(this.tbxCourseEnd);
            this.Controls.Add(this.tbxCourseStart);
            this.Controls.Add(this.tbxCoursePoints);
            this.Controls.Add(this.tbxCourseCode);
            this.Controls.Add(this.lblCourseActive);
            this.Controls.Add(this.lblCourseEnd);
            this.Controls.Add(this.lblCourseStart);
            this.Controls.Add(this.lblCoursePoints);
            this.Controls.Add(this.lblCourseCode);
            this.Controls.Add(this.tbxCourseName);
            this.Controls.Add(this.lblCourseName);
            this.Name = "CourseView";
            this.Text = "Mina Kurser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.TextBox tbxCourseName;
        private System.Windows.Forms.Label lblCourseCode;
        private System.Windows.Forms.Label lblCoursePoints;
        private System.Windows.Forms.Label lblCourseStart;
        private System.Windows.Forms.Label lblCourseEnd;
        private System.Windows.Forms.Label lblCourseActive;
        private System.Windows.Forms.TextBox tbxCourseCode;
        private System.Windows.Forms.TextBox tbxCoursePoints;
        private System.Windows.Forms.TextBox tbxCourseStart;
        private System.Windows.Forms.TextBox tbxCourseEnd;
        private System.Windows.Forms.TextBox tbxCourseActive;
        private System.Windows.Forms.Label lblCourseList;
        private System.Windows.Forms.ListBox lbxCourseList;
    }
}

