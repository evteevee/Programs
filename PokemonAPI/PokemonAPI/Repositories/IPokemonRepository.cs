using PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PokemonAPI.Repositories
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<Pokemon>> Get();
        Task<Pokemon> Get(int id);
        Pokemon GetName(string name);

        Task<Pokemon> Create(Pokemon pokemon);
        Task Update(Pokemon pokemon);
        Task Delete(int id);
    }
}
