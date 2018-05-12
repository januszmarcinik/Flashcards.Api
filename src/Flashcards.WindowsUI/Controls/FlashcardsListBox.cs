using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Flashcards.WindowsUI.Infrastructure;

namespace Flashcards.WindowsUI.Controls
{
    public class FlashcardsListBox : ListBox
    {
        public void LoadItems(IEnumerable<IControlItem> items)
        {
            Items.Clear();
            Items.AddRange(items.ToArray());
            DisplayMember = nameof(IControlItem.Display);
        }
    }
}
