using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Pokedex.Models;

namespace Pokedex.Services.Interfaces
{
	public interface IPokemonService
	{
		Task<List<Pokemon>> GetPokemons(int limit = 0,int offset = 20);
        Task<List<PokemonDetail>> GetPokemons(int offset = 20);

        Task<PokemonDetail> GetPokemonDetailByNameOrId(string nameOrId);
    }
}

