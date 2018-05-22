using System.Windows.Forms;

namespace Flashcards.WindowsUI.Controls
{
    public static class FlashcardsMessageBox
    {
        public static bool YesNo(string text, string caption = "Confirm")
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        public static void Error(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Info(string text)
        {
            MessageBox.Show(text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
