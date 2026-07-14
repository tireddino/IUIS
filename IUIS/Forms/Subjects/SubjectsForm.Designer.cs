namespace IUIS.Forms.Subjects
{
    partial class SubjectsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubjectCode;
        private System.Windows.Forms.Label lblSubjectName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.Label lblYearLevel;
        private System.Windows.Forms.Label lblPrerequisites;
        private System.Windows.Forms.TextBox txtSubjectCode;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.NumericUpDown numUnits;
        private System.Windows.Forms.NumericUpDown numSemester;
        private System.Windows.Forms.NumericUpDown numYearLevel;
        private System.Windows.Forms.TextBox txtPrerequisites;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvSubjects;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblRecordCount;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubjectCode = new System.Windows.Forms.Label();
            this.lblSubjectName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblUnits = new System.Windows.Forms.Label();
            this.lblSemester = new System.Windows.Forms.Label();
            this.lblYearLevel = new System.Windows.Forms.Label();
            this.lblPrerequisites = new System.Windows.Forms.Label();
            this.txtSubjectCode = new System.Windows.Forms.TextBox();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.numUnits = new System.Windows.Forms.NumericUpDown();
            this.numSemester = new System.Windows.Forms.NumericUpDown();
            this.numYearLevel = new System.Windows.Forms.NumericUpDown();
            this.txtPrerequisites = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvSubjects = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSemester)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.btnDelete);
            this.pnlForm.Controls.Add(this.btnClear);
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.txtPrerequisites);
            this.pnlForm.Controls.Add(this.lblPrerequisites);
            this.pnlForm.Controls.Add(this.numYearLevel);
            this.pnlForm.Controls.Add(this.lblYearLevel);
            this.pnlForm.Controls.Add(this.numSemester);
            this.pnlForm.Controls.Add(this.lblSemester);
            this.pnlForm.Controls.Add(this.numUnits);
            this.pnlForm.Controls.Add(this.lblUnits);
            this.pnlForm.Controls.Add(this.cmbCourse);
            this.pnlForm.Controls.Add(this.lblCourse);
            this.pnlForm.Controls.Add(this.txtDescription);
            this.pnlForm.Controls.Add(this.lblDescription);
            this.pnlForm.Controls.Add(this.txtSubjectName);
            this.pnlForm.Controls.Add(this.lblSubjectName);
            this.pnlForm.Controls.Add(this.txtSubjectCode);
            this.pnlForm.Controls.Add(this.lblSubjectCode);
            this.pnlForm.Controls.Add(this.lblTitle);
            this.pnlForm.Location = new System.Drawing.Point(20, 20);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(350, 580);
            this.pnlForm.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(85, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Subject Form";
            // 
            // lblSubjectCode
            // 
            this.lblSubjectCode.AutoSize = true;
            this.lblSubjectCode.Location = new System.Drawing.Point(15, 45);
            this.lblSubjectCode.Name = "lblSubjectCode";
            this.lblSubjectCode.Size = new System.Drawing.Size(85, 15);
            this.lblSubjectCode.TabIndex = 1;
            this.lblSubjectCode.Text = "Subject Code:";
            // 
            // txtSubjectCode
            // 
            this.txtSubjectCode.Location = new System.Drawing.Point(15, 63);
            this.txtSubjectCode.Name = "txtSubjectCode";
            this.txtSubjectCode.Size = new System.Drawing.Size(320, 23);
            this.txtSubjectCode.TabIndex = 2;
            // 
            // lblSubjectName
            // 
            this.lblSubjectName.AutoSize = true;
            this.lblSubjectName.Location = new System.Drawing.Point(15, 95);
            this.lblSubjectName.Name = "lblSubjectName";
            this.lblSubjectName.Size = new System.Drawing.Size(95, 15);
            this.lblSubjectName.TabIndex = 3;
            this.lblSubjectName.Text = "Subject Name:";
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(15, 113);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(320, 23);
            this.txtSubjectName.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(15, 145);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(70, 15);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(15, 163);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(320, 50);
            this.txtDescription.TabIndex = 6;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(15, 225);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(50, 15);
            this.lblCourse.TabIndex = 7;
            this.lblCourse.Text = "Course:";
            // 
            // cmbCourse
            // 
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.Location = new System.Drawing.Point(15, 243);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(320, 23);
            this.cmbCourse.TabIndex = 8;
            // 
            // lblUnits
            // 
            this.lblUnits.AutoSize = true;
            this.lblUnits.Location = new System.Drawing.Point(15, 275);
            this.lblUnits.Name = "lblUnits";
            this.lblUnits.Size = new System.Drawing.Size(40, 15);
            this.lblUnits.TabIndex = 9;
            this.lblUnits.Text = "Units:";
            // 
            // numUnits
            // 
            this.numUnits.Location = new System.Drawing.Point(15, 293);
            this.numUnits.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            this.numUnits.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numUnits.Name = "numUnits";
            this.numUnits.Size = new System.Drawing.Size(80, 23);
            this.numUnits.TabIndex = 10;
            this.numUnits.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Location = new System.Drawing.Point(110, 275);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(60, 15);
            this.lblSemester.TabIndex = 11;
            this.lblSemester.Text = "Semester:";
            // 
            // numSemester
            // 
            this.numSemester.Location = new System.Drawing.Point(110, 293);
            this.numSemester.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSemester.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            this.numSemester.Name = "numSemester";
            this.numSemester.Size = new System.Drawing.Size(60, 23);
            this.numSemester.TabIndex = 12;
            this.numSemester.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblYearLevel
            // 
            this.lblYearLevel.AutoSize = true;
            this.lblYearLevel.Location = new System.Drawing.Point(185, 275);
            this.lblYearLevel.Name = "lblYearLevel";
            this.lblYearLevel.Size = new System.Drawing.Size(70, 15);
            this.lblYearLevel.TabIndex = 13;
            this.lblYearLevel.Text = "Year Level:";
            // 
            // numYearLevel
            // 
            this.numYearLevel.Location = new System.Drawing.Point(185, 293);
            this.numYearLevel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numYearLevel.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numYearLevel.Name = "numYearLevel";
            this.numYearLevel.Size = new System.Drawing.Size(60, 23);
            this.numYearLevel.TabIndex = 14;
            this.numYearLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPrerequisites
            // 
            this.lblPrerequisites.AutoSize = true;
            this.lblPrerequisites.Location = new System.Drawing.Point(15, 325);
            this.lblPrerequisites.Name = "lblPrerequisites";
            this.lblPrerequisites.Size = new System.Drawing.Size(85, 15);
            this.lblPrerequisites.TabIndex = 15;
            this.lblPrerequisites.Text = "Prerequisites:";
            // 
            // txtPrerequisites
            // 
            this.txtPrerequisites.Location = new System.Drawing.Point(15, 343);
            this.txtPrerequisites.Multiline = true;
            this.txtPrerequisites.Name = "txtPrerequisites";
            this.txtPrerequisites.Size = new System.Drawing.Size(320, 40);
            this.txtPrerequisites.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 395);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(125, 395);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(235, 395);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.AllowUserToAddRows = false;
            this.dgvSubjects.AllowUserToDeleteRows = false;
            this.dgvSubjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSubjects.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.Location = new System.Drawing.Point(390, 20);
            this.dgvSubjects.MultiSelect = false;
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.ReadOnly = true;
            this.dgvSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubjects.Size = new System.Drawing.Size(580, 430);
            this.dgvSubjects.TabIndex = 1;
            this.dgvSubjects.SelectionChanged += new System.EventHandler(this.DgvSubjects_SelectionChanged);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.Controls.Add(this.lblRecordCount);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Location = new System.Drawing.Point(390, 460);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(580, 40);
            this.pnlSearch.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(10, 12);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(45, 15);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(60, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 23);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(380, 12);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(100, 15);
            this.lblRecordCount.TabIndex = 2;
            this.lblRecordCount.Text = "Total Records: 0";
            // 
            // SubjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 520);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.dgvSubjects);
            this.Controls.Add(this.pnlForm);
            this.Name = "SubjectsForm";
            this.Text = "Subjects Management";
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSemester)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
