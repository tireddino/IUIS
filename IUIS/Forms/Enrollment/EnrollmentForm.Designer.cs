namespace IUIS.Forms.Enrollment
{
    partial class EnrollmentForm
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpStudentInfo = new System.Windows.Forms.GroupBox();
            this.lblStudYear = new System.Windows.Forms.Label();
            this.lblStudCourse = new System.Windows.Forms.Label();
            this.lblStudName = new System.Windows.Forms.Label();
            this.lblStudId = new System.Windows.Forms.Label();
            this.lblYearLabel = new System.Windows.Forms.Label();
            this.lblCourseLabel = new System.Windows.Forms.Label();
            this.lblNameLabel = new System.Windows.Forms.Label();
            this.lblIdLabel = new System.Windows.Forms.Label();
            this.cmbStudents = new System.Windows.Forms.ComboBox();
            this.lblSelectStudent = new System.Windows.Forms.Label();
            this.grpEnrollmentDetails = new System.Windows.Forms.GroupBox();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.cmbAcadYear = new System.Windows.Forms.ComboBox();
            this.lblAcadYear = new System.Windows.Forms.Label();
            this.grpSubjectSelection = new System.Windows.Forms.GroupBox();
            this.btnRemoveSubject = new System.Windows.Forms.Button();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.cmbSubjectList = new System.Windows.Forms.ComboBox();
            this.lblAvailableSubjects = new System.Windows.Forms.Label();
            this.dgvSelectedSubjects = new System.Windows.Forms.DataGridView();
            this.lblSelectedSubjects = new System.Windows.Forms.Label();
            this.grpFees = new System.Windows.Forms.GroupBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtAmountPaid = new System.Windows.Forms.TextBox();
            this.lblTotalAssessment = new System.Windows.Forms.Label();
            this.lblMiscFee = new System.Windows.Forms.Label();
            this.lblTuitionFee = new System.Windows.Forms.Label();
            this.lblTotalUnits = new System.Windows.Forms.Label();
            this.lblBalanceLabel = new System.Windows.Forms.Label();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblAmountPaidLabel = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblMiscLabel = new System.Windows.Forms.Label();
            this.lblTuitionLabel = new System.Windows.Forms.Label();
            this.lblUnitsLabel = new System.Windows.Forms.Label();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrintAssessment = new System.Windows.Forms.Button();
            this.grpEnrollmentHistory = new System.Windows.Forms.GroupBox();
            this.dgvEnrollmentHistory = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.grpStudentInfo.SuspendLayout();
            this.grpEnrollmentDetails.SuspendLayout();
            this.grpSubjectSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedSubjects)).BeginInit();
            this.grpFees.SuspendLayout();
            this.grpEnrollmentHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrollmentHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1084, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(298, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Enrollment Management";
            // 
            // grpStudentInfo
            // 
            this.grpStudentInfo.Controls.Add(this.lblStudCourse);
            this.grpStudentInfo.Controls.Add(this.lblStudName);
            this.grpStudentInfo.Controls.Add(this.lblStudId);
            this.grpStudentInfo.Controls.Add(this.lblCourseLabel);
            this.grpStudentInfo.Controls.Add(this.lblNameLabel);
            this.grpStudentInfo.Controls.Add(this.lblIdLabel);
            this.grpStudentInfo.Controls.Add(this.cmbStudents);
            this.grpStudentInfo.Controls.Add(this.lblSelectStudent);
            this.grpStudentInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpStudentInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.grpStudentInfo.Location = new System.Drawing.Point(20, 80);
            this.grpStudentInfo.Name = "grpStudentInfo";
            this.grpStudentInfo.Size = new System.Drawing.Size(500, 194);
            this.grpStudentInfo.TabIndex = 1;
            this.grpStudentInfo.TabStop = false;
            this.grpStudentInfo.Text = "Student Information";
            // 
            // lblStudYear
            // 
            this.lblStudYear.AutoSize = true;
            this.lblStudYear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStudYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.lblStudYear.Location = new System.Drawing.Point(120, 245);
            this.lblStudYear.Name = "lblStudYear";
            this.lblStudYear.Size = new System.Drawing.Size(22, 15);
            this.lblStudYear.TabIndex = 9;
            this.lblStudYear.Text = "---";
            // 
            // lblStudCourse
            // 
            this.lblStudCourse.AutoSize = true;
            this.lblStudCourse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStudCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.lblStudCourse.Location = new System.Drawing.Point(100, 140);
            this.lblStudCourse.Name = "lblStudCourse";
            this.lblStudCourse.Size = new System.Drawing.Size(22, 15);
            this.lblStudCourse.TabIndex = 7;
            this.lblStudCourse.Text = "---";
            // 
            // lblStudName
            // 
            this.lblStudName.AutoSize = true;
            this.lblStudName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStudName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.lblStudName.Location = new System.Drawing.Point(100, 115);
            this.lblStudName.Name = "lblStudName";
            this.lblStudName.Size = new System.Drawing.Size(22, 15);
            this.lblStudName.TabIndex = 5;
            this.lblStudName.Text = "---";
            // 
            // lblStudId
            // 
            this.lblStudId.AutoSize = true;
            this.lblStudId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStudId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.lblStudId.Location = new System.Drawing.Point(100, 90);
            this.lblStudId.Name = "lblStudId";
            this.lblStudId.Size = new System.Drawing.Size(22, 15);
            this.lblStudId.TabIndex = 3;
            this.lblStudId.Text = "---";
            // 
            // lblYearLabel
            // 
            this.lblYearLabel.AutoSize = true;
            this.lblYearLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblYearLabel.ForeColor = System.Drawing.Color.Black;
            this.lblYearLabel.Location = new System.Drawing.Point(40, 245);
            this.lblYearLabel.Name = "lblYearLabel";
            this.lblYearLabel.Size = new System.Drawing.Size(62, 15);
            this.lblYearLabel.TabIndex = 8;
            this.lblYearLabel.Text = "Year Level:";
            // 
            // lblCourseLabel
            // 
            this.lblCourseLabel.AutoSize = true;
            this.lblCourseLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCourseLabel.ForeColor = System.Drawing.Color.Black;
            this.lblCourseLabel.Location = new System.Drawing.Point(20, 140);
            this.lblCourseLabel.Name = "lblCourseLabel";
            this.lblCourseLabel.Size = new System.Drawing.Size(47, 15);
            this.lblCourseLabel.TabIndex = 6;
            this.lblCourseLabel.Text = "Course:";
            // 
            // lblNameLabel
            // 
            this.lblNameLabel.AutoSize = true;
            this.lblNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNameLabel.ForeColor = System.Drawing.Color.Black;
            this.lblNameLabel.Location = new System.Drawing.Point(20, 115);
            this.lblNameLabel.Name = "lblNameLabel";
            this.lblNameLabel.Size = new System.Drawing.Size(42, 15);
            this.lblNameLabel.TabIndex = 4;
            this.lblNameLabel.Text = "Name:";
            // 
            // lblIdLabel
            // 
            this.lblIdLabel.AutoSize = true;
            this.lblIdLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIdLabel.ForeColor = System.Drawing.Color.Black;
            this.lblIdLabel.Location = new System.Drawing.Point(20, 90);
            this.lblIdLabel.Name = "lblIdLabel";
            this.lblIdLabel.Size = new System.Drawing.Size(65, 15);
            this.lblIdLabel.TabIndex = 2;
            this.lblIdLabel.Text = "Student ID:";
            // 
            // cmbStudents
            // 
            this.cmbStudents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudents.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbStudents.FormattingEnabled = true;
            this.cmbStudents.Location = new System.Drawing.Point(20, 50);
            this.cmbStudents.Name = "cmbStudents";
            this.cmbStudents.Size = new System.Drawing.Size(460, 23);
            this.cmbStudents.TabIndex = 1;
            this.cmbStudents.SelectedIndexChanged += new System.EventHandler(this.cmbStudents_SelectedIndexChanged);
            // 
            // lblSelectStudent
            // 
            this.lblSelectStudent.AutoSize = true;
            this.lblSelectStudent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSelectStudent.ForeColor = System.Drawing.Color.Black;
            this.lblSelectStudent.Location = new System.Drawing.Point(20, 30);
            this.lblSelectStudent.Name = "lblSelectStudent";
            this.lblSelectStudent.Size = new System.Drawing.Size(85, 15);
            this.lblSelectStudent.TabIndex = 0;
            this.lblSelectStudent.Text = "Select Student:";
            // 
            // grpEnrollmentDetails
            // 
            this.grpEnrollmentDetails.Controls.Add(this.cmbSemester);
            this.grpEnrollmentDetails.Controls.Add(this.lblSemester);
            this.grpEnrollmentDetails.Controls.Add(this.cmbAcadYear);
            this.grpEnrollmentDetails.Controls.Add(this.lblAcadYear);
            this.grpEnrollmentDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpEnrollmentDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.grpEnrollmentDetails.Location = new System.Drawing.Point(540, 80);
            this.grpEnrollmentDetails.Name = "grpEnrollmentDetails";
            this.grpEnrollmentDetails.Size = new System.Drawing.Size(520, 180);
            this.grpEnrollmentDetails.TabIndex = 2;
            this.grpEnrollmentDetails.TabStop = false;
            this.grpEnrollmentDetails.Text = "Enrollment Details";
            // 
            // cmbSemester
            // 
            this.cmbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemester.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Items.AddRange(new object[] {
            "1st Semester",
            "2nd Semester",
            "Summer"});
            this.cmbSemester.Location = new System.Drawing.Point(280, 70);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(200, 23);
            this.cmbSemester.TabIndex = 3;
            this.cmbSemester.SelectedIndexChanged += new System.EventHandler(this.cmbSemester_SelectedIndexChanged);
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSemester.ForeColor = System.Drawing.Color.Black;
            this.lblSemester.Location = new System.Drawing.Point(280, 50);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(58, 15);
            this.lblSemester.TabIndex = 2;
            this.lblSemester.Text = "Semester:";
            // 
            // cmbAcadYear
            // 
            this.cmbAcadYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAcadYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbAcadYear.FormattingEnabled = true;
            this.cmbAcadYear.Location = new System.Drawing.Point(20, 70);
            this.cmbAcadYear.Name = "cmbAcadYear";
            this.cmbAcadYear.Size = new System.Drawing.Size(200, 23);
            this.cmbAcadYear.TabIndex = 1;
            this.cmbAcadYear.SelectedIndexChanged += new System.EventHandler(this.cmbAcadYear_SelectedIndexChanged);
            // 
            // lblAcadYear
            // 
            this.lblAcadYear.AutoSize = true;
            this.lblAcadYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAcadYear.ForeColor = System.Drawing.Color.Black;
            this.lblAcadYear.Location = new System.Drawing.Point(20, 50);
            this.lblAcadYear.Name = "lblAcadYear";
            this.lblAcadYear.Size = new System.Drawing.Size(88, 15);
            this.lblAcadYear.TabIndex = 0;
            this.lblAcadYear.Text = "Academic Year:";
            // 
            // grpSubjectSelection
            // 
            this.grpSubjectSelection.Controls.Add(this.btnRemoveSubject);
            this.grpSubjectSelection.Controls.Add(this.btnAddSubject);
            this.grpSubjectSelection.Controls.Add(this.cmbSubjectList);
            this.grpSubjectSelection.Controls.Add(this.lblAvailableSubjects);
            this.grpSubjectSelection.Controls.Add(this.dgvSelectedSubjects);
            this.grpSubjectSelection.Controls.Add(this.lblSelectedSubjects);
            this.grpSubjectSelection.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpSubjectSelection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.grpSubjectSelection.Location = new System.Drawing.Point(20, 280);
            this.grpSubjectSelection.Name = "grpSubjectSelection";
            this.grpSubjectSelection.Size = new System.Drawing.Size(1040, 250);
            this.grpSubjectSelection.TabIndex = 3;
            this.grpSubjectSelection.TabStop = false;
            this.grpSubjectSelection.Text = "Subject Selection";
            // 
            // btnRemoveSubject
            // 
            this.btnRemoveSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemoveSubject.FlatAppearance.BorderSize = 0;
            this.btnRemoveSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveSubject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoveSubject.ForeColor = System.Drawing.Color.White;
            this.btnRemoveSubject.Location = new System.Drawing.Point(410, 120);
            this.btnRemoveSubject.Name = "btnRemoveSubject";
            this.btnRemoveSubject.Size = new System.Drawing.Size(90, 30);
            this.btnRemoveSubject.TabIndex = 5;
            this.btnRemoveSubject.Text = "<< Remove";
            this.btnRemoveSubject.UseVisualStyleBackColor = false;
            this.btnRemoveSubject.Click += new System.EventHandler(this.btnRemoveSubject_Click);
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnAddSubject.FlatAppearance.BorderSize = 0;
            this.btnAddSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSubject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddSubject.ForeColor = System.Drawing.Color.White;
            this.btnAddSubject.Location = new System.Drawing.Point(410, 80);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(90, 30);
            this.btnAddSubject.TabIndex = 4;
            this.btnAddSubject.Text = "Add >>";
            this.btnAddSubject.UseVisualStyleBackColor = false;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // cmbSubjectList
            // 
            this.cmbSubjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubjectList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSubjectList.FormattingEnabled = true;
            this.cmbSubjectList.Location = new System.Drawing.Point(20, 50);
            this.cmbSubjectList.Name = "cmbSubjectList";
            this.cmbSubjectList.Size = new System.Drawing.Size(380, 23);
            this.cmbSubjectList.TabIndex = 3;
            // 
            // lblAvailableSubjects
            // 
            this.lblAvailableSubjects.AutoSize = true;
            this.lblAvailableSubjects.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAvailableSubjects.ForeColor = System.Drawing.Color.Black;
            this.lblAvailableSubjects.Location = new System.Drawing.Point(20, 30);
            this.lblAvailableSubjects.Name = "lblAvailableSubjects";
            this.lblAvailableSubjects.Size = new System.Drawing.Size(105, 15);
            this.lblAvailableSubjects.TabIndex = 2;
            this.lblAvailableSubjects.Text = "Available Subjects:";
            // 
            // dgvSelectedSubjects
            // 
            this.dgvSelectedSubjects.AllowUserToAddRows = false;
            this.dgvSelectedSubjects.AllowUserToDeleteRows = false;
            this.dgvSelectedSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSelectedSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedSubjects.Location = new System.Drawing.Point(520, 50);
            this.dgvSelectedSubjects.MultiSelect = false;
            this.dgvSelectedSubjects.Name = "dgvSelectedSubjects";
            this.dgvSelectedSubjects.ReadOnly = true;
            this.dgvSelectedSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedSubjects.Size = new System.Drawing.Size(500, 140);
            this.dgvSelectedSubjects.TabIndex = 1;
            // 
            // lblSelectedSubjects
            // 
            this.lblSelectedSubjects.AutoSize = true;
            this.lblSelectedSubjects.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSelectedSubjects.ForeColor = System.Drawing.Color.Black;
            this.lblSelectedSubjects.Location = new System.Drawing.Point(520, 30);
            this.lblSelectedSubjects.Name = "lblSelectedSubjects";
            this.lblSelectedSubjects.Size = new System.Drawing.Size(101, 15);
            this.lblSelectedSubjects.TabIndex = 0;
            this.lblSelectedSubjects.Text = "Selected Subjects:";
            // 
            // grpFees
            // 
            this.grpFees.Controls.Add(this.lblBalance);
            this.grpFees.Controls.Add(this.lblStatus);
            this.grpFees.Controls.Add(this.txtAmountPaid);
            this.grpFees.Controls.Add(this.lblTotalAssessment);
            this.grpFees.Controls.Add(this.lblMiscFee);
            this.grpFees.Controls.Add(this.lblTuitionFee);
            this.grpFees.Controls.Add(this.lblTotalUnits);
            this.grpFees.Controls.Add(this.lblBalanceLabel);
            this.grpFees.Controls.Add(this.lblStatusLabel);
            this.grpFees.Controls.Add(this.lblAmountPaidLabel);
            this.grpFees.Controls.Add(this.lblTotalLabel);
            this.grpFees.Controls.Add(this.lblMiscLabel);
            this.grpFees.Controls.Add(this.lblTuitionLabel);
            this.grpFees.Controls.Add(this.lblUnitsLabel);
            this.grpFees.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.grpFees.Location = new System.Drawing.Point(20, 550);
            this.grpFees.Name = "grpFees";
            this.grpFees.Size = new System.Drawing.Size(700, 180);
            this.grpFees.TabIndex = 4;
            this.grpFees.TabStop = false;
            this.grpFees.Text = "Assessment of Fees";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBalance.ForeColor = System.Drawing.Color.Red;
            this.lblBalance.Location = new System.Drawing.Point(450, 115);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(31, 15);
            this.lblBalance.TabIndex = 13;
            this.lblBalance.Text = "0.00";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Location = new System.Drawing.Point(450, 90);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(97, 15);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "New Enrollment";
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAmountPaid.Location = new System.Drawing.Point(350, 60);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.Size = new System.Drawing.Size(150, 23);
            this.txtAmountPaid.TabIndex = 9;
            this.txtAmountPaid.Text = "0";
            this.txtAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmountPaid.TextChanged += new System.EventHandler(this.txtAmountPaid_TextChanged);
            // 
            // lblTotalAssessment
            // 
            this.lblTotalAssessment.AutoSize = true;
            this.lblTotalAssessment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalAssessment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(76)))));
            this.lblTotalAssessment.Location = new System.Drawing.Point(150, 115);
            this.lblTotalAssessment.Name = "lblTotalAssessment";
            this.lblTotalAssessment.Size = new System.Drawing.Size(31, 15);
            this.lblTotalAssessment.TabIndex = 7;
            this.lblTotalAssessment.Text = "0.00";
            // 
            // lblMiscFee
            // 
            this.lblMiscFee.AutoSize = true;
            this.lblMiscFee.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMiscFee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.lblMiscFee.Location = new System.Drawing.Point(150, 90);
            this.lblMiscFee.Name = "lblMiscFee";
            this.lblMiscFee.Size = new System.Drawing.Size(31, 15);
            this.lblMiscFee.TabIndex = 5;
            this.lblMiscFee.Text = "0.00";
            // 
            // lblTuitionFee
            // 
            this.lblTuitionFee.AutoSize = true;
            this.lblTuitionFee.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTuitionFee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.lblTuitionFee.Location = new System.Drawing.Point(150, 65);
            this.lblTuitionFee.Name = "lblTuitionFee";
            this.lblTuitionFee.Size = new System.Drawing.Size(31, 15);
            this.lblTuitionFee.TabIndex = 3;
            this.lblTuitionFee.Text = "0.00";
            // 
            // lblTotalUnits
            // 
            this.lblTotalUnits.AutoSize = true;
            this.lblTotalUnits.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalUnits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.lblTotalUnits.Location = new System.Drawing.Point(150, 40);
            this.lblTotalUnits.Name = "lblTotalUnits";
            this.lblTotalUnits.Size = new System.Drawing.Size(14, 15);
            this.lblTotalUnits.TabIndex = 1;
            this.lblTotalUnits.Text = "0";
            // 
            // lblBalanceLabel
            // 
            this.lblBalanceLabel.AutoSize = true;
            this.lblBalanceLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBalanceLabel.ForeColor = System.Drawing.Color.Black;
            this.lblBalanceLabel.Location = new System.Drawing.Point(350, 115);
            this.lblBalanceLabel.Name = "lblBalanceLabel";
            this.lblBalanceLabel.Size = new System.Drawing.Size(53, 15);
            this.lblBalanceLabel.TabIndex = 12;
            this.lblBalanceLabel.Text = "Balance:";
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatusLabel.ForeColor = System.Drawing.Color.Black;
            this.lblStatusLabel.Location = new System.Drawing.Point(350, 90);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(42, 15);
            this.lblStatusLabel.TabIndex = 10;
            this.lblStatusLabel.Text = "Status:";
            // 
            // lblAmountPaidLabel
            // 
            this.lblAmountPaidLabel.AutoSize = true;
            this.lblAmountPaidLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAmountPaidLabel.ForeColor = System.Drawing.Color.Black;
            this.lblAmountPaidLabel.Location = new System.Drawing.Point(350, 40);
            this.lblAmountPaidLabel.Name = "lblAmountPaidLabel";
            this.lblAmountPaidLabel.Size = new System.Drawing.Size(80, 15);
            this.lblAmountPaidLabel.TabIndex = 8;
            this.lblAmountPaidLabel.Text = "Amount Paid:";
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.Black;
            this.lblTotalLabel.Location = new System.Drawing.Point(20, 115);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(105, 15);
            this.lblTotalLabel.TabIndex = 6;
            this.lblTotalLabel.Text = "Total Assessment:";
            // 
            // lblMiscLabel
            // 
            this.lblMiscLabel.AutoSize = true;
            this.lblMiscLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMiscLabel.ForeColor = System.Drawing.Color.Black;
            this.lblMiscLabel.Location = new System.Drawing.Point(20, 90);
            this.lblMiscLabel.Name = "lblMiscLabel";
            this.lblMiscLabel.Size = new System.Drawing.Size(106, 15);
            this.lblMiscLabel.TabIndex = 4;
            this.lblMiscLabel.Text = "Miscellaneous Fee:";
            // 
            // lblTuitionLabel
            // 
            this.lblTuitionLabel.AutoSize = true;
            this.lblTuitionLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTuitionLabel.ForeColor = System.Drawing.Color.Black;
            this.lblTuitionLabel.Location = new System.Drawing.Point(20, 65);
            this.lblTuitionLabel.Name = "lblTuitionLabel";
            this.lblTuitionLabel.Size = new System.Drawing.Size(68, 15);
            this.lblTuitionLabel.TabIndex = 2;
            this.lblTuitionLabel.Text = "Tuition Fee:";
            // 
            // lblUnitsLabel
            // 
            this.lblUnitsLabel.AutoSize = true;
            this.lblUnitsLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUnitsLabel.ForeColor = System.Drawing.Color.Black;
            this.lblUnitsLabel.Location = new System.Drawing.Point(20, 40);
            this.lblUnitsLabel.Name = "lblUnitsLabel";
            this.lblUnitsLabel.Size = new System.Drawing.Size(65, 15);
            this.lblUnitsLabel.TabIndex = 0;
            this.lblUnitsLabel.Text = "Total Units:";
            // 
            // btnEnroll
            // 
            this.btnEnroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(76)))));
            this.btnEnroll.FlatAppearance.BorderSize = 0;
            this.btnEnroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnroll.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEnroll.ForeColor = System.Drawing.Color.White;
            this.btnEnroll.Location = new System.Drawing.Point(740, 580);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(150, 45);
            this.btnEnroll.TabIndex = 5;
            this.btnEnroll.Text = "ENROLL";
            this.btnEnroll.UseVisualStyleBackColor = false;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(740, 640);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 45);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrintAssessment
            // 
            this.btnPrintAssessment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnPrintAssessment.FlatAppearance.BorderSize = 0;
            this.btnPrintAssessment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintAssessment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrintAssessment.ForeColor = System.Drawing.Color.White;
            this.btnPrintAssessment.Location = new System.Drawing.Point(910, 610);
            this.btnPrintAssessment.Name = "btnPrintAssessment";
            this.btnPrintAssessment.Size = new System.Drawing.Size(150, 40);
            this.btnPrintAssessment.TabIndex = 7;
            this.btnPrintAssessment.Text = "PRINT FORM";
            this.btnPrintAssessment.UseVisualStyleBackColor = false;
            this.btnPrintAssessment.Click += new System.EventHandler(this.btnPrintAssessment_Click);
            // 
            // grpEnrollmentHistory
            // 
            this.grpEnrollmentHistory.Controls.Add(this.dgvEnrollmentHistory);
            this.grpEnrollmentHistory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpEnrollmentHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.grpEnrollmentHistory.Location = new System.Drawing.Point(20, 280);
            this.grpEnrollmentHistory.Name = "grpEnrollmentHistory";
            this.grpEnrollmentHistory.Size = new System.Drawing.Size(1040, 280);
            this.grpEnrollmentHistory.TabIndex = 8;
            this.grpEnrollmentHistory.TabStop = false;
            this.grpEnrollmentHistory.Text = "Existing Enrollment Status";
            this.grpEnrollmentHistory.Visible = false;
            // 
            // dgvEnrollmentHistory
            // 
            this.dgvEnrollmentHistory.AllowUserToAddRows = false;
            this.dgvEnrollmentHistory.AllowUserToDeleteRows = false;
            this.dgvEnrollmentHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEnrollmentHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvEnrollmentHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEnrollmentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnrollmentHistory.Location = new System.Drawing.Point(20, 30);
            this.dgvEnrollmentHistory.MultiSelect = false;
            this.dgvEnrollmentHistory.Name = "dgvEnrollmentHistory";
            this.dgvEnrollmentHistory.ReadOnly = true;
            this.dgvEnrollmentHistory.RowHeadersVisible = false;
            this.dgvEnrollmentHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEnrollmentHistory.Size = new System.Drawing.Size(1000, 230);
            this.dgvEnrollmentHistory.TabIndex = 0;
            // 
            // EnrollmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1084, 720);
            this.Controls.Add(this.grpEnrollmentHistory);
            this.Controls.Add(this.lblStudYear);
            this.Controls.Add(this.btnPrintAssessment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.grpFees);
            this.Controls.Add(this.lblYearLabel);
            this.Controls.Add(this.grpSubjectSelection);
            this.Controls.Add(this.grpEnrollmentDetails);
            this.Controls.Add(this.grpStudentInfo);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EnrollmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enrollment Management";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpStudentInfo.ResumeLayout(false);
            this.grpStudentInfo.PerformLayout();
            this.grpEnrollmentDetails.ResumeLayout(false);
            this.grpEnrollmentDetails.PerformLayout();
            this.grpSubjectSelection.ResumeLayout(false);
            this.grpSubjectSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedSubjects)).EndInit();
            this.grpFees.ResumeLayout(false);
            this.grpFees.PerformLayout();
            this.grpEnrollmentHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrollmentHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpStudentInfo;
        private System.Windows.Forms.Label lblSelectStudent;
        private System.Windows.Forms.ComboBox cmbStudents;
        private System.Windows.Forms.Label lblIdLabel;
        private System.Windows.Forms.Label lblStudId;
        private System.Windows.Forms.Label lblNameLabel;
        private System.Windows.Forms.Label lblStudName;
        private System.Windows.Forms.Label lblCourseLabel;
        private System.Windows.Forms.Label lblStudCourse;
        private System.Windows.Forms.Label lblYearLabel;
        private System.Windows.Forms.Label lblStudYear;
        private System.Windows.Forms.GroupBox grpEnrollmentDetails;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.ComboBox cmbAcadYear;
        private System.Windows.Forms.Label lblAcadYear;
        private System.Windows.Forms.GroupBox grpSubjectSelection;
        private System.Windows.Forms.Button btnRemoveSubject;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.ComboBox cmbSubjectList;
        private System.Windows.Forms.Label lblAvailableSubjects;
        private System.Windows.Forms.DataGridView dgvSelectedSubjects;
        private System.Windows.Forms.Label lblSelectedSubjects;
        private System.Windows.Forms.GroupBox grpFees;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtAmountPaid;
        private System.Windows.Forms.Label lblTotalAssessment;
        private System.Windows.Forms.Label lblMiscFee;
        private System.Windows.Forms.Label lblTuitionFee;
        private System.Windows.Forms.Label lblTotalUnits;
        private System.Windows.Forms.Label lblBalanceLabel;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Label lblAmountPaidLabel;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblMiscLabel;
        private System.Windows.Forms.Label lblTuitionLabel;
        private System.Windows.Forms.Label lblUnitsLabel;
        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrintAssessment;
        private System.Windows.Forms.GroupBox grpEnrollmentHistory;
        private System.Windows.Forms.DataGridView dgvEnrollmentHistory;
    }
}