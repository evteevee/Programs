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
            Pokemon newPokemon = new Pokemon();

            //check if input name is integer
            if (CheckNameIsINT(pokemon.Name))
            {
                newPokemon.Id = 0;
                newPokemon.Name = "Error: Pokemon Name cannot be number(s)!";
                newPokemon.Description = "Error: Pokemon Name cannot be number(s)!";
                return newPokemon;
            }
            else
            {
                //check if input name is exist
                if (CheckNameExist(pokemon.Name))
                {
                    newPokemon.Id = 0;
                    newPokemon.Name = "Error: Pokemon already exist in the system!";
                    newPokemon.Description = "Error: Pokemon already exist in the system!";
                    return newPokemon;
                }
                else
                {
                    //create if it does not exist and name format is valid
                    _context.Pokemons.Add(pokemon);
                    await _context.SaveChangesAsync();

                    return pokemon;
                }
            }
        }

        //uses remove method of dbset for deleting pokemon instance
        public async Task Delete(int id)
        {
            var pokemonToDelete = await _context.Pokemons.FindAsync(id);
            _context.Pokemons.Remove(pokemonToDelete);
            await _context.SaveChangesAsync();

        }

        //catch if Pokemon name is blank.
        public Pokemon BlankInput()
        {
            Pokemon emptyPokemon = new Pokemon();
            emptyPokemon.Name = "Error: Name is blank!";
            emptyPokemon.Description = "Error: Name is blank!";
            return emptyPokemon;
        }

        //takes an integer id parameter to retrieve a specific pokemon
        public async Task<Pokemon> Get(int id)
        {
            return await _context.Pokemons.FindAsync(id);
        }

        //takes name string and returns an object of pokemon that matches the name
        public Pokemon GetName(string name)
        {
            Pokemon retrievedPokemon = new Pokemon();

            //check if input name is integer
            if (CheckNameIsINT(name))
            {
                retrievedPokemon.Name = "Error: Pokemon Name cannot be number(s)!";
                retrievedPokemon.Description = "Error: Pokemon Name cannot be number(s)";
                return retrievedPokemon;
            }
            else
            {
                //check if input name is exist and retrieve
                if (CheckNameExist(name))
                {
                    retrievedPokemon = _context.Pokemons.Single(pokemon => pokemon.Name == name);
                    return retrievedPokemon;
                }
                else
                {
                    //throw error message if pokemon name input format is valid but does not exist
                    retrievedPokemon.Name = "Error: Pokemon does not exist in the system!";
                    retrievedPokemon.Description = "Error: Pokemon does not exist in the system!";
                    return retrievedPokemon;
                }
                
            }
        }

        //check if pokemon name input is an integer
        public bool CheckNameIsINT(string name)
        {
            if (int.TryParse(name, out int result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //check if pokemon name exist in db
        public bool CheckNameExist(string name)
        {
            Pokemon retrievedPokemon = new Pokemon();

            //return true if pokemon name exist in the system (if no object null error)
            try
            {
                retrievedPokemon = _context.Pokemons.Single(pokemon => pokemon.Name == name);
                return true;
            }
            //return false if object null error (does not exist)
            catch
            {
                return false;
            }
        }

        //change state of entity and savechangeasync method will update the entity in db
        public async Task Update(Pokemon pokemon)
        {
            _context.Entry(pokemon).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
