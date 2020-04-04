﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GreatPizzaAPI.Domains
{
    public class Pizza
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
