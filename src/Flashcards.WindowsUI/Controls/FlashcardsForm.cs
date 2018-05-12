using System.Drawing;
using System.Windows.Forms;

namespace Flashcards.WindowsUI.Controls
{
    public class FlashcardsForm : Form
    {
        public FlashcardsForm()
        {
            ClientSize = new System.Drawing.Size(800, 600);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(255, 81, 139, 191);
        }
    }
}
