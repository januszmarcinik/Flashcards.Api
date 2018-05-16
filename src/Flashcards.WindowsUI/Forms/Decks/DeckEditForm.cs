using System;
using Flashcards.WindowsUI.Controls;
using Flashcards.WindowsUI.Models;
using Flashcards.WindowsUI.Services;

namespace Flashcards.WindowsUI.Forms.Decks
{
    public partial class DeckEditForm : FlashcardsForm
    {
        private readonly Topic _topic;
        private readonly string _category;
        private readonly Deck _deck;
        private readonly DecksService _decksService;

        public DeckEditForm(Topic topic, string category, Deck deck)
        {
            InitializeComponent();

            _topic = topic;
            _category = category;
            _deck = deck;
            _decksService = new DecksService();

            tbName.Text = deck.Name;
            tbDescription.Text = deck.Description;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _deck.Name = tbName.Text;
            _deck.Description = tbDescription.Text;

            if (_decksService.Edit(_topic, _category, _deck))
            {
                Close();
            }
        }
    }
}
