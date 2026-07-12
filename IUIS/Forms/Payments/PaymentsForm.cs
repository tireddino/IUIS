using System;
using System.Windows.Forms;

namespace IUIS.Forms.Payments
{
    public partial class PaymentsForm : Form
    {
        public PaymentsForm()
        {
            InitializeComponent();
            this.Text = "Payments Management";
            this.Dock = DockStyle.Fill;
        }
    }
}
