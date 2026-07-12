using System;
using System.Windows.Forms;

namespace IUIS.Forms.Enrollment
{
    public partial class EnrollmentForm : Form
    {
        public EnrollmentForm()
        {
            InitializeComponent();
            this.Text = "Enrollment Management";
            this.Dock = DockStyle.Fill;
        }
    }
}
