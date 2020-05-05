namespace DatabaseProgramming___Advanced_list___mock_database
{
    partial class ChangeCourseBelongingStudent
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
            this.lbxClasses = new System.Windows.Forms.ListBox();
            this.lbxStudents = new System.Windows.Forms.ListBox();
            this.lblClasses = new System.Windows.Forms.Label();
            this.lblIStudents = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxClasses
            // 
            this.lbxClasses.FormattingEnabled = true;
            this.lbxClasses.Location = new System.Drawing.Point(12, 25);
            this.lbxClasses.Name = "lbxClasses";
            this.lbxClasses.Size = new System.Drawing.Size(200, 212);
            this.lbxClasses.TabIndex = 2;
            this.lbxClasses.SelectedIndexChanged += new System.EventHandler(this.lbxClasses_SelectedIndexChanged);
            // 
            // lbxStudents
            // 
            this.lbxStudents.FormattingEnabled = true;
            this.lbxStudents.Location = new System.Drawing.Point(218, 25);
            this.lbxStudents.Name = "lbxStudents";
            this.lbxStudents.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxStudents.Size = new System.Drawing.Size(200, 212);
            this.lbxStudents.TabIndex = 3;
            this.lbxStudents.SelectedIndexChanged += new System.EventHandler(this.lbxStudents_SelectedIndexChanged);
            // 
            // lblClasses
            // 
            this.lblClasses.AutoSize = true;
            this.lblClasses.Location = new System.Drawing.Point(12, 9);
            this.lblClasses.Name = "lblClasses";
            this.lblClasses.Size = new System.Drawing.Size(41, 13);
            this.lblClasses.TabIndex = 4;
            this.lblClasses.Text = "Klasser";
            // 
            // lblIStudents
            // 
            this.lblIStudents.AutoSize = true;
            this.lblIStudents.Location = new System.Drawing.Point(218, 9);
            this.lblIStudents.Name = "lblIStudents";
            this.lblIStudents.Size = new System.Drawing.Size(37, 13);
            this.lblIStudents.TabIndex = 5;
            this.lblIStudents.Text = "Elever";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 244);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(138, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Uppdatera";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(267, 244);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(151, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Stäng/Avbryt";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Location = new System.Drawing.Point(156, 244);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(105, 23);
            this.btnClearSelection.TabIndex = 8;
            this.btnClearSelection.Text = "Rensa";
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // ChangeCourseBelongingStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 280);
            this.Controls.Add(this.btnClearSelection);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblIStudents);
            this.Controls.Add(this.lblClasses);
            this.Controls.Add(this.lbxStudents);
            this.Controls.Add(this.lbxClasses);
            this.Name = "ChangeCourseBelongingStudent";
            this.Text = "ChangeCourseBelonging";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxClasses;
        private System.Windows.Forms.ListBox lbxStudents;
        private System.Windows.Forms.Label lblClasses;
        private System.Windows.Forms.Label lblIStudents;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClearSelection;
    }
}