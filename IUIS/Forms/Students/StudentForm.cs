using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
#nullable enable
using IUIS.Models;
using IUIS.Utilities;

namespace IUIS.Forms.Students
{
    public partial class StudentForm : Form
    {
        private readonly StudentRepository _studentRepository = null!;
        private readonly CourseRepository _courseRepository = null!;
        private Student? _currentStudent;
        private bool _isEditMode;

        public StudentForm()
        {
            InitializeComponent();
            _studentRepository = new StudentRepository();
            _courseRepository = new CourseRepository();
            InitializeForm();
            LoadStudents();
            LoadCourses();
        }

        private void InitializeForm()
        {
            this.Text = "Student Management";
            this.Dock = DockStyle.Fill;
            
            ApplyModernStyle();
            SetupDataGridView();
            ClearFields();
        }

        private void ApplyModernStyle()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);
            
            // Panel styling
            pnlForm.BackColor = Color.White;
            pnlForm.Location = new Point(20, 20);
            pnlForm.Size = new Size(350, 550);
            
            // Labels
            foreach (Control ctrl in pnlForm.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.Font = new Font("Segoe UI", 9F);
                    lbl.ForeColor = Color.FromArgb(51, 51, 51);
                }
                else if (ctrl is TextBox txtBox)
                {
                    txtBox.Font = new Font("Segoe UI", 9F);
                    txtBox.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (ctrl is ComboBox cb)
                {
                    cb.Font = new Font("Segoe UI", 9F);
                }
                else if (ctrl is DateTimePicker dtp)
                {
                    dtp.Font = new Font("Segoe UI", 9F);
                }
            }
            
            // Buttons
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.ForeColor = Color.White;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;
            
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 1;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnClear.BackColor = Color.White;
            btnClear.ForeColor = Color.FromArgb(51, 51, 51);
            btnClear.Font = new Font("Segoe UI", 10F);
            btnClear.Cursor = Cursors.Hand;
            
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.Cursor = Cursors.Hand;
            
            // Search box
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
        }

        private void SetupDataGridView()
        {
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.Columns.Clear();
            
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StudentId",
                HeaderText = "Student ID",
                Width = 100
            });
            
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Full Name",
                Width = 200
            });
            
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Width = 180
            });
            
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "Phone",
                Width = 120
            });
            
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CourseName",
                HeaderText = "Course",
                Width = 100
            });
            
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "YearLevel",
                HeaderText = "Year",
                Width = 60
            });
            
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EnrollmentStatus",
                HeaderText = "Status",
                Width = 100
            });
            
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.ReadOnly = true;
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.GridColor = Color.FromArgb(230, 230, 230);
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStudents.EnableHeadersVisualStyles = false;
            dgvStudents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
        }

        private void LoadStudents()
        {
            try
            {
                var students = _studentRepository.GetAll().Where(s => s.IsActive).ToList();
                var courses = _courseRepository.GetAll().Where(c => c.IsActive).ToList();
                
                // Create anonymous objects with course name instead of ID
                var studentData = students.Select(s => new
                {
                    s.StudentId,
                    FullName = s.FullName,
                    s.Email,
                    s.Phone,
                    CourseName = courses.FirstOrDefault(c => c.Id == s.CourseId)?.CourseCode ?? "N/A",
                    s.YearLevel,
                    s.EnrollmentStatus
                }).ToList();
                
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = studentData;
                lblRecordCount.Text = $"Total Records: {studentData.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCourses()
        {
            try
            {
                var courses = _courseRepository.GetAll().Where(c => c.IsActive).ToList();
                cbCourse.DataSource = courses;
                cbCourse.DisplayMember = "CourseCode";
                cbCourse.ValueMember = "Id";
                cbCourse.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            _currentStudent = null;
            _isEditMode = false;
            
            txtStudentId.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtGuardianName.Clear();
            txtGuardianContact.Clear();
            cbCourse.SelectedIndex = -1;
            numYearLevel.Value = 1;
            cbEnrollmentStatus.SelectedIndex = 0;
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-18);
            
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        private void PopulateFields(Student student)
        {
            _currentStudent = student;
            _isEditMode = true;
            
            txtStudentId.Text = student.StudentId;
            txtFirstName.Text = student.FirstName;
            txtMiddleName.Text = student.MiddleName;
            txtLastName.Text = student.LastName;
            txtEmail.Text = student.Email;
            txtPhone.Text = student.Phone;
            txtAddress.Text = student.Address;
            txtGuardianName.Text = student.GuardianName;
            txtGuardianContact.Text = student.GuardianContact;
            
            if (cbCourse.Items.Count > 0)
            {
                for (int i = 0; i < cbCourse.Items.Count; i++)
                {
                    if (((Course)cbCourse.Items[i]).Id == student.CourseId)
                    {
                        cbCourse.SelectedIndex = i;
                        break;
                    }
                }
            }
            
            numYearLevel.Value = student.YearLevel;
            if (cbEnrollmentStatus.Items.Contains(student.EnrollmentStatus))
            {
                cbEnrollmentStatus.SelectedItem = student.EnrollmentStatus;
            }
            dtpDateOfBirth.Value = student.DateOfBirth;
            
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }

        private Student GetStudentFromFields()
        {
            var student = _currentStudent ?? new Student();
            
            student.StudentId = txtStudentId.Text.Trim().ToUpper();
            student.FirstName = txtFirstName.Text.Trim();
            student.MiddleName = txtMiddleName.Text.Trim();
            student.LastName = txtLastName.Text.Trim();
            student.Email = txtEmail.Text.Trim();
            student.Phone = txtPhone.Text.Trim();
            student.Address = txtAddress.Text.Trim();
            student.GuardianName = txtGuardianName.Text.Trim();
            student.GuardianContact = txtGuardianContact.Text.Trim();
            student.CourseId = cbCourse.SelectedValue?.ToString() ?? string.Empty;
            student.YearLevel = (int)numYearLevel.Value;
            student.EnrollmentStatus = cbEnrollmentStatus.SelectedItem?.ToString() ?? "Active";
            student.DateOfBirth = dtpDateOfBirth.Value;
            
            return student;
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Student ID is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentId.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }
            
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && txtEmail.Text.IndexOf("@", StringComparison.Ordinal) <= 0)
            {
                MessageBox.Show("Invalid email format.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            
            return true;
        }

        private void SaveStudent()
        {
            if (!ValidateFields()) return;
            
            try
            {
                var student = GetStudentFromFields();
                
                if (_isEditMode)
                {
                    _studentRepository.Update(student);
                    MessageBox.Show("Student record updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Check if student ID already exists
                    var existing = _studentRepository.GetByStudentId(student.StudentId);
                    if (existing != null)
                    {
                        MessageBox.Show("Student ID already exists. Please use a different ID.", "Duplicate Entry",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtStudentId.Focus();
                        return;
                    }
                    
                    _studentRepository.Add(student);
                    MessageBox.Show("Student record saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                LoadStudents();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving student: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteStudent()
        {
            if (_currentStudent == null)
            {
                MessageBox.Show("Please select a student to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var result = MessageBox.Show($"Are you sure you want to delete student {_currentStudent.FullName}?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    _studentRepository.Delete(_currentStudent.Id);
                    MessageBox.Show("Student record deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting student: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region Event Handlers

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveStudent();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteStudent();
        }

        private void DgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0 && dgvStudents.Rows.Count > 0)
            {
                var row = dgvStudents.SelectedRows[0];
                string? studentId = null;
                
                // Safely get the StudentId value
                if (row.Cells.Count > 0 && row.Cells[0].Value != null)
                {
                    studentId = row.Cells[0].Value?.ToString();
                }
                
                if (!string.IsNullOrEmpty(studentId))
                {
                    var student = _studentRepository.GetByStudentId(studentId!);
                    if (student != null)
                    {
                        PopulateFields(student);
                    }
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var searchTerm = txtSearch.Text.Trim();
                var students = _studentRepository.GetAll().Where(s => s.IsActive).ToList();
                var courses = _courseRepository.GetAll().Where(c => c.IsActive).ToList();
                
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    students = students.Where(s =>
                        s.StudentId.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        s.FirstName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        s.LastName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        s.Email.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                
                // Create anonymous objects with course name instead of ID
                var studentData = students.Select(s => new
                {
                    s.StudentId,
                    FullName = s.FullName,
                    s.Email,
                    s.Phone,
                    CourseName = courses.FirstOrDefault(c => c.Id == s.CourseId)?.CourseCode ?? "N/A",
                    s.YearLevel,
                    s.EnrollmentStatus
                }).ToList();
                
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = studentData;
                lblRecordCount.Text = $"Showing: {studentData.Count} records";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
