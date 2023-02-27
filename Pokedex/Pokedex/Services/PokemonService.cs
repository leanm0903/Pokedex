using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Pokedex.Commons.RestService;
using Pokedex.Models;
using Pokedex.Models.Response;
using Pokedex.Services.Interfaces;

namespace Pokedex.Services
{
	public class PokemonService : IPokemonService
	{
        private int offset => 20;
        private readonly IRestService restService;
        private const string baseUrl = "https://pokeapi.co/api/v2/pokemon";

        public PokemonService(IRestService restService)
		{
            this.restService = restService;
		}

        public Task<PokemonDetail> GetPokemonDetailByNameOrId(string name)
        {
            return this.restService.GetAsync<PokemonDetail>($"{baseUrl}/{name}");
        }

        public async Task<List<Pokemon>> GetPokemons(int limit, int offset)
        {
	        var response = await this.restService.GetAsync<GetPokemonsResponse>($"{baseUrl}?limit={limit}&offset={offset})");

            var pokemonDetailTask = new List<Task<PokemonDetail>>();

            response.Results.ForEach(pokemon =>
            {
                pokemonDetailTask.Add(this.GetPokemonDetailByNameOrId(pokemon.Name));                
            });

            var pokemonDetails = await Task.WhenAll(pokemonDetailTask);

            response.Results.ForEach(pokemon =>
            {
                pokemon.Detail = pokemonDetails.Where(p => p.Name == pokemon.Name).FirstOrDefault();
            });

	        return response.Results;
        }

        public Task<List<PokemonDetail>> GetPokemons(int offset = 20)
        {
            throw new NotImplementedException();
        }
    }
}

