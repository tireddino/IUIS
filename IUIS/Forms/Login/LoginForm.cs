using System;
using System.Drawing;
using System.Windows.Forms;

namespace IUIS.Forms.Login
{
    public partial class LoginForm : Form
    {
        private readonly Utilities.UserRepository _userRepository;

        public LoginForm()
        {
            InitializeComponent();
            _userRepository = new Utilities.UserRepository();
            
            // Apply modern UI styling
            ApplyModernStyle();
        }

        private void ApplyModernStyle()
        {
            this.Text = "IUIS - Login";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            // Modern color scheme
            this.BackColor = Color.FromArgb(245, 247, 250);
            
            // Style the login panel
            pnlLogin.BackColor = Color.White;
            pnlLogin.Location = new Point((this.ClientSize.Width - pnlLogin.Width) / 2, 
                                          (this.ClientSize.Height - pnlLogin.Height) / 2);
            pnlLogin.Anchor = AnchorStyles.None;
            
            // Style labels
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(51, 51, 51);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            
            lblUsername.Font = new Font("Segoe UI", 10F);
            lblUsername.ForeColor = Color.FromArgb(51, 51, 51);
            
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.ForeColor = Color.FromArgb(51, 51, 51);
            
            // Style textboxes
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Padding = new Padding(5);
            
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.PasswordChar = '•';
            txtPassword.Padding = new Padding(5);
            
            // Style buttons
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.BackColor = Color.FromArgb(0, 123, 255);
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.Cursor = Cursors.Hand;
            
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 1;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnClear.BackColor = Color.White;
            btnClear.ForeColor = Color.FromArgb(51, 51, 51);
            btnClear.Font = new Font("Segoe UI", 10F);
            btnClear.Cursor = Cursors.Hand;
            
            // Style error label
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.ForeColor = Color.Red;
            lblError.Visible = false;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;

                if (string.IsNullOrWhiteSpace(username))
                {
                    ShowError("Please enter username");
                    txtUsername.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    ShowError("Please enter password");
                    txtPassword.Focus();
                    return;
                }

                var user = _userRepository.Authenticate(username, password);

                if (user != null)
                {
                    // Update last login
                    user.LastLogin = DateTime.Now;
                    _userRepository.Update(user);

                    // Open dashboard
                    var dashboard = new Dashboard.DashboardForm(user);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    ShowError("Invalid username or password");
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            lblError.Visible = false;
            txtUsername.Focus();
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void TxtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Create default admin user if no users exist
            var users = _userRepository.GetAll();
            if (users.Count == 0)
            {
                var adminUser = new Models.User
                {
                    Username = "admin",
                    Password = "admin123",
                    Role = "Administrator",
                    FullName = "System Administrator"
                };
                _userRepository.Add(adminUser);
                
                MessageBox.Show("Default admin account created.\nUsername: admin\nPassword: admin123", 
                    "First Time Setup", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
        }
    }
}
