using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IUIS.Models;
using IUIS.Utilities;

namespace IUIS.Forms.Courses
{
    public partial class CourseForm : Form
    {
        private readonly CourseRepository _courseRepository;
        private Course? _currentCourse;
        private bool _isEditMode;

        public CourseForm()
        {
            InitializeComponent();
            _courseRepository = new CourseRepository();
            InitializeForm();
            LoadCourses();
            InitializeBatStateUCourses();
        }

        private void InitializeBatStateUCourses()
        {
            // Pre-populate with Batangas State University courses if none exist
            if (_courseRepository.GetAll().Count == 0)
            {
                var batStateUCourses = new List<Course>
                {
                    // College of Engineering
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSCE", CourseName = "Bachelor of Science in Civil Engineering", Description = "Focuses on infrastructure design and construction", Degree = "Bachelor", TotalUnits = 198, DurationYears = 4, IsActive = true },
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSME", CourseName = "Bachelor of Science in Mechanical Engineering", Description = "Focuses on mechanical systems and design", Degree = "Bachelor", TotalUnits = 196, DurationYears = 4, IsActive = true },
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSEE", CourseName = "Bachelor of Science in Electrical Engineering", Description = "Focuses on electrical systems and power", Degree = "Bachelor", TotalUnits = 197, DurationYears = 4, IsActive = true },
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSCpE", CourseName = "Bachelor of Science in Computer Engineering", Description = "Focuses on computer hardware and software integration", Degree = "Bachelor", TotalUnits = 195, DurationYears = 4, IsActive = true },
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSChE", CourseName = "Bachelor of Science in Chemical Engineering", Description = "Focuses on chemical processes and production", Degree = "Bachelor", TotalUnits = 199, DurationYears = 4, IsActive = true },
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSMtlE", CourseName = "Bachelor of Science in Metallurgical Engineering", Description = "Focuses on metal extraction and processing", Degree = "Bachelor", TotalUnits = 194, DurationYears = 4, IsActive = true },
                    
                    // College of Information Technology
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSIT", CourseName = "Bachelor of Science in Information Technology", Description = "Focuses on software development and IT systems", Degree = "Bachelor", TotalUnits = 142, DurationYears = 4, IsActive = true },
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSCS", CourseName = "Bachelor of Science in Computer Science", Description = "Focuses on computing theory and algorithms", Degree = "Bachelor", TotalUnits = 145, DurationYears = 4, IsActive = true },
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSIS", CourseName = "Bachelor of Science in Information Systems", Description = "Focuses on business information systems", Degree = "Bachelor", TotalUnits = 140, DurationYears = 4, IsActive = true },
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSAT", CourseName = "Bachelor of Science in Animation", Description = "Focuses on digital animation and multimedia", Degree = "Bachelor", TotalUnits = 138, DurationYears = 4, IsActive = true },
                    
                    // College of Business and Economics
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSBA", CourseName = "Bachelor of Science in Business Administration", Description = "General business management program", Degree = "Bachelor", TotalUnits = 135, DurationYears = 4, IsActive = true },
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSA", CourseName = "Bachelor of Science in Accountancy", Description = "Professional accountancy program", Degree = "Bachelor", TotalUnits = 168, DurationYears = 4, IsActive = true },
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSMA", CourseName = "Bachelor of Science in Management Accounting", Description = "Focuses on management accounting practices", Degree = "Bachelor", TotalUnits = 155, DurationYears = 4, IsActive = true },
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSHM", CourseName = "Bachelor of Science in Hospitality Management", Description = "Focuses on hospitality and tourism industry", Degree = "Bachelor", TotalUnits = 132, DurationYears = 4, IsActive = true },
                    
                    // College of Education
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BEED", CourseName = "Bachelor of Elementary Education", Description = "Prepares teachers for elementary level", Degree = "Bachelor", TotalUnits = 150, DurationYears = 4, IsActive = true },
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSED-ENG", CourseName = "Bachelor of Secondary Education - English", Description = "Prepares teachers for English subjects", Degree = "Bachelor", TotalUnits = 152, DurationYears = 4, IsActive = true },
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSED-MATH", CourseName = "Bachelor of Secondary Education - Mathematics", Description = "Prepares teachers for Mathematics subjects", Degree = "Bachelor", TotalUnits = 152, DurationYears = 4, IsActive = true },
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSED-SCI", CourseName = "Bachelor of Secondary Education - Science", Description = "Prepares teachers for Science subjects", Degree = "Bachelor", TotalUnits = 152, DurationYears = 4, IsActive = true },
                    
                    // College of Nursing
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSN", CourseName = "Bachelor of Science in Nursing", Description = "Professional nursing program", Degree = "Bachelor", TotalUnits = 165, DurationYears = 4, IsActive = true },
                    
                    // College of Criminal Justice
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSCRIM", CourseName = "Bachelor of Science in Criminology", Description = "Focuses on criminal justice and law enforcement", Degree = "Bachelor", TotalUnits = 148, DurationYears = 4, IsActive = true },
                    
                    // College of Maritime Education
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSMarE", CourseName = "Bachelor of Science in Marine Engineering", Description = "Focuses on ship engineering and operations", Degree = "Bachelor", TotalUnits = 170, DurationYears = 4, IsActive = true },
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BSMT", CourseName = "Bachelor of Science in Marine Transportation", Description = "Focuses on maritime navigation and transport", Degree = "Bachelor", TotalUnits = 168, DurationYears = 4, IsActive = true },
                    
                    // College of Industrial Technology
                    new Course { Id = Guid.NewGuid().ToString(), CourseCode = "BIT", CourseName = "Bachelor in Industrial Technology", Description = "Focuses on industrial technology applications", Degree = "Bachelor", TotalUnits = 136, DurationYears = 4, IsActive = true }
                };

                foreach (var course in batStateUCourses)
                {
                    _courseRepository.Add(course);
                }
            }
        }

        private void InitializeForm()
        {
            this.Text = "Course Management";
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
                else if (ctrl is NumericUpDown num)
                {
                    num.Font = new Font("Segoe UI", 9F);
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
            dgvCourses.AutoGenerateColumns = false;
            dgvCourses.Columns.Clear();
            
            dgvCourses.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CourseCode",
                HeaderText = "Code",
                Width = 80
            });
            
            dgvCourses.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CourseName",
                HeaderText = "Course Name",
                Width = 250
            });
            
            dgvCourses.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Degree",
                HeaderText = "Degree",
                Width = 80
            });
            
            dgvCourses.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalUnits",
                HeaderText = "Units",
                Width = 60
            });
            
            dgvCourses.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DurationYears",
                HeaderText = "Years",
                Width = 60
            });
            
            dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCourses.ReadOnly = true;
            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.BackgroundColor = Color.White;
            dgvCourses.GridColor = Color.FromArgb(230, 230, 230);
            dgvCourses.RowHeadersVisible = false;
            dgvCourses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvCourses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvCourses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCourses.EnableHeadersVisualStyles = false;
            dgvCourses.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
        }

        private void LoadCourses()
        {
            try
            {
                var courses = _courseRepository.GetAll().Where(c => c.IsActive).ToList();
                dgvCourses.DataSource = null;
                dgvCourses.DataSource = courses;
                lblRecordCount.Text = $"Total Records: {courses.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            _currentCourse = null;
            _isEditMode = false;
            
            txtCourseCode.Clear();
            txtCourseName.Clear();
            txtDescription.Clear();
            txtDegree.Text = "Bachelor";
            numTotalUnits.Value = 140;
            numDurationYears.Value = 4;
            
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        private void PopulateFields(Course course)
        {
            _currentCourse = course;
            _isEditMode = true;
            
            txtCourseCode.Text = course.CourseCode;
            txtCourseName.Text = course.CourseName;
            txtDescription.Text = course.Description;
            txtDegree.Text = course.Degree;
            numTotalUnits.Value = course.TotalUnits;
            numDurationYears.Value = course.DurationYears;
            
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }

        private Course GetCourseFromFields()
        {
            var course = _currentCourse ?? new Course();
            
            course.CourseCode = txtCourseCode.Text.Trim().ToUpper();
            course.CourseName = txtCourseName.Text.Trim();
            course.Description = txtDescription.Text.Trim();
            course.Degree = txtDegree.Text.Trim();
            course.TotalUnits = (int)numTotalUnits.Value;
            course.DurationYears = (int)numDurationYears.Value;
            
            return course;
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtCourseCode.Text))
            {
                MessageBox.Show("Course Code is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCourseCode.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Course Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCourseName.Focus();
                return false;
            }
            
            return true;
        }

        private void SaveCourse()
        {
            if (!ValidateFields()) return;
            
            try
            {
                var course = GetCourseFromFields();
                
                if (_isEditMode)
                {
                    _courseRepository.Update(course);
                    MessageBox.Show("Course record updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Check if course code already exists
                    var existing = _courseRepository.GetAll().FirstOrDefault(c => 
                        c.CourseCode.Equals(course.CourseCode, StringComparison.OrdinalIgnoreCase));
                    if (existing != null)
                    {
                        MessageBox.Show("Course Code already exists. Please use a different code.", "Duplicate Entry",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCourseCode.Focus();
                        return;
                    }
                    
                    _courseRepository.Add(course);
                    MessageBox.Show("Course record saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                LoadCourses();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving course: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteCourse()
        {
            if (_currentCourse == null)
            {
                MessageBox.Show("Please select a course to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var result = MessageBox.Show($"Are you sure you want to delete course {_currentCourse.CourseName}?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    _courseRepository.Delete(_currentCourse.Id);
                    MessageBox.Show("Course record deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCourses();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting course: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region Event Handlers

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveCourse();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteCourse();
        }

        private void DgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count > 0)
            {
                var course = (Course)dgvCourses.SelectedRows[0].DataBoundItem;
                PopulateFields(course);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var searchTerm = txtSearch.Text.Trim();
                var courses = _courseRepository.GetAll().Where(c => c.IsActive).ToList();
                
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    courses = courses.Where(c =>
                        c.CourseCode.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        c.CourseName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        c.Description.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                
                dgvCourses.DataSource = null;
                dgvCourses.DataSource = courses;
                lblRecordCount.Text = $"Showing: {courses.Count} records";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching courses: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
