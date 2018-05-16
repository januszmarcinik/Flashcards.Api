using System;
using Flashcards.WindowsUI.Controls;
using Flashcards.WindowsUI.Models;
using Flashcards.WindowsUI.Services;

namespace Flashcards.WindowsUI.Forms.Categories
{
    public partial class CategoryEditForm : FlashcardsForm
    {
        private readonly Topic _topic;
        private readonly Category _category;
        private readonly CategoriesService _categoriesService;

        public CategoryEditForm(Topic topic, Category category)
        {
            InitializeComponent();

            _topic = topic;
            _category = category;
            _categoriesService = new CategoriesService();

            tbName.Text = _category.Name;
            tbDescription.Text = _category.Description;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _category.Name = tbName.Text;
            _category.Description = tbDescription.Text;

            if (_categoriesService.Edit(_topic, _category))
            {
                Close();
            }
        }
    }
}
