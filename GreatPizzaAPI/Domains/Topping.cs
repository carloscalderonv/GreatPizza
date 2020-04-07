using System;
using System.ComponentModel.DataAnnotations;

namespace GreatPizzaAPI.Domains
{
    public class Topping
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
    }
}
