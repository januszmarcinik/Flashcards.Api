using System;
using Flashcards.WindowsUI.Controls;
using Flashcards.WindowsUI.Forms.Cards;
using Flashcards.WindowsUI.Forms.Categories;
using Flashcards.WindowsUI.Forms.Decks;
using Flashcards.WindowsUI.Forms.Session;
using Flashcards.WindowsUI.Models;
using Flashcards.WindowsUI.Services;

namespace Flashcards.WindowsUI.Forms.ResourcesExplorer
{
    public partial class ResourcesExplorerForm : FlashcardsForm
    {
        private readonly CategoriesService _categoriesService;
        private readonly DecksService _decksService;
        private readonly CardsService _cardsService;

        private readonly Topic _topic;

        public ResourcesExplorerForm(Topic topic)
        {
            InitializeComponent();
            _topic = topic;

            _categoriesService = new CategoriesService();
            _decksService = new DecksService();
            _cardsService = new CardsService();

            RefreshCategories();
        }

        #region Refresh

        private void RefreshCategories()
        {
            lbCategories.LoadItems(_categoriesService.GetAll(_topic));
        }

        private void RefreshDecks(string category)
        {
            lbDecks.LoadItems(_decksService.GetAll(_topic, category));
        }

        private void RefreshCards(string category, string deck)
        {
            lbCards.LoadItems(_cardsService.GetAll(_topic, category, deck));
        }

        #endregion

        #region SelectedIndexChanged

        private void LbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCategories.SelectedItem != null)
            {
                RefreshDecks((lbCategories.SelectedItem as Category)?.Name);
                lbCards.Items.Clear();
            }
        }

        private void LbDecks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCategories.SelectedItem != null && lbDecks.SelectedItem != null)
            {
                RefreshCards((lbCategories.SelectedItem as Category)?.Name, (lbDecks.SelectedItem as Deck)?.Name);
            }
        }

        #endregion

        #region Categories

        private void BtnCategoriesAdd_Click(object sender, EventArgs e)
        {
            new CategoryAddForm(_topic).ShowDialog();
            RefreshCategories();
        }

        private void BtnCategoriesEdit_Click(object sender, EventArgs e)
        {
            if (lbCategories.SelectedItem != null)
            {
                new CategoryEditForm(_topic, lbCategories.SelectedItem as Category).ShowDialog();
                RefreshCategories();
            }
        }

        private void BtnCategoriesDelete_Click(object sender, EventArgs e)
        {
            if (lbCategories.SelectedItem != null)
            {
                if (FlashcardsMessageBox.YesNo("Are you sure to delete category with all decks and cards?"))
                {
                    _categoriesService.Delete(_topic, ((Category)lbCategories.SelectedItem).Id);
                    RefreshCategories();
                }
            }
        }

        #endregion

        #region Decks

        private void BtnDecksAdd_Click(object sender, EventArgs e)
        {
            if (lbCategories.SelectedItem != null)
            {
                var category = (lbCategories.SelectedItem as Category)?.Name;
                new DeckAddForm(_topic, category).ShowDialog();
                RefreshDecks(category);
            }
        }

        private void BtnDecksEdit_Click(object sender, EventArgs e)
        {
            if (lbDecks.SelectedItem != null)
            {
                var category = (lbCategories.SelectedItem as Category)?.Name;
                new DeckEditForm(_topic, category, (Deck)lbDecks.SelectedItem).ShowDialog();
                RefreshDecks(category);
            }
        }

        private void BtnDecksDelete_Click(object sender, EventArgs e)
        {
            if (lbDecks.SelectedItem != null)
            {
                if (FlashcardsMessageBox.YesNo("Are you sure to delete deck with all cards?"))
                {
                    var category = (lbCategories.SelectedItem as Category)?.Name;
                    _decksService.Delete(_topic, category, ((Deck)lbDecks.SelectedItem).Id);
                    RefreshDecks(category);
                }
            }
        }

        #endregion

        #region Cards

        private void BtnCardsAdd_Click(object sender, EventArgs e)
        {
            if (lbDecks.SelectedItem != null)
            {
                var category = (lbCategories.SelectedItem as Category)?.Name;
                var deck = (lbDecks.SelectedItem as Deck)?.Name;
                new CardAddForm(_topic, category, deck).ShowDialog();
                RefreshCards(category, deck);
            }
        }

        private void BtnCardsEdit_Click(object sender, EventArgs e)
        {
            if (lbCards.SelectedItem != null)
            {
                var category = (lbCategories.SelectedItem as Category)?.Name;
                var deck = (lbDecks.SelectedItem as Deck)?.Name;
                new CardEditForm(_topic, category, deck, ((Card)lbCards.SelectedItem).Id).ShowDialog();
                RefreshCards(category, deck);
            }
        }

        private void BtnCardsDelete_Click(object sender, EventArgs e)
        {
            if (lbCards.SelectedItem != null)
            {
                if (FlashcardsMessageBox.YesNo("Are you sure to delete card?"))
                {
                    var category = (lbCategories.SelectedItem as Category)?.Name;
                    var deck = (lbDecks.SelectedItem as Deck)?.Name;
                    _cardsService.Delete(_topic, category, deck, ((Card)lbCards.SelectedItem).Id);
                    RefreshCards(category, deck);
                }
            }
        }

        #endregion

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (lbCategories.SelectedItem != null && lbDecks.SelectedItem != null)
            {
                var category = (lbCategories.SelectedItem as Category)?.Name;
                var deck = (lbDecks.SelectedItem as Deck)?.Name;
                new SessionForm(_topic, category, deck).ShowDialog();
            }
        }
    }
}
