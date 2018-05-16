using System.Windows.Forms;

namespace Flashcards.WindowsUI.Controls
{
    public static class FlashcardsMessageBox
    {
        public static bool YesNo(string text, string caption = "Confirm")
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }
    }
}
