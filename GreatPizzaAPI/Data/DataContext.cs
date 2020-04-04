using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GreatPizzaAPI.Domains;

namespace GreatPizzaAPI.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Topping> Topping { get; set; }
        public DbSet<ToppingPizza> ToppingPizza { get; set; }
    }
}
