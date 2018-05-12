using System.Windows.Forms;
using System.Drawing;

namespace Flashcards.WindowsUI.Controls
{
    public class FlashcardsLabel : Label
    {
        public FlashcardsLabel()
        {
            AutoSize = false;
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackColor = Color.Moccasin;
            TextAlign = ContentAlignment.MiddleCenter;
            Margin = new Padding(3);
            Size = new Size(134, 23);
        }
    }
}
