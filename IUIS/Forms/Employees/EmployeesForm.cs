using System;
using System.Windows.Forms;

namespace IUIS.Forms.Employees
{
    public partial class EmployeesForm : Form
    {
        public EmployeesForm()
        {
            InitializeComponent();
            this.Text = "Employees Management";
            this.Dock = DockStyle.Fill;
        }
    }
}
