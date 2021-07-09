using PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


//this class implements the Pokemon Repository interface
namespace PokemonAPI.Repositories
{

    //query the database using the Pokemon Context
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokemonContext _context;

        public PokemonRepository(PokemonContext context)
        {
            _context = context;
        }

       
        //add method of dbset to add new instance of pokemon class
        public async Task<Pokemon> Create(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();

            return pokemon;
        }

        //uses remove method of dbset for deleting pokemon instance
        public async Task Delete(int id)
        {
            var pokemonToDelete = await _context.Pokemons.FindAsync(id);
            _context.Pokemons.Remove(pokemonToDelete);
            await _context.SaveChangesAsync();

        }

        //fetch all the pokemons from database
        public async Task<IEnumerable<Pokemon>> Get()
        {
            return await _context.Pokemons.ToListAsync();
        }

        //takes an integer id parameter to retrieve a specific pokemon
        public async Task<Pokemon> Get(int id)
        {
            return await _context.Pokemons.FindAsync(id);
        }

        //takes name string and returns an object of pokemon that matches the name
        public Pokemon GetName(string name)
        {

            return _context.Pokemons.Single(pokemon => pokemon.Name == name);

        }

        //change state of entity and savechangeasync method will update the entity in db
        public async Task Update(Pokemon pokemon)
        {
            _context.Entry(pokemon).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
