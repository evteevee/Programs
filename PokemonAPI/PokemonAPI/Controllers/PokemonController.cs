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
using System.Web;
using System.Web.Http.Cors;

//API controller is a class responsible for handling requests for an Endpoint
namespace PokemonAPI.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]

    //route the controller will handle 
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;

        //injecting pokemon repository
        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }
           
        //method will handle HTTPGET requests
        [HttpGet]
        public async Task<IEnumerable<Pokemon>> GetPokemons()
        {
            //returns all pokemon
            return await _pokemonRepository.Get();
        }

        //returns a single pokemon that matches the arguement name
        [HttpGet("{name}")]
        public Pokemon GetPokemons(string name)
        {
            return _pokemonRepository.GetName(name);
        }

        //handles post requests for creating a new pokemon instance in the database
        [HttpPost]
        public async Task<ActionResult<Pokemon>>PostPokemons([FromBody] Pokemon pokemon)
        {
            var newPokemon = await _pokemonRepository.Create(pokemon);
            return CreatedAtAction(nameof(GetPokemons), new { id = newPokemon.Id }, newPokemon);
        }

        //handles post requests for creating a new pokemon instance in the database
        [HttpPut]
        public async Task<ActionResult> PutPokemon(int id, [FromBody] Pokemon pokemon)
        {
            if (id != pokemon.Id)
            {
                return BadRequest();
            }

            await _pokemonRepository.Update(pokemon);

            return NoContent();
        }

        //handle delete requests for removing specific pokemon instance from database using id as identifier 
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
