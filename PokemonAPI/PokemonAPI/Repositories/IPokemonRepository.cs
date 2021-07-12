using PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

//Repositories are layers that sits between application and data access layer (Pokemon Context)
//this is just for good practice for abstraction between code and data access
namespace PokemonAPI.Repositories
{
    //Interface describes operations that can be performed against the database
    public interface IPokemonRepository
    {
        Pokemon BlankInput();

        //retrieves a single pokemon using its id key (not used)
        Task<Pokemon> Get(int id);

        //retrieves a single pokemon using its name as required
        Pokemon GetName(string name);

        //additional features for adding new Pokemon, updating its data, and deleting if no longer needed or if duplication occurs
        Task<Pokemon> Create(Pokemon pokemon);
        Task Update(Pokemon pokemon);
        Task Delete(int id);

        //check if input name is integer
        bool CheckNameIsINT(string name);

        //check if input name is exist
        bool CheckNameExist(string name);
    }
}
