using System.Collections.Generic;
using System.Threading.Tasks;

using Pokedex.Models;
using Pokedex.Services.Interfaces;
using Pokedex.ViewModels.Base;

namespace Pokedex.ViewModels
{
    public class PokemonListViewModel : BaseViewModel
	{
		protected List<Pokemon> Pokemons { get; set; }

		private readonly IPokemonService pokemonService;

		public PokemonListViewModel(IPokemonService pokemonService)
		{
			this.pokemonService = pokemonService;
		}

		public async Task<List<Pokemon>> GetPokemons()
		{
			this.Pokemons = new List<Pokemon>();

			this.Pokemons = await pokemonService.GetPokemons(this.Limit, this.OffSet);

			return this.Pokemons;
		}
	}
}

