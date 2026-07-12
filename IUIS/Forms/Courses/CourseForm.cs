using System;
using System.Windows.Forms;

namespace IUIS.Forms.Courses
{
    public partial class CourseForm : Form
    {
        public CourseForm()
        {
            InitializeComponent();
            this.Text = "Course Management";
            this.Dock = DockStyle.Fill;
        }
    }
}
