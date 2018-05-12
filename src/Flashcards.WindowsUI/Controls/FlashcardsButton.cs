using System.Drawing;
using System.Windows.Forms;

namespace Flashcards.WindowsUI.Controls
{
    class FlashcardsButton : Button
    {
        public FlashcardsButton()
        {
            BackColor = Color.SandyBrown;
            FlatStyle = FlatStyle.Popup;
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Size = new Size(125, 30);
            UseVisualStyleBackColor = false;
        }
    }
}
