using System;
using Flashcards.WindowsUI.Controls;
using Flashcards.WindowsUI.Extensions;
using Flashcards.WindowsUI.Models;
using Flashcards.WindowsUI.Services;

namespace Flashcards.WindowsUI.Forms.Cards
{
    public partial class CardEditForm : FlashcardsForm
    {
        private readonly Topic _topic;
        private readonly string _category;
        private readonly string _deck;
        private readonly CardsService _cardsService;
        private Card _card;

        public CardEditForm(Topic topic, string category, string deck, Guid id)
        {
            InitializeComponent();

            _topic = topic;
            _category = category;
            _deck = deck;
            _cardsService = new CardsService();

            _card = _cardsService.GetById(_topic, _category, _deck, id);

            SetControlsValues(_card);
            ToggleEditMode(false);
            btnSave.Visible = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (_cardsService.Edit(_topic, _category, _deck, new Card()
            {
                Id = _card.Id,
                Title = tbTitle.Text,
                Question = tbQuestion.Text,
                Answer = tbAnswer.Text
            }))
            {
                ToggleEditMode(false);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ToggleEditMode(true);
        }

        private void ToggleEditMode(bool enable)
        {
            tbQuestion.Enabled = enable;
            tbAnswer.Enabled = enable;
            tbTitle.Enabled = enable;
            btnSave.Visible = enable;
            btnEdit.Visible = !enable;
        }

        private void SetControlsValues(Card card)
        {
            tbQuestion.Text = card.Question;
            tbAnswer.Text = card.Answer;
            tbTitle.Text = card.Title;
            btnPrevious.Enabled = !card.PreviousCardId.IsEmpty();
            btnNext.Enabled = !card.NextCardId.IsEmpty();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _card = _cardsService.GetById(_topic, _category, _deck, _card.PreviousCardId);
            SetControlsValues(_card);
            ToggleEditMode(false);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _card = _cardsService.GetById(_topic, _category, _deck, _card.NextCardId);
            SetControlsValues(_card);
            ToggleEditMode(false);
        }
    }
}
