using System;
using System.Windows.Forms;

namespace IUIS.Forms.Medical
{
    public partial class MedicalForm : Form
    {
        public MedicalForm()
        {
            InitializeComponent();
            this.Text = "Medical Management";
            this.Dock = DockStyle.Fill;
        }
    }
}
