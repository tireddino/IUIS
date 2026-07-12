namespace IUIS.Forms.Dashboard
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnCourses = new System.Windows.Forms.Button();
            this.btnSubjects = new System.Windows.Forms.Button();
            this.btnEnrollment = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnLibrary = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnCounseling = new System.Windows.Forms.Button();
            this.btnViolations = new System.Windows.Forms.Button();
            this.btnMedical = new System.Windows.Forms.Button();
            this.btnClearances = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnUsers);
            this.pnlSidebar.Controls.Add(this.btnClearances);
            this.pnlSidebar.Controls.Add(this.btnMedical);
            this.pnlSidebar.Controls.Add(this.btnViolations);
            this.pnlSidebar.Controls.Add(this.btnCounseling);
            this.pnlSidebar.Controls.Add(this.btnAttendance);
            this.pnlSidebar.Controls.Add(this.btnEmployees);
            this.pnlSidebar.Controls.Add(this.btnLibrary);
            this.pnlSidebar.Controls.Add(this.btnPayments);
            this.pnlSidebar.Controls.Add(this.btnEnrollment);
            this.pnlSidebar.Controls.Add(this.btnSubjects);
            this.pnlSidebar.Controls.Add(this.btnCourses);
            this.pnlSidebar.Controls.Add(this.btnStudents);
            this.pnlSidebar.Location = new System.Drawing.Point(0, 60);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 640);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblRole);
            this.pnlTop.Controls.Add(this.lblWelcome);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 60);
            this.pnlTop.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Location = new System.Drawing.Point(20, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(300, 25);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, User";
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(20, 40);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(200, 15);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Role: User";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(250, 60);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(950, 640);
            this.pnlContent.TabIndex = 2;
            // 
            // btnStudents
            // 
            this.btnStudents.Location = new System.Drawing.Point(10, 10);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(230, 40);
            this.btnStudents.TabIndex = 0;
            this.btnStudents.Text = "📚 Students";
            this.btnStudents.UseVisualStyleBackColor = true;
            this.btnStudents.Click += new System.EventHandler(this.BtnStudents_Click);
            // 
            // btnCourses
            // 
            this.btnCourses.Location = new System.Drawing.Point(10, 55);
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Size = new System.Drawing.Size(230, 40);
            this.btnCourses.TabIndex = 1;
            this.btnCourses.Text = "🎓 Courses";
            this.btnCourses.UseVisualStyleBackColor = true;
            this.btnCourses.Click += new System.EventHandler(this.BtnCourses_Click);
            // 
            // btnSubjects
            // 
            this.btnSubjects.Location = new System.Drawing.Point(10, 100);
            this.btnSubjects.Name = "btnSubjects";
            this.btnSubjects.Size = new System.Drawing.Size(230, 40);
            this.btnSubjects.TabIndex = 2;
            this.btnSubjects.Text = "📖 Subjects";
            this.btnSubjects.UseVisualStyleBackColor = true;
            this.btnSubjects.Click += new System.EventHandler(this.BtnSubjects_Click);
            // 
            // btnEnrollment
            // 
            this.btnEnrollment.Location = new System.Drawing.Point(10, 145);
            this.btnEnrollment.Name = "btnEnrollment";
            this.btnEnrollment.Size = new System.Drawing.Size(230, 40);
            this.btnEnrollment.TabIndex = 3;
            this.btnEnrollment.Text = "📝 Enrollment";
            this.btnEnrollment.UseVisualStyleBackColor = true;
            this.btnEnrollment.Click += new System.EventHandler(this.BtnEnrollment_Click);
            // 
            // btnPayments
            // 
            this.btnPayments.Location = new System.Drawing.Point(10, 190);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(230, 40);
            this.btnPayments.TabIndex = 4;
            this.btnPayments.Text = "💳 Payments";
            this.btnPayments.UseVisualStyleBackColor = true;
            this.btnPayments.Click += new System.EventHandler(this.BtnPayments_Click);
            // 
            // btnLibrary
            // 
            this.btnLibrary.Location = new System.Drawing.Point(10, 235);
            this.btnLibrary.Name = "btnLibrary";
            this.btnLibrary.Size = new System.Drawing.Size(230, 40);
            this.btnLibrary.TabIndex = 5;
            this.btnLibrary.Text = "📕 Library";
            this.btnLibrary.UseVisualStyleBackColor = true;
            this.btnLibrary.Click += new System.EventHandler(this.BtnLibrary_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Location = new System.Drawing.Point(10, 280);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(230, 40);
            this.btnEmployees.TabIndex = 6;
            this.btnEmployees.Text = "👨‍🏫 Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.BtnEmployees_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.Location = new System.Drawing.Point(10, 325);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(230, 40);
            this.btnAttendance.TabIndex = 7;
            this.btnAttendance.Text = "⏰ Attendance";
            this.btnAttendance.UseVisualStyleBackColor = true;
            this.btnAttendance.Click += new System.EventHandler(this.BtnAttendance_Click);
            // 
            // btnCounseling
            // 
            this.btnCounseling.Location = new System.Drawing.Point(10, 370);
            this.btnCounseling.Name = "btnCounseling";
            this.btnCounseling.Size = new System.Drawing.Size(230, 40);
            this.btnCounseling.TabIndex = 8;
            this.btnCounseling.Text = "💬 Counseling";
            this.btnCounseling.UseVisualStyleBackColor = true;
            this.btnCounseling.Click += new System.EventHandler(this.BtnCounseling_Click);
            // 
            // btnViolations
            // 
            this.btnViolations.Location = new System.Drawing.Point(10, 415);
            this.btnViolations.Name = "btnViolations";
            this.btnViolations.Size = new System.Drawing.Size(230, 40);
            this.btnViolations.TabIndex = 9;
            this.btnViolations.Text = "⚠️ Violations";
            this.btnViolations.UseVisualStyleBackColor = true;
            this.btnViolations.Click += new System.EventHandler(this.BtnViolations_Click);
            // 
            // btnMedical
            // 
            this.btnMedical.Location = new System.Drawing.Point(10, 460);
            this.btnMedical.Name = "btnMedical";
            this.btnMedical.Size = new System.Drawing.Size(230, 40);
            this.btnMedical.TabIndex = 10;
            this.btnMedical.Text = "🏥 Medical";
            this.btnMedical.UseVisualStyleBackColor = true;
            this.btnMedical.Click += new System.EventHandler(this.BtnMedical_Click);
            // 
            // btnClearances
            // 
            this.btnClearances.Location = new System.Drawing.Point(10, 505);
            this.btnClearances.Name = "btnClearances";
            this.btnClearances.Size = new System.Drawing.Size(230, 40);
            this.btnClearances.TabIndex = 11;
            this.btnClearances.Text = "✅ Clearances";
            this.btnClearances.UseVisualStyleBackColor = true;
            this.btnClearances.Click += new System.EventHandler(this.BtnClearances_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(10, 550);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(230, 40);
            this.btnUsers.TabIndex = 12;
            this.btnUsers.Text = "👤 Users";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.BtnUsers_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(10, 595);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(230, 40);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlTop);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IUIS Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DashboardForm_FormClosing);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnCourses;
        private System.Windows.Forms.Button btnSubjects;
        private System.Windows.Forms.Button btnEnrollment;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnLibrary;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Button btnCounseling;
        private System.Windows.Forms.Button btnViolations;
        private System.Windows.Forms.Button btnMedical;
        private System.Windows.Forms.Button btnClearances;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnLogout;
    }
}
