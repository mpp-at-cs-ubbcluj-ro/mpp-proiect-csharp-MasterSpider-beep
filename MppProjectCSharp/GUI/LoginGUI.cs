using System.Windows;
using MppProjectCSharp.Exceptions;
using MppProjectCSharp.GUI;
using MppProjectCSharp.services;
using TemaC.domain;

namespace MppProjectCSharp
{
    public partial class LoginGUI : Form
    {
        public LoginGUI()
        {
            InitializeComponent();
        }
        public LoginGUI(Service service)
        {
            InitializeComponent();
            this.service = service;
        }

        private Service service;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length == 0 || txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Please complete the required fields!");
                return;
            }
            try
            {
                User user = service.LogIn(txtUsername.Text, txtPassword.Text);
                MainForm mainForm = new MainForm(service);
                mainForm.User = user;
                mainForm.Show();
                this.Hide();
            }
            catch (LogInException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Select();
                txtPassword.Focus();
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void LoginGUI_Shown(object sender, EventArgs e)
        {
            txtUsername.Select();
            txtUsername.Focus();
        }

        public Service Service
        {
            set { service = value; }
        }

    }
}