using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;


namespace PokemonAPI.Models
{
    public class PokemonContext : DbContext

    {
        public PokemonContext(DbContextOptions<PokemonContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Pokemon> Pokemons { get; set; }
     }
}
