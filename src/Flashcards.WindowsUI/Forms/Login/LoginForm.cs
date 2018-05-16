using System;
using System.Windows.Forms;
using Flashcards.WindowsUI.Controls;
using Flashcards.WindowsUI.Services;

namespace Flashcards.WindowsUI.Forms.Login
{
    public partial class LoginForm : FlashcardsForm
    {
        private readonly UsersService _usersService;

        public LoginForm()
        {
            _usersService = new UsersService();

            InitializeComponent();

            tbEmail.Text = "admin@januszmarcinik.pl";
            tbPassword.Text = "JAma94ikSZ";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _usersService.Auth(tbEmail.Text, tbPassword.Text);
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
