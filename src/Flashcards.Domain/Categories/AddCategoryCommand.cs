﻿using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Domain.Categories
{
    public class AddCategoryCommand : ICommand
    {
        [Required]
        [MaxLength(32)]
        [RegularExpression(@"([A-Za-z\d\-]+)", ErrorMessage = "Name can contains only letters from a-z and \"-\" not case sensitive.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public Topic? Topic { get; set; }
    }
}
