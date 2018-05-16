using System;
using Flashcards.WindowsUI.Controls;
using Flashcards.WindowsUI.Models;
using Flashcards.WindowsUI.Services;

namespace Flashcards.WindowsUI.Forms.Decks
{
    public partial class DeckAddForm : FlashcardsForm
    {
        private readonly Topic _topic;
        private readonly string _category;
        private readonly DecksService _decksService;

        public DeckAddForm(Topic topic, string category)
        {
            InitializeComponent();

            _topic = topic;
            _category = category;
            _decksService = new DecksService();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (_decksService.Add(_topic, _category, new Deck()
            {
                Name = tbName.Text,
                Description = tbDescription.Text
            }))
            {
                Close();
            }
        }
    }
}
