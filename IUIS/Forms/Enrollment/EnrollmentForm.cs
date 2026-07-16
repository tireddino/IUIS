using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IUIS.Models;
using IUIS.Utilities;
using EnrollmentModel = IUIS.Models.Enrollment;

namespace IUIS.Forms.Enrollment
{
    public partial class EnrollmentForm : Form
    {
        private StudentRepository _studentRepo = null!;
        private SubjectRepository _subjectRepo = null!;
        private EnrollmentRepository _enrollmentRepo = null!;
        private CourseRepository _courseRepo = null!;

        private Student? _selectedStudent;
        private List<Subject> _selectedSubjects = new List<Subject>();
        private decimal _miscellaneousFee = 3500.00m; // Base misc fee
        private decimal _tuitionPerUnit = 1200.00m;   // Estimated per unit cost

        public EnrollmentForm()
        {
            InitializeComponent();
            InitializeRepositories();
            InitializeCustomStyles();
            LoadStudents();
            LoadAcademicYears();
            
            dgvSelectedSubjects.DataSource = null;
            dgvSelectedSubjects.AutoGenerateColumns = false;
            SetupSubjectGridColumns();
        }

        private void InitializeRepositories()
        {
            _studentRepo = new StudentRepository();
            _subjectRepo = new SubjectRepository();
            _enrollmentRepo = new EnrollmentRepository();
            _courseRepo = new CourseRepository();
        }

        private void InitializeCustomStyles()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(240, 240, 240);

            // Panel Styles
            pnlTop.BackColor = Color.FromArgb(0, 51, 102); // BatStateU Blue
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 60;

            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 15);

            // Group Boxes
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is GroupBox gb)
                {
                    gb.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    gb.ForeColor = Color.FromArgb(0, 51, 102);
                    gb.FlatStyle = FlatStyle.Standard;
                }
            }

            // Buttons
            btnEnroll.BackColor = Color.FromArgb(0, 153, 76);
            btnEnroll.ForeColor = Color.White;
            btnEnroll.FlatStyle = FlatStyle.Flat;
            btnEnroll.FlatAppearance.BorderSize = 0;
            btnEnroll.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            btnCancel.BackColor = Color.FromArgb(204, 0, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            btnAddSubject.BackColor = Color.FromArgb(0, 102, 204);
            btnAddSubject.ForeColor = Color.White;
            btnAddSubject.FlatStyle = FlatStyle.Flat;
            btnAddSubject.FlatAppearance.BorderSize = 0;

            btnRemoveSubject.BackColor = Color.FromArgb(204, 0, 0);
            btnRemoveSubject.ForeColor = Color.White;
            btnRemoveSubject.FlatStyle = FlatStyle.Flat;
            btnRemoveSubject.FlatAppearance.BorderSize = 0;
        }

        private void LoadStudents()
        {
            var students = _studentRepo.GetAll();
            cmbStudents.DataSource = students;
            cmbStudents.DisplayMember = "FullName";
            cmbStudents.ValueMember = "Id";
            cmbStudents.SelectedIndex = -1;
        }

        private void LoadAcademicYears()
        {
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear - 2; i <= currentYear + 1; i++)
            {
                cmbAcadYear.Items.Add($"{i}-{i + 1}");
            }
            cmbAcadYear.SelectedItem = $"{currentYear}-{currentYear + 1}";
        }

        private void SetupSubjectGridColumns()
        {
            DataGridViewTextBoxColumn colCode = new DataGridViewTextBoxColumn();
            colCode.HeaderText = "Code";
            colCode.DataPropertyName = "Code";
            colCode.Width = 80;

            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.HeaderText = "Description";
            colDesc.DataPropertyName = "Description";
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn colUnits = new DataGridViewTextBoxColumn();
            colUnits.HeaderText = "Units";
            colUnits.DataPropertyName = "Units";
            colUnits.Width = 60;

            dgvSelectedSubjects.Columns.AddRange(colCode, colDesc, colUnits);
        }

        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudents.SelectedItem != null)
            {
                _selectedStudent = (Student)cmbStudents.SelectedItem;
                LoadStudentDetails();
                LoadAvailableSubjects();
            }
            else
            {
                ClearForm();
            }
        }

        private void LoadStudentDetails()
        {
            if (_selectedStudent == null) return;

            lblStudId.Text = _selectedStudent.StudentId;
            lblStudName.Text = _selectedStudent.FullName;
            
            // Get course name - try multiple approaches
            string courseName = _selectedStudent.Course;
            
            if (string.IsNullOrEmpty(courseName) && !string.IsNullOrEmpty(_selectedStudent.CourseId))
            {
                // First try to find by CourseCode
                var course = _courseRepo.GetByCourseCode(_selectedStudent.CourseId);
                
                // If not found by code, try to find by searching all courses for matching Id or Name
                if (course == null)
                {
                    var allCourses = _courseRepo.GetAll();
                    course = allCourses.FirstOrDefault(c => c.Id == _selectedStudent.CourseId) 
                          ?? allCourses.FirstOrDefault(c => c.CourseCode == _selectedStudent.CourseId);
                }
                
                courseName = course?.CourseName ?? _selectedStudent.CourseId;
            }
            
            lblStudCourse.Text = courseName;
            
            lblStudYear.Text = _selectedStudent.YearLevel.ToString();
            
            // Check existing enrollment for current term
            string currentTerm = GetSelectedTerm();
            var existing = _enrollmentRepo.GetByStudentAndTerm(_selectedStudent.StudentId, currentTerm);
            
            if (existing != null)
            {
                LoadExistingEnrollment(existing);
            }
            else
            {
                ClearSelections();
            }
        }

        private string GetSelectedTerm()
        {
            return $"{cmbAcadYear.SelectedItem}-{cmbSemester.SelectedItem}";
        }

        private void LoadAvailableSubjects()
        {
            if (_selectedStudent == null) return;

            // Get selected semester number (1, 2, or 3 for Summer)
            int selectedSemesterNum = GetSelectedSemesterNumber();

            // Filter subjects by course and year level
            var allSubjects = _subjectRepo.GetAll();
            var filtered = allSubjects.Where(s => 
                s.CourseCode == _selectedStudent.Course && 
                s.YearLevel == _selectedStudent.YearLevel &&
                s.Semester == selectedSemesterNum
            ).ToList();

            cmbSubjectList.DataSource = filtered;
            cmbSubjectList.DisplayMember = "DisplayName";
            cmbSubjectList.ValueMember = "Code";
        }

        private int GetSelectedSemesterNumber()
        {
            string selectedText = cmbSemester.SelectedItem?.ToString() ?? "";
            if (selectedText.Contains("1st")) return 1;
            if (selectedText.Contains("2nd")) return 2;
            if (selectedText.IndexOf("Summer", StringComparison.OrdinalIgnoreCase) >= 0) return 3;
            return 1; // Default to 1st semester
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            if (cmbSubjectList.SelectedItem == null) return;

            var subject = (Subject)cmbSubjectList.SelectedItem;
            
            if (_selectedSubjects.Any(s => s.SubjectCode == subject.SubjectCode))
            {
                MessageBox.Show("Subject already added!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _selectedSubjects.Add(subject);
            RefreshSubjectGrid();
            CalculateFees();
        }

        private void btnRemoveSubject_Click(object sender, EventArgs e)
        {
            if (dgvSelectedSubjects.CurrentRow != null && dgvSelectedSubjects.CurrentRow.Index >= 0)
            {
                var subject = (Subject)dgvSelectedSubjects.CurrentRow.DataBoundItem;
                if (subject != null)
                {
                    _selectedSubjects.Remove(subject);
                    RefreshSubjectGrid();
                    CalculateFees();
                }
            }
        }

        private void RefreshSubjectGrid()
        {
            dgvSelectedSubjects.DataSource = null;
            dgvSelectedSubjects.DataSource = _selectedSubjects;
        }

        private void CalculateFees()
        {
            int totalUnits = _selectedSubjects.Sum(s => s.Units);
            decimal tuition = totalUnits * _tuitionPerUnit;
            decimal totalFees = tuition + _miscellaneousFee;

            lblTotalUnits.Text = totalUnits.ToString();
            lblTuitionFee.Text = tuition.ToString("C2");
            lblMiscFee.Text = _miscellaneousFee.ToString("C2");
            lblTotalAssessment.Text = totalFees.ToString("C2");

            // Update Balance
            decimal paid = string.IsNullOrEmpty(txtAmountPaid.Text) ? 0 : decimal.Parse(txtAmountPaid.Text);
            decimal balance = totalFees - paid;
            lblBalance.Text = balance.ToString("C2");

            UpdateEnrollmentStatus(balance);
        }

        private void UpdateEnrollmentStatus(decimal balance)
        {
            if (_selectedSubjects.Count == 0)
            {
                lblStatus.Text = "No Subjects";
                lblStatus.ForeColor = Color.Gray;
            }
            else if (balance <= 0)
            {
                lblStatus.Text = "FULLY ENROLLED";
                lblStatus.ForeColor = Color.Green;
                lblStatus.Font = new Font(lblStatus.Font, FontStyle.Bold);
            }
            else
            {
                lblStatus.Text = "PENDING PAYMENT";
                lblStatus.ForeColor = Color.OrangeRed;
                lblStatus.Font = new Font(lblStatus.Font, FontStyle.Regular);
            }
        }

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            CalculateFees();
        }

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAvailableSubjects();
            ClearSelections();
        }

        private void LoadExistingEnrollment(EnrollmentModel enrollment)
        {
            MessageBox.Show($"Loading existing enrollment for {GetSelectedTerm()}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearSelections()
        {
            _selectedSubjects.Clear();
            RefreshSubjectGrid();
            txtAmountPaid.Text = "0";
            lblTotalUnits.Text = "0";
            lblTuitionFee.Text = "0.00";
            lblTotalAssessment.Text = "0.00";
            lblBalance.Text = "0.00";
            lblStatus.Text = "New Enrollment";
            lblStatus.ForeColor = Color.Blue;
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if (_selectedStudent == null)
            {
                MessageBox.Show("Please select a student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_selectedSubjects.Count == 0)
            {
                MessageBox.Show("Please add at least one subject.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string term = GetSelectedTerm();
                
                var enrollment = new EnrollmentModel
                {
                    Id = Guid.NewGuid().ToString(),
                    EnrollmentId = Guid.NewGuid().ToString(),
                    StudentId = _selectedStudent.StudentId,
                    AcademicYear = cmbAcadYear.SelectedItem.ToString(),
                    Semester = cmbSemester.SelectedItem.ToString(),
                    Term = term,
                    DateEnrolled = DateTime.Now,
                    EnrollmentDate = DateTime.Now,
                    TotalUnits = _selectedSubjects.Sum(s => s.Units),
                    TuitionFee = decimal.Parse(lblTuitionFee.Text.Replace(",", "").Replace("₱", "").Replace("$", "").Trim()),
                    MiscellaneousFee = _miscellaneousFee,
                    TotalAssessment = decimal.Parse(lblTotalAssessment.Text.Replace(",", "").Replace("₱", "").Replace("$", "").Trim()),
                    AmountPaid = string.IsNullOrEmpty(txtAmountPaid.Text) ? 0 : decimal.Parse(txtAmountPaid.Text),
                    Balance = decimal.Parse(lblBalance.Text.Replace(",", "").Replace("₱", "").Replace("$", "").Trim()),
                    Status = lblStatus.Text,
                    Subjects = _selectedSubjects,
                    CreatedAt = DateTime.Now
                };

                _enrollmentRepo.Add(enrollment);

                if (enrollment.Balance <= 0)
                {
                    _selectedStudent.Status = "Active";
                    _studentRepo.Update(_selectedStudent);
                }

                MessageBox.Show("Enrollment saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadStudents();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving enrollment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            cmbStudents.SelectedIndex = -1;
            _selectedStudent = null;
            ClearSelections();
            lblStudId.Text = "---";
            lblStudName.Text = "---";
            lblStudCourse.Text = "---";
            lblStudYear.Text = "---";
        }

        private void btnPrintAssessment_Click(object sender, EventArgs e)
        {
            if (_selectedStudent == null || _selectedSubjects.Count == 0)
            {
                MessageBox.Show("No enrollment data to print.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Generating Assessment Form for " + _selectedStudent.FullName, "Print Preview", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
