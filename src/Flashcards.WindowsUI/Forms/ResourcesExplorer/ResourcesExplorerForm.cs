using System;
using Flashcards.WindowsUI.Controls;
using Flashcards.WindowsUI.Forms.Categories;
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

        private void lbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCategories.SelectedItem != null)
            {
                RefreshDecks((lbCategories.SelectedItem as Category)?.Name);
                lbCards.Items.Clear();
            }
        }

        private void lbDecks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCategories.SelectedItem != null && lbDecks.SelectedItem != null)
            {
                RefreshCards((lbCategories.SelectedItem as Category)?.Name, (lbDecks.SelectedItem as Deck)?.Name);
            }
        }

        private void btnCategoriesAdd_Click(object sender, EventArgs e)
        {
            new CategoryAddForm(_topic).ShowDialog();
        }
    }
}
