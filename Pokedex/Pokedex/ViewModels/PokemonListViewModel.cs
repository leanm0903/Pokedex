using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Pokedex.Models;
using Pokedex.Services.Interfaces;
using Pokedex.ViewModels.Base;
using Xamarin.Forms;

namespace Pokedex.ViewModels
{
    public class PokemonListViewModel : BaseViewModel
    {
	    
	    private ObservableCollection<Pokemon> pokemons;
	    private int lastPage = 0;
	    private int nextPage = 2;

		private readonly IPokemonService pokemonService;
		
		public ObservableCollection<Pokemon> Pokemons
		{
			get
			{
				return pokemons;
			}
			set
			{
				pokemons = value;
				RaisePropertyChanged(() => Pokemons);
			}
		}

		public int NextPage
		{
			get
			{
				return nextPage;
			}
			set
			{
				nextPage = value;
				RaisePropertyChanged(() => NextPage);
			}
		}
		public int LastPage
		{
			get
			{
				return lastPage;
			}
			set
			{
				lastPage = value;
				RaisePropertyChanged(() => LastPage);
			}
		}
		
		public int ActualPage
		{
			get
			{
				return PageNumber;
			}
			set
			{
				PageNumber = value;
				RaisePropertyChanged(() => ActualPage);
			}
		}

		
		public ICommand SetPokemons { get; }
		public ICommand NextPageCommand { get; }
		public ICommand LastPageCommand { get; }

		public PokemonListViewModel(IPokemonService pokemonService)
		{
			this.pokemonService = pokemonService;
			this.ActualPage = 1;
			this.SetPokemons = new Command(async () =>
			{
				this.Pokemons =
					new ObservableCollection<Pokemon>(await this.pokemonService.GetPokemons(this.Limit, this.OffSet));
			});

			this.NextPageCommand = new Command(async() =>
			{
				this.ActualPage++;
				this.NextPage++;
				this.LastPage++;
				this.OffSet = this.Limit + this.OffSet;
				this.Pokemons =
					new ObservableCollection<Pokemon>(await this.pokemonService.GetPokemons(this.Limit, this.OffSet));
			});
			
			this.LastPageCommand = new Command(async() =>
			{
				this.ActualPage--;
				this.NextPage--;
				this.LastPage--;
				this.OffSet = this.OffSet - this.Limit;
				this.Pokemons =
					new ObservableCollection<Pokemon>(await this.pokemonService.GetPokemons(this.Limit, this.OffSet));
			});
		}

		public override async Task InitializeAsync(object navigationData)
		{
			this.Pokemons = new ObservableCollection<Pokemon>
				(await this.pokemonService.GetPokemons(this.Limit, this.OffSet));
		}
	}
}

