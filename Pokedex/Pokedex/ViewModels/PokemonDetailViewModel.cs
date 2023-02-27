using System;
using System.Windows.Input;

using Pokedex.Models;
using Pokedex.Services.Interfaces;
using Pokedex.ViewModels.Base;
using Xamarin.Forms;

namespace Pokedex.ViewModels
{
    public class PokemonDetailViewModel : BaseViewModel
    {

        private PokemonDetail detail;
        private readonly IPokemonService pokemonService;

        public int Id { get; set; }
        public PokemonDetail Detail
        {
            get
            {
                return detail;
            }
            set
            {
                detail = value;
                RaisePropertyChanged(() => Detail);
            }
        }

        public ICommand GetDetail { get; }

        public PokemonDetailViewModel(IPokemonService pokemonService)
        {
            this.pokemonService = pokemonService;

            GetDetail = new Command(async () =>
            {
                Detail = await this.pokemonService.GetPokemonDetailByNameOrId(Convert.ToString(Id));
            });
        }
    }
}