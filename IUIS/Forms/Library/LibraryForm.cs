using System;
using System.Windows.Forms;

namespace IUIS.Forms.Library
{
    public partial class LibraryForm : Form
    {
        public LibraryForm()
        {
            InitializeComponent();
            this.Text = "Library Management";
            this.Dock = DockStyle.Fill;
        }
    }
}
