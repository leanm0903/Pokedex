using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Pokedex.Commons.RestService;
using Pokedex.Models;
using Pokedex.Services.Interfaces;

namespace Pokedex.Services
{
	public class PokemonService : IPokemonService
	{
        private readonly IRestService restService;
        private const string baseUrl = "https://pokeapi.co/api/v2/pokemon";

        public PokemonService(IRestService restService)
		{
            this.restService = restService;
		}

        public Task<PokemonDetail> GetPokemonByName(string name)
        {
            return this.restService.GetAsync<PokemonDetail>($"{baseUrl}/{name})");
        }

        public Task<List<Pokemon>> GetPokemons(int limit, int offset)
        {
            return this.restService.GetAsync<List<Pokemon>>($"{baseUrl}?limit={limit}&offset={offset})");
        }
    }
}

