﻿using System.ComponentModel.DataAnnotations;

namespace LTIMindtree_API.Models
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
