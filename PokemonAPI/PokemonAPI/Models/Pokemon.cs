using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

//Pokemon Model used to create instances of a Pokemon 
//Each Pokemon Model will have a unique key Id generated automatically, Pokemon Name and a Shakespearean Description as the project requires
namespace PokemonAPI.Models
{
    public class Pokemon
    {
        //unique Id
        public int Id { get; set; }

        //Pokemon Name
        public string Name { get; set; }

        //Shakespearean Description
        public string Description { get; set; }
    }
}
