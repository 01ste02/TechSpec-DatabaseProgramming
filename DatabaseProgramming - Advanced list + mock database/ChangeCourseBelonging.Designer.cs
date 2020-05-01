namespace DatabaseProgramming___Advanced_list___mock_database
{
    partial class ChangeCourseBelonging
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
        private void InitializeComponent()
        {
            this.lbxItemOne = new System.Windows.Forms.ListBox();
            this.lbxCourses = new System.Windows.Forms.ListBox();
            this.lblItemOne = new System.Windows.Forms.Label();
            this.lblICourses = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxItemOne
            // 
            this.lbxItemOne.FormattingEnabled = true;
            this.lbxItemOne.Location = new System.Drawing.Point(12, 25);
            this.lbxItemOne.Name = "lbxItemOne";
            this.lbxItemOne.Size = new System.Drawing.Size(200, 212);
            this.lbxItemOne.TabIndex = 2;
            this.lbxItemOne.SelectedIndexChanged += new System.EventHandler(this.lbxItemOne_SelectedIndexChanged);
            // 
            // lbxCourses
            // 
            this.lbxCourses.FormattingEnabled = true;
            this.lbxCourses.Location = new System.Drawing.Point(218, 25);
            this.lbxCourses.Name = "lbxCourses";
            this.lbxCourses.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxCourses.Size = new System.Drawing.Size(200, 212);
            this.lbxCourses.TabIndex = 3;
            // 
            // lblItemOne
            // 
            this.lblItemOne.AutoSize = true;
            this.lblItemOne.Location = new System.Drawing.Point(12, 9);
            this.lblItemOne.Name = "lblItemOne";
            this.lblItemOne.Size = new System.Drawing.Size(35, 13);
            this.lblItemOne.TabIndex = 4;
            this.lblItemOne.Text = "label1";
            // 
            // lblICourses
            // 
            this.lblICourses.AutoSize = true;
            this.lblICourses.Location = new System.Drawing.Point(218, 9);
            this.lblICourses.Name = "lblICourses";
            this.lblICourses.Size = new System.Drawing.Size(37, 13);
            this.lblICourses.TabIndex = 5;
            this.lblICourses.Text = "Kurser";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 244);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(200, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Uppdatera";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(218, 244);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(200, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Stäng/Avbryt";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ChangeCourseBelonging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 280);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblICourses);
            this.Controls.Add(this.lblItemOne);
            this.Controls.Add(this.lbxCourses);
            this.Controls.Add(this.lbxItemOne);
            this.Name = "ChangeCourseBelonging";
            this.Text = "ChangeCourseBelonging";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxItemOne;
        private System.Windows.Forms.ListBox lbxCourses;
        private System.Windows.Forms.Label lblItemOne;
        private System.Windows.Forms.Label lblICourses;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
    }
}