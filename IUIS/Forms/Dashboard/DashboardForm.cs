using System;
using System.Drawing;
using System.Windows.Forms;
using IUIS.Models;
using IUIS.Forms.Login;
using IUIS.Forms.Enrollment;

namespace IUIS.Forms.Dashboard
{
    public partial class DashboardForm : Form
    {
        private User _currentUser;
        private Form? _activeForm;

        public DashboardForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            this.Text = $"IUIS - Dashboard ({_currentUser.Username})";
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;

            // Apply modern styling
            ApplyModernStyle();

            // Update welcome label
            lblWelcome.Text = $"Welcome, {_currentUser.FullName}";
            lblRole.Text = $"Role: {_currentUser.Role}";

            // Setup menu items based on role
            SetupMenuItems();
        }

        private void ApplyModernStyle()
        {
            // Main panel colors
            pnlSidebar.BackColor = Color.FromArgb(44, 62, 80);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 250;

            pnlTop.BackColor = Color.FromArgb(52, 73, 94);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 60;

            pnlContent.BackColor = Color.FromArgb(245, 247, 250);
            pnlContent.Dock = DockStyle.Fill;

            // Welcome label styling
            lblWelcome.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.AutoSize = true;

            lblRole.Font = new Font("Segoe UI", 10F);
            lblRole.ForeColor = Color.FromArgb(189, 195, 199);
            lblRole.AutoSize = true;

            // Button styling helper
            StyleMenuButton(btnStudents);
            StyleMenuButton(btnCourses);
            StyleMenuButton(btnSubjects);
            StyleMenuButton(btnEnrollment);
            StyleMenuButton(btnPayments);
            StyleMenuButton(btnLibrary);
            StyleMenuButton(btnEmployees);
            StyleMenuButton(btnAttendance);
            StyleMenuButton(btnCounseling);
            StyleMenuButton(btnViolations);
            StyleMenuButton(btnMedical);
            StyleMenuButton(btnClearances);
            StyleMenuButton(btnUsers);
            StyleMenuButton(btnLogout);
        }

        private void StyleMenuButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.FromArgb(236, 240, 241);
            btn.Font = new Font("Segoe UI", 10F);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Cursor = Cursors.Hand;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            
            // Add hover effect
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(52, 73, 94);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.Transparent;
        }

        private void SetupMenuItems()
        {
            // Show/hide modules based on role
            bool isAdmin = _currentUser.Role == "Administrator";

            btnUsers.Visible = isAdmin;
            
            // All other modules visible for now (can be customized per role)
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.StartPosition = FormStartPosition.Manual;
            childForm.Location = new Point(0, 0);
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        #region Menu Button Click Handlers

        private void BtnStudents_Click(object sender, EventArgs e)
        {
            var form = new Students.StudentForm();
            OpenChildForm(form, sender);
        }

        private void BtnCourses_Click(object sender, EventArgs e)
        {
            var form = new Courses.CourseForm();
            OpenChildForm(form, sender);
        }

        private void BtnSubjects_Click(object sender, EventArgs e)
        {
            var form = new Subjects.SubjectsForm();
            OpenChildForm(form, sender);
        }

        private void BtnEnrollment_Click(object sender, EventArgs e)
        {
            var form = new EnrollmentForm();
            OpenChildForm(form, sender);
        }

        private void BtnPayments_Click(object sender, EventArgs e)
        {
            var form = new Payments.PaymentsForm();
            OpenChildForm(form, sender);
        }

        private void BtnLibrary_Click(object sender, EventArgs e)
        {
            var form = new Library.LibraryForm();
            OpenChildForm(form, sender);
        }

        private void BtnEmployees_Click(object sender, EventArgs e)
        {
            var form = new Employees.EmployeesForm();
            OpenChildForm(form, sender);
        }

        private void BtnAttendance_Click(object sender, EventArgs e)
        {
            var form = new Attendance.AttendanceForm();
            OpenChildForm(form, sender);
        }

        private void BtnCounseling_Click(object sender, EventArgs e)
        {
            var form = new Counseling.CounselingForm();
            OpenChildForm(form, sender);
        }

        private void BtnViolations_Click(object sender, EventArgs e)
        {
            var form = new Form(); // Create ViolationForm later
            OpenChildForm(form, sender);
        }

        private void BtnMedical_Click(object sender, EventArgs e)
        {
            var form = new Medical.MedicalForm();
            OpenChildForm(form, sender);
        }

        private void BtnClearances_Click(object sender, EventArgs e)
        {
            var form = new Form(); // Create ClearanceForm later
            OpenChildForm(form, sender);
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            var form = new Form(); // Create UserForm later
            OpenChildForm(form, sender);
        }

        #endregion

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void DashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
