using System;
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_usersService.Auth(tbEmail.Text, tbPassword.Text))
            {
                Close();
            }
        }
    }
}
