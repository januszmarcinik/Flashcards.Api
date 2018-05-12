using System.Windows.Forms;
using Flashcards.WindowsUI.Controls;
using Flashcards.WindowsUI.Forms.ResourcesExplorer;
using Flashcards.WindowsUI.Models;

namespace Flashcards.WindowsUI.Forms.Dashboard
{
    public partial class DashboardForm : FlashcardsForm
    {
        public DashboardForm() : base()
        {
            InitializeComponent();
        }

        private void btnIt_Click(object sender, System.EventArgs e)
        {
            new ResourcesExplorerForm(Topic.It).ShowDialog();
        }

        private void btnEnPl_Click(object sender, System.EventArgs e)
        {
            new ResourcesExplorerForm(Topic.EnPl).ShowDialog();
        }

        private void DashboardForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
