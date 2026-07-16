namespace IUIS.Forms.Students
{
    partial class StudentForm
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
            this.pnlForm = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.cbEnrollmentStatus = new System.Windows.Forms.ComboBox();
            this.numYearLevel = new System.Windows.Forms.NumericUpDown();
            this.cbCourse = new System.Windows.Forms.ComboBox();
            this.txtGuardianContact = new System.Windows.Forms.TextBox();
            this.txtGuardianName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblGuardianContact = new System.Windows.Forms.Label();
            this.lblGuardianName = new System.Windows.Forms.Label();
            this.lblEnrollmentStatus = new System.Windows.Forms.Label();
            this.lblYearLevel = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYearLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.btnDelete);
            this.pnlForm.Controls.Add(this.btnClear);
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.dtpDateOfBirth);
            this.pnlForm.Controls.Add(this.cbEnrollmentStatus);
            this.pnlForm.Controls.Add(this.numYearLevel);
            this.pnlForm.Controls.Add(this.cbCourse);
            this.pnlForm.Controls.Add(this.txtGuardianContact);
            this.pnlForm.Controls.Add(this.txtGuardianName);
            this.pnlForm.Controls.Add(this.txtAddress);
            this.pnlForm.Controls.Add(this.txtPhone);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.txtLastName);
            this.pnlForm.Controls.Add(this.txtMiddleName);
            this.pnlForm.Controls.Add(this.txtFirstName);
            this.pnlForm.Controls.Add(this.txtStudentId);
            this.pnlForm.Controls.Add(this.lblDateOfBirth);
            this.pnlForm.Controls.Add(this.lblGuardianContact);
            this.pnlForm.Controls.Add(this.lblGuardianName);
            this.pnlForm.Controls.Add(this.lblEnrollmentStatus);
            this.pnlForm.Controls.Add(this.lblYearLevel);
            this.pnlForm.Controls.Add(this.lblCourse);
            this.pnlForm.Controls.Add(this.lblAddress);
            this.pnlForm.Controls.Add(this.lblPhone);
            this.pnlForm.Controls.Add(this.lblEmail);
            this.pnlForm.Controls.Add(this.lblLastName);
            this.pnlForm.Controls.Add(this.lblMiddleName);
            this.pnlForm.Controls.Add(this.lblFirstName);
            this.pnlForm.Controls.Add(this.lblStudentId);
            this.pnlForm.Controls.Add(this.lblTitle);
            this.pnlForm.Location = new System.Drawing.Point(17, 17);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(300, 545);
            this.pnlForm.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(201, 507);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 26);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(107, 507);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 26);
            this.btnClear.TabIndex = 28;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 507);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 26);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(154, 479);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(133, 20);
            this.dtpDateOfBirth.TabIndex = 26;
            // 
            // cbEnrollmentStatus
            // 
            this.cbEnrollmentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEnrollmentStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive",
            "Graduated",
            "Dropped"});
            this.cbEnrollmentStatus.Location = new System.Drawing.Point(219, 393);
            this.cbEnrollmentStatus.Name = "cbEnrollmentStatus";
            this.cbEnrollmentStatus.Size = new System.Drawing.Size(69, 21);
            this.cbEnrollmentStatus.TabIndex = 20;
            // 
            // numYearLevel
            // 
            this.numYearLevel.Location = new System.Drawing.Point(154, 393);
            this.numYearLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numYearLevel.Name = "numYearLevel";
            this.numYearLevel.Size = new System.Drawing.Size(51, 20);
            this.numYearLevel.TabIndex = 18;
            this.numYearLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbCourse
            // 
            this.cbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCourse.Location = new System.Drawing.Point(13, 393);
            this.cbCourse.Name = "cbCourse";
            this.cbCourse.Size = new System.Drawing.Size(129, 21);
            this.cbCourse.TabIndex = 16;
            // 
            // txtGuardianContact
            // 
            this.txtGuardianContact.Location = new System.Drawing.Point(13, 479);
            this.txtGuardianContact.Name = "txtGuardianContact";
            this.txtGuardianContact.Size = new System.Drawing.Size(275, 20);
            this.txtGuardianContact.TabIndex = 24;
            // 
            // txtGuardianName
            // 
            this.txtGuardianName.Location = new System.Drawing.Point(13, 436);
            this.txtGuardianName.Name = "txtGuardianName";
            this.txtGuardianName.Size = new System.Drawing.Size(275, 20);
            this.txtGuardianName.TabIndex = 22;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(13, 323);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(275, 44);
            this.txtAddress.TabIndex = 14;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(13, 280);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(275, 20);
            this.txtPhone.TabIndex = 12;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(13, 237);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(275, 20);
            this.txtEmail.TabIndex = 10;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(13, 193);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(275, 20);
            this.txtLastName.TabIndex = 8;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(13, 150);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(275, 20);
            this.txtMiddleName.TabIndex = 6;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(13, 107);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(275, 20);
            this.txtFirstName.TabIndex = 4;
            // 
            // txtStudentId
            // 
            this.txtStudentId.Location = new System.Drawing.Point(13, 63);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(275, 20);
            this.txtStudentId.TabIndex = 2;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(154, 464);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(69, 13);
            this.lblDateOfBirth.TabIndex = 25;
            this.lblDateOfBirth.Text = "Date of Birth:";
            // 
            // lblGuardianContact
            // 
            this.lblGuardianContact.AutoSize = true;
            this.lblGuardianContact.Location = new System.Drawing.Point(13, 464);
            this.lblGuardianContact.Name = "lblGuardianContact";
            this.lblGuardianContact.Size = new System.Drawing.Size(93, 13);
            this.lblGuardianContact.TabIndex = 23;
            this.lblGuardianContact.Text = "Guardian Contact:";
            // 
            // lblGuardianName
            // 
            this.lblGuardianName.AutoSize = true;
            this.lblGuardianName.Location = new System.Drawing.Point(13, 420);
            this.lblGuardianName.Name = "lblGuardianName";
            this.lblGuardianName.Size = new System.Drawing.Size(84, 13);
            this.lblGuardianName.TabIndex = 21;
            this.lblGuardianName.Text = "Guardian Name:";
            // 
            // lblEnrollmentStatus
            // 
            this.lblEnrollmentStatus.AutoSize = true;
            this.lblEnrollmentStatus.Location = new System.Drawing.Point(219, 377);
            this.lblEnrollmentStatus.Name = "lblEnrollmentStatus";
            this.lblEnrollmentStatus.Size = new System.Drawing.Size(40, 13);
            this.lblEnrollmentStatus.TabIndex = 19;
            this.lblEnrollmentStatus.Text = "Status:";
            // 
            // lblYearLevel
            // 
            this.lblYearLevel.AutoSize = true;
            this.lblYearLevel.Location = new System.Drawing.Point(154, 377);
            this.lblYearLevel.Name = "lblYearLevel";
            this.lblYearLevel.Size = new System.Drawing.Size(61, 13);
            this.lblYearLevel.TabIndex = 17;
            this.lblYearLevel.Text = "Year Level:";
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(13, 377);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(43, 13);
            this.lblCourse.TabIndex = 15;
            this.lblCourse.Text = "Course:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(13, 308);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 13;
            this.lblAddress.Text = "Address:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(13, 264);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 13);
            this.lblPhone.TabIndex = 11;
            this.lblPhone.Text = "Phone:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(13, 221);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(13, 178);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 7;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Location = new System.Drawing.Point(13, 134);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(72, 13);
            this.lblMiddleName.TabIndex = 5;
            this.lblMiddleName.Text = "Middle Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(13, 91);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 3;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblStudentId
            // 
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Location = new System.Drawing.Point(13, 48);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(61, 13);
            this.lblStudentId.TabIndex = 1;
            this.lblStudentId.Text = "Student ID:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(86, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(135, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Student Form";
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(334, 69);
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(729, 493);
            this.dgvStudents.TabIndex = 1;
            this.dgvStudents.SelectionChanged += new System.EventHandler(this.DgvStudents_SelectionChanged);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.lblRecordCount);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Location = new System.Drawing.Point(334, 17);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(729, 43);
            this.pnlSearch.TabIndex = 2;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(600, 13);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(86, 13);
            this.lblRecordCount.TabIndex = 2;
            this.lblRecordCount.Text = "Total Records: 0";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(9, 13);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(58, 19);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(69, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(258, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 597);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.pnlForm);
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Student Management";
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearLevel)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblYearLevel;
        private System.Windows.Forms.Label lblEnrollmentStatus;
        private System.Windows.Forms.Label lblGuardianName;
        private System.Windows.Forms.Label lblGuardianContact;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtGuardianName;
        private System.Windows.Forms.TextBox txtGuardianContact;
        private System.Windows.Forms.ComboBox cbCourse;
        private System.Windows.Forms.NumericUpDown numYearLevel;
        private System.Windows.Forms.ComboBox cbEnrollmentStatus;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblRecordCount;
    }
}
