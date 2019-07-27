﻿using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Domain.Users
{
    public class LoginUserCommand : ICommand
    {
        public Guid TokenId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}