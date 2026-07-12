using System;
using System.Windows.Forms;

namespace IUIS.Forms.Attendance
{
    public partial class AttendanceForm : Form
    {
        public AttendanceForm()
        {
            InitializeComponent();
            this.Text = "Attendance Management";
            this.Dock = DockStyle.Fill;
        }
    }
}
