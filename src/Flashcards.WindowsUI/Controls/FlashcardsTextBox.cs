using System.Drawing;
using System.Windows.Forms;

namespace Flashcards.WindowsUI.Controls
{
    public class FlashcardsTextBox : TextBox
    {
        public FlashcardsTextBox()
        {
            Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Size = new Size(258, 26);
        }
    }
}
