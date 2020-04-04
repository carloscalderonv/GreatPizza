using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreatPizzaAPI.Domains
{
    public class ToppingPizza
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(PizzaId))]
        public Guid PizzaId { get; set; }
        public virtual Pizza Pizza{ get; set; }
        [ForeignKey(nameof(ToppingId))]
        public Guid ToppingId { get; set; }
        public virtual Topping Topping{ get; set; }
    }
}
