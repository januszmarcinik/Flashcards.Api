using System;
using Flashcards.WindowsUI.Controls;
using Flashcards.WindowsUI.Models;
using Flashcards.WindowsUI.Services;

namespace Flashcards.WindowsUI.Forms.Cards
{
    public partial class CardAddForm : FlashcardsForm
    {
        private readonly Topic _topic;
        private readonly string _category;
        private readonly string _deck;
        private readonly CardsService _cardsService;

        public CardAddForm(Topic topic, string category, string deck)
        {
            InitializeComponent();

            _topic = topic;
            _category = category;
            _deck = deck;
            _cardsService = new CardsService();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (_cardsService.Add(_topic, _category, _deck, new Card()
            {
                Title = tbTitle.Text,
                Question = tbQuestion.Text,
                Answer = tbAnswer.Text
            }))
            {
                Close();
            }
        }
    }
}
