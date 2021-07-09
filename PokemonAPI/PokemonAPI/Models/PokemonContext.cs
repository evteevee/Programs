using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

//Context Object used for Entity Framework Core which allows querying and saving data
namespace PokemonAPI.Models
{
    //Pokemon Context inherits from DbContext class
    public class PokemonContext : DbContext

    {
        //configuration of the context, injected through dependency injection
        public PokemonContext(DbContextOptions<PokemonContext> options)
            : base(options)
        {
            //ensure database is created when using db context
            Database.EnsureCreated();
        }

        //represents a collection of Pokemon
        public DbSet<Pokemon> Pokemons { get; set; }
     }
}
