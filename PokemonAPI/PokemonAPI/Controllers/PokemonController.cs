using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models;
using PokemonAPI.Repositories;

namespace PokemonAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }
           
        [HttpGet]
        public async Task<IEnumerable<Pokemon>> GetPokemons()
        {
            return await _pokemonRepository.Get();
        }

        [HttpGet("{name}")]
        public Pokemon GetPokemons(string name)
        {

            return _pokemonRepository.GetName(name);
        }

        [HttpPost]
        public async Task<ActionResult<Pokemon>>PostPokemons([FromBody] Pokemon pokemon)
        {
            var newPokemon = await _pokemonRepository.Create(pokemon);
            return CreatedAtAction(nameof(GetPokemons), new { id = newPokemon.Id }, newPokemon);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pokemonToDelete = await _pokemonRepository.Get(id);
            if (pokemonToDelete == null)
                return NotFound();

            await _pokemonRepository.Delete(pokemonToDelete.Id);
            return NoContent();
        }



    }
}
