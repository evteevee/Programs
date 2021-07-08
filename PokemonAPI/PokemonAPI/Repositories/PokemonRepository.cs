using PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PokemonAPI.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokemonContext _context;

        public PokemonRepository(PokemonContext context)
        {
            _context = context;
        }

       

        public async Task<Pokemon> Create(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();

            return pokemon;
        }

        public async Task Delete(int id)
        {
            var pokemonToDelete = await _context.Pokemons.FindAsync(id);
            _context.Pokemons.Remove(pokemonToDelete);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Pokemon>> Get()
        {
            return await _context.Pokemons.ToListAsync();
        }

        public async Task<Pokemon> Get(int id)
        {
            return await _context.Pokemons.FindAsync(id);
        }

        public Pokemon GetName(string name)
        {
            Pokemon myPokemon = _context.Pokemons.Single(pokemon => pokemon.Name == name);

            return myPokemon;
        }

        public async Task Update(Pokemon pokemon)
        {
            _context.Entry(pokemon).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
