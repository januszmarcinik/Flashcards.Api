using System;
using System.Windows.Forms;
using Flashcards.WindowsUI.Forms.Login;

namespace Flashcards.WindowsUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
